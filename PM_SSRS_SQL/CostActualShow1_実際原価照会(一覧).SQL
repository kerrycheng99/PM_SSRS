--CostActualShow1_実際原価照会-一覧
DECLARE @LANG INT = 1
DECLARE @YYMM INT = 201608    --対象年月
DECLARE @ITEM_NO VARCHAR(30) = 'H52-001'
DECLARE @JOC_CD VARCHAR(10) = ''

SELECT
R.JOC_CD      ,                                                                   --製番
R.YYMM        ,                                                                   --年月
R.ITEM_NO,       IM.ITEM_DESC,               SP.DATA_CHAR UMSR_NAME,              --品目コード
R.ITEM_TYPE   ,                                                                   --品目区分
R.PO_TYPE     ,                                                                   --手配区分
R.LLC         ,                                                                   --ﾛｰﾚﾍﾞﾙｺｰﾄﾞ
R.DEPT_CD,                                                                        --部門コード
CASE @LANG 
     WHEN 1 THEN DM.DEPT_DESC1 
     WHEN 2 THEN DM.DEPT_DESC2
     WHEN 3 THEN DM.DEPT_DESC3
     WHEN 4 THEN DM.DEPT_DESC4 
END DEPT_DESC,                                                                    --部門
D.WS_CD,                                                                          --作業区コード
R.INPUT_LADOR_HOURS,                                                              --当月投入工数
R.COMPL_QTY        ,                                                              --当月完成数
R.COMPL_MATERIALS         + R.T_COMPL_MATERIALS           COMPL_MATERIALS    ,    --完成直接材料費
R.COMPL_LADOR             + R.T_COMPL_LADOR               COMPL_LADOR        ,    --完成直接労務費
R.COMPL_SUBCONTRACT       + R.T_COMPL_SUBCONTRACT         COMPL_SUBCONTRACT   ,   --完成直接外注加工費
R.COMPL_OVER_MATERIALS    + R.T_COMPL_OVER_MATERIALS      COMPL_OVER_MATERIALS,   --完成間接材料費
R.COMPL_OVER_LADOR        + R.T_COMPL_OVER_LADOR          COMPL_OVER_LADOR    ,   --完成間接労務費
R.COMPL_OVER_SUBCONTRACT  + R.T_COMPL_OVER_SUBCONTRACT    COMPL_OVER_SUBCONTRACT, --完成間接経費
(                                                                                
 R.COMPL_MATERIALS        + R.COMPL_LADOR        + R.COMPL_SUBCONTRACT+          
 R.T_COMPL_MATERIALS      + R.T_COMPL_LADOR      + R.T_COMPL_SUBCONTRACT+        
 R.COMPL_OVER_MATERIALS   + R.COMPL_OVER_LADOR   + R.COMPL_OVER_SUBCONTRACT+     
 R.T_COMPL_OVER_MATERIALS + R.T_COMPL_OVER_LADOR + R.T_COMPL_OVER_SUBCONTRACT    
) COMPL_COST                                    ,                                 --実際原価
(R.COMPL_QTY * ISNULL(M.STD_PRC,0)) STD_COST    ,                                 --標準原価
(                                                                                
 R.COMPL_MATERIALS        + R.COMPL_LADOR        + R.COMPL_SUBCONTRACT+          
 R.T_COMPL_MATERIALS      + R.T_COMPL_LADOR      + R.T_COMPL_SUBCONTRACT+        
 R.COMPL_OVER_MATERIALS   + R.COMPL_OVER_LADOR   + R.COMPL_OVER_SUBCONTRACT+     
 R.T_COMPL_OVER_MATERIALS + R.T_COMPL_OVER_LADOR + R.T_COMPL_OVER_SUBCONTRACT-   
 (R.COMPL_QTY * ISNULL(M.STD_PRC,0))                                             
 ) DIFF_COST,                                                                     --原価差異
