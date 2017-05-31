--PurManPOPlanRpt_マニュアル発注計画表SQL
DECLARE @DATE_TYPE INT = 1               --発行日付単位分類: 0.週単位 1.月単位
DECLARE @CALENDAR_DATE INT = 20170501    --開始週
DECLARE @TTL_WEEK INT = 648              --開始月
DECLARE @BUYER_CD VARCHAR(10) = ''
DECLARE @VENDOR_CD VARCHAR(10) = ''
DECLARE @SCH_ID VARCHAR(10) = ''
DECLARE @CATG_CD VARCHAR(10) = ''

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

--マニュアル発注計画表未加工のデータ
IF OBJECT_ID('tempdb..#TMP_PUR') IS NOT NULL DROP TABLE #TMP_PUR
SELECT * INTO #TMP_PUR FROM (
  SELECT
  (CASE @DATE_TYPE WHEN 0 THEN 'WEEK' ELSE 'MONTH' END) DATE_TYPE_TXT,
  PM.BUYER_CD,        S1.DATA_CHAR BUYER_NAME,
  PD.SCH_ID,          S2.DATA_CHAR SCH_NAME,
  PM.VENDOR_CD,       V.VENDOR_NAME,      PM.DELV_LT,
  PD.ITEM_NO,         I.ITEM_DESC,
  PD.DISB_WHS,        W.WHS_DESC,
  PP.TENTATIVE_PRC,   PP.TENTATIVE_CUR,   S5.DATA_CHAR TEN_CUR_NAME,
  PP.ACT_PRC,         PP.ACT_CUR,         S4.DATA_CHAR ACT_CUR_NAME,
  PP.COM_PRC_FLAG,
  S3.DATA_CHAR UMSR,
  INV.INV_BAL,
  S6.DATA_CHAR ITEM_UMSR,
  SUM(PD.PO_QTY) PO_QTY,  --//発注残
  SUM(CASE WHEN PD.PLAN_QTY-PD.INPUT_QTY<0 THEN 0 ELSE PD.PLAN_QTY-PD.INPUT_QTY END) PLAN_QTY,--//所要数量
  MIN(C.CALENDAR_DATE) MIN_DATE,MAX(C.CALENDAR_DATE) MAX_DATE,
  (CASE @DATE_TYPE WHEN 0 THEN C.TTL_WEEK ELSE C.CALENDAR_CYM END) DATE_WEEK_CYM,
  ISNULL(T.DATE_ID,0) DATE_ID
  FROM (   --//所要データ 
           SELECT P.DEMAND_NO, P.SCH_ID, P.ITEM_NO, P.DISB_WHS, P.PLAN_QTY, P.SCH_DISB_DATE,
                 P.SUB_GRP_CD, P.SUB_ACTION_FLAG, P.PO_TYPE,P.INPUT_QTY,
                 ISNULL(MIN(PTY_NO),0) PTY_NO
                ,P.PO_QTY
           FROM
            (  
               SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, PLAN_QTY, SCH_DISB_DATE,
                      SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE, 0 INPUT_QTY
                      ,0 PO_QTY
               FROM PLANNED_DEMAND
                  WHERE ITEM_TYPE <> '99'
               UNION ALL
               SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, PLAN_QTY, SCH_DISB_DATE,
                      SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE, INPUT_QTY
                      ,0 PO_QTY
               FROM DEMAND
               WHERE DEMAND_STATUS < 85
                  AND ITEM_TYPE <> '99'
               UNION ALL
               SELECT '' DEMAND_NO, POD.SCH_ID, POD.ITEM_NO, POD.DISB_WHS, 0 PLAN_QTY, PO_DUE_DATE SCH_DISB_DATE, 
                      POD.SUB_GRP_CD, POD.SUB_ACTION_FLAG, POD.PO_TYPE, 0 INPUT_QTY
                      ,CAST((CASE WHEN PO_QTY-STOCK_QTY < 0 THEN 0 ELSE PO_QTY-STOCK_QTY END)
                       * (CASE WHEN ISNULL(UMSR_CONV_RATIO,1) = 0 THEN 1 ELSE ISNULL(UMSR_CONV_RATIO,1) END) AS DECIMAL(11,2)) PO_QTY 
               FROM PUR_ORDER PO
               INNER JOIN (
                            SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE
                            FROM PLANNED_DEMAND
                               WHERE ITEM_TYPE <> '99'
                               AND PO_TYPE = 3
                               AND (SUB_GRP_CD = '' OR (SUB_GRP_CD <> '' AND SUB_ACTION_FLAG = 1))
                            UNION ALL
                            SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE
                            FROM DEMAND
                            WHERE DEMAND_STATUS < 85
                               AND ITEM_TYPE <> '99'
                               AND PO_TYPE = 3
                               AND (SUB_GRP_CD = '' OR (SUB_GRP_CD <> '' AND SUB_ACTION_FLAG = 1))
                          ) POD ON POD.ITEM_NO = PO.ITEM_NO AND POD.DISB_WHS = PO.WHS_CD
               WHERE ORDER_STATUS < 77
            ) P
           LEFT OUTER JOIN PURCHASE_MASTER M                                                                                 
                ON P.ITEM_NO = M.ITEM_NO                                                                                                
                AND P.SCH_DISB_DATE >= M.BEG_EFF_DATE                                                                             
                AND P.SCH_DISB_DATE <= M.END_EFF_DATE                                                                             
           GROUP BY P.DEMAND_NO, P.SCH_ID, P.ITEM_NO, P.DISB_WHS, P.PLAN_QTY, P.SCH_DISB_DATE,       
                    P.SUB_GRP_CD, P.SUB_ACTION_FLAG, P.PO_TYPE,P.INPUT_QTY                                   
                   ,P.PO_QTY                                                                                  
       ) PD
  LEFT OUTER JOIN WAREHOUSE_MASTER W ON W.WHS_CD  = PD.DISB_WHS
  INNER JOIN --//CALENDAR
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
      ) C ON C.CALENDAR_DATE  = PD.SCH_DISB_DATE
  LEFT OUTER JOIN ITEM_MASTER I ON I.ITEM_NO  = PD.ITEM_NO 
       AND (I.CATG_CD = @CATG_CD or @CATG_CD = '')
  LEFT OUTER JOIN PURCHASE_MASTER PM ON PM.ITEM_NO  = PD.ITEM_NO
       AND PM.PTY_NO  = PD.PTY_NO
       AND PM.BEG_EFF_DATE <= PD.SCH_DISB_DATE
       AND PM.END_EFF_DATE >= PD.SCH_DISB_DATE
       AND (PM.BUYER_CD = @BUYER_CD or @BUYER_CD = '')
       AND (PM.VENDOR_CD = @VENDOR_CD or @VENDOR_CD = '')
  LEFT OUTER JOIN --// 現在庫
       (SELECT ITEM_NO, WHS_CD, SUM(INV_BAL) INV_BAL
          FROM INVENTORY_DETAIL INV
         WHERE INV.INV_YM = 0
               AND INV.INV_WIP_TYPE IN (0,1)
               AND INV.INV_TYPE=0
         GROUP BY ITEM_NO, WHS_CD) INV
      ON INV.ITEM_NO = PD.ITEM_NO AND INV.WHS_CD = PD.DISB_WHS
  LEFT OUTER JOIN
       ( SELECT IW.ITEM_NO, IW.WS_CD, IW.BEG_EFF_DATE, IW.END_EFF_DATE, MIW.PTY_NO, WM.SC_FLAG 
         FROM ITEM_WS_MASTER IW
         INNER JOIN
           (
            SELECT ITEM_NO, MIN(PTY_NO) PTY_NO
                 FROM ITEM_WS_MASTER
             GROUP BY ITEM_NO
           ) MIW ON IW.ITEM_NO = MIW.ITEM_NO AND IW.PTY_NO = MIW.PTY_NO
         INNER JOIN WORKSHOP_MASTER WM ON IW.WS_CD = WM.WS_CD
        ) IW ON PD.ITEM_NO = IW.ITEM_NO
        AND PD.SCH_DISB_DATE >= IW.BEG_EFF_DATE
        AND PD.SCH_DISB_DATE <= IW.END_EFF_DATE
  LEFT OUTER JOIN PURCHASE_PRICE_MASTER PP ON PP.ITEM_NO = PM.ITEM_NO
       AND PP.WS_CD = ISNULL(IW.WS_CD,'*')
       AND PP.PROCESS_CD = '*'
       AND PP.VENDOR_CD = PM.VENDOR_CD
       AND PP.BEG_EFF_DATE <= PD.SCH_DISB_DATE
       AND PP.END_EFF_DATE >= PD.SCH_DISB_DATE
  LEFT OUTER JOIN VENDOR_MASTER V ON V.VENDOR_CD = PM.VENDOR_CD
       AND V.BEG_EFF_DATE <= PD.SCH_DISB_DATE
       AND V.END_EFF_DATE >= PD.SCH_DISB_DATE
  LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01 = 'BUYER_CD' AND S1.KEY02 = PM.BUYER_CD
  LEFT OUTER JOIN SYSTEM_PARAMETER S2 ON S2.KEY01 = 'SCH_ID' AND S2.KEY02 = PD.SCH_ID
  LEFT OUTER JOIN SYSTEM_PARAMETER S3 ON S3.KEY01 = 'ITEM_UMSR' AND S3.KEY02 = PM.PUR_UMSR
  LEFT OUTER JOIN SYSTEM_PARAMETER S4 ON S4.KEY01 = 'CURRENCY_CD' AND S4.KEY02 = PP.ACT_CUR
  LEFT OUTER JOIN SYSTEM_PARAMETER S5 ON S5.KEY01 = 'CURRENCY_CD' AND S5.KEY02 = PP.TENTATIVE_CUR
  LEFT OUTER JOIN SYSTEM_PARAMETER S6 ON S6.KEY01 = 'ITEM_UMSR' AND S6.KEY02 = I.ITEM_UMSR
  LEFT JOIN #TMP_CAL T ON T.DATE_WEEK_CYM=(CASE @DATE_TYPE WHEN 0 THEN C.TTL_WEEK ELSE C.CALENDAR_CYM END)
  WHERE 1 = 1
  AND (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
  AND ISNULL(IW.SC_FLAG,1) = 1
  AND PD.PO_TYPE = 3
  AND (PD.SCH_ID = @SCH_ID or @SCH_ID = '')
  AND (I.CATG_CD  = @CATG_CD or @CATG_CD = '')
  GROUP BY
        PM.BUYER_CD,        S1.DATA_CHAR,       PD.SCH_ID,     S2.DATA_CHAR,   
        PM.VENDOR_CD,       V.VENDOR_NAME,      PM.DELV_LT,     
        PD.ITEM_NO,         I.ITEM_DESC,        PD.DISB_WHS,    W.WHS_DESC,     
        PP.TENTATIVE_PRC,   PP.TENTATIVE_CUR,   S5.DATA_CHAR,
        PP.ACT_PRC,         PP.ACT_CUR,         S4.DATA_CHAR,
        PP.COM_PRC_FLAG,    S3.DATA_CHAR,       INV.INV_BAL,
        S6.DATA_CHAR,        
        (CASE @DATE_TYPE WHEN 0 THEN C.TTL_WEEK ELSE C.CALENDAR_CYM END)  --0.週単位 1.月単位
        ,T.DATE_ID 
  --//開始週(月)以前のデータ抽出
  UNION ALL
  SELECT
  (CASE @DATE_TYPE WHEN 0 THEN 'WEEK' ELSE 'MONTH' END) DATE_TYPE_TXT,
  PM.BUYER_CD,        S1.DATA_CHAR BUYER_NAME,
  PD.SCH_ID,          S2.DATA_CHAR SCH_NAME,
  PM.VENDOR_CD,       V.VENDOR_NAME,      PM.DELV_LT,
  PD.ITEM_NO,         I.ITEM_DESC,
  PD.DISB_WHS,        W.WHS_DESC,
  PP.TENTATIVE_PRC,   PP.TENTATIVE_CUR,   S5.DATA_CHAR TEN_CUR_NAME,
  PP.ACT_PRC,         PP.ACT_CUR,         S4.DATA_CHAR ACT_CUR_NAME,
  PP.COM_PRC_FLAG,
  S3.DATA_CHAR UMSR,
  INV.INV_BAL,
  S6.DATA_CHAR ITEM_UMSR,
  SUM(PD.PO_QTY) PO_QTY,  --//発注残
  SUM(CASE WHEN PD.PLAN_QTY-PD.INPUT_QTY<0 THEN 0 ELSE PD.PLAN_QTY-PD.INPUT_QTY END) PLAN_QTY,--//所要数量
  0 MIN_DATE,     MAX(C.CALENDAR_DATE) MAX_DATE,
  (CASE @DATE_TYPE WHEN 0 THEN (@TTL_WEEK - 1) ELSE
        YEAR(DATEADD(DAY,-1,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))*100
        + MONTH(DATEADD(DAY,-1,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))
  END) DATE_WEEK_CYM,
  CAST(1 AS INT) DATE_ID
  FROM (   --//所要データ
           SELECT P.DEMAND_NO, P.SCH_ID, P.ITEM_NO, P.DISB_WHS, P.PLAN_QTY, P.SCH_DISB_DATE,
              P.SUB_GRP_CD, P.SUB_ACTION_FLAG, P.PO_TYPE,P.INPUT_QTY,
              ISNULL(MIN(PTY_NO),0) PTY_NO
              ,P.PO_QTY
           FROM
            (
               SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, PLAN_QTY, SCH_DISB_DATE,
                      SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE,0 INPUT_QTY
                      ,0 PO_QTY
               FROM PLANNED_DEMAND
                  WHERE ITEM_TYPE <> '99'
               UNION ALL
               SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, PLAN_QTY, SCH_DISB_DATE,
                      SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE,INPUT_QTY
                      ,0 PO_QTY
               FROM DEMAND
               WHERE DEMAND_STATUS < 85
                  AND ITEM_TYPE <> '99'
                 UNION ALL
                 SELECT '' DEMAND_NO, POD.SCH_ID, POD.ITEM_NO, POD.DISB_WHS, 0 PLAN_QTY, PO_DUE_DATE SCH_DISB_DATE, 
                        POD.SUB_GRP_CD, POD.SUB_ACTION_FLAG, POD.PO_TYPE, 0 INPUT_QTY,
                        CAST((CASE WHEN PO_QTY-STOCK_QTY < 0 THEN 0 ELSE PO_QTY-STOCK_QTY END)
                         * (CASE WHEN ISNULL(UMSR_CONV_RATIO,1) = 0 THEN 1 ELSE ISNULL(UMSR_CONV_RATIO,1) END) AS DECIMAL(11,2)) PO_QTY 
                 FROM PUR_ORDER PO
                 INNER JOIN (
               SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE
               FROM PLANNED_DEMAND
                  WHERE ITEM_TYPE <> '99'
                  AND PO_TYPE = 3
                  AND (SUB_GRP_CD = '' OR (SUB_GRP_CD <> '' AND SUB_ACTION_FLAG = 1))
               UNION ALL
               SELECT DEMAND_NO, SCH_ID, ITEM_NO, DISB_WHS, SUB_GRP_CD, SUB_ACTION_FLAG, PO_TYPE
               FROM DEMAND
               WHERE DEMAND_STATUS < 85
                  AND ITEM_TYPE <> '99'
                  AND PO_TYPE = 3
                  AND (SUB_GRP_CD = '' OR (SUB_GRP_CD <> '' AND SUB_ACTION_FLAG = 1))
                 ) POD ON POD.ITEM_NO = PO.ITEM_NO AND POD.DISB_WHS = PO.WHS_CD
                 WHERE ORDER_STATUS < 77
            ) P
           LEFT OUTER JOIN PURCHASE_MASTER M
             ON P.ITEM_NO = M.ITEM_NO
            AND P.SCH_DISB_DATE >= M.BEG_EFF_DATE
            AND P.SCH_DISB_DATE <= M.END_EFF_DATE
           GROUP BY P.DEMAND_NO, P.SCH_ID, P.ITEM_NO, P.DISB_WHS, P.PLAN_QTY, P.SCH_DISB_DATE,
                    P.SUB_GRP_CD, P.SUB_ACTION_FLAG, P.PO_TYPE,P.INPUT_QTY
                   ,P.PO_QTY
       ) PD
  LEFT OUTER JOIN WAREHOUSE_MASTER W ON W.WHS_CD  = PD.DISB_WHS
  INNER JOIN 
       (SELECT * FROM CALENDAR_MASTER
              WHERE CALENDAR_ID = '00'
                AND CALENDAR_DATE  <= ( CASE @DATE_TYPE  --0.週単位 1.月単位
                                        WHEN 0 THEN (SELECT MAX(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK-1) 
                                        WHEN 1 THEN (SELECT MAX(CALENDAR_DATE) FROM CALENDAR_MASTER WHERE CALENDAR_DATE < @CALENDAR_DATE)
                                        END 
                                      )
       ) C ON C.CALENDAR_DATE  = PD.SCH_DISB_DATE
  LEFT OUTER JOIN ITEM_MASTER I ON I.ITEM_NO  = PD.ITEM_NO 
      AND (I.CATG_CD = @CATG_CD or @CATG_CD = '')
  LEFT OUTER JOIN PURCHASE_MASTER PM ON PM.ITEM_NO  = PD.ITEM_NO
       AND PM.PTY_NO  = PD.PTY_NO
       AND PM.BEG_EFF_DATE <= PD.SCH_DISB_DATE
       AND PM.END_EFF_DATE >= PD.SCH_DISB_DATE
       AND (PM.BUYER_CD = @BUYER_CD or @BUYER_CD = '')
       AND (PM.VENDOR_CD = @VENDOR_CD or @VENDOR_CD = '')
  LEFT OUTER JOIN --// 現在庫
       (SELECT ITEM_NO, WHS_CD, SUM(INV_BAL) INV_BAL
          FROM INVENTORY_DETAIL INV
         WHERE INV.INV_YM = 0
               AND INV.INV_WIP_TYPE IN (0,1)
               AND INV.INV_TYPE=0
         GROUP BY ITEM_NO, WHS_CD) INV
       ON INV.ITEM_NO = PD.ITEM_NO AND INV.WHS_CD = PD.DISB_WHS
  LEFT OUTER JOIN
       ( SELECT IW.ITEM_NO, IW.WS_CD, IW.BEG_EFF_DATE, IW.END_EFF_DATE, MIW.PTY_NO, WM.SC_FLAG 
         FROM ITEM_WS_MASTER IW
         INNER JOIN
           (
             SELECT ITEM_NO, MIN(PTY_NO) PTY_NO FROM ITEM_WS_MASTER GROUP BY ITEM_NO
           ) MIW ON IW.ITEM_NO = MIW.ITEM_NO AND IW.PTY_NO = MIW.PTY_NO
         INNER JOIN WORKSHOP_MASTER WM ON IW.WS_CD = WM.WS_CD
       ) IW 
       ON PD.ITEM_NO = IW.ITEM_NO
       AND PD.SCH_DISB_DATE >= IW.BEG_EFF_DATE
       AND PD.SCH_DISB_DATE <= IW.END_EFF_DATE
  LEFT OUTER JOIN PURCHASE_PRICE_MASTER PP 
       ON PP.ITEM_NO = PM.ITEM_NO
       AND PP.WS_CD = ISNULL(IW.WS_CD,'*')
       AND PP.PROCESS_CD = '*'
       AND PP.VENDOR_CD = PM.VENDOR_CD
       AND PP.BEG_EFF_DATE <= PD.SCH_DISB_DATE
       AND PP.END_EFF_DATE >= PD.SCH_DISB_DATE
  LEFT OUTER JOIN VENDOR_MASTER V 
       ON V.VENDOR_CD = PM.VENDOR_CD
       AND V.BEG_EFF_DATE <= PD.SCH_DISB_DATE
       AND V.END_EFF_DATE >= PD.SCH_DISB_DATE
  LEFT OUTER JOIN SYSTEM_PARAMETER S1 ON S1.KEY01 = 'BUYER_CD' AND S1.KEY02 = PM.BUYER_CD
  LEFT OUTER JOIN SYSTEM_PARAMETER S2 ON S2.KEY01 = 'SCH_ID' AND S2.KEY02 = PD.SCH_ID
  LEFT OUTER JOIN SYSTEM_PARAMETER S3 ON S3.KEY01 = 'ITEM_UMSR' AND S3.KEY02 = PM.PUR_UMSR
  LEFT OUTER JOIN SYSTEM_PARAMETER S4 ON S4.KEY01 = 'CURRENCY_CD' AND S4.KEY02 = PP.ACT_CUR
  LEFT OUTER JOIN SYSTEM_PARAMETER S5 ON S5.KEY01 = 'CURRENCY_CD' AND S5.KEY02 = PP.TENTATIVE_CUR
  LEFT OUTER JOIN SYSTEM_PARAMETER S6 ON S6.KEY01 = 'ITEM_UMSR' AND S6.KEY02 = I.ITEM_UMSR
  WHERE 1 = 1
  AND (PD.SUB_GRP_CD = '' OR (PD.SUB_GRP_CD <> '' AND PD.SUB_ACTION_FLAG = 1))
  AND ISNULL(IW.SC_FLAG,1) = 1
  AND PD.PO_TYPE = 3
  AND (PD.SCH_ID = @SCH_ID or @SCH_ID = '')
  AND (I.CATG_CD  = @CATG_CD or @CATG_CD = '')
  GROUP BY
        PM.BUYER_CD,        S1.DATA_CHAR,       PD.SCH_ID,     S2.DATA_CHAR,   
        PM.VENDOR_CD,       V.VENDOR_NAME,      PM.DELV_LT,     
        PD.ITEM_NO,         I.ITEM_DESC,        PD.DISB_WHS,    W.WHS_DESC,     
        PP.TENTATIVE_PRC,   PP.TENTATIVE_CUR,   S5.DATA_CHAR,
        PP.ACT_PRC,         PP.ACT_CUR,         S4.DATA_CHAR,
        PP.COM_PRC_FLAG,    S3.DATA_CHAR,       INV.INV_BAL,
        S6.DATA_CHAR
 --ORDER BY PD.ITEM_NO, (CASE @DATE_TYPE WHEN 0 THEN C.TTL_WEEK ELSE C.CALENDAR_CYM END)
) B
ORDER BY ITEM_NO,DATE_WEEK_CYM 
CREATE INDEX TMP_JOB_IDX1 ON #TMP_PUR (SCH_ID)
CREATE INDEX TMP_JOB_IDX2 ON #TMP_PUR (ITEM_NO)
CREATE INDEX TMP_JOB_IDX3 ON #TMP_PUR (DISB_WHS)
CREATE INDEX TMP_JOB_IDX4 ON #TMP_PUR (VENDOR_CD)
CREATE INDEX TMP_JOB_IDX5 ON #TMP_PUR (DATE_ID)
--SELECT * FROM #TMP_PUR

DECLARE @dat_num_col NVARCHAR(MAX)
DECLARE @dat_min_col NVARCHAR(MAX)
DECLARE @dat_max_col NVARCHAR(MAX)
DECLARE @pln_qty_col NVARCHAR(MAX)
DECLARE @pur_qty_col NVARCHAR(MAX)
DECLARE @pln_qty_val NVARCHAR(MAX)
DECLARE @pur_qty_val NVARCHAR(MAX)
DECLARE @sql_str NVARCHAR(MAX)

--月（週）単位のカレンダの列名（二の統合）
--SELECT @dat_num_col = ISNULL(@dat_num_col + ',', '') + QUOTENAME('DAT_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@dat_min_col = ISNULL(@dat_min_col + ',', '') + QUOTENAME('MIN_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@dat_max_col = ISNULL(@dat_max_col + ',', '') + QUOTENAME('MAX_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@pln_qty_col = ISNULL(@pln_qty_col + ',', '') + QUOTENAME('PLN_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@pur_qty_col = ISNULL(@pur_qty_col + ',', '') + QUOTENAME('PUR_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@pln_qty_val = ISNULL(@pln_qty_val + ',', '') + 'ISNULL(' + QUOTENAME('PLN_'+CAST(DATE_ID AS VARCHAR(8))) + ',0) AS ' + QUOTENAME('PLN_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@pur_qty_val = ISNULL(@pur_qty_val + ',', '') + 'ISNULL(' + QUOTENAME('PUR_'+CAST(DATE_ID AS VARCHAR(8))) + ',0) AS ' + QUOTENAME('PUR_'+CAST(DATE_ID AS VARCHAR(8)))
--FROM #TMP_CAL
--SSRS固定の表現
SET @dat_num_col = 'DAT_1, DAT_2, DAT_3, DAT_4, DAT_5, DAT_6, DAT_7, DAT_8'
SET @dat_min_col = 'MIN_1, MIN_2, MIN_3, MIN_4, MIN_5, MIN_6, MIN_7, MIN_8'
SET @dat_max_col = 'MAX_1, MAX_2, MAX_3, MAX_4, MAX_5, MAX_6, MAX_7, MAX_8'
SET @pln_qty_col = 'PLN_1, PLN_2, PLN_3, PLN_4, PLN_5, PLN_6, PLN_7, PLN_8'
SET @pur_qty_col = 'PUR_1, PUR_2, PUR_3, PUR_4, PUR_5, PUR_6, PUR_7, PUR_8'
SET @pln_qty_val = 'ISNULL(PLN_1,0) PLN_1, ISNULL(PLN_2,0) PLN_2, ISNULL(PLN_3,0) PLN_3, ISNULL(PLN_4,0) PLN_4, ISNULL(PLN_5,0) PLN_5, ISNULL(PLN_6,0) PLN_6, ISNULL(PLN_7,0) PLN_7, ISNULL(PLN_8,0) PLN_8'
SET @pur_qty_val = 'ISNULL(PUR_1,0) PUR_1, ISNULL(PUR_2,0) PUR_2, ISNULL(PUR_3,0) PUR_3, ISNULL(PUR_4,0) PUR_4, ISNULL(PUR_5,0) PUR_5, ISNULL(PUR_6,0) PUR_6, ISNULL(PUR_7,0) PUR_7, ISNULL(PUR_8,0) PUR_8'

--PRINT (@dat_num_col)
--PRINT (@dat_min_col)
--PRINT (@dat_max_col)
--PRINT (@pln_qty_col)
--PRINT (@pur_qty_col)
--PRINT (@pln_qty_val)
--PRINT (@pur_qty_val)

--SQLの合成,ライン変換列の処理[PIVOT]
SET @sql_str = '
    SELECT  PVT.DATE_TYPE_TXT,
            PVT.BUYER_CD,       PVT.BUYER_NAME,     PVT.SCH_ID,        PVT.SCH_NAME,
            PVT.VENDOR_CD,      PVT.VENDOR_NAME,    PVT.DELV_LT,
            PVT.ITEM_NO,        PVT.ITEM_DESC,      PVT.DISB_WHS,      PVT.WHS_DESC,
            PVT.TENTATIVE_PRC,  PVT.TENTATIVE_CUR,  PVT.TEN_CUR_NAME,
            PVT.ACT_PRC,        PVT.ACT_CUR,        PVT.ACT_CUR_NAME,
            PVT.COM_PRC_FLAG,   PVT.UMSR,           PVT.INV_BAL,       PVT.ITEM_UMSR, ' + '
            ' + @pln_qty_val + ', ' + '
            ' + @pur_qty_val + ', ' + '
            ' + @dat_num_col + ', ' + '
            ' + @dat_min_col + ', ' + '
            ' + @dat_max_col + '
    FROM (         --PLAN_QTY 所要数量
        SELECT ''PLN_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, DATE_TYPE_TXT,
               BUYER_CD,       BUYER_NAME,     SCH_ID,        SCH_NAME,
               VENDOR_CD,      VENDOR_NAME,    DELV_LT,
               ITEM_NO,        ITEM_DESC,      DISB_WHS,      WHS_DESC,
               TENTATIVE_PRC,  TENTATIVE_CUR,  TEN_CUR_NAME,
               ACT_PRC,        ACT_CUR,        ACT_CUR_NAME,
               COM_PRC_FLAG,   UMSR,           INV_BAL,       ITEM_UMSR,
               PLAN_QTY FROM #TMP_PUR
        ) PLN
        PIVOT
        ( SUM(PLAN_QTY) 
          FOR DATE_ID_COL IN (' + @pln_qty_col +')
    ) AS PVT
    CROSS APPLY (  --PO_QTY 発注残数量
        SELECT * 
        FROM ( 
              SELECT ''PUR_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, DATE_TYPE_TXT,
                     BUYER_CD,       BUYER_NAME,     SCH_ID,        SCH_NAME,
                     VENDOR_CD,      VENDOR_NAME,    DELV_LT,
                     ITEM_NO,        ITEM_DESC,      DISB_WHS,      WHS_DESC,
                     TENTATIVE_PRC,  TENTATIVE_CUR,  TEN_CUR_NAME,
                     ACT_PRC,        ACT_CUR,        ACT_CUR_NAME,
                     COM_PRC_FLAG,   UMSR,           INV_BAL,       ITEM_UMSR,
                     PO_QTY FROM #TMP_PUR
             ) PO
             PIVOT
             ( SUM(PO_QTY) 
               FOR DATE_ID_COL IN (' + @pur_qty_col +')
              ) AS PO_PVT
        WHERE PVT.BUYER_CD=PO_PVT.BUYER_CD
        AND   PVT.SCH_ID=PO_PVT.SCH_ID 
        AND   PVT.ITEM_NO=PO_PVT.ITEM_NO
        AND   PVT.DISB_WHS=PO_PVT.DISB_WHS
        AND   PVT.VENDOR_CD=PO_PVT.VENDOR_CD
    ) T1
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