﻿using System;
using System.IO;
using System.Web.UI;

namespace IMDb_Applicatie.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void RegisterButton_Click(object sender, EventArgs e)
        {
            if(Portal.InsertUser(tbNaam.Text, tbPassword.Text))
            {
                Response.Redirect("Login");
            }
        else
            {
                lblError.Visible = true;
            }
        }
    }
}