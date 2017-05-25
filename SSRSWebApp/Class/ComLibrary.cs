using System;
using System.Web;
using System.Web.UI;
using System.Web.Configuration;
using System.Globalization;
using System.Text;

using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

//QRコード（2次元バーコード）を生成の参照
using ThoughtWorks.QRCode.Codec;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

/// <summary>
/// 各種関数クラス
/// </summary>
namespace PMClass
{
    public class ComLibrary
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ComLibrary()
        {
            //throw new System.NotImplementedException();
        }

        #region:日付書式の取得
        public string GetDateFormat(string p_user_id, int p_lang)
        {
            SystemParameter sys = new SystemParameter(p_user_id, p_lang);
            sys.key01 = "DATE_FORMAT";
            int rtn = sys.GetDetail();
            if (rtn == ComConst.FAILED) sys.data_char = "yyyy/MM/dd";
            sys.data_char = CheckDateFormat(sys.data_char);
            return sys.data_char;
        }
        #endregion

        #region : 数値関数
        //public void RoudUp()
        //{
        //    //throw new System.NotImplementedException();
        //}

        //public void Round()
        //{
        //    //throw new System.NotImplementedException();
        //}

        /// ------------------------------------------------------------------------
        /// <summary>
        ///     指定した精度の数値に切り捨てします。</summary>
        /// <param name="dValue">
        ///     丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">
        ///     戻り値の有効桁数の精度。</param>
        /// <returns>
        ///     iDigits に等しい精度の数値に切り捨てられた数値。</returns>
        /// ------------------------------------------------------------------------
        public double ToRoundDown(double dValue, int iDigits)
        {
            double dCoef = System.Math.Pow(10, iDigits);

            return dValue > 0 ? System.Math.Floor(dValue * dCoef) / dCoef :
                                System.Math.Ceiling(dValue * dCoef) / dCoef;
        }
        #endregion

        #region Substring : 文字の取り出し
        /// -----------------------------------------------------------------------------------
        /// <summary>
        ///     文字列の左端から指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iLength">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     左端から指定された文字数分の文字列。
        ///     文字数を超えた場合は、文字列全体が返されます。</returns>
        /// -----------------------------------------------------------------------------------
        public string Left(string stTarget, int iLength)
        {
            if (iLength <= stTarget.Length)
            {
                return stTarget.Substring(0, iLength);
            }

            return stTarget;
        }

        /// <summary>
        ///     文字列の右端から指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iLength">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     右端から指定された文字数分の文字列。
        ///     文字数を超えた場合は、文字列全体が返されます。</returns>
        public string Right(string stTarget, int iLength)
        {
            if (iLength <= stTarget.Length)
            {
                return stTarget.Substring(stTarget.Length - iLength);
            }
            return stTarget;
        }

        /// <summary>
        ///     文字列の指定された位置から、指定された文字数分の文字列を返します。</summary>
        /// <param name="stTarget">
        ///     取り出す元になる文字列。</param>
        /// <param name="iStart">
        ///     取り出しを開始する位置。</param>
        /// <param name="iLength">
        ///     取り出す文字数。</param>
        /// <returns>
        ///     指定された位置から指定された文字数分の文字列。
        ///     文字数を超えた場合は、指定された位置からすべての文字列が返されます。</returns>
        public string Mid(string stTarget, int iStart, int iLength)
        {
            if (iStart <= stTarget.Length)
            {
                if (iStart + iLength - 1 <= stTarget.Length)
                {
                    return stTarget.Substring(iStart - 1, iLength);
                }

                return stTarget.Substring(iStart - 1);
            }

            return string.Empty;
        }
        #endregion

