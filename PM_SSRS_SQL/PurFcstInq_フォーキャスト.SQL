--PurFcstInq_フォーキャストSQL
DECLARE @DATE_TYPE INT = 1               --発行日付単位分類: 0.週単位 1.月単位
DECLARE @CALENDAR_DATE INT = 20140101    --開始月
DECLARE @TTL_WEEK INT = 484              --開始週 20140401
DECLARE @VENDOR_CD VARCHAR(10) = ''
DECLARE @ITEM_NO VARCHAR(20) = ''

--月（週）単位のカレンダ未加工のデータ（二の統合）
IF OBJECT_ID('tempdb..#TMP_CAL') IS NOT NULL DROP TABLE #TMP_CAL
SELECT * INTO #TMP_CAL FROM (
    SELECT  DISTINCT (CASE @DATE_TYPE WHEN 0 THEN TTL_WEEK ELSE CALENDAR_CYM END) DATE_WEEK_CYM, --0.週単位 1.月単位
            min(CALENDAR_DATE) MIN_DATE,  
            max(CALENDAR_DATE) MAX_DATE,
            (ROW_NUMBER() OVER (order by (CASE @DATE_TYPE WHEN 0 THEN TTL_WEEK ELSE CALENDAR_CYM END))) DATE_ID
    FROM  CALENDAR_MASTER
    WHERE CALENDAR_ID = '00'
    AND ( (@DATE_TYPE = 1  --Month
           and CALENDAR_DATE >= @CALENDAR_DATE  
           and CALENDAR_DATE <= CONVERT(VARCHAR(8), DATEADD(DAY,-1,(DATEADD(MONTH,8,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))), 112)
          ) or 
          (@DATE_TYPE != 1 --Week
           and TTL_WEEK >= @TTL_WEEK
           and TTL_WEEK <= (@TTL_WEEK + 7)
          )
        )
    GROUP BY (CASE @DATE_TYPE WHEN 0 THEN TTL_WEEK ELSE CALENDAR_CYM END)
) A
CREATE INDEX TMP_CAL_IDX1 ON #TMP_CAL (DATE_WEEK_CYM)
CREATE INDEX TMP_CAL_IDX2 ON #TMP_CAL (DATE_ID)
--SELECT * FROM #TMP_CAL

--フォーキャスト明細未加工のデータ
IF OBJECT_ID('tempdb..#TMP_FCS') IS NOT NULL DROP TABLE #TMP_FCS
SELECT * INTO #TMP_FCS FROM (
  SELECT
   (CASE @DATE_TYPE WHEN 0 THEN 'WEEK' ELSE 'MONTH' END) DATE_TYPE_TXT
  ,PO.VENDOR_CD
  ,VM.VENDOR_NAME 
  ,PO.ITEM_NO
  ,PO.ITEM_DESC
  ,CASE PM.DELV_LT_TYPE 
   WHEN 0 THEN convert(varchar,PM.DELV_LT) 
   WHEN 1 THEN convert(varchar,PM.DELV_LT_PROPORTION) 
          + '(LOT:' + convert(varchar,PM.STD_LOT_SIZE) + ')' END DELV_LT 
  ,SUM(PO.PO_QTY) PO_QTY
  ,(CASE @DATE_TYPE WHEN 0 THEN CAL.TTL_WEEK ELSE CAL.CALENDAR_CYM END) DATE_WEEK_CYM
  ,T.DATE_ID
  FROM PLANNED_ORDER PO
  LEFT JOIN CALENDAR_MASTER CAL ON CAL.CALENDAR_DATE = PO.PO_DUE_DATE
       AND CAL.CALENDAR_ID = '00'
       AND ( (@DATE_TYPE = 1  --Month
              and CAL.CALENDAR_DATE  >= (SELECT MIN(CALENDAR_DATE) from CALENDAR_MASTER WHERE CALENDAR_DATE >= @CALENDAR_DATE)
              and CAL.CALENDAR_DATE  <= (SELECT MAX(CALENDAR_DATE) from CALENDAR_MASTER WHERE CALENDAR_DATE <=
                  CONVERT(VARCHAR(8), DATEADD(DAY,-1,(DATEADD(MONTH,8,CONVERT(DATETIME,CONVERT(VARCHAR(8),@CALENDAR_DATE))))), 112))
             ) or 
             (@DATE_TYPE != 1 --Week
              and CAL.CALENDAR_DATE  >= (SELECT MIN(CALENDAR_DATE) from CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK)
              and CAL.CALENDAR_DATE  <= (SELECT MAX(CALENDAR_DATE) from CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK + 7)
             ) 
           )
  LEFT OUTER JOIN PURCHASE_MASTER PM ON PM.ITEM_NO  = PO.ITEM_NO
       AND PO.VENDOR_CD = PM.VENDOR_CD
       AND PO.PO_DUE_DATE >= PM.BEG_EFF_DATE
       AND PO.PO_DUE_DATE <= PM.END_EFF_DATE
  LEFT OUTER JOIN VENDOR_MASTER VM ON PO.VENDOR_CD = VM.VENDOR_CD
  LEFT JOIN #TMP_CAL T ON T.DATE_WEEK_CYM=(CASE @DATE_TYPE WHEN 0 THEN CAL.TTL_WEEK ELSE CAL.CALENDAR_CYM END)
  WHERE 1 = 1
    AND PO.SC_FLAG = 1
    AND PO.ITEM_TYPE <> '99'
    AND (PO.VENDOR_CD = @VENDOR_CD or @VENDOR_CD = '')
    AND (PO.ITEM_NO LIKE @ITEM_NO or @ITEM_NO = '')
    AND ( (@DATE_TYPE = 1  --Month
              and PO.PO_DUE_DATE >= @CALENDAR_DATE  
              and PO.PO_DUE_DATE <= CONVERT(varchar(8), DATEADD(Month,8,convert(datetime,convert(varchar(8),@CALENDAR_DATE))), 112)
             ) or 
             (@DATE_TYPE != 1 --Week
              and PO.PO_DUE_DATE  >= (SELECT MIN(CALENDAR_DATE) from CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK)
              and PO.PO_DUE_DATE  <= (SELECT MAX(CALENDAR_DATE) from CALENDAR_MASTER WHERE TTL_WEEK = @TTL_WEEK + 7)
             ) 
        )
  GROUP BY 
        PO.VENDOR_CD, VM.VENDOR_NAME, PO.ITEM_NO, PO.ITEM_DESC
       ,CASE PM.DELV_LT_TYPE 
        WHEN 0 THEN convert(varchar,PM.DELV_LT) 
        WHEN 1 THEN convert(varchar,PM.DELV_LT_PROPORTION)   + '(LOT:' + convert(varchar,PM.STD_LOT_SIZE) + ')' END
       ,CASE @DATE_TYPE WHEN 0 THEN CAL.TTL_WEEK ELSE CAL.CALENDAR_CYM END
       ,T.DATE_ID 
  --ORDER BY PO.VENDOR_CD, PO.ITEM_NO
) B
ORDER BY VENDOR_CD, ITEM_NO, DATE_WEEK_CYM
CREATE INDEX TMP_JOB_IDX1 ON #TMP_FCS (ITEM_NO)
CREATE INDEX TMP_JOB_IDX2 ON #TMP_FCS (VENDOR_CD)
CREATE INDEX TMP_JOB_IDX5 ON #TMP_FCS (DATE_ID)
--SELECT * FROM #TMP_FCS

