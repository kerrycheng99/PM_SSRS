--CostActualShow2_実際原価照会-明細
DECLARE @LANG INT = 1
DECLARE @YYMM INT = 201608    --対象年月
DECLARE @ITEM_NO VARCHAR(30) = 'H52-001'
DECLARE @JOC_CD VARCHAR(10) = ''

--最上位品目、製番原価-明細
SELECT
    R.JOC_CD                    ,                                                   --製番
    R.YYMM                      ,                                                   --年月
    R.ITEM_NO O_ITEM_NO,    IM.ITEM_DESC O_ITEM_DESC,   SP.DATA_CHAR O_UMSR_NAME,   --親品目コード
    R.ITEM_TYPE     O_ITEM_TYPE ,                                                   --親品目区分
    R.PO_TYPE       O_PO_TYPE   ,                                                   --親品目手配区分
    R.LLC           O_LLC       ,                                                   --親品目ﾛｰﾚﾍﾞﾙｺｰﾄﾞ
    D.WS_CD,        WM.WS_DESC,                                                     --作業区コード
    R.DEPT_CD,                                                                      --部門コード
    CASE @LANG 
         WHEN 1 THEN DM.DEPT_DESC1 
         WHEN 2 THEN DM.DEPT_DESC2
         WHEN 3 THEN DM.DEPT_DESC3
         WHEN 4 THEN DM.DEPT_DESC4 
    END DEPT_DESC,                                                                  --部門
    R.COMPL_MATERIALS           ,                                                   --親品目完成直接材料費
    R.COMPL_LADOR               ,                                                   --親品目完成直接労務費
    R.COMPL_SUBCONTRACT         ,                                                   --親品目完成直接外注加工費
    R.COMPL_OVER_MATERIALS      ,                                                   --親品目完成間接材料費
    R.COMPL_OVER_LADOR          ,                                                   --親品目完成間接労務費
    R.COMPL_OVER_SUBCONTRACT    ,                                                   --親品目完成間接経費
    (                                                                               
         R.COMPL_MATERIALS          + R.COMPL_LADOR         + R.COMPL_SUBCONTRACT+
         R.COMPL_OVER_MATERIALS     + R.COMPL_OVER_LADOR    + R.COMPL_OVER_SUBCONTRACT  
    ) O_COMPL_COST,                                                                    
    R.INPUT_LADOR_HOURS         ,                                                   --親品目当月投入工数
    R.COMPL_QTY                 ,                                                   --親品目当月完成数
    D.ITEM_NO,          IM1.ITEM_DESC ITEM_DESC,   SP1.DATA_CHAR UMSR_NAME,         --子品目コード
    D.ITEM_TYPE                 ,                                                   --子品目区分
    D.PO_TYPE                   ,                                                   --子品目手配区分
    D.LLC                       ,                                                   --子品目ﾛｰﾚﾍﾞﾙｺｰﾄﾞ
    D.PART_SEQ                  ,                                                   --子品目部番
    D.USAGE_DEC                 ,                                                   --子品目原単位数
    D.INPUT_QTY                 ,                                                   --子品目当月消費数
    D.MATERIALS_PROC * D.INPUT_QTY           INPUT_MATERIALS         ,              --子品目消費直接材料費
    D.LADOR_PROC * D.INPUT_QTY               INPUT_LADOR             ,              --子品目消費直接労務費
    D.SUBCONTRACT_PROC * D.INPUT_QTY         INPUT_SUBCONTRACT       ,              --子品目消費直接外注加工費
    D.OVER_MATERIALS_PROC * D.INPUT_QTY      INPUT_OVER_MATERIALS    ,              --子品目消費間接材料費
    D.OVER_LADOR_PROC * D.INPUT_QTY          INPUT_OVER_LADOR        ,              --子品目消費間接労務費
    D.OVER_SUBCONTRACT_PROC * D.INPUT_QTY    INPUT_OVER_SUBCONTRACT  ,              --子品目消費間接経費
    (
     (
      D.MATERIALS_PROC        + D.LADOR_PROC        + D.SUBCONTRACT_PROC    +
      D.OVER_MATERIALS_PROC   + D.OVER_LADOR_PROC   + D.OVER_SUBCONTRACT_PROC
     ) * D.INPUT_QTY
    ) K_COMPL_COST,
    '' SORTCOL
FROM JOC_COST_RESULTS R
INNER JOIN JOC_COST_DETAIL D
   ON R.YYMM     = D.YYMM
  AND R.JOC_CD   = D.JOC_CD
  AND R.ITEM_NO  = D.PARENT_ITEM_NO
  AND D.ORIGIN_TYPE = 4
LEFT JOIN ITEM_MASTER IM
  ON R.ITEM_NO = IM.ITEM_NO
LEFT OUTER JOIN SYSTEM_PARAMETER SP
               ON SP.KEY01 = 'ITEM_UMSR'
               AND SP.KEY02 = IM.ITEM_UMSR
LEFT JOIN ITEM_MASTER IM1
  ON D.ITEM_NO = IM1.ITEM_NO
LEFT JOIN SYSTEM_PARAMETER SP1
               ON SP1.KEY01 = 'ITEM_UMSR'
               AND SP1.KEY02 = IM1.ITEM_UMSR
LEFT JOIN DEPT_MASTER DM
  ON R.DEPT_CD = DM.DEPT_CD
LEFT JOIN WORKSHOP_MASTER WM
  ON WM.WS_CD = D.WS_CD
