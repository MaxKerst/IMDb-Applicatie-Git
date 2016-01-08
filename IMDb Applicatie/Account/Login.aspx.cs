using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace IMDb_Applicatie.Account
{
    public partial class Login : Page
    {
        private static string connectionstring = "Data Source=localhost; User Id=SYSTEM; password=SYSTEM";
        private OracleConnection connection;
        private OracleCommand cmd = new OracleCommand();
        private OracleDataReader reader;
        private string query = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Portal.ValidateUser(tbName.Text, tbPassword.Text) != 0)
            {
                //Context.User.Identity.GetUserName();
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, tbName.Text, DateTime.Now,
                    DateTime.Now.AddMinutes(30), true, tbName.Text);
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (true)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);
                IMDbSession.UserID = (Portal.ValidateUser(tbName.Text, tbPassword.Text)).ToString();
                Response.Redirect("~/", true);
            }
            else
            {
                ErrorTextBox.Visible = true;
                //Response.Redirect("Login.aspx", true);
            }
        }
    }
}