DECLARE @dat_num_col NVARCHAR(MAX)
DECLARE @dat_min_col NVARCHAR(MAX)
DECLARE @dat_max_col NVARCHAR(MAX)
DECLARE @pur_qty_col NVARCHAR(MAX)
DECLARE @pur_qty_val NVARCHAR(MAX)
DECLARE @sql_str NVARCHAR(MAX)

--月（週）単位のカレンダの列名（二の統合）
--SELECT @dat_num_col = ISNULL(@dat_num_col + ',', '') + QUOTENAME('DAT_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@dat_min_col = ISNULL(@dat_min_col + ',', '') + QUOTENAME('MIN_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@dat_max_col = ISNULL(@dat_max_col + ',', '') + QUOTENAME('MAX_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@pur_qty_col = ISNULL(@pur_qty_col + ',', '') + QUOTENAME('PUR_'+CAST(DATE_ID AS VARCHAR(8)))
--      ,@pur_qty_val = ISNULL(@pur_qty_val + ',', '') + 'ISNULL(' + QUOTENAME('PUR_'+CAST(DATE_ID AS VARCHAR(8))) + ',0) AS ' + QUOTENAME('PUR_'+CAST(DATE_ID AS VARCHAR(8)))
--FROM #TMP_CAL
--SSRS固定の表現
SET @dat_num_col = 'DAT_1, DAT_2, DAT_3, DAT_4, DAT_5, DAT_6, DAT_7, DAT_8'
SET @dat_min_col = 'MIN_1, MIN_2, MIN_3, MIN_4, MIN_5, MIN_6, MIN_7, MIN_8'
SET @dat_max_col = 'MAX_1, MAX_2, MAX_3, MAX_4, MAX_5, MAX_6, MAX_7, MAX_8'
SET @pur_qty_col = 'PUR_1, PUR_2, PUR_3, PUR_4, PUR_5, PUR_6, PUR_7, PUR_8'
SET @pur_qty_val = 'ISNULL(PUR_1,0) PUR_1, ISNULL(PUR_2,0) PUR_2, ISNULL(PUR_3,0) PUR_3, ISNULL(PUR_4,0) PUR_4, ISNULL(PUR_5,0) PUR_5, ISNULL(PUR_6,0) PUR_6, ISNULL(PUR_7,0) PUR_7, ISNULL(PUR_8,0) PUR_8'

--PRINT (@dat_num_col)
--PRINT (@dat_min_col)
--PRINT (@dat_max_col)
--PRINT (@pur_qty_col)
--PRINT (@pur_qty_val)

--SQLの合成,ライン変換列の処理[PIVOT]
SET @sql_str = '
    SELECT  PVT.DATE_TYPE_TXT,
            PVT.VENDOR_CD,   PVT.VENDOR_NAME,   PVT.ITEM_NO,   PVT.ITEM_DESC,   PVT.DELV_LT,
            ' + @pur_qty_val + ', ' + '
            ' + @dat_num_col + ', ' + '
            ' + @dat_min_col + ', ' + '
            ' + @dat_max_col + '
    FROM (         --PO_QTY 発注残数量
        SELECT ''PUR_'' + CAST(DATE_ID AS VARCHAR(8)) AS DATE_ID_COL, DATE_TYPE_TXT,
               VENDOR_CD,      VENDOR_NAME,    ITEM_NO,        ITEM_DESC,      DELV_LT,
               PO_QTY FROM #TMP_FCS
        ) PLN
        PIVOT
        ( SUM(PO_QTY) 
          FOR DATE_ID_COL IN (' + @pur_qty_col +')
    ) AS PVT
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
    ORDER BY PVT.VENDOR_CD,PVT.ITEM_NO'

--PRINT (@sql_str)
EXEC (@sql_str)