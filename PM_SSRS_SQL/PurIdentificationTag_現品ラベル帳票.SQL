--PurIdentificationTag_現品ラベル帳票SQL
DECLARE @ITEM_NO        VARCHAR(30)  = 'H52-104' 
DECLARE @WHS_CD         VARCHAR(10)  = 'WP01'
DECLARE @ACT_QTY        DECIMAL(11,2)= 98.00    --総数量
DECLARE @LOT_NO         VARCHAR(20)  = '120717000000351'
DECLARE @LOCATION       VARCHAR(10)  = 'LOC-001'
DECLARE @SLIP_DATE      INT          = 20150527
DECLARE @IDTAG_UNIT_QTY DECIMAL(11,2)= 20.00    --発行単位数量

IF OBJECT_ID('tempdb..#IDTAG_LBL') IS NOT NULL DROP TABLE #IDTAG_LBL
CREATE TABLE #IDTAG_LBL ( 
    ITEM_NO                  VARCHAR (30) ,    --品目コード
    ITEM_DESC                NVARCHAR(50) ,    --品名
    WHS_CD                   VARCHAR (10) ,    --倉庫コード
    WHS_DESC                 NVARCHAR(30) ,    --倉庫名称
    ACT_QTY                  DECIMAL(11,2),    --総数量
    ITEM_UMSR_NAME           VARCHAR (10) ,
    LOT_NO                   VARCHAR (20) ,
    LOCATION                 VARCHAR (10) ,
    SLIP_DATE                INT          ,
    IDTAG_UNIT_QTY           DECIMAL(11,2),    --発行単位数量
    LABEL_CNT                INT          ,    --現品ラベル枚数
    LABEL_IDX                INT          ,
    LABEL_QTY                DECIMAL(11,2)
)

DECLARE @wITEM_DESC      NVARCHAR(50)
DECLARE @wITEM_UMSR_NAME VARCHAR(10)
DECLARE @wWHS_DESC       NVARCHAR(30)

SELECT @wITEM_DESC = I.ITEM_DESC, @wITEM_UMSR_NAME = ISNULL(SP.DATA_CHAR, I.ITEM_UMSR)
FROM ITEM_MASTER I
LEFT JOIN SYSTEM_PARAMETER SP 
     ON SP.KEY01='ITEM_UMSR' 
     AND SP.KEY02 = I.ITEM_UMSR
WHERE ITEM_NO = @ITEM_NO
  
SELECT @wWHS_DESC = WHS_DESC FROM WAREHOUSE_MASTER WHERE WHS_CD = @WHS_CD

DECLARE @wLBL_CNT INT = CEILING(@ACT_QTY / @IDTAG_UNIT_QTY)  --現品ラベル枚数
DECLARE @wLBL_IDX INT = 1    --現品ラベルのシーケンス番号

WHILE @wLBL_IDX <= @wLBL_CNT
BEGIN
    insert into #IDTAG_LBL (
        ITEM_NO      ,ITEM_DESC         ,WHS_CD            ,WHS_DESC, 
        ACT_QTY      ,ITEM_UMSR_NAME    ,LOT_NO            ,LOCATION, 
        SLIP_DATE    ,IDTAG_UNIT_QTY    ,LABEL_CNT         ,
        LABEL_IDX    ,
        LABEL_QTY
        )
    SELECT
        @ITEM_NO     ,@wITEM_DESC       ,@WHS_CD           ,@wWHS_DESC, 
        @ACT_QTY     ,@wITEM_UMSR_NAME  ,@LOT_NO           ,@LOCATION, 
        @SLIP_DATE   ,@IDTAG_UNIT_QTY   ,@wLBL_CNT         ,
        @wLBL_IDX    ,
        case when @wLBL_IDX=@wLBL_CNT 
             then (@ACT_QTY-@IDTAG_UNIT_QTY*(@wLBL_CNT-1))
             else @IDTAG_UNIT_QTY
        end
        
    select @wLBL_IDX = @wLBL_IDX + 1
END
SELECT * FROM #IDTAG_LBL