(
 CASE WHEN (R.COMPL_QTY * ISNULL(M.STD_PRC,0)) = 0 THEN 0 ELSE
 (
  (
   R.COMPL_MATERIALS        + R.COMPL_LADOR        + R.COMPL_SUBCONTRACT+
   R.T_COMPL_MATERIALS      + R.T_COMPL_LADOR      + R.T_COMPL_SUBCONTRACT+
   R.COMPL_OVER_MATERIALS   + R.COMPL_OVER_LADOR   + R.COMPL_OVER_SUBCONTRACT+ 
   R.T_COMPL_OVER_MATERIALS + R.T_COMPL_OVER_LADOR + R.T_COMPL_OVER_SUBCONTRACT-
   (R.COMPL_QTY * ISNULL(M.STD_PRC,0))
  ) / (R.COMPL_QTY * ISNULL(M.STD_PRC,0)) * 100
 ) END
) DIFF_RATE    ,                                                                  --原価差異率
'' SORTCOL
FROM JOC_COST_RESULTS R
INNER JOIN JOC_COST_DETAIL D
   ON R.YYMM = D.YYMM
  AND R.JOC_CD = D.JOC_CD
  AND R.ITEM_NO = D.ITEM_NO
  AND D.ORIGIN_TYPE = 2
  AND D.LAST_FLAG = 1
LEFT JOIN ITEM_MASTER IM 
  ON R.ITEM_NO = IM.ITEM_NO
LEFT JOIN SYSTEM_PARAMETER SP 
  ON SP.KEY01 = 'ITEM_UMSR' 
 AND SP.KEY02 = IM.ITEM_UMSR
LEFT JOIN DEPT_MASTER DM 
  ON R.DEPT_CD = DM.DEPT_CD
LEFT JOIN STD_PRICE_MASTER M
  ON R.ITEM_NO = M.ITEM_NO
 AND M.BEG_EFF_DATE <= @YYMM
 AND M.END_EFF_DATE >= @YYMM
WHERE R.JOC_CD    = @JOC_CD
  AND R.ITEM_NO   = @ITEM_NO
  AND R.YYMM      = @YYMM
UNION ALL --子品目、製番原価
SELECT
R.JOC_CD,                                                                              --製番
R.YYMM,                                                                                --年月
R.ITEM_NO,       IM.ITEM_DESC,               SP.DATA_CHAR UMSR_NAME,                   --品目コード
R.ITEM_TYPE,                                                                           --品目区分
R.PO_TYPE,                                                                             --手配区分
R.LLC,                                                                                 --ﾛｰﾚﾍﾞﾙｺｰﾄﾞ
R.DEPT_CD,                                                                             --部門コード
CASE @LANG 
     WHEN 1 THEN DM.DEPT_DESC1 
     WHEN 2 THEN DM.DEPT_DESC2
     WHEN 3 THEN DM.DEPT_DESC3
     WHEN 4 THEN DM.DEPT_DESC4 
