using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace PMClass.CustomControls
{
    
	/// <summary>
	/// Number Box ASP.NET control
	/// 
	/// Created by Fons Sonnemans, Reflection IT
	///
	/// Be sure to notice that this code is provided as a technology sample 
	/// and 'as is', no warranties are made by the author.
	///
	/// For questions and comments: Fons.Sonnemans@reflectionit.nl
	///
	/// </summary>
	[
	ToolboxData("<{0}:NumberBox runat=server></{0}:NumberBox>"),
	DefaultProperty("DecimalPlaces"),
	]
	public class NumberBox : TextBox
	{
		private int mDecimalPlaces = 0;
        private char mDecimalSymbol = '.';
        private bool mAllowNegatives = true;
        ////private string mText = "0";
        private double mBefor_Value = 0;
        private bool mEditComma = true;

        /// <summary>
        /// Gets or sets the number of befor_value for the number box.
        /// </summary>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(0),
        Description("Indicates the number of befor_value places to display.")
        ]
        public virtual double Befor_Value
        {
            get { return mBefor_Value; }
            set { mBefor_Value = value; }
        }

		/// <summary>
		/// Gets or sets the number of decimals for the number box.
		/// </summary>
		[
		Bindable(true),
		Category("Appearance"),
		DefaultValue(0),
		Description("Indicates the number of decimal places to display.")
		]
		public virtual int DecimalPlaces
		{
			get { return mDecimalPlaces; }
			set { mDecimalPlaces = value; }
		}

		/// <summary>
		/// Gets or sets the digit grouping symbol for the number box.
		/// </summary>
		[
		Bindable(true),
		Category("Appearance"),
		DefaultValue("."),
		Description("The digit grouping symbol.")
		]
		public virtual char DecimalSymbol
		{
			get { return mDecimalSymbol; }
			set { mDecimalSymbol = value; }
		}

		/// <summary>
		/// Gets or sets wheter negative numbers are allowed in the number box.
		/// </summary>
		[
		Bindable(true),
		Category("Appearance"),
		DefaultValue(true),
		Description("True when negative values are allowed")
		]
		public virtual bool AllowNegatives
		{
			get { return mAllowNegatives; }
			set { mAllowNegatives = value; }
		}

        /// <summary>
        /// Number Formatstring
        /// </summary>
        [
        Bindable(true),
        Category("Appearance"),
        DefaultValue(true),
        Description("Set Number Formatstring")
        ]
        public virtual bool EditComma
        {
            get { return mEditComma; }
            set { mEditComma = value; }
        }

		/// <summary>
		/// Gets or sets the value of the number box.
		/// </summary>
		public virtual double Value
		{
			get
			{
				try 
				{
                    //return ParseStringToDouble(this.mText);
                    return ParseStringToDouble(this.Text);
				}
                catch (FormatException e)
                {
                    string m = e.Message;
					throw new
                        InvalidOperationException("NumberBox does not contain a valid Number.");
				} 
				catch (Exception e) 
				{
					throw e;
				}
			
			}
			set
			{
				if ((value < 0) & !AllowNegatives) 
					throw new
                        ArgumentOutOfRangeException("Only positive values are allowed for this NumberBox.");
				
					//base.Text = value.ToString(this.Format);
					//base.Text = value.ToString(GetFormat()).Replace(".", DecimalSymbol.ToString());
                    //mText = value.ToString(GetFormat()).Replace(".", DecimalSymbol.ToString());
                    base.Text = value.ToString(GetFormat()).Replace(".", DecimalSymbol.ToString());
			}
		}

		/// <summary>
		/// Gets or sets the text content of the number box.
		/// </summary>
		[
		Bindable(true),
		Category("Appearance"),
		DefaultValue(0),
		Description("Indicates the number of decimal places to display.")
		]
		override public string Text
		{
            get
            {
                return base.Text;
            }
            set
            {
                try
                {
                    double intWork = 0;
                    try
                    {
                        intWork = ParseStringToDouble(value);
                    }
                    catch{}
                    this.Value = intWork;
                }
                catch (FormatException e)
                {
                    string m = e.Message;
                    base.Text = value;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            //get {
            //    return mText;
            //}
            //set {
            //    try {
            //        this.Value = ParseStringToDouble(value);
            //    } 
            //    catch (FormatException e) {
            //        mText = value;
            //    } 
            //    catch (Exception e) {
            //        throw e;
            //    }
            //}
		}
		
		
		/// <summary>
		///	Add a JavaScript to the Page and call it from the onKeyPress event
		/// </summary>
		/// <param name="e"></param>
		
		override protected void OnPreRender(EventArgs e) 
		{
			this.Style.Add("text-align","right");
            
			if (this.Page.Request.Browser.EcmaScriptVersion.Major >= 1) 
			{
                //
                // JavaScriptを追加
                //

                //| Style設定[onload]
                StringBuilder sb = new StringBuilder();
                sb.Append("\n<script type='text/javascript' language = 'JavaScript' onload>\n");
                sb.Append("<!--\n");
                sb.Append("    function NumberBoxStyle() {\n");
                sb.Append("	     text-align = right;\n");
                sb.Append("       return true;\n");
                sb.Append("    }\n");
                sb.Append("// -->\n");
                sb.Append("</script>\n");

                //| ImeMode-off設定
				StringBuilder sb2 = new StringBuilder();
				sb2.Append("\n<script type = 'text/javascript' language = 'JavaScript' >\n");
				sb2.Append("<!--\n");
				sb2.Append("    function NumberBoxGotFocus(o) {\n");
                sb2.Append("	     o.style.imeMode = \"disabled\";\n");
                sb2.Append("	     o.value = o.value.split(\",\").join(\"\");\n");        //Add 2009/04/27 T.matsuno
                //Add 2009/05/19 T.matsuno
                sb2.Append("	     o.focus();\n");
                sb2.Append("	     if (o.createTextRange) {\n");
                sb2.Append("	        var range = o.createTextRange();\n");
                sb2.Append("	        range.move('character', o.value.length);\n");
                sb2.Append("	        o.select();\n");
                sb2.Append("	     } else if (o.setSelectionRange) {\n");
                sb2.Append("	     o.setSelectionRange(o.value.length, o.value.length);\n");
                sb2.Append("	     }\n");
                //End Add
				sb2.Append("       return true;\n");
				sb2.Append("    }\n");
				sb2.Append("// -->\n");
				sb2.Append("</script>\n");
				//		object.style.imeMode [ = sMode ]

                //| KeyPressイベント設定	
				StringBuilder sb3 = new StringBuilder();
				sb3.Append("\n<script type='text/javascript' language='JavaScript'>\n");
				sb3.Append("<!--\n");
                sb3.Append("    function NumberBoxKeyUp(event, decimalPlace, decimalChar, negative, maxLength) {\n");
                sb3.Append("	   var myString = new String(event.srcElement.value);\n");
                sb3.Append("	   var Befor_Value = new String(event.srcElement.Befor_Value);\n");
                sb3.Append("	   var pntPos = myString.indexOf(String.fromCharCode(decimalChar));\n");
				sb3.Append("	   var keyChar = window.event.keyCode;\n");

                //sb3.Append("            alert('event3.Befor_Value=' + Befor_Value);");

                ////--キャラクターコードチェック
                //sb3.Append("       if ((keyChar < 48) || (keyChar > 57)) {\n");  //--数値以外
                //sb3.Append("           if (keyChar == decimalChar) {\n");                  //--小数点文字
                //sb3.Append("              if ( (pntPos != -1) || (decimalPlace < 1) ) {\n"); //--小数点文字が既にある、又は、小数点以下０桁の場合
                //sb3.Append("                  event.returnValue = false; ");     //→何もしない(Eventを起こさない)
                //sb3.Append("                  return false;\n");                 
                //sb3.Append("              }\n");
                //sb3.Append("           } else {\n");
                ////sb3.Append("if (((keyChar == 45) && (!n || myString.length != 0)) || (keyChar != 45)) \n");
                //sb3.Append("              if ((keyChar == 45 && !negative) || (keyChar != 45)){ \n");   //--マイナス文字でマイナス不可、又は、マイナス文字以外
                //sb3.Append("                   event.returnValue = false; ");
                //sb3.Append("		           return false;\n");                              //→何もしない(Eventを起こさない)
                //sb3.Append("              }\n ");
                //sb3.Append("           }\n ");
                //sb3.Append("       }\n");

                //--最大桁数チェック
                sb3.Append("       var myInt = myString; \n");
                sb3.Append("       var myDecimal = ''; \n" );                
                sb3.Append("       var decCheck = false; ");

                sb3.Append("       if (pntPos != -1){ \n");
                sb3.Append("           myInt = myString.substring(0, pntPos); \n");
                sb3.Append("           myDecimal = myString.substring(pntPos+1, myString.length); \n");
                sb3.Append("           if (myDecimal.length >= decimalPlace){ \n");
                sb3.Append("               decCheck = true;\n");
                sb3.Append("           } \n");
                sb3.Append("       } \n");

                sb3.Append("       var myLength = myInt.length + myDecimal.length; \n");
                sb3.Append("       if (myLength > maxLength) {\n");
                //sb3.Append("            alert('event3.maxLength_Err');");
                sb3.Append("           event.srcElement.value = Befor_Value;\n"); //→元のデータセット
                sb3.Append("           event.returnValue = true; ");  //→何もしない(Eventを起こさない)
                //sb3.Append("	       return false;\n");
                sb3.Append("       }\n");

//Add 20081224 
                //--整数部チェック(整数部が制限桁-指数部桁を超えたら入力を行わせない)
                sb3.Append("       if (pntPos != -1){ \n");
                sb3.Append("           myInt = myString.substring(0, pntPos); \n");
                sb3.Append("       } else { \n");
                sb3.Append("           myInt = myString; \n");
                sb3.Append("       } \n");

                //sb3.Append("            alert('event.myInt=' + myInt);");
                //sb3.Append("            alert('event.maxLength=' + maxLength);");
                //sb3.Append("            alert('event.decimalPlace=' + decimalPlace);");

                sb3.Append("       var myLength = maxLength - decimalPlace; \n");
                sb3.Append("       if (decimalPlace > 0){ \n");
                sb3.Append("           myLength = myLength - 1; \n");
                sb3.Append("       } \n");

                //sb3.Append("            alert('event.myLength=' + myLength);");
                //sb3.Append("            alert('event.myInt.length=' + myInt.length);");
                sb3.Append("       if (myLength < myInt.length) {\n");
                //sb3.Append("            alert('event3.myIntLength_Err');");
                sb3.Append("           event.srcElement.value = Befor_Value;\n"); //→元のデータセット
                sb3.Append("           event.returnValue = true; ");  //→何もしない(Eventを起こさない)
                //sb3.Append("	       return false;\n");
                sb3.Append("       }\n");
//End Add

//Add 20070516 T.Sawada
                //--指数部チェック(指数部が制限桁を超えたら入力を行わせない)
                sb3.Append("       if (pntPos != -1){ \n");
                sb3.Append("           myDecimal = myString.substring(pntPos+1,myString.length); \n");
                sb3.Append("           if (myDecimal.length > decimalPlace){ \n");
                //sb3.Append("                alert('event3.decimalPlace_Err');");
                sb3.Append("               event.srcElement.value = Befor_Value;\n"); //→元のデータセット
                sb3.Append("               event.returnValue = true; ");  //→何もしない(Eventを起こさない)
                //sb3.Append("	           return false;\n");
                sb3.Append("           } \n");
                sb3.Append("       } \n");
//End Add
                
                //-- 現在入力された文字がテキストのどの位置かとれないので
                //-- エラーにできない→あとで検討
                //sb3.Append("       if (pntPos != -1 && decCheck){ \n");
                //sb3.Append("            alert('event.offsetX=' + event.offsetX);");
                //sb3.Append("            alert('Position.realOffset(event.srcElement)=' + Position.realOffset(event.srcElement));");
                //sb3.Append("       } \n");
				sb3.Append("       return true;\n"); //→イベント許可
				sb3.Append("    }\n");
				sb3.Append("// -->\n");
				sb3.Append("</script>\n");

                ////| OnChangeイベント設定	
                //StringBuilder sb4 = new StringBuilder();
                //sb4.Append("\n<script type='text/javascript' language='JavaScript'>\n");
                //sb4.Append("<!--\n");
                //sb4.Append("    function NumberBoxOnChange(){\n");
                //// This final check occurs when then leave the textbox, it ensures that it is an integer
                //sb4.Append("        if (isNaN(parseInt(window.event.srcElement.value))) {\n");
                //sb4.Append("            window.event.srcElement.value = '';\n");
                //sb4.Append("        } else {\n");
                //sb4.Append("            window.event.srcElement.value = parseInt(window.event.srcElement.value);\n");
                //sb4.Append("        }\n");
                //sb4.Append("    }\n");
                //sb4.Append("// -->\n");
                //sb4.Append("</script>\n");

                //| KeyPressイベント設定	
                StringBuilder sb5 = new StringBuilder();
                sb5.Append("\n<script type='text/javascript' language='JavaScript'>\n");
                sb5.Append("<!--\n");
                sb5.Append("    function NumberBoxKeyPress(event, decimalPlace, decimalChar, negative, maxLength) {\n");
                sb5.Append("	   var myString = new String(event.srcElement.value);\n");
                sb5.Append("	   var pntPos = myString.indexOf(String.fromCharCode(decimalChar));\n");
                sb5.Append("	   var keyChar = window.event.keyCode;\n");

                //sb5.Append("            alert('event5.myString=' + myString);");

                //--キャラクターコードチェック
                sb5.Append("       if ((keyChar < 48) || (keyChar > 57)) {\n");  //--数値以外
                //sb5.Append("   alert('event5.keyChar=' + keyChar);");
                //sb5.Append("   alert('event5.decimalChar=' + decimalChar);");
                //sb5.Append("   alert('event5.pntPos=' + pntPos);");
                sb5.Append("           if (keyChar == decimalChar) {\n");                  //--小数点文字
                sb5.Append("              if ( (pntPos != -1) || (decimalPlace < 1) ) {\n"); //--小数点文字が既にある、又は、小数点以下０桁の場合
                //sb5.Append("   alert('event5.decimalChar=' + decimalChar);");
                //sb5.Append("   alert('event5.keyChar=' + keyChar);");
                //sb5.Append("   alert('event5.keyChar_Err=');");
                sb5.Append("                  event.returnValue = false; ");     //→何もしない(Eventを起こさない)
                sb5.Append("                  return false;\n");
                sb5.Append("              }\n");
                sb5.Append("           } else {\n");
                sb5.Append("              if ((keyChar == 45 && !negative) || (keyChar != 45)){ \n");   //--マイナス文字でマイナス不可、又は、マイナス文字以外
                //sb5.Append("   alert('event5.negative=' + negative);");
                //sb5.Append("   alert('event5.keyChar=' + keyChar);");
                //sb5.Append("   alert('event5.keyChar_Err=');");
                sb5.Append("                   event.returnValue = false; ");
                sb5.Append("		           return false;\n");                              //→何もしない(Eventを起こさない)
                sb5.Append("              }\n ");
                sb5.Append("           }\n ");
                sb5.Append("       }\n");

                sb5.Append("       event.srcElement.Befor_Value = event.srcElement.value;\n"); //→イベント許可

                sb5.Append("       return true;\n"); //→イベント許可
                sb5.Append("    }\n");
                sb5.Append("// -->\n");
                sb5.Append("</script>\n");

//Add 2009/04/27 matsuno
                //| LostFocusイベント設定
                StringBuilder sb6 = new StringBuilder();
                sb6.Append("\n<script type = 'text/javascript' language = 'JavaScript' >\n");
                sb6.Append("<!--\n");
                sb6.Append("    function NumberBoxLostFocus(o, editComma) {\n");
                sb6.Append("	   if (editComma == false) return true;\n");
                sb6.Append("	   var myString = new String(o.value);\n");
                sb6.Append("	   var i;\n");
                sb6.Append("	   for(i = 0; i < myString.length/3; i++){\n");
                sb6.Append("	        myString = myString.replace(/^([+-]?\\d+)(\\d\\d\\d)/,\"$1,$2\");\n");
                sb6.Append("	   }\n");
                sb6.Append("	   o.value = myString;\n");
                sb6.Append("       return true;\n");
                sb6.Append("    }\n");
                sb6.Append("// -->\n");
                sb6.Append("</script>\n");
//End Add

                // スクリプトをページに追加
                Type cstype = this.GetType();
                this.Page.ClientScript.RegisterClientScriptBlock(cstype, "NumberBoxKeyGotFocus", sb2.ToString());
                this.Page.ClientScript.RegisterClientScriptBlock(cstype, "NumberBoxKeyUp", sb3.ToString());
                this.Page.ClientScript.RegisterClientScriptBlock(cstype, "NumberBoxKeyPress", sb5.ToString());
                this.Page.ClientScript.RegisterClientScriptBlock(cstype, "NumberBoxLostFocus", sb6.ToString());     //Add 2009/04/27 T.matsuno
                //this.Page.ClientScript.RegisterClientScriptBlock(cstype, "NumberBoxOnChange", sb4.ToString());

				// イベントを追加
                //Add 2009/05/27 T.matsuno
                string _onKeyUp = "";
                string _onKeyPress = "";
                string _onFocus = "";
                string _onBlure = "";
                //End Add
				try 
				{
                    //Add 2009/05/27 T.matsuno
                    if (this.Attributes["onKeyUp"] != null) _onKeyUp = this.Attributes["onKeyUp"];
                    if (this.Attributes["onKeyPress"] != null) _onKeyPress = this.Attributes["onKeyPress"];
                    if (this.Attributes["onFocus"] != null) _onFocus = this.Attributes["onFocus"];
                    if (this.Attributes["onBlur"] != null) _onBlure = this.Attributes["onBlur"];
                    //End Add    
                    this.Attributes.Remove("onKeyUp");
                    this.Attributes.Remove("onKeyPress");
                    this.Attributes.Remove("onFocus");
                    this.Attributes.Remove("onBlur");   //Add 2009/04/27 T.matsuno
                    //this.Attributes.Remove("onChange");   //onChangeは他で使ってるので使用不可
				} 
				finally 
				{
                    if (MaxLength == 0) MaxLength = 50;
//Del 2009/05/27 T.matsuno
                    //this.Attributes.Add("onKeyUp", "return NumberBoxKeyUp(event, "
                    //    + mDecimalPlaces.ToString() + ", "
                    //    + ((int)mDecimalSymbol).ToString() + ", "
                    //    + mAllowNegatives.ToString().ToLower() + ", "
                    //    + MaxLength.ToString() + ");");
                    //this.Attributes.Add("onKeyPress", "return NumberBoxKeyPress(event, " 
                    //    + mDecimalPlaces.ToString() + ", "
                    //    + ((int)mDecimalSymbol).ToString() + ", "
                    //    + mAllowNegatives.ToString().ToLower() + ", " 
                    //    + MaxLength.ToString() + ");");
                    //this.Attributes.Add("onFocus", "return NumberBoxGotFocus(this)");
                    ////this.Attributes.Add("onChange", "return NumberBoxOnChange()");   //onChangeは他で使ってるので使用不可
                    ////Add 2009/04/27 T.matsuno
                    //this.Attributes.Add("onBlur", "return NumberBoxLostFocus(this, "
                    //    + EditComma.ToString().ToLower() + ");");
                    ////End Add                     
//End Del
//Upd 2009/04/27 T.matsuno
                    string evtKeyUp = "return NumberBoxKeyUp(event, "
                        + mDecimalPlaces.ToString() + ", "
                        + ((int)mDecimalSymbol).ToString() + ", "
                        + mAllowNegatives.ToString().ToLower() + ", "
                        + MaxLength.ToString() + ");";
                    //if (_onKeyUp != "") evtKeyUp = _onKeyUp + evtKeyUp;
                    evtKeyUp = CheckEventExist(_onKeyUp, evtKeyUp);  //Upd 2009/06/11 T.matsuno
                    this.Attributes.Add("onKeyUp", evtKeyUp);

                    string evtKeyPress = "return NumberBoxKeyPress(event, "
                        + mDecimalPlaces.ToString() + ", "
                        + ((int)mDecimalSymbol).ToString() + ", "
                        + mAllowNegatives.ToString().ToLower() + ", "
                        + MaxLength.ToString() + ");";
                    //if (_onKeyPress != "") evtKeyPress = _onKeyPress + evtKeyPress;
                    evtKeyPress = CheckEventExist(_onKeyPress, evtKeyPress);  //Upd 2009/06/11 T.matsuno
                    this.Attributes.Add("onKeyPress", evtKeyPress);

                    string evtFocus = "return NumberBoxGotFocus(this);";
                    //if (_onFocus != "") evtFocus = _onFocus + evtFocus;
                    evtFocus = CheckEventExist(_onFocus, evtFocus);  //Upd 2009/06/11 T.matsuno
                    this.Attributes.Add("onFocus", evtFocus);

                    string evtBlure = "return NumberBoxLostFocus(this, " + EditComma.ToString().ToLower() + ");";
                    //if (_onBlure != "") evtBlure = _onBlure + evtBlure;
                    evtBlure = CheckEventExist(_onBlure, evtBlure);  //Upd 2009/06/11 T.matsuno
                    this.Attributes.Add("onBlur", evtBlure);
//End Upd
				}
			}
		}
//Add 2009/06/11 T.matsuno
        private string CheckEventExist(string oldEvent, string addEvent)
        {
            string evt = oldEvent;
            if (!oldEvent.Contains(addEvent))
                evt += addEvent;
            return evt;
        }
//End Add

        ///// <summary>
        ///// Returns the RegularExpression string which can be used for validating 
        ///// using a RegularExpressionValidator.
        ///// </summary>
        //virtual public string ValidationRegularExpression
        //{
        //    get
        //    {
        //        StringBuilder regexp = new StringBuilder();
        //			
        //        if (AllowNegatives)
        //            regexp.Append("([-]|[0-9])");
		//	
        //        regexp.Append("[0-9]*");
		//	
        //        if (DecimalPlaces > 0) 
        //        {
        //            regexp.Append("([");
        //            regexp.Append(DecimalSymbol);
        //            regexp.Append("]|[0-9]){0,1}[0-9]{0,");
        //            regexp.Append(DecimalPlaces.ToString());
        //            regexp.Append("}$");
        //        }
		//	
        //        return regexp.ToString();
        //    }
        //}

		/// <summary>
		/// Parse a String to a Double
		/// </summary>
		/// <param name="s">string to be parsed to a double</param>
		/// <returns>double value</returns>
		virtual protected double ParseStringToDouble(string s)
		{
			s = s.Replace(DecimalSymbol.ToString(), ".");
			return double.Parse(s);
		}		
	
		/// <summary>
		/// Returns the FormatString used to display the value in the number box
		/// </summary>
		/// <returns>Format string</returns>
		virtual protected string GetFormat()
		{
			StringBuilder f = new StringBuilder();

            //Add 2009/04/27 T.matsuno
            if (EditComma)
            {
                f.Append("#,");
            }
            //End Add

			f.Append("0");
			if (DecimalPlaces > 0) 
			{
				f.Append(".");
				f.Append('0', DecimalPlaces);
			}
			return f.ToString();
		}
	
	}

}