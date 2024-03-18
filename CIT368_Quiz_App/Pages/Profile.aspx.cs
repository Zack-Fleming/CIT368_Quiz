using System;

using static CIT368_Quiz_App.Util.DB;

namespace CIT368_Quiz_App.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u"] == null) Response.Redirect("RegisterLogin.aspx");

            if (!IsPostBack)
            {
                aa.Text = A();

                bb.Text = F((int)Session["u"]);

                string[] t = G((int)Session["u"], "");

                jj.Text = t[0];
                bb.Text += t[1];

                gg.Visible = Convert.ToBoolean(t[2]);
                hh.Visible = Convert.ToBoolean(t[2]);
                ii.Visible = Convert.ToBoolean(t[2]);
            }
        }

        protected void AA(object sender, EventArgs a)
        {
            int i = cc.SelectedIndex, len = 0;

            if (i == 0 | i == 1) len = E("State_Data");
            else if (i == 2 | i == 3) len = E("Country_Data");
            else return;

            Session["z"] = len;

            ff.MaximumValue = len.ToString();
            dd.Enabled = true;
            dd.Attributes.Add("placeholder", "1-" + len);
        }

        protected void BB(object semder, EventArgs e)
        {
            Session["m"] = cc.SelectedValue;
            Session["q"] = true;
            Session["n"] = Convert.ToInt32(dd.Text);
            Response.Redirect("Quiz.aspx");
        }

        protected void CC(object sender, EventArgs e)
        {
            string v = gg.SelectedValue;

            if (v.Equals("Type")) hh.Visible = true;
            else hh.Visible = false;
        }

        protected void DD(object sender, EventArgs e)
        {
            string[] t = G((int)Session["u"], gg.SelectedValue);

            jj.Text = t[0];
        }
    }
}