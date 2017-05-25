--MfgManJOPlanRpt_マニュアル作業計画表SQL
DECLARE @DATE_TYPE INT = 1    --発行日付単位分類: 0.週単位 1.月単位
DECLARE @CALENDAR_DATE INT = 20170501
DECLARE @TTL_WEEK INT = 227  --648
DECLARE @SCH_ID VARCHAR(10) = ''
DECLARE @WS_CD VARCHAR(10) = ''

--月（週）単位のカレンダ未加工のデータ（二の統合）
IF OBJECT_ID('tempdb..#TMP_CAL') IS NOT NULL DROP TABLE #TMP_CAL
SELECT * INTO #TMP_CAL FROM (
        SELECT (CASE @DATE_TYPE WHEN 0 THEN MAX(TTL_WEEK) ELSE MAX(CALENDAR_CYM) END) DATE_WEEK_CYM, --0.週単位 1.月単位
               min(CALENDAR_DATE) MIN_DATE,  
               max(CALENDAR_DATE) MAX_DATE,
               CAST(1 AS INT) DATE_ID
        FROM CALENDAR_MASTER
        WHERE CALENDAR_ID = '00'
        AND CALENDAR_CYM = (CASE @DATE_TYPE WHEN 0 THEN CALENDAR_CYM
                            ELSE YEAR(DATEADD(DAY,-1,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))*100
                                 + MONTH(DATEADD(DAY,-1,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))
                            END)
        AND TTL_WEEK = (CASE @DATE_TYPE WHEN 0 THEN (@TTL_WEEK - 1) ELSE TTL_WEEK END)
        UNION ALL
        SELECT DISTINCT (CASE @DATE_TYPE WHEN 0 THEN TTL_WEEK ELSE CALENDAR_CYM END) DATE_WEEK_CYM, --0.週単位 1.月単位
               min(CALENDAR_DATE) MIN_DATE,  
               max(CALENDAR_DATE) MAX_DATE,
               (ROW_NUMBER() OVER (order by (CASE @DATE_TYPE WHEN 0 THEN TTL_WEEK ELSE CALENDAR_CYM END))+1) DATE_ID
        FROM CALENDAR_MASTER
       WHERE CALENDAR_ID = '00'
       AND CALENDAR_DATE >= (CASE @DATE_TYPE WHEN 0 THEN CALENDAR_DATE ELSE @CALENDAR_DATE END)   
       AND CALENDAR_DATE <= (CASE @DATE_TYPE WHEN 0 THEN CALENDAR_DATE 
                             ELSE CONVERT(VARCHAR(8), DATEADD(DAY,-1,(DATEADD(MONTH,7,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))), 112)
                             END)
       AND TTL_WEEK >= (CASE @DATE_TYPE WHEN 0 THEN @TTL_WEEK  ELSE TTL_WEEK END)  
       AND TTL_WEEK <= (CASE @DATE_TYPE WHEN 0 THEN @TTL_WEEK + 6  ELSE TTL_WEEK END)  
        GROUP BY (CASE @DATE_TYPE WHEN 0 THEN TTL_WEEK ELSE CALENDAR_CYM END)
) A
CREATE INDEX TMP_CAL_IDX1 ON #TMP_CAL (DATE_WEEK_CYM)
CREATE INDEX TMP_CAL_IDX2 ON #TMP_CAL (DATE_ID)
--SELECT * FROM #TMP_CAL

