using CIT368_Quiz_App.Util;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using static CIT368_Quiz_App.Util.DB;

namespace CIT368_Quiz_App.Pages
{
    public partial class RegisterLogin : System.Web.UI.Page
    {
        int error = 0;



        protected void Page_Load(object sender, EventArgs e) { }

        protected void S(object sender, EventArgs e)
        {
            if (register_content.Visible)
            {
                login_content.Visible = true;
                register_content.Visible = false;

                btn_submit.Text = "Login";
                btn_switch.Text = "Register";
                txt_switch.Text = "Not a User?";
                header.Text     = "Login";
            }
            else
            {
                login_content.Visible = false;
                register_content.Visible = true;

                btn_submit.Text = "Register Account";
                btn_switch.Text = "Login";
                txt_switch.Text = "Already a user?";
                header.Text     = "Register";
            }
        }

        protected void B(object sender, EventArgs e)
        {
            string text = btn_submit.Text;

            if (text == "Login") L();
            else R();
        }

        private void R()
        {
            E();

            string  z = qq.Text,
                    y = yy.Text,
                    x = ll.Text,
                    w = zz.Text,
                    v = mm.Text;

            C(z, qq);
            C(y, yy);
            C(x, ll);
            C(w, zz);
            C(v, mm);
            C(ff.Text, ff);
            C(rr.Text, rr);
            if (error == 1) { P(1, lit_error); return; }

            if (Security.D(z, qq, 0) == 6) { P(6, lit_error); return; }
            if (Security.D(y, yy, 0) == 6) { P(6, lit_error); return; }
            if (Security.D(w, zz, 1) == 6) { P(6, lit_error); return; }
            if (Security.D(x, ll, 2) == 6) { P(6, lit_error); return; }
            if (Security.D(v, mm, 3) == 6) { P(6, lit_error); return; }

            int j = Security.C(ff.Text, ff, rr.Text, rr);
            if (j != 0) { P(j, lit_error); return; }

            string u = Util.Security.A();
            string t = Util.Security.B(Util.Security.B(ff.Text + u));
            int r = Util.DB.C(z, y, x, w, v, t, u);

            if (r != 0) { P(r, lit_error); return; }

            qq.Text = "";
            yy.Text = "";
            ll.Text = "";
            zz.Text = "";
            mm.Text = "";
            ff.Text = "";
            rr.Text = "";

            Response.Redirect("Profile.aspx");
        }

        private void L()
        {
            E();

            string a = jj.Text;

            C(a, jj);
            C(ii.Text, ii);

            if (error == 1) { P(1, lit_error); return; }

            int g = D(a, ii.Text);

            if (g == 0) { P(4, lit_error); return; }

            Session["u"] = g;
            Response.Redirect("Profile.aspx");
        }

        private void E()
        {
            qq.BackColor = Site1.reg_background;
            yy.BackColor = Site1.reg_background;
            ll.BackColor = Site1.reg_background;
            zz.BackColor = Site1.reg_background;
            mm.BackColor = Site1.reg_background;
            ff.BackColor = Site1.reg_background;
            rr.BackColor = Site1.reg_background;

            ii.BackColor = Site1.reg_background;
            jj.BackColor = Site1.reg_background;

            lit_error.Text = "";
            
            error = 0;
        }

        private void C(string a, TextBox b)
        {
            bool isNotValid = string.IsNullOrEmpty(a);
            b.BackColor = (isNotValid ? Site1.error_background : Site1.reg_background);
            error = ((isNotValid | (error == 1)) ? 1 : 0);
        }

        private void P(int a, Literal b)
        {
            switch (a)
            {
                case 1:  b.Text = "error: one or more fields not filled in..."; break;
                case 2:  b.Text = "error: passwords do not match. Try again..."; break;
                case 3:  b.Text = "error: password does not match requirements..."; break;
                case 4:  b.Text = "error: username or password is incorrect..."; break;
                case 5:  b.Text = "error: username already exists..."; break;
                case 6:  b.Text = "error: field(s) does not match proper formatting..."; break;
                default: b.Text = "error: something went wrong. Try again..."; break;
            }
        }
    }
}