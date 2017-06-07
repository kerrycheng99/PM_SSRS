--InvRcvDisbList_月次受払表SQL
DECLARE @WHS_CD VARCHAR(10) = ''      
DECLARE @YYMM INT = 0                --対象年月
DECLARE @ITEM_TYPE VARCHAR(20) = ''  --品目区分:21.仕込製品 22.受注製品 30.半製品 52.購入品 
DECLARE @INPUT_TYPE INT = 0          --出力区分:0.数量 1.金額
DECLARE @PRC_TYPE INT = 0            --評価単価:0.標準単価 1.月次移動平均単価 2.最終仕入単価

SELECT I.ITEM_NO,  IM.ITEM_DESC,   I.ITEM_TYPE,    I.ITEM_UMSR,
 I.BEG_INV_BAL,     I.BEG_INV_AMT,  S2.DATA_CHAR UMSR_NAME, 
 I.WHS_CD,          W.WHS_DESC,
 ISNULL(R1.QTY,0) QTY_R1,ISNULL(R2.QTY,0) QTY_R2,ISNULL(R3.QTY,0) QTY_R3,
 ISNULL(R4.QTY,0) QTY_R4,ISNULL(R5.QTY,0) QTY_R5,ISNULL(R6.QTY,0) QTY_R6,
 ISNULL(R7.QTY,0) QTY_R7,
 CASE @PRC_TYPE
      WHEN 0 THEN ISNULL(P1.STD_PRC,0)
      WHEN 1 THEN ISNULL(P2.MA_PRC,0)
      WHEN 2 THEN ISNULL(P2.LAST_RCV_PRC,0)
 END CUR_PRC,
 CASE @PRC_TYPE
      WHEN 0 THEN ISNULL(P1.CURRENCY,S.CURRENCY)
      WHEN 1 THEN S.CURRENCY
      WHEN 2 THEN S.CURRENCY
 END CURRENCY,
 CASE @PRC_TYPE
      WHEN 0 THEN ISNULL(P1.AMT_DEC,S.AMT_DEC)
      WHEN 1 THEN S.AMT_DEC
      WHEN 2 THEN S.AMT_DEC
 END AMT_DEC
FROM (     --//繰越在庫
    SELECT  WHS_CD,          ITEM_NO,             ITEM_TYPE,          ITEM_UMSR,
           SUM(BEG_INV_BAL) BEG_INV_BAL,         SUM(BEG_INV_AMT) BEG_INV_AMT
    FROM INVENTORY_DETAIL
    WHERE 1 = 1
    AND INV_YM       = (case when @YYMM=YEAR(GETDATE())*100+MONTH(GETDATE()) then 0 else @YYMM end)
    AND INV_WIP_TYPE = 0
    AND INV_TYPE     = 0
    AND (WHS_CD      = @WHS_CD or @WHS_CD = '')
    GROUP BY WHS_CD,          ITEM_NO,             ITEM_TYPE,          ITEM_UMSR
  ) I
LEFT JOIN (--受払履歴-入庫 # R1
    SELECT TO_WHS_CD WHS_CD,       ITEM_NO,          SUM(QTY) QTY
    FROM RCV_DISB_TRANS
    WHERE 1 = 1
    AND SLIP_TYPE   =   '01' --//01：倉庫入庫
    AND REQ_TYPE    <>  '25' --//25：部品返品
    AND REQ_TYPE    <>  '26' --//26：製品出荷返品
    AND TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
    AND (TO_WHS_CD   =   @WHS_CD or @WHS_CD = '')
    GROUP BY TO_WHS_CD,          ITEM_NO
  ) R1 ON I.ITEM_NO = R1.ITEM_NO 
       AND I.WHS_CD = R1.WHS_CD
LEFT JOIN ( --受払履歴-在庫調整増 # R2
    SELECT TO_WHS_CD WHS_CD,       ITEM_NO,          SUM(QTY) QTY
    FROM   RCV_DISB_TRANS
    WHERE  SLIP_TYPE   =   '91'--//91：在庫調整増
    AND    REQ_TYPE    <>  '25'--//25：部品返品
    AND    REQ_TYPE    <>  '26'--//26：製品出荷返品
    AND    TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
    AND    (TO_WHS_CD   =   @WHS_CD or @WHS_CD = '')
    GROUP BY TO_WHS_CD,          ITEM_NO
  ) R2 ON I.ITEM_NO = R2.ITEM_NO
       AND I.WHS_CD = R2.WHS_CD
LEFT JOIN ( --受払履歴-出庫 # R3
    SELECT FROM_WHS_CD WHS_CD,       ITEM_NO,          SUM(QTY) QTY
    FROM   RCV_DISB_TRANS
    WHERE  SLIP_TYPE   =   '02'--//02：倉庫出庫
    AND    REQ_TYPE    <>  '25'--//25：部品返品
    AND    REQ_TYPE    <>  '26'--//26：製品出荷返品
    AND    TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
    AND    (FROM_WHS_CD   =   @WHS_CD or @WHS_CD = '')
    GROUP BY FROM_WHS_CD,          ITEM_NO
  ) R3 ON I.ITEM_NO = R3.ITEM_NO
       AND I.WHS_CD = R3.WHS_CD
