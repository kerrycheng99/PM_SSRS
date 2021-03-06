﻿--CostStandardRpt_標準原価一覧表
DECLARE @YYMM INT = 201608    --対象年月
DECLARE @SYS_YYMM INT = YEAR(GETDATE())*100+MONTH(GETDATE())
DECLARE @ITEM_NO VARCHAR(30) = 'H52-001'
DECLARE @JOC_CD VARCHAR(10) = ''

 SELECT     PD.JOC_CD,
 0 AS LVL,  '' AS SORTCOL,   PD.ITEM_NO,     IM.ITEM_DESC,     1 AS ORDER_QTY,
 SP.DATA_CHAR UMSR_NAME,       PD.PR_MATERIALS,  PD.PR_SUBCONTRACT,
 PD.PR_LADOR_ARG + PD.PR_LADOR_MANU + PD.PR_LADOR_TRANS AS PR_LADOR,
 ISNULL(PO.PR_OVERHEAD,0) AS PR_OVERHEAD,      PD.PR_PRICE+ISNULL(PO.PR_OVERHEAD,0) AS PR_PRICE, 
 ISNULL(ST.STD_PRC,0) STD_PRC,   (PD.PR_PRICE+ISNULL(PO.PR_OVERHEAD,0))-ISNULL(ST.STD_PRC,0) AS DIFF,
 (CASE ISNULL(ST.STD_PRC,0) WHEN 0 THEN NULL ELSE (((PD.PR_PRICE+ISNULL(PO.PR_OVERHEAD,0))-ISNULL(ST.STD_PRC,0))/ISNULL(ST.STD_PRC,0)*100) END) AS DIFF_RATE  ,PD.YYMM
 FROM    PRODUCT_RAISING_DIRECT PD
 LEFT OUTER JOIN (SELECT YYMM, ITEM_NO, SUM(PR_OVERHEAD) PR_OVERHEAD 
                  ,JOC_CD
                  FROM PRODUCT_RAISING_OVERHEAD
                  GROUP BY YYMM,JOC_CD, ITEM_NO) PO
         ON PD.YYMM = PO.YYMM AND PD.ITEM_NO = PO.ITEM_NO
         AND PD.JOC_CD = PO.JOC_CD
 LEFT OUTER JOIN ITEM_MASTER IM ON PD.ITEM_NO = IM.ITEM_NO
 LEFT OUTER JOIN STD_PRICE_MASTER ST ON PD.ITEM_NO = ST.ITEM_NO
    AND ST.BEG_EFF_DATE <= @YYMM
    AND ST.END_EFF_DATE >= @YYMM
 LEFT OUTER JOIN SYSTEM_PARAMETER SP ON SP.KEY01 = 'ITEM_UMSR'
               AND SP.KEY02 = IM.ITEM_UMSR
 WHERE PD.YYMM       = @YYMM
   AND PD.ITEM_NO    = @ITEM_NO
   AND PD.JOC_CD     = @JOC_CD
 UNION ALL 
 SELECT  PD.JOC_CD,
 BM.LVL, BM.SORTCOL, BM.CHILD_ITEM_NO,        IM.ITEM_DESC,
    (CASE WHEN BM.USAGE_TYPE = 0 THEN BM.USAGE_DEC ELSE BM.USAGE_NUMERATOR/  
    (CASE  BM.USAGE_DENOMINATOR WHEN 0 THEN 1 ELSE BM.USAGE_DENOMINATOR END)END) AS ORDER_QTY, 
    SP.DATA_CHAR UMSR_NAME,        PD.PR_MATERIALS,    PD.PR_SUBCONTRACT,  
    PD.PR_LADOR_ARG + PD.PR_LADOR_MANU + PD.PR_LADOR_TRANS AS PR_LADOR, 
    ISNULL(PO.PR_OVERHEAD,0) AS PR_OVERHEAD,        PD.PR_PRICE+ISNULL(PO.PR_OVERHEAD,0) AS PR_PRICE, 
    ISNULL(ST.STD_PRC,0) STD_PRC,        (PD.PR_PRICE+ISNULL(PO.PR_OVERHEAD,0))-ISNULL(ST.STD_PRC,0) AS DIFF,
    (CASE ISNULL(ST.STD_PRC,0) WHEN 0 THEN NULL ELSE (((PD.PR_PRICE+ISNULL(PO.PR_OVERHEAD,0))-ISNULL(ST.STD_PRC,0))/ISNULL(ST.STD_PRC,0)*100) END) AS DIFF_RATE ,PD.YYMM
 FROM (SELECT * FROM MBOMTreeView(
                 @JOC_CD
                ,@ITEM_NO
                ,(CASE WHEN @YYMM!=@SYS_YYMM THEN @YYMM ELSE @SYS_YYMM END)
                ,(CASE WHEN @YYMM!=@SYS_YYMM THEN @YYMM ELSE @SYS_YYMM END))
          WHERE (SUB_GRP_CD = '' OR (SUB_GRP_CD <> '' AND SUB_ACTION_FLAG = 1))) BM
 LEFT OUTER JOIN PRODUCT_RAISING_DIRECT PD
         ON BM.CHILD_ITEM_NO = PD.ITEM_NO AND PD.YYMM = @YYMM
         AND BM.MBOM_SUB_CD = PD.JOC_CD
 LEFT OUTER JOIN (SELECT YYMM, ITEM_NO, SUM(PR_OVERHEAD) PR_OVERHEAD 
                  ,JOC_CD
                     FROM PRODUCT_RAISING_OVERHEAD
                     GROUP BY YYMM,JOC_CD, ITEM_NO) PO
         ON  BM.CHILD_ITEM_NO = PO.ITEM_NO AND PO.YYMM = @YYMM
         AND BM.MBOM_SUB_CD = PO.JOC_CD
 LEFT OUTER JOIN ITEM_MASTER IM ON BM.CHILD_ITEM_NO = IM.ITEM_NO
 LEFT OUTER JOIN STD_PRICE_MASTER ST ON BM.CHILD_ITEM_NO = ST.ITEM_NO 
    AND ST.BEG_EFF_DATE <= @YYMM
    AND ST.END_EFF_DATE >= @YYMM
 LEFT OUTER JOIN SYSTEM_PARAMETER SP ON SP.KEY01 = 'ITEM_UMSR'
    AND SP.KEY02 = IM.ITEM_UMSR
 ORDER BY SORTCOL