--マニュアル作業計画表未加工のデータ
IF OBJECT_ID('tempdb..#TMP_JOB') IS NOT NULL DROP TABLE #TMP_JOB
SELECT * INTO #TMP_JOB FROM (
  SELECT
  PD.SCH_ID,
  S_SCH_NAME.DATA_CHAR SCH_NAME,
  PD.ITEM_NO,
  IM.ITEM_DESC,
  IW.WS_CD,
  IW.WS_DESC,
  ISNULL(RM.MFG_LT,0) MFG_LT,
  PD.DISB_WHS,
  WH.WHS_DESC,
  --ISNULL(ID.INV_BAL,0) INV_BAL,
  (SELECT ISNULL(SUM(ID.INV_BAL),0) INV_BAL FROM INVENTORY_DETAIL ID
    WHERE ID.INV_YM = 0
      AND ID.INV_TYPE = 0
      AND ID.INV_WIP_TYPE IN (0,1)
      AND ID.ITEM_NO = PD.ITEM_NO
      AND ID.WHS_CD = PD.DISB_WHS
      AND (ID.WS_CD = IW.WS_CD OR ID.WS_CD='') ) INV_BAL,--// 現在庫
  S_UMSR_NAME.DATA_CHAR UMSR_NAME,
  ISNULL(T.DATE_ID,0) DATE_ID,
  (CASE @DATE_TYPE WHEN 0 THEN CM.TTL_WEEK ELSE CM.CALENDAR_CYM END) DATE_WEEK_CYM,
  MIN(CM.CALENDAR_DATE) MIN_DATE,
  MAX(CM.CALENDAR_DATE) MAX_DATE,
  SUM(CASE WHEN PD.PLAN_QTY-PD.INPUT_QTY<0 THEN 0 ELSE PD.PLAN_QTY-PD.INPUT_QTY END) PLAN_QTY,
  SUM(PD.ORDER_QTY) ORDER_QTY,
  SUM(PD.JOB_ORDER_QTY) JOB_ORDER_QTY
  FROM ( --//所要データ
      SELECT PD.SCH_ID, PD.ITEM_UMSR, PD.ITEM_NO, PD.WS_CD, PD.DISB_WHS, PD.SCH_DISB_DATE, PD.PLAN_QTY, 0 INPUT_QTY 
            ,0 ORDER_QTY, 0 JOB_ORDER_QTY
          FROM PLANNED_DEMAND PD
          INNER JOIN PLANNED_ORDER PO ON PD.ORDER_NO = PO.ORDER_NO
          WHERE (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
            AND PO.SC_FLAG = 0
            AND PD.PO_TYPE = 3
            AND PD.ITEM_TYPE <> '99'
      UNION ALL
      SELECT D.SCH_ID, D.ITEM_UMSR, D.ITEM_NO, D.WS_CD, D.DISB_WHS, D.SCH_DISB_DATE, D.PLAN_QTY, D.INPUT_QTY
            ,0 ORDER_QTY, 0 JOB_ORDER_QTY
          FROM DEMAND D
          INNER JOIN JOB_ORDER JO ON D.ORDER_NO = JO.ORDER_NO
          WHERE (D.SUB_GRP_CD = '' OR (D.SUB_GRP_CD <> '' AND D.SUB_ACTION_FLAG = 1))
            AND D.PO_TYPE = 3
            AND D.ITEM_TYPE <> '99'
            AND D.DEMAND_STATUS < 85
      UNION ALL
      SELECT POD.SCH_ID, POD.ITEM_UMSR, POD.ITEM_NO, POD.WS_CD, POD.DISB_WHS, PO.SCH_COMPL_DATE SCH_DISB_DATE, 0 PLAN_QTY, 0 INPUT_QTY
            ,PO.ORDER_QTY, 0 JOB_ORDER_QTY
          FROM PLANNED_ORDER PO
          INNER JOIN (
                  SELECT PD.SCH_ID, PD.ITEM_UMSR, PD.ITEM_NO, PD.WS_CD, PD.DISB_WHS
                  FROM PLANNED_DEMAND PD
                  INNER JOIN PLANNED_ORDER PO ON PD.ORDER_NO = PO.ORDER_NO
                  WHERE (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
                    AND PO.SC_FLAG = 0
                    AND PD.PO_TYPE = 3
                    AND PD.ITEM_TYPE <> '99'
                  UNION ALL
                  SELECT D.SCH_ID, D.ITEM_UMSR, D.ITEM_NO, D.WS_CD, D.DISB_WHS
                  FROM DEMAND D
                  INNER JOIN JOB_ORDER JO ON D.ORDER_NO = JO.ORDER_NO
                  WHERE (D.SUB_GRP_CD = '' OR (D.SUB_GRP_CD <> '' AND D.SUB_ACTION_FLAG = 1))
                    AND D.PO_TYPE = 3
                    AND D.ITEM_TYPE <> '99'
                    AND D.DEMAND_STATUS < 85
                  ) POD ON POD.ITEM_NO = PO.ITEM_NO AND POD.DISB_WHS = PO.WHS_CD
          WHERE PO.SC_FLAG = 0
            AND PO.PO_TYPE = 3
            AND PO.ITEM_TYPE <> '99'
      UNION ALL
      SELECT JOD.SCH_ID, JOD.ITEM_UMSR, JOD.ITEM_NO, JOD.WS_CD, JOD.DISB_WHS, JO.SCH_COMPL_DATE SCH_DISB_DATE, 0 PLAN_QTY, 0 INPUT_QTY
            ,0 ORDER_QTY, CASE WHEN (JO.ORDER_QTY - JO.JOB_ORDER_COMPL_QTY) < 0 THEN 0 ELSE (JO.ORDER_QTY - JO.JOB_ORDER_COMPL_QTY) END JOB_ORDER_QTY
          FROM JOB_ORDER JO
          INNER JOIN (
                  SELECT PD.SCH_ID, PD.ITEM_UMSR, PD.ITEM_NO, PD.WS_CD, PD.DISB_WHS
                  FROM PLANNED_DEMAND PD
                  INNER JOIN PLANNED_ORDER PO ON PD.ORDER_NO = PO.ORDER_NO
                  WHERE (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
                    AND PO.SC_FLAG = 0
                    AND PD.PO_TYPE = 3
                    AND PD.ITEM_TYPE <> '99'
                  UNION ALL
                  SELECT D.SCH_ID, D.ITEM_UMSR, D.ITEM_NO, D.WS_CD, D.DISB_WHS
                  FROM DEMAND D
                  INNER JOIN JOB_ORDER JO ON D.ORDER_NO = JO.ORDER_NO
                  WHERE (D.SUB_GRP_CD = '' OR (D.SUB_GRP_CD <> '' AND D.SUB_ACTION_FLAG = 1))
                    AND D.PO_TYPE = 3
                    AND D.ITEM_TYPE <> '99'
                    AND D.DEMAND_STATUS < 85
                  ) JOD ON JOD.ITEM_NO = JO.ITEM_NO AND JOD.DISB_WHS = JO.WHS_CD
          WHERE    JO.PO_TYPE = 3
            AND JO.ITEM_TYPE <> '99'
            AND JO.ORDER_STATUS < 85
      ) PD                
  INNER JOIN 
      ( SELECT * FROM CALENDAR_MASTER            
        WHERE CALENDAR_ID = '00'
          AND CALENDAR_DATE  >= ( CASE @DATE_TYPE  --0.週単位 1.月単位
                                  WHEN 0 THEN (SELECT MIN(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK)
                                  WHEN 1 THEN (SELECT MIN(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE CALENDAR_DATE >= @CALENDAR_DATE)
                                  END 
                                )
          AND CALENDAR_DATE  <= ( CASE @DATE_TYPE 
                                  WHEN 0 THEN (SELECT MAX(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK + 6)
                                  WHEN 1 THEN (SELECT MAX(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE CALENDAR_DATE <=
                                               CONVERT(VARCHAR(8), DATEADD(DAY,-1,(DATEADD(MONTH,7,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))), 112)) 
                                  END
                                )
      ) CM ON PD.SCH_DISB_DATE = CM.CALENDAR_DATE
  INNER JOIN ITEM_MASTER IM ON PD.ITEM_NO = IM.ITEM_NO
  LEFT JOIN WORKSHOP_MASTER WS ON PD.WS_CD = WS.WS_CD
  LEFT JOIN ( SELECT IW.ITEM_NO, IW.WS_CD, IW.BEG_EFF_DATE, IW.END_EFF_DATE, MIW.PTY_NO, WM.SC_FLAG, WM.WS_DESC
              FROM ITEM_WS_MASTER IW
              INNER JOIN ( SELECT ITEM_NO, MIN(PTY_NO) PTY_NO FROM ITEM_WS_MASTER GROUP BY ITEM_NO ) MIW
                 ON IW.ITEM_NO = MIW.ITEM_NO AND IW.PTY_NO = MIW.PTY_NO
              INNER JOIN WORKSHOP_MASTER WM ON IW.WS_CD = WM.WS_CD
            ) IW ON PD.ITEM_NO = IW.ITEM_NO
                AND PD.SCH_DISB_DATE >= IW.BEG_EFF_DATE
                AND PD.SCH_DISB_DATE <= IW.END_EFF_DATE
  LEFT JOIN ( SELECT ITEM_NO, WS_CD, SUM(MFG_LT) MFG_LT
              FROM  ROUTINE_MASTER
              WHERE BEG_EFF_DATE <= CONVERT(varchar(100), GETDATE(), 112)
              AND END_EFF_DATE >= CONVERT(varchar(100), GETDATE(), 112)
              GROUP BY ITEM_NO, WS_CD
            ) RM ON PD.ITEM_NO = RM.ITEM_NO AND IW.WS_CD = RM.WS_CD
  LEFT JOIN WAREHOUSE_MASTER WH ON PD.DISB_WHS = WH.WHS_CD
  --LEFT JOIN ( --// 現在庫
  --            SELECT ID.ITEM_NO, ID.WHS_CD, ID.WS_CD, SUM(ID.INV_BAL) INV_BAL
  --            FROM INVENTORY_DETAIL ID
  --            WHERE ID.INV_YM = 0
  --            AND ID.INV_TYPE = 0
  --            AND ID.INV_WIP_TYPE IN (0,1)
  --            GROUP BY ID.ITEM_NO, ID.WHS_CD, ID.WS_CD
  --          ) ID ON PD.ITEM_NO = ID.ITEM_NO
  --          AND PD.DISB_WHS = ( CASE WHEN ID.WHS_CD = '' THEN PD.DISB_WHS ELSE ID.WHS_CD END )
  --          AND PD.WS_CD = ( CASE WHEN ID.WS_CD = '' THEN PD.WS_CD ELSE ID.WS_CD END )           
  LEFT JOIN ( SELECT * FROM SYSTEM_PARAMETER WHERE KEY01 = 'SCH_ID' ) S_SCH_NAME ON PD.SCH_ID = S_SCH_NAME.KEY02
  LEFT JOIN ( SELECT * FROM SYSTEM_PARAMETER WHERE KEY01 = 'ITEM_UMSR' ) S_UMSR_NAME ON PD.ITEM_UMSR = S_UMSR_NAME.KEY02
  LEFT JOIN #TMP_CAL T ON T.DATE_WEEK_CYM=(CASE @DATE_TYPE WHEN 0 THEN CM.TTL_WEEK ELSE CM.CALENDAR_CYM END)
  WHERE 1=1
  AND ISNULL(IW.SC_FLAG,1) = 0
  AND (PD.SCH_ID = @SCH_ID or @SCH_ID = '')
  AND (IW.WS_CD = @WS_CD or @WS_CD = '')
  GROUP BY
       PD.SCH_ID,
       S_SCH_NAME.DATA_CHAR,
       PD.ITEM_NO,
       IM.ITEM_DESC,
       IW.WS_CD,
       IW.WS_DESC,
       RM.MFG_LT,
       T.DATE_ID,
       (CASE @DATE_TYPE WHEN 0 THEN CM.TTL_WEEK ELSE CM.CALENDAR_CYM END),  --0.週単位 1.月単位
       PD.DISB_WHS,
       WH.WHS_DESC,
       --ID.INV_BAL,
       S_UMSR_NAME.DATA_CHAR 
  --//開始週(月)以前のデータ抽出
  UNION ALL
  SELECT
  PD.SCH_ID,
  S_SCH_NAME.DATA_CHAR SCH_NAME,
  PD.ITEM_NO,
  IM.ITEM_DESC,
  IW.WS_CD,
  IW.WS_DESC,
  ISNULL(RM.MFG_LT,0) MFG_LT,
  PD.DISB_WHS,
  WH.WHS_DESC,
  --ISNULL(ID.INV_BAL,0) INV_BAL,
  (SELECT ISNULL(SUM(ID.INV_BAL),0) INV_BAL FROM INVENTORY_DETAIL ID
    WHERE ID.INV_YM = 0
      AND ID.INV_TYPE = 0
      AND ID.INV_WIP_TYPE IN (0,1)
      AND ID.ITEM_NO = PD.ITEM_NO
      AND ID.WHS_CD = PD.DISB_WHS
      AND (ID.WS_CD = IW.WS_CD OR ID.WS_CD='')) INV_BAL,--// 現在庫
  S_UMSR_NAME.DATA_CHAR UMSR_NAME,
  MAX(ISNULL(T.DATE_ID,0)) DATE_ID,
  (CASE @DATE_TYPE WHEN 0 THEN (@TTL_WEEK - 1) ELSE
        YEAR(DATEADD(DAY,-1,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))*100
        + MONTH(DATEADD(DAY,-1,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))
  END) DATE_WEEK_CYM,
  0 MIN_DATE,
  MAX(CM.CALENDAR_DATE) MAX_DATE,
  SUM(CASE WHEN PD.PLAN_QTY-PD.INPUT_QTY<0 THEN 0 ELSE PD.PLAN_QTY-PD.INPUT_QTY END) PLAN_QTY,
  SUM(PD.ORDER_QTY) ORDER_QTY,
  SUM(PD.JOB_ORDER_QTY) JOB_ORDER_QTY
  FROM ( --//所要データ
      SELECT PD.SCH_ID, PD.ITEM_UMSR, PD.ITEM_NO, PD.WS_CD, PD.DISB_WHS, PD.SCH_DISB_DATE, PD.PLAN_QTY, 0 INPUT_QTY 
            ,0 ORDER_QTY, 0 JOB_ORDER_QTY
          FROM PLANNED_DEMAND PD    
          INNER JOIN PLANNED_ORDER PO ON PD.ORDER_NO = PO.ORDER_NO
          WHERE (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
            AND PO.SC_FLAG = 0
            AND PD.PO_TYPE = 3
            AND PD.ITEM_TYPE <> '99'
      UNION ALL                
      SELECT D.SCH_ID, D.ITEM_UMSR, D.ITEM_NO, D.WS_CD, D.DISB_WHS, D.SCH_DISB_DATE, D.PLAN_QTY, D.INPUT_QTY
            ,0 ORDER_QTY, 0 JOB_ORDER_QTY 
          FROM DEMAND D
          INNER JOIN JOB_ORDER JO ON D.ORDER_NO = JO.ORDER_NO
          WHERE (D.SUB_GRP_CD = '' OR (D.SUB_GRP_CD <> '' AND D.SUB_ACTION_FLAG = 1))
           AND D.PO_TYPE = 3
           AND D.ITEM_TYPE <> '99'
           AND D.DEMAND_STATUS < 85
      UNION ALL 
      SELECT POD.SCH_ID, POD.ITEM_UMSR, POD.ITEM_NO, POD.WS_CD, POD.DISB_WHS, PO.SCH_COMPL_DATE SCH_DISB_DATE, 0 PLAN_QTY, 0 INPUT_QTY
           , PO.ORDER_QTY, 0 JOB_ORDER_QTY
          FROM  PLANNED_ORDER PO 
          INNER JOIN ( SELECT PD.SCH_ID, PD.ITEM_UMSR, PD.ITEM_NO, PD.WS_CD, PD.DISB_WHS
                       FROM PLANNED_DEMAND PD
                       INNER JOIN PLANNED_ORDER PO ON PD.ORDER_NO = PO.ORDER_NO
                       WHERE (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
                         AND PO.SC_FLAG = 0
                         AND PD.PO_TYPE = 3
                         AND PD.ITEM_TYPE <> '99'
                       UNION ALL
                       SELECT D.SCH_ID, D.ITEM_UMSR, D.ITEM_NO, D.WS_CD, D.DISB_WHS
                       FROM DEMAND D
                       INNER JOIN JOB_ORDER JO ON D.ORDER_NO = JO.ORDER_NO
                       WHERE (D.SUB_GRP_CD = '' OR (D.SUB_GRP_CD <> '' AND D.SUB_ACTION_FLAG = 1))
                         AND D.PO_TYPE = 3 
                         AND D.ITEM_TYPE <> '99' 
                         AND D.DEMAND_STATUS < 85 
                      ) POD ON POD.ITEM_NO = PO.ITEM_NO AND POD.DISB_WHS = PO.WHS_CD
          WHERE PO.SC_FLAG = 0                        
            AND PO.PO_TYPE = 3                        
            AND PO.ITEM_TYPE <> '99'                
      UNION ALL
      SELECT JOD.SCH_ID, JOD.ITEM_UMSR, JOD.ITEM_NO, JOD.WS_CD, JOD.DISB_WHS, JO.SCH_COMPL_DATE SCH_DISB_DATE, 0 PLAN_QTY, 0 INPUT_QTY
           , 0 ORDER_QTY, CASE WHEN (JO.ORDER_QTY - JO.JOB_ORDER_COMPL_QTY) < 0 THEN 0 ELSE (JO.ORDER_QTY - JO.JOB_ORDER_COMPL_QTY) END JOB_ORDER_QTY         
          FROM JOB_ORDER JO 
          INNER JOIN ( SELECT PD.SCH_ID, PD.ITEM_UMSR, PD.ITEM_NO, PD.WS_CD, PD.DISB_WHS
                       FROM PLANNED_DEMAND PD                            
                       INNER JOIN PLANNED_ORDER PO ON PD.ORDER_NO = PO.ORDER_NO    
                       WHERE (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
                         AND PO.SC_FLAG = 0                                
                         AND PD.PO_TYPE = 3                                
                         AND PD.ITEM_TYPE <> '99'                        
                       UNION ALL
                       SELECT D.SCH_ID, D.ITEM_UMSR, D.ITEM_NO, D.WS_CD, D.DISB_WHS
                       FROM DEMAND D                                    
                       INNER JOIN JOB_ORDER JO ON D.ORDER_NO = JO.ORDER_NO            
                       WHERE (D.SUB_GRP_CD = '' OR (D.SUB_GRP_CD <> '' AND D.SUB_ACTION_FLAG = 1))    
                         AND D.PO_TYPE = 3                
                         AND D.ITEM_TYPE <> '99'            
                         AND D.DEMAND_STATUS < 85        
                      ) JOD ON JOD.ITEM_NO = JO.ITEM_NO AND JOD.DISB_WHS = JO.WHS_CD
          WHERE JO.PO_TYPE = 3                        
            AND JO.ITEM_TYPE <> '99'                    
            AND JO.ORDER_STATUS < 85                    
      ) PD                
  INNER JOIN ( SELECT * FROM CALENDAR_MASTER 
             WHERE CALENDAR_ID = '00'
               AND CALENDAR_DATE  <= ( CASE @DATE_TYPE  --0.週単位 1.月単位
                                       WHEN 0 THEN (SELECT MAX(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK-1) 
                                       WHEN 1 THEN (SELECT MAX(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE CALENDAR_DATE < @CALENDAR_DATE)
                                       END 
                                     )
             ) CM ON PD.SCH_DISB_DATE = CM.CALENDAR_DATE
  INNER JOIN ITEM_MASTER IM ON PD.ITEM_NO = IM.ITEM_NO
  LEFT JOIN WORKSHOP_MASTER WS ON PD.WS_CD = WS.WS_CD    
  LEFT JOIN ( SELECT IW.ITEM_NO, IW.WS_CD, IW.BEG_EFF_DATE, IW.END_EFF_DATE, MIW.PTY_NO, WM.SC_FLAG, WM.WS_DESC 
              FROM ITEM_WS_MASTER IW                                                                
              INNER JOIN ( SELECT ITEM_NO, MIN(PTY_NO) PTY_NO FROM ITEM_WS_MASTER GROUP BY ITEM_NO ) MIW 
                    ON IW.ITEM_NO = MIW.ITEM_NO AND IW.PTY_NO = MIW.PTY_NO
              INNER JOIN WORKSHOP_MASTER WM ON IW.WS_CD = WM.WS_CD
            ) IW
          ON  PD.ITEM_NO = IW.ITEM_NO
          AND PD.SCH_DISB_DATE >= IW.BEG_EFF_DATE
          AND PD.SCH_DISB_DATE <= IW.END_EFF_DATE
  LEFT JOIN ( --// 製造L/T 
              SELECT ITEM_NO, WS_CD, SUM(MFG_LT) MFG_LT
              FROM  ROUTINE_MASTER
              WHERE BEG_EFF_DATE <= CONVERT(varchar(100), GETDATE(), 112)
              AND END_EFF_DATE   >= CONVERT(varchar(100), GETDATE(), 112)
              GROUP BY ITEM_NO, WS_CD
             ) RM ON PD.ITEM_NO = RM.ITEM_NO AND IW.WS_CD = RM.WS_CD
  LEFT JOIN WAREHOUSE_MASTER WH ON PD.DISB_WHS = WH.WHS_CD
  --LEFT JOIN (  --// 現在庫
  --            SELECT ID.ITEM_NO, ID.WHS_CD, ID.WS_CD, SUM(ID.INV_BAL) INV_BAL
  --            FROM INVENTORY_DETAIL ID
  --            WHERE ID.INV_YM = 0
  --            AND ID.INV_TYPE = 0
  --            AND ID.INV_WIP_TYPE IN (0,1)
  --            GROUP BY ID.ITEM_NO, ID.WHS_CD, ID.WS_CD
  --          ) ID ON PD.ITEM_NO = ID.ITEM_NO
  --          AND PD.DISB_WHS = ( CASE WHEN ID.WHS_CD = '' THEN PD.DISB_WHS ELSE ID.WHS_CD END )
  --          AND PD.WS_CD = ( CASE WHEN ID.WS_CD = '' THEN PD.WS_CD ELSE ID.WS_CD END )
  LEFT JOIN (SELECT * FROM SYSTEM_PARAMETER WHERE KEY01 = 'SCH_ID' ) S_SCH_NAME ON PD.SCH_ID = S_SCH_NAME.KEY02 
  LEFT JOIN (SELECT * FROM SYSTEM_PARAMETER WHERE KEY01 = 'ITEM_UMSR' ) S_UMSR_NAME ON PD.ITEM_UMSR = S_UMSR_NAME.KEY02 
  LEFT JOIN #TMP_CAL T ON T.DATE_WEEK_CYM=(CASE @DATE_TYPE WHEN 0 THEN CM.TTL_WEEK ELSE CM.CALENDAR_CYM END)
  WHERE    1=1
  AND ISNULL(IW.SC_FLAG,1) = 0
  AND (PD.SCH_ID = @SCH_ID or @SCH_ID = '')
  AND (IW.WS_CD = @WS_CD or @WS_CD = '')
  GROUP BY
      PD.SCH_ID,
      S_SCH_NAME.DATA_CHAR,
      PD.ITEM_NO,
      IM.ITEM_DESC,
      IW.WS_CD,
      IW.WS_DESC,
      RM.MFG_LT, 
      --開始週(月)以前のデータ、日付単位分類使用しません
      --(CASE @DATE_TYPE WHEN 0 THEN CM.TTL_WEEK ELSE CM.CALENDAR_CYM END),  --0.週単位 1.月単位
      PD.DISB_WHS,                    
      WH.WHS_DESC,                    
      --ID.INV_BAL,                        
      S_UMSR_NAME.DATA_CHAR            
  --ORDER BY PD.SCH_ID,PD.ITEM_NO,IW.WS_CD,PD.DISB_WHS 
) B
ORDER BY SCH_ID,ITEM_NO,WS_CD,DISB_WHS,DATE_WEEK_CYM 
CREATE INDEX TMP_JOB_IDX1 ON #TMP_JOB (SCH_ID)
CREATE INDEX TMP_JOB_IDX2 ON #TMP_JOB (ITEM_NO)
CREATE INDEX TMP_JOB_IDX3 ON #TMP_JOB (DISB_WHS)
CREATE INDEX TMP_JOB_IDX4 ON #TMP_JOB (WS_CD)
CREATE INDEX TMP_JOB_IDX5 ON #TMP_JOB (DATE_ID)
--SELECT * FROM #TMP_JOB

DECLARE @dat_num_col NVARCHAR(MAX)
DECLARE @dat_min_col NVARCHAR(MAX)
DECLARE @dat_max_col NVARCHAR(MAX)
DECLARE @pln_qty_col NVARCHAR(MAX)
DECLARE @ord_qty_col NVARCHAR(MAX)
DECLARE @job_qty_col NVARCHAR(MAX)
DECLARE @pln_qty_val NVARCHAR(MAX)
DECLARE @ord_qty_val NVARCHAR(MAX)
DECLARE @job_qty_val NVARCHAR(MAX)
DECLARE @sql_str NVARCHAR(MAX)

--月（週）単位のカレンダの列名（二の統合）
SELECT @dat_num_col = ISNULL(@dat_num_col + ',', '') + QUOTENAME('DAT_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@dat_min_col = ISNULL(@dat_min_col + ',', '') + QUOTENAME('MIN_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@dat_max_col = ISNULL(@dat_max_col + ',', '') + QUOTENAME('MAX_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@pln_qty_col = ISNULL(@pln_qty_col + ',', '') + QUOTENAME('PLN_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@ord_qty_col = ISNULL(@ord_qty_col + ',', '') + QUOTENAME('ORD_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@job_qty_col = ISNULL(@job_qty_col + ',', '') + QUOTENAME('JOB_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@pln_qty_val = ISNULL(@pln_qty_val + ',', '') + 'ISNULL(' + QUOTENAME('PLN_'+CAST(DATE_ID AS VARCHAR(8))) + ',0) AS ' + QUOTENAME('PLN_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@ord_qty_val = ISNULL(@ord_qty_val + ',', '') + 'ISNULL(' + QUOTENAME('ORD_'+CAST(DATE_ID AS VARCHAR(8))) + ',0) AS ' + QUOTENAME('ORD_'+CAST(DATE_ID AS VARCHAR(8)))
      ,@job_qty_val = ISNULL(@job_qty_val + ',', '') + 'ISNULL(' + QUOTENAME('JOB_'+CAST(DATE_ID AS VARCHAR(8))) + ',0) AS ' + QUOTENAME('JOB_'+CAST(DATE_ID AS VARCHAR(8)))
FROM #TMP_CAL

--PRINT (@dat_num_col)
--PRINT (@dat_min_col)
--PRINT (@dat_max_col)
--PRINT (@pln_qty_col)
--PRINT (@ord_qty_col)
--PRINT (@job_qty_col)
--PRINT (@pln_qty_val)
--PRINT (@ord_qty_val)
--PRINT (@job_qty_val)

--SQLの合成,ライン変換列の処理[PIVOT]
SET @sql_str = '
    SELECT  PVT.SCH_ID, PVT.SCH_NAME, PVT.ITEM_NO,  PVT.ITEM_DESC, PVT.WS_CD, PVT.WS_DESC,
            PVT.MFG_LT, PVT.DISB_WHS, PVT.WHS_DESC, PVT.INV_BAL,   PVT.UMSR_NAME, ' + '
            ' + @pln_qty_val + ', ' + '
            ' + @ord_qty_val + ', ' + '
            ' + @job_qty_val + ', ' + '
            ' + @dat_num_col + ', ' + '
            ' + @dat_min_col + ', ' + '
            ' + @dat_max_col + '
    FROM (         --PLAN_QTY 所要数量
        SELECT ''PLN_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, 
               SCH_ID, SCH_NAME, ITEM_NO, ITEM_DESC, WS_CD, WS_DESC, 
               MFG_LT, DISB_WHS, WHS_DESC, INV_BAL, UMSR_NAME, PLAN_QTY FROM #TMP_JOB
        ) PLN
        PIVOT
        ( SUM(PLAN_QTY) 
          FOR DATE_ID_COL IN (' + @pln_qty_col +')
    ) AS PVT
    CROSS APPLY (  --ORDER_QTY 計画数量
        SELECT * 
        FROM ( 
              SELECT ''ORD_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, 
                     SCH_ID, SCH_NAME, ITEM_NO, ITEM_DESC, WS_CD, WS_DESC, 
                     MFG_LT, DISB_WHS, WHS_DESC, INV_BAL, UMSR_NAME, ORDER_QTY FROM #TMP_JOB
             ) ORD
             PIVOT
             ( SUM(ORDER_QTY) 
               FOR DATE_ID_COL IN (' + @ord_qty_col +')
              ) AS ORD_PVT
        WHERE PVT.SCH_ID=ORD_PVT.SCH_ID 
        AND   PVT.ITEM_NO=ORD_PVT.ITEM_NO
        AND   PVT.DISB_WHS=ORD_PVT.DISB_WHS
        AND   PVT.WS_CD=ORD_PVT.WS_CD
    ) T1
    CROSS APPLY (  --JOB_ORDER_QTY 指示残数量
        SELECT * 
        FROM (
              SELECT ''JOB_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, 
                     SCH_ID, SCH_NAME, ITEM_NO, ITEM_DESC, WS_CD, WS_DESC, 
                     MFG_LT, DISB_WHS, WHS_DESC, INV_BAL, UMSR_NAME, JOB_ORDER_QTY FROM #TMP_JOB
             ) JOB
             PIVOT
             ( SUM(JOB_ORDER_QTY) 
               FOR DATE_ID_COL IN (' + @job_qty_col +')
              ) AS JOB_PVT
        WHERE PVT.SCH_ID=JOB_PVT.SCH_ID 
        AND   PVT.ITEM_NO=JOB_PVT.ITEM_NO
        AND   PVT.DISB_WHS=JOB_PVT.DISB_WHS
        AND   PVT.WS_CD=JOB_PVT.WS_CD
    ) T2
    CROSS APPLY (  --DATE_WEEK_CYM
        SELECT * 
        FROM ( 
              SELECT ''DAT_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, 
                     DATE_WEEK_CYM FROM #TMP_CAL
             ) DAT
             PIVOT
             ( MIN(DATE_WEEK_CYM) 
               FOR DATE_ID_COL IN (' + @dat_num_col +')
              ) AS DAT_PVT
    ) T3
    CROSS APPLY (  --MIN_DATE
        SELECT * 
        FROM ( 
              SELECT ''MIN_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, 
                     MIN_DATE FROM #TMP_CAL
             ) DAT
             PIVOT
             ( MIN(MIN_DATE) 
               FOR DATE_ID_COL IN (' + @dat_min_col +')
              ) AS DAT_PVT
    ) T4
    CROSS APPLY (  --MAX_DATE
        SELECT * 
        FROM ( 
              SELECT ''MAX_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, 
                     MAX_DATE FROM #TMP_CAL
             ) DAT
             PIVOT
             ( MAX(MAX_DATE) 
               FOR DATE_ID_COL IN (' + @dat_max_col +')
              ) AS DAT_PVT
    ) T5
    ORDER BY PVT.ITEM_NO'

--PRINT (@sql_str)
EXEC (@sql_str)