WHERE R.JOC_CD   = @JOC_CD
  AND R.ITEM_NO  = @ITEM_NO
  AND R.YYMM     = @YYMM
UNION ALL
--子品目、製番原価-明細
SELECT
    R.JOC_CD         ,                                                               --製番
    R.YYMM           ,                                                               --年月
    R.ITEM_NO O_ITEM_NO,  IM.ITEM_DESC O_ITEM_DESC,   SP.DATA_CHAR O_UMSR_NAME,      --親品目コード
    R.ITEM_TYPE      ,                                                               --親品目区分
    R.PO_TYPE        ,                                                               --親品目手配区分
    R.LLC            ,                                                               --親品目ﾛｰﾚﾍﾞﾙｺｰﾄﾞ
    D.WS_CD,        WM.WS_DESC,                                                      --作業区コード
    R.DEPT_CD,                                                                       --部門コード
    CASE @LANG 
         WHEN 1 THEN DM.DEPT_DESC1 
         WHEN 2 THEN DM.DEPT_DESC2
         WHEN 3 THEN DM.DEPT_DESC3
         WHEN 4 THEN DM.DEPT_DESC4 
    END DEPT_DESC,                                                                   --部門
    R.COMPL_MATERIALS,                                                               --親品目完成直接材料費
    R.COMPL_LADOR    ,                                                               --親品目完成直接労務費
    R.COMPL_SUBCONTRACT,                                                             --親品目完成直接外注加工費
    R.COMPL_OVER_MATERIALS    ,                                                      --親品目完成間接材料費
    R.COMPL_OVER_LADOR        ,                                                      --親品目完成間接労務費
    R.COMPL_OVER_SUBCONTRACT,                                                        --親品目完成間接経費
    (
         R.COMPL_MATERIALS         + R.COMPL_LADOR         + R.COMPL_SUBCONTRACT+
         R.COMPL_OVER_MATERIALS    + R.COMPL_OVER_LADOR    + R.COMPL_OVER_SUBCONTRACT  
    ) O_COMPL_COST,
    R.INPUT_LADOR_HOURS        ,                                                     --親品目当月投入工数
    R.COMPL_QTY                ,                                                     --親品目当月完成数
    D.ITEM_NO                  ,IM1.ITEM_DESC ITEM_DESC,   SP1.DATA_CHAR UMSR_NAME,  --子品目コード
    D.ITEM_TYPE                ,                                                     --子品目区分
    D.PO_TYPE                  ,                                                     --子品目手配区分
    D.LLC                      ,                                                     --子品目ﾛｰﾚﾍﾞﾙｺｰﾄﾞ
    D.PART_SEQ                 ,                                                     --子品目部番
    D.USAGE_DEC                ,                                                     --子品目原単位数
    D.INPUT_QTY                ,                                                     --子品目当月消費数
    D.MATERIALS_PROC * D.INPUT_QTY           INPUT_MATERIALS    ,                    --子品目消費直接材料費
    D.LADOR_PROC * D.INPUT_QTY               INPUT_LADOR    ,                        --子品目消費直接労務費
    D.SUBCONTRACT_PROC * D.INPUT_QTY         INPUT_SUBCONTRACT,                      --子品目消費直接外注加工費
    D.OVER_MATERIALS_PROC * D.INPUT_QTY      INPUT_OVER_MATERIALS,                   --子品目消費間接材料費
    D.OVER_LADOR_PROC * D.INPUT_QTY          INPUT_OVER_LADOR    ,                   --子品目消費間接労務費
    D.OVER_SUBCONTRACT_PROC * D.INPUT_QTY    INPUT_OVER_SUBCONTRACT,                 --子品目消費間接経費
    (
     (
      D.MATERIALS_PROC        + D.LADOR_PROC        + D.SUBCONTRACT_PROC    +
      D.OVER_MATERIALS_PROC   + D.OVER_LADOR_PROC   + D.OVER_SUBCONTRACT_PROC
     ) * D.INPUT_QTY
    ) K_COMPL_COST,
    T.SORTCOL
FROM JOC_COST_TreeView(@JOC_CD,@ITEM_NO,@YYMM) T
INNER JOIN JOC_COST_RESULTS R
    ON T.JOC_CD          = R.JOC_CD
    AND T.ITEM_NO        = R.ITEM_NO
    AND T.YYMM           = R.YYMM
INNER JOIN JOC_COST_DETAIL D
    ON R.YYMM            = D.YYMM
    AND R.JOC_CD         = D.JOC_CD
    AND R.ITEM_NO        = D.PARENT_ITEM_NO
    AND D.ORIGIN_TYPE    = 4
LEFT JOIN ITEM_MASTER IM
  ON R.ITEM_NO = IM.ITEM_NO
LEFT OUTER JOIN SYSTEM_PARAMETER SP
               ON SP.KEY01 = 'ITEM_UMSR'
               AND SP.KEY02 = IM.ITEM_UMSR
LEFT JOIN ITEM_MASTER IM1
  ON D.ITEM_NO = IM1.ITEM_NO
LEFT JOIN SYSTEM_PARAMETER SP1
               ON SP1.KEY01 = 'ITEM_UMSR'
               AND SP1.KEY02 = IM1.ITEM_UMSR
LEFT JOIN DEPT_MASTER DM
  ON R.DEPT_CD = DM.DEPT_CD
LEFT JOIN WORKSHOP_MASTER WM
  ON WM.WS_CD = D.WS_CD
ORDER BY SORTCOL, PART_SEQ