END DEPT_DESC,                                                                         --部門
D.WS_CD,                                                                               --作業区コード
R.INPUT_LADOR_HOURS     ,                                                              --当月投入工数
R.COMPL_QTY,                                                                           --当月完成数
R.COMPL_MATERIALS         + R.T_COMPL_MATERIALS              COMPL_MATERIALS,          --完成直接材料費
R.COMPL_LADOR             + R.T_COMPL_LADOR                  COMPL_LADOR,              --完成直接労務費
R.COMPL_SUBCONTRACT       + R.T_COMPL_SUBCONTRACT            COMPL_SUBCONTRACT,        --完成直接外注加工費
R.COMPL_OVER_MATERIALS    + R.T_COMPL_OVER_MATERIALS         COMPL_OVER_MATERIALS,     --完成間接材料費
R.COMPL_OVER_LADOR        + R.T_COMPL_OVER_LADOR             COMPL_OVER_LADOR,         --完成間接労務費
R.COMPL_OVER_SUBCONTRACT  + R.T_COMPL_OVER_SUBCONTRACT COMPL_OVER_SUBCONTRACT,         --完成間接経費
(
 R.COMPL_MATERIALS        + R.COMPL_LADOR             + R.COMPL_SUBCONTRACT+
 R.T_COMPL_MATERIALS      + R.T_COMPL_LADOR           + R.T_COMPL_SUBCONTRACT+
 R.COMPL_OVER_MATERIALS   + R.COMPL_OVER_LADOR        + R.COMPL_OVER_SUBCONTRACT+
 R.T_COMPL_OVER_MATERIALS + R.T_COMPL_OVER_LADOR      + R.T_COMPL_OVER_SUBCONTRACT
) COMPL_COST,                                                                          --実際原価
(R.COMPL_QTY * ISNULL(M.STD_PRC,0)) STD_COST,                                          --標準原価
(
 R.COMPL_MATERIALS        + R.COMPL_LADOR             + R.COMPL_SUBCONTRACT         +
 R.T_COMPL_MATERIALS      + R.T_COMPL_LADOR           + R.T_COMPL_SUBCONTRACT       +
 R.COMPL_OVER_MATERIALS   + R.COMPL_OVER_LADOR        + R.COMPL_OVER_SUBCONTRACT    +
 R.T_COMPL_OVER_MATERIALS + R.T_COMPL_OVER_LADOR      + R.T_COMPL_OVER_SUBCONTRACT  -
 (R.COMPL_QTY * ISNULL(M.STD_PRC,0))
) DIFF_COST,                                                                            --原価差異
(
 CASE WHEN (R.COMPL_QTY * ISNULL(M.STD_PRC,0)) = 0 THEN 0 ELSE
 (
     (R.COMPL_MATERIALS           + R.COMPL_LADOR        + R.COMPL_SUBCONTRACT         +
      R.T_COMPL_MATERIALS         + R.T_COMPL_LADOR      + R.T_COMPL_SUBCONTRACT       +
      R.COMPL_OVER_MATERIALS      + R.COMPL_OVER_LADOR   + R.COMPL_OVER_SUBCONTRACT    +
      R.T_COMPL_OVER_MATERIALS    + R.T_COMPL_OVER_LADOR + R.T_COMPL_OVER_SUBCONTRACT  -
      R.COMPL_QTY * ISNULL(M.STD_PRC,0)
     ) / (R.COMPL_QTY * ISNULL(M.STD_PRC,0)) * 100
 ) END
) DIFF_RATE,                                                                            --原価差異率
T.SORTCOL
FROM JOC_COST_TreeView(@JOC_CD,@ITEM_NO,@YYMM) T 
INNER JOIN JOC_COST_RESULTS R
   ON T.JOC_CD     = R.JOC_CD
  AND T.ITEM_NO   = R.ITEM_NO
  AND T.YYMM      = R.YYMM
INNER JOIN JOC_COST_DETAIL D
   ON R.YYMM       = D.YYMM
  AND R.JOC_CD    = D.JOC_CD
  AND R.ITEM_NO   = D.ITEM_NO
  AND D.ORIGIN_TYPE = 2
  AND D.LAST_FLAG = 1
LEFT JOIN ITEM_MASTER IM
  ON R.ITEM_NO = IM.ITEM_NO
LEFT JOIN SYSTEM_PARAMETER SP
  ON SP.KEY01 = 'ITEM_UMSR'
 AND SP.KEY02 = IM.ITEM_UMSR
LEFT JOIN DEPT_MASTER DM
  ON R.DEPT_CD = DM.DEPT_CD
LEFT JOIN STD_PRICE_MASTER M
  ON R.ITEM_NO        = M.ITEM_NO
 AND M.BEG_EFF_DATE  <= @YYMM
 AND M.END_EFF_DATE  >= @YYMM