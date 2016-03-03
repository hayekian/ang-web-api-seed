using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HLib;
using System.Web.Security;

namespace SampleAngular
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void Login1_LoggedIn(object sender, EventArgs args)
        {    
            Login L = sender as Login;
            HLib.Misc.Log("User " + L.UserName + " has logged in.");
            Response.Redirect("index.aspx");

        }


        protected void Login1_LoginError(object sender, EventArgs args)
        {
            Login l = sender as Login;

            string username = l.UserName;

            if (Membership.GetUser(username) == null)

                l.FailureText = "This username does not exist.<br />  Please contact your local administrator<br /> to be registered for this system.";

            else
                l.FailureText = "Your login attempt was not successful. Please try again.";



        }
    }
}