        #region 　VariousChange :  変換関数
        /// <summary>
        /// BOOL値型の数値[Int]への変換
        /// </summary>
        /// <param name="blValue"></param>
        /// <returns></returns>
        public int BoolToInt(bool blValue)
        {
            if (blValue)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// BOOL文字列の数値[Int]への変換
        /// </summary>
        /// <param name="blValue"></param>
        /// <returns></returns>
        public int BoolToInt(string strValue)
        {
            bool blValue = true;

            if (strValue != "true" && strValue != "false")
                return 0;
            else
                blValue = bool.Parse(strValue);

            if (blValue)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// 数値[Int]のBOOL値型への変換
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        public bool IntToBool(int intValue)
        {
            if (intValue == 0)
                return false;
            else
                return true;

        }

        /// <summary>
        /// 文字列の数値[int]への変換
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public int StringToInt(string strValue)
        {
            int rtnValue = 0;

            if (string.IsNullOrEmpty(strValue))
            {
            }
            else
            {
                if (IsNumeric(strValue))
                {
                    //| 数値の時のみReturn
                    //rtnValue = int.Parse(strValue)
                    //rtnValue = int.Parse(strValue, System.Globalization.NumberStyles.Any, null);   //Upd 2009/04/27 T.matsuno
                    rtnValue = int.Parse(strValue, System.Globalization.NumberStyles.Any, new CultureInfo("en-us"));    //UPD 2014/9/5 null→new CultureInfo("en-us")
                }
                else
                {
                    //| 数値の時以外の時はとりあえず0をReturn　：　保留
                }
            }
            return rtnValue;
        }

        /// <summary>
        /// 文字列の数値[int]への変換
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public double StringToDouble(string strValue)
        {
            double rtnValue = 0;

            if (string.IsNullOrEmpty(strValue))
            {
            }
            else
            {
                if (IsNumeric(strValue))
                {
                    //| 数値の時のみReturn
                    //rtnValue = double.Parse(strValue);
                    //rtnValue = double.Parse(strValue, System.Globalization.NumberStyles.Any, null);    //Upd 2009/04/27 T.matsuno
                    rtnValue = double.Parse(strValue, System.Globalization.NumberStyles.Any, new CultureInfo("en-us")); //UPD 2014/9/5 null→new CultureInfo("en-us")
                }
                else
                {
                    //| 数値の時以外の時はとりあえず0をReturn　：　保留
                }
            }
            return rtnValue;
        }

        /// <summary>
        /// 文字列[日付フォーマット]を数値[int]への変換
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public int DateFormatToInt(string strValue, string p_DateFormat)
        {
            int rtnValue = 0;
            if (string.IsNullOrEmpty(strValue))
            {
            }
            else
            {
                try
                {
                    p_DateFormat = CheckDateFormat(p_DateFormat);
                    DateTime txtDate = DateTime.ParseExact(strValue, p_DateFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo);
                    rtnValue = txtDate.Year * 10000 + txtDate.Month * 100 + txtDate.Day;
                }
                catch
                {
                    string strTemp = strValue.Replace("/", "").Replace("-", "");//ADD Replace("-","") by UBIQ-LIU 2009/12/09
                    if (!int.TryParse(strTemp, out rtnValue))
                    {
                        rtnValue = 0;
                    }
                }
            }
            return rtnValue;
        }

        /// <summary>
        /// 数値[int]を文字列[日付フォーマット]への変換
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public string IntToDateFormat(int strValue, string p_DateFormat)
        {
            string rtnValue = strValue.ToString();
            try
            {
                double yyyy = ToRoundDown(strValue / 10000, 0);
                double mm = ToRoundDown((strValue % 10000) / 100, 0);
                double dd = ToRoundDown(strValue % 100, 0);
                DateTime dt = new DateTime((int)yyyy, (int)mm, (int)dd);
                rtnValue = DateFormat(dt, p_DateFormat);
            }
            catch
            {
                //変換エラーの場合
                if (strValue == 0 || strValue == 99999999)
                {
                    string strFormat = p_DateFormat.ToUpper().Replace('Y', '0').Replace('M', '0').Replace('D', '0');
                    rtnValue = strValue.ToString(strFormat);
                }
            }

            return rtnValue;
        }

        /// <summary>
        /// 日付型を文字列[日付フォーマット]に変換
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string DateFormat(DateTime dt, string p_DateFormat)
        {
            try
            {
                p_DateFormat = CheckDateFormat(p_DateFormat);

                return dt.ToString(p_DateFormat, DateTimeFormatInfo.InvariantInfo);//DataFoemat Change 2008.3.6 
            }
            catch
            {
                //変換エラーの場合はとりあえずShortDateStringを返す
                return dt.ToShortDateString();
            }
        }
        public string CheckDateFormat(string p_DateFormat)
        {
            string rtnFormat = "";
            for (int i = 0; i < p_DateFormat.Length; i++)
            {
                string w = p_DateFormat.Substring(i, 1);
                switch (w)
                {
                    case "Y": w = w.ToLower(); break;
                    case "m": w = w.ToUpper(); break;
                    case "D": w = w.ToLower(); break;

                }
                rtnFormat += w;
            }
            return rtnFormat;
        }

        /// <summary>
        /// クライアントユニークIDを取得
        /// 
        /// クライアント側(JavaScript)にて使用するためのID
        /// ：ContentPlaceHolder内のコントロールIDは
        /// 　実行されるとJavaScriptで処理する際に通常のIDではなくなる為、
        /// 　クライアント側でのユニークIDを取得する。
        /// 
        /// 2007/03/13 : 未使用？
        /// </summary>
        /// <param name="p_UniqueId"></param>
        /// <returns></returns>
        public string GetClientUniqueID(string p_UniqueId)
        {
            string uniq = null;
            try
            {
                uniq = (p_UniqueId.Replace("$", "_"));
            }
            catch
            {
                uniq = p_UniqueId;
            }
            return uniq;
        }

        #endregion

        #region 　Validation :  検証
        /// <summary>
        ///     文字列が数値であるかどうかを返します。</summary>
        /// <param name="stTarget">
        ///     検査対象となる文字列。<param>
        /// <returns>
        ///     指定した文字列が数値であれば true。それ以外は false。</returns>
        public bool IsNumeric(string stTarget)
        {
            double dNullable;

            return double.TryParse(
                stTarget,
                System.Globalization.NumberStyles.Any,
                new CultureInfo("en-us"),       //UPD 2014/9/5 null→new CultureInfo("en-us")
                out dNullable
            );
        }
        /// <summary>
        ///     オブジェクトが数値であるかどうかを返します。</summary>
        /// <param name="oTarget">
        ///     検査対象となるオブジェクト。<param>
        /// <returns>
        ///     指定したオブジェクトが数値であれば true。それ以外は false。</returns>
        public bool IsNumeric(object oTarget)
        {
            //UPD 2014/9/5 -----> ピリオドがカンマの国がある
            if (oTarget == null) return false;
            if (oTarget.GetType() == typeof(decimal) || oTarget.GetType() == typeof(double))
                return IsNumeric(oTarget.ToString().Replace(',', '.'));
            else
                return IsNumeric(oTarget.ToString());
            //return IsNumeric(oTarget.ToString());
            //UPD 2014/9/5 <-----
        }
        #endregion

        #region : SetInitialFocus
        /// <summary>
        /// Set the InitialFocus to the given control. Only works when JavaScript is supported.
        /// </summary>
        /// <param name="control">Control to set the InitialFocus on.</param>
        public void SetInitialFocus(Control control)
        {
            if (control.Page == null)
            {
                throw new ArgumentException(
                    "The Control must be added to a Page before you can set the IntialFocus to it.");
            }
            if (control.Page.Request.Browser.JavaScript == true)
            {
                // Create JavaScript
                StringBuilder s = new StringBuilder();
                s.Append("\n<SCRIPT LANGUAGE='JavaScript'>\n");
                s.Append("<!--\n");
                s.Append("function SetInitialFocus()\n");
                s.Append("{\n");




                // Find the Form
                Control p = control.Parent;
                while (!(p is System.Web.UI.HtmlControls.HtmlForm))
                    p = p.Parent;

                string buf = p.ClientID;


                s.Append("  if (!document.");
                s.Append(buf);
                s.Append("['");
                s.Append(control.UniqueID);
                s.Append("'])\n");
                s.Append("	return;\n");

                s.Append("   document.");
                s.Append(buf);

                s.Append("['");
                s.Append(control.UniqueID);
                s.Append("'].focus();\n");

                s.Append("   if (document.");
                s.Append(buf);
                s.Append("['");
                s.Append(control.UniqueID);
                s.Append("'].tagName != 'SELECT') \n");

                s.Append("   document.");
                s.Append(buf);
                s.Append("['");
                s.Append(control.UniqueID);
                s.Append("'].select();\n");

                s.Append("}\n");
                s.Append("// -->\n");

                s.Append("window.onload = SetInitialFocus;\n");
                s.Append("</SCRIPT>");

                // Register Client Script
                control.Page.RegisterClientScriptBlock("InitialFocus", s.ToString());
            }
        }
        #endregion

        //------------------------------------------------------------------------
        // Grid Layout Panel の子部品の属性を以下の Mode により属性を設定
        //
        //		Mode)  0:照会  1:訂正
        //------------------------------------------------------------------------
        public void Set_Attributes(System.Web.UI.HtmlControls.HtmlContainerControl divC, int Mode)
        {
            string strCss = "";

            for (int i = 0; i < divC.Controls.Count; i++)
            {
                switch (divC.Controls[i].GetType().Name)
                {
                    case "Label":
                        if (((Label)divC.Controls[i]).CssClass != "fd_mtitle" && ((Label)divC.Controls[i]).CssClass != "fi_mtitle")
                        {
                            if (Mode == 1)
                            {
                                if (((Label)divC.Controls[i]).CssClass == "d_mtitle")
                                    ((Label)divC.Controls[i]).CssClass = "i_mtitle";
                                else if (((Label)divC.Controls[i]).CssClass == "d_mtitle_c")
                                    ((Label)divC.Controls[i]).CssClass = "i_mtitle_c";
                            }
                            else
                            {
                                if (((Label)divC.Controls[i]).CssClass == "i_mtitle")
                                    ((Label)divC.Controls[i]).CssClass = "d_mtitle";
                                else if (((Label)divC.Controls[i]).CssClass == "i_mtitle_c")
                                    ((Label)divC.Controls[i]).CssClass = "d_mtitle_c";
                            }
                        }
                        break;

                    case "TextBox":
                    case "NumberBox":
                        strCss = ((TextBox)divC.Controls[i]).CssClass;
                        if (Mode == 1)
                        {
                            if (((TextBox)divC.Controls[i]).CssClass != "d_label")
                            {
                                ((TextBox)divC.Controls[i]).ReadOnly = false;
                            }
                            if (divC.Controls[i].GetType().Name == "NumberBox")
                            {
                                strCss = "text_input_right_key";
                            }
                            else
                            {
                                switch (((TextBox)divC.Controls[i]).CssClass)
                                {
                                    case "text_disp_right": strCss = "text_input_right"; break;
                                    case "text_disp_center": strCss = "text_input_center"; break;
                                    case "text_disp_left": strCss = "text_input_left"; break;
                                    case "text_disp_right_key": strCss = "text_input_right_key"; break;
                                    case "text_disp_center_key": strCss = "text_input_center_key"; break;
                                    case "text_disp_left_key": strCss = "text_input_left_key"; break;
                                }
                            }
                        }
                        else
                        {
                            ((TextBox)divC.Controls[i]).ReadOnly = true;
                            if (divC.Controls[i].GetType().Name == "NumberBox")
                            {
                                strCss = "text_disp_right_key";
                            }
                            else
                            {
                                switch (((TextBox)divC.Controls[i]).CssClass)
                                {
                                    case "text_input_right": strCss = "text_disp_right"; break;
                                    case "text_input_center": strCss = "text_disp_center"; break;
                                    case "text_input_left": strCss = "text_disp_left"; break;
                                    case "text_input_right_key": strCss = "text_disp_right_key"; break;
                                    case "text_input_center_key": strCss = "text_disp_center_key"; break;
                                    case "text_input_left_key": strCss = "text_disp_left_key"; break;
                                }
                            }
                        }



                        ((TextBox)divC.Controls[i]).CssClass = strCss;
                        break;
                    /**
                                        case "NumberBox" :
                                            if (Mode == 1 || Mode == 0 || Mode == 4 ) {
                                                ((TextBox)divC.Controls[i]).ReadOnly = false;
                                                ((TextBox)divC.Controls[i]).ForeColor = Color.Black;
                                            }
                                            else {
                                                ((TextBox)divC.Controls[i]).ReadOnly = true;
                                                ((TextBox)divC.Controls[i]).ForeColor = Color.Gray;
                                            }							
                                            break;
                    **/
                    case "DropDownList":
                        if (Mode == 1)
                            ((DropDownList)divC.Controls[i]).Enabled = true;
                        else
                            ((DropDownList)divC.Controls[i]).Enabled = false;
                        break;

                    case "CheckBox":
                        if (Mode == 1)
                            ((CheckBox)divC.Controls[i]).Enabled = true;
                        else
                            ((CheckBox)divC.Controls[i]).Enabled = false;
                        break;
                    case "RadioButtonList":
                        if (Mode == 1)
                            ((RadioButtonList)divC.Controls[i]).Enabled = true;
                        else
                            ((RadioButtonList)divC.Controls[i]).Enabled = false;
						break;
					case "CheckBoxList":
						//ADD BY UBIQ-LIU 2015/06/09
						if (Mode == 1)
							((CheckBoxList)divC.Controls[i]).Enabled = true;
						else
							((CheckBoxList)divC.Controls[i]).Enabled = false;
						break;
					case "Panel":
						//ADD BY UBIQ-LIU 2015/06/09
						if (Mode == 1)
							((Panel)divC.Controls[i]).Enabled = true;
						else
							((Panel)divC.Controls[i]).Enabled = false;
						break;

                }
            }
        }

        public string DateFormat(string p, string p_2)
        {
            throw new NotImplementedException();
        }

        //ADD BY UBIQ-LIU 2010/8/24
        #region # javascript 文字変換 #
        /// <summary>
        /// シンボルを使う場合、変換した文字列を戻り
        /// </summary>
        /// <param name="instr">コード、名称</param>
        /// <returns>変換した文字列</returns>
        public string SetJsStr(string instr)
        {
            return instr.Replace("'", "\\'");//コード、名称に「'」を使う場合、「\\'」の変換
        }
        #endregion

        #region # CSV 文字変換 #
        /// <summary>
        /// 「,」を使う場合、変換した文字列を戻り
        /// </summary>
        /// <param name="instr">原文字</param>
        /// <returns>変換した文字列(含「,」)</returns>
        public string SetCsvStr(string instr)
        {
            //原文字に「,」を使った場合
            if (instr.IndexOf(",") != -1)
            {
                return "\"" + instr + "\"" + Getcharacter();
            }
            else//その他場合
            {
                return "=\"" + instr + "\"" + Getcharacter();
            }
        }
        #endregion

        //add by ubiq-suo 2010/10/21 start
        #region # 区切り文字 #
        public string Getcharacter()
        {
            return "\t";
        }
        #endregion
        //add by ubiq-suo 2010/10/21 end
        #region # XML 文字変換 #
        /// <summary>
        /// XML禁則文字の変換した文字列を戻り
        /// </summary>
        /// <param name="instr">原文字</param>
        /// <returns>変換した文字列(含「,」)</returns>
        public string XMLString(string instr)
        {
            return instr.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }
        #endregion

        //Add 2015.07.06 Ubiq-Sai Begin
        public string GetSelectFilterString(string filterString)
        {
            string text = string.Empty;
            foreach (char c in filterString)
            {
                switch (c)
                {
                    case '*':
                    case '%':
                    case '[':
                    case ']':
                        text += "[" + c + "]";
                        break;
                    default:
                        text += c;
                        break;
                }
            }
            return text;
        }
        //Add 2015.07.06 Ubiq-Sai End
        /// <summary>
        /// 設置NumberBox小数桁。
        /// </summary>
        /// <his>ADD BY UBIQ-LIU 2016-6-22</his>
        /// <param name="nbox">NumberBoxコントロール</param>
        /// <param name="decemailPlace">小数桁</param>
        public void SetNumberBoxDecmial(PMClass.CustomControls.NumberBox nbox, int decemailPlace)
        {
            nbox.Attributes["onkeypress"] = "NumberBoxKeyPress(event, " + decemailPlace + ", 46, true, " + nbox.MaxLength + ");";
            nbox.Attributes["onkeyup"] = "NumberBoxKeyUp(event, " + decemailPlace + ", 46, true, " + nbox.MaxLength + ");";
            nbox.DecimalPlaces = decemailPlace;
            if (nbox.Text == "")
            {
                nbox.Value = Math.Round(0.0, decemailPlace);
            }
            else
            {
                nbox.Value = Math.Round(nbox.Value, decemailPlace);
            }
        }
        /// <summary>
        /// 单价&金額の小数桁を設定する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decemailPlace"></param>
        /// <returns></returns>
        public string GetNumberDecemal(decimal value, int decemailPlace)
        {
            return Math.Round(value, decemailPlace).ToString("N" + decemailPlace.ToString());
        }

        #region : QRコードを生成する //20161212 UBIQ_SH ADD
        /// <summary>
        /// QRコードを生成する。
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        public byte[] BuildQRCode(string QRcode)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //ALPHA_NUMERIC,BYTE,NUMERIC
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //QRCode大小（増幅の割合）x N
            qrCodeEncoder.QRCodeScale = 2;
            //文字の容量[0-40] 0：自動
            qrCodeEncoder.QRCodeVersion = 0;
            //QRコード密度 L/M/Q/H(小→大)
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;

            Bitmap image = qrCodeEncoder.Encode(QRcode);

            return ImageToBytes(image);
        }
        /// <summary>
        /// Convert Image to Byte[]
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Bitmap image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                switch (format.ToString())
                {
                    case "ImageFormat.Jpeg":
                        image.Save(ms, ImageFormat.Jpeg);
                        break;
                    case "ImageFormat.Png":
                        image.Save(ms, ImageFormat.Png);
                        break;
                    case "ImageFormat.Bmp":
                        image.Save(ms, ImageFormat.Bmp);
                        break;
                    case "ImageFormat.Gif":
                        image.Save(ms, ImageFormat.Gif);
                        break;
                    case "ImageFormat.Icon":
                        image.Save(ms, ImageFormat.Icon);
                        break;
                    default:
                        image.Save(ms, ImageFormat.Jpeg);
                        break;
                }
                byte[] buffer = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        #endregion

    }
}