using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI;

using static CIT368_Quiz_App.Util.DB;

namespace CIT368_Quiz_App.Pages
{
    public partial class Quiz : System.Web.UI.Page
    {
        private int a, b, c;
        private string m;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u"] == null) Response.Redirect("RegisterLogin.aspx");
            if (Session["n"] == null) Response.Redirect("Profile.aspx");

            a = (Int32)Session["n"];
            b = c = 0;
            m = Session["m"].ToString();

            if ((bool)Session["q"] == true)
            {
                Dictionary<string, string>  d = H(m.Contains("s") ? "State_Data" : "Country_Data"),
                                            f = new Dictionary<string, string>();
                                            // key - country/state;     value - capital

                while(f.Count < a)
                {
                    int i = Site1.RAND.Next(0, Convert.ToInt32(Session["z"]));
                    if (!f.ContainsKey(d.ElementAt(i).Key)) f.Add(d.ElementAt(i).Key, d.ElementAt(i).Value);
                }

                Session["values"] = d;
                Session["questions"] = f;

                while (b < a)
                {
                    Literal q = new Literal();
                    q.Text = "<p>Question #" + (b + 1) + ": ";
                    if (m.Equals("sc") | m.Equals("gc")) q.Text += "What is the capital of " + f.ElementAt(b).Key;
                    else if (m.Contains("s")) q.Text += "What state has the capital of " + f.ElementAt(b).Value;
                    else q.Text += "What country has the capital of " + f.ElementAt(b).Value;
                    q.Text += "?</p>\n";
                    bb.Controls.Add(q);

                    string[] g = { m.Equals("sc") | m.Equals("gc") ? f.ElementAt(b).Value : f.ElementAt(b).Key, "", "", "", "" };
                    int i = 1;
                    while(g.Contains(""))
                    {
                        int index = Site1.RAND.Next(0, Convert.ToInt32(Session["z"]));
                        string h = m.Equals("sc") | m.Equals("gc") ? d.ElementAt(index).Value : d.ElementAt(index).Key;
                        if (!g.Contains(h))
                        {
                            g[i] = h;
                            i ++;
                        }
                    }
                    g = g.OrderBy(x => Site1.RAND.Next()).ToArray();
                    Session["question" + b] = g;

                    for (int n = 0; n < g.Length; n++)
                    {
                        RadioButton o = new RadioButton();
                        o.Text = g[n];
                        o.ID = "question" + b + "_answer" + n;
                        o.GroupName = "question" + b;

                        bb.Controls.Add(new LiteralControl("<p class=\"compact\">"));
                        bb.Controls.Add(o);
                        bb.Controls.Add(new LiteralControl("</p><br />\n"));
                    }

                    b ++;
                }
            }
            else
            {
                while(b < a)
                {
                    Literal q = new Literal();
                    q.Text = "<p>Question #" + (b + 1) + ": ";
                    if (m.Equals("sc") | m.Equals("gc")) q.Text += "What is the capital of " + ((Dictionary<string, string>)Session["questions"]).ElementAt(b).Key;
                    else if (m.Contains("s")) q.Text += "What state has the capital of " + ((Dictionary<string, string>)Session["questions"]).ElementAt(b).Value;
                    else q.Text += "What country has the capital of " + ((Dictionary<string, string>)Session["questions"]).ElementAt(b).Value;
                    q.Text += "?</p>\n";
                    bb.Controls.Add(q);

                    string[] j = (string[])Session["question" + b];
                    for (int n = 0; n < j.Length; n++)
                    {
                        RadioButton k = new RadioButton();
                        k.Text = j[n];
                        k.ID = "question" + b + "_answer" + n;
                        k.GroupName = "question" + b;

                        bb.Controls.Add(new LiteralControl("<p class=\"compact\">"));
                        bb.Controls.Add(k);
                        bb.Controls.Add(new LiteralControl("</p><br />\n"));
                    }

                    b ++;
                }
            }

            Session["q"] = false;
            b = 0;
        }

        protected void AA(object sender, EventArgs e)
        {
            if (cc.Text.Equals("Submit Quiz"))
            {
                cc.Text = "Finish Quiz";

                while( b < a )
                {
                    for (int n = 0; n < 5; n++)
                    {
                        string i = "question" + b + "_answer" + n;

                        RadioButton l = bb.FindControl(i) as RadioButton;

                        if (l.Checked) l.Attributes["style"] += "font-weight: bold;";
                        if (m.Equals("sc") | m.Equals("gc") ? !l.Text.Equals(((Dictionary<string, string>)Session["questions"]).ElementAt(b).Value) : !l.Text.Equals(((Dictionary<string, string>)Session["questions"]).ElementAt(b).Key)) 
                            l.Attributes["style"] += "text-decoration: line-through;";

                        if (l.Checked && (m.Equals("sc") | m.Equals("gc") ? l.Text.Equals(((Dictionary<string, string>)Session["questions"]).ElementAt(b).Value) : l.Text.Equals(((Dictionary<string, string>)Session["questions"]).ElementAt(b).Key))) c++;
                    }
                    b ++;
                }

                dd.Text += "<p>Your final quiz grade: " + c + "/" + a + " or " + ((c * 100) / a) + "%</p>";

                I(Convert.ToInt32(Session["u"]), c, a, m);
            }
            else
            {
                Session["n"] = null;
            }
        }
    }
}