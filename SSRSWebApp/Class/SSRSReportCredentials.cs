using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Configuration;
using Microsoft.Reporting.WebForms;
using System.Net;

namespace PMClass
{
    /// <summary>
    /// SSRS服务器认证信息获得
    /// </summary>
    [Serializable]
    public class SSRSReportCredentials : IReportServerCredentials
    {
        private string _UserName;
        private string _PassWord;
        private string _DomainName;
        /// <summary>
        /// 自动从web.config中读取SSRS认证信息
        /// </summary>
        public SSRSReportCredentials()
        {
            _UserName = WebConfigurationManager.ConnectionStrings["ReportViewerUser"].ConnectionString;
            _PassWord = WebConfigurationManager.ConnectionStrings["ReportViewerPassWord"].ConnectionString;
            _DomainName = WebConfigurationManager.ConnectionStrings["ReportViewerDomain"].ConnectionString;
        }
        /// <summary>
        /// 手动指定SSRS认证信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <param name="DomainName"></param>
        public SSRSReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get
            {
                // Use the default Windows user.  Credentials will be
                // provided by the NetworkCredentials property.
                return null;
            }
        }
        public ICredentials NetworkCredentials
        {
            get
            {
                // Read the user information from the Web.config file.  
                // By reading the information on demand instead of 
                // storing it, the credentials will not be stored in 
                // session, reducing the vulnerable surface area to the
                // Web.config file, which can be secured with an ACL.
                //1.若没有指定用户名和密码时，默认为本地认证
                if (string.IsNullOrEmpty(_UserName) || string.IsNullOrEmpty(_PassWord))
                    return null;
                else if (string.IsNullOrEmpty(_DomainName)) //2.若未指定域，则表示当前请求域
                    return new NetworkCredential(_UserName, _PassWord);
                else //3.用户+域认证
                    return new NetworkCredential(_UserName, _PassWord, _DomainName);
            }
        }
        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string user, out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            // Not using form credentials
            return false;
        }

    }
}