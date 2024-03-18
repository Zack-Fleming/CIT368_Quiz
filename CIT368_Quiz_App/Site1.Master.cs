using System;
using System.Configuration;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;

namespace CIT368_Quiz_App
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static Color error_background = (Color)new WebColorConverter().ConvertFromString("#FFFF8A8A"),
                            reg_background = (Color)new WebColorConverter().ConvertFromString("#FFFFFFFF");
        public static Random RAND = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache); // do not cache the page

            // change navbar, depending on login status
            if (Session["u"] == null)
            {
                profile.Visible = logout.Visible = false;
                register.Visible = true;
            }
            else
            {
                profile.Visible = logout.Visible = true;
                register.Visible = false;
            }

            // get the currently running page
            string page = HttpContext.Current.CurrentHandler.ToString();
            string[] pieces = page.Split('_');

            // setting navbar link to active, for the current page
            switch (pieces[1])
            {
                case "registerlogin":
                    register.Attributes["class"] = "active left";
                    title.Text = "Register";
                    break;
                case "profile":
                    profile.Attributes["class"] = "active left";
                    title.Text = "Profile";
                    break;
                case "home":
                    home.Attributes["class"] = "active right";
                    title.Text = "Home";
                    break;
                case "quiz":
                    title.Text = "Quiz";
                    break;
                default:
                    break;
            }
        }

        protected void User_Logout(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionID", ""));
            Response.Redirect("RegisterLogin.aspx");
        }
    }
}