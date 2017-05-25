using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PMClass
{
    class Encrypto
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Encrypto()
        {
        }

        #region : フィールド
        /// <summary>
        /// フィールド
        /// </summary>
        #endregion

        #region : プロパティ
        ///<summary>
        /// プロパティ
        ///</summary>
        #endregion
        /// <summary>
        /// 暗号化
        /// </summary>
        public string Code(string inStr)
        {
            byte[] HashValue;
            string outStr = "";

            //Create a new instance of the UnicodeEncoding class to 
            //convert the string into an array of Unicode bytes.
            UnicodeEncoding UE = new UnicodeEncoding();

            //Convert the string into an array of bytes.
            byte[] MessageBytes = UE.GetBytes(inStr);

            //Create a new instance of the SHA1Managed class to create 
            //the hash value.
            SHA1Managed SHhash = new SHA1Managed();

            //Create the hash value from the array of bytes.
            HashValue = SHhash.ComputeHash(MessageBytes);

            //Display the hash value to the console. 
            foreach (byte b in HashValue)
            {
                outStr += b.ToString();
            }

            return outStr;
        }
    }
}