LEFT JOIN ( --受払履歴-返品 # R4
    SELECT WHS_CD,       ITEM_NO,          SUM(QTY) QTY
    FROM (SELECT FROM_WHS_CD WHS_CD,       ITEM_NO,        SUM(QTY) QTY
          FROM   RCV_DISB_TRANS
          WHERE  SLIP_TYPE   =   '02'--//02：倉庫出庫
          AND    REQ_TYPE    =   '25'--//25：部品返品
          AND    TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
          AND    (FROM_WHS_CD   =   @WHS_CD or @WHS_CD = '')
          GROUP BY FROM_WHS_CD,          ITEM_NO
          UNION ALL
          SELECT TO_WHS_CD WHS_CD,       ITEM_NO,          SUM(QTY)*(-1) QTY 
          FROM   RCV_DISB_TRANS
          WHERE  SLIP_TYPE   =   '01'--//01：倉庫入庫
          AND    REQ_TYPE    =   '26'--//26：製品出荷返品
          AND    TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
          AND    (TO_WHS_CD   =   @WHS_CD or @WHS_CD = '')
          GROUP BY TO_WHS_CD,          ITEM_NO
         ) A                
    GROUP BY WHS_CD,          ITEM_NO
  ) R4 ON I.ITEM_NO = R4.ITEM_NO
       AND I.WHS_CD = R4.WHS_CD
LEFT JOIN ( --受払履歴-在庫調整減 # R5
    SELECT TO_WHS_CD WHS_CD,       ITEM_NO,          SUM(QTY) QTY 
    FROM   RCV_DISB_TRANS
    WHERE  SLIP_TYPE   =   '92'--//92：在庫調整減（棚卸調整出庫）
    AND    REQ_TYPE    <>  '25'--//25：部品返品
    AND    REQ_TYPE    <>  '26'--//26：製品出荷返品
    AND    REQ_TYPE    <>  '92'--//92：仕掛棚卸調整 
    AND    TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
    AND    (TO_WHS_CD   =   @WHS_CD or @WHS_CD = '')
    GROUP BY TO_WHS_CD,          ITEM_NO
  ) R5 ON I.ITEM_NO = R5.ITEM_NO
       AND I.WHS_CD = R5.WHS_CD
LEFT JOIN ( --受払履歴-振替入庫 # R6
    SELECT TO_WHS_CD WHS_CD,       ITEM_NO,          SUM(QTY) QTY
    FROM   RCV_DISB_TRANS
    WHERE  SLIP_TYPE   =   '11'--//11：振替入庫
    AND    REQ_TYPE    <>  '25'--//25：部品返品
    AND    REQ_TYPE    <>  '26'--//26：製品出荷返品
    AND    TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
    AND     (TO_WHS_CD   =   @WHS_CD or @WHS_CD = '')
    GROUP BY TO_WHS_CD,          ITEM_NO
  ) R6 ON I.ITEM_NO = R6.ITEM_NO
       AND I.WHS_CD = R6.WHS_CD
LEFT JOIN ( --受払履歴-振替出庫 # R7
    SELECT FROM_WHS_CD WHS_CD,       ITEM_NO,          SUM(QTY) QTY
    FROM   RCV_DISB_TRANS
    WHERE  SLIP_TYPE   =   '12'--//12：振替出庫
    AND    REQ_TYPE    <>  '25'--//25：部品返品
    AND    REQ_TYPE    <>  '26'--//26：製品出荷返品
    AND    TRANS_DATE  BETWEEN  @YYMM*100 AND @YYMM*100+99 
    AND    (FROM_WHS_CD   =   @WHS_CD or @WHS_CD = '')
    GROUP BY FROM_WHS_CD,          ITEM_NO
  ) R7 ON I.ITEM_NO = R7.ITEM_NO
       AND I.WHS_CD = R7.WHS_CD
LEFT JOIN ( --評価単価-標準単価
    SELECT SPM.ITEM_NO,          SPM.STD_PRC,         SPM.CURRENCY
          ,S.DATA_DEC2 AMT_DEC
    FROM  STD_PRICE_MASTER SPM
    LEFT JOIN  SYSTEM_PARAMETER S ON S.KEY01='CURRENCY_CD' AND S.KEY02 = SPM.CURRENCY
    WHERE SPM.BEG_EFF_DATE   <=   @YYMM
    AND   SPM.END_EFF_DATE   >=   @YYMM
  ) P1 ON I.ITEM_NO = P1.ITEM_NO
LEFT JOIN ( --評価単価-月次移動平均単価、最終仕入単価
    SELECT WHS_CD,    ITEM_NO,     MA_PRC,    LAST_RCV_PRC
    FROM   MONTHLY_INV
    WHERE  YYMM     =   @YYMM
    AND    (WHS_CD  =   @WHS_CD or @WHS_CD = '')
  ) P2 ON  I.WHS_CD    = P2.WHS_CD
       AND I.ITEM_NO   = P2.ITEM_NO
LEFT JOIN ( --基軸通貨 S #
    SELECT KEY02 CURRENCY ,ISNULL(DATA_DEC2,0) AMT_DEC  
    FROM   SYSTEM_PARAMETER
    WHERE  KEY01     =   'CURRENCY_CD'
    AND    DATA_INT  =   1
  ) S ON 1=1
LEFT JOIN ITEM_MASTER IM ON IM.ITEM_NO = I.ITEM_NO  
LEFT JOIN WAREHOUSE_MASTER W ON I.WHS_CD = W.WHS_CD 
LEFT JOIN SYSTEM_PARAMETER S2 ON S2.KEY01 = 'ITEM_UMSR'  AND S2.KEY02 = I.ITEM_UMSR  
WHERE 1 = 1
AND I.ITEM_TYPE IN (@ITEM_TYPE)
ORDER BY I.WHS_CD