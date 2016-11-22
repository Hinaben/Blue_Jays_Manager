using Blue_Jays_Manager.Models.DataAccessLayer;
using System;
using System.Web.UI;

namespace Blue_Jays_Manager
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            LoadExcelData.LoadToDatabase();
            string JQueryVer = "3.1.0";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });


        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex != null)
            {
                ExceptionLogger.Log(ex);
                Server.ClearError();
                Server.Transfer("ErrorPage.aspx");
            }
        }

        protected void Session_Start(object sender, EventArgs args)
        {
            Session["login"] = "loggedout";
            Session["CoachChanges"] = false;
            Session["PlayerChanges"] = false;
        }
    }
}