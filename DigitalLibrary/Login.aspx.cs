using DigitalLibrary.Models;
using DigitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassword.Text.Trim();
            DoValidate(userName, passWord);
        }

        private void DoValidate(string userName, string passWord)
        {
            UserData userData = new UserData();
            if (!string.IsNullOrEmpty(userName) & !string.IsNullOrEmpty(passWord))
            {
                UserData.UserLogs userLogs = new UserData.UserLogs();
                userLogs.UserName = userName;
                userLogs.Password = passWord;
                //userLogs.IsAdmin = IsAdmin;
                UserService userService = new UserService();
                userData = userService.DoValidate(userLogs);
                if(userData !=null)
                {
                    string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                    string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString(); // Get the IP
                    bool isRestricted = userService.CheckRestictedIPAddress(myIP);
                    if (!isRestricted)
                    {
                        Response.Redirect("Demo.aspx");
                    }
                    else
                    {
                        lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                        lblMsg.Text = "You can't access the application";
                    }

                    
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                    lblMsg.Text = "Invalid UserName or Password.";
                }
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                lblMsg.Text = "Please Enter UserName and Password.";

                
            }
        }
    }
}