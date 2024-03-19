using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Collections.Generic;

namespace CIT368_Quiz_App.Util
{
    public class DB
    {
        private static readonly string db = ConfigurationManager.ConnectionStrings["db2"].ConnectionString;


        public static string A() { return a(); }
        public static bool B(string a) { return b(a); }
        public static int C(string a, string b, string c, string d, string e, string f, string g) { return DB.c(a, b, c, d, e, f, g); }
        public static int D(string a, string b) { return d(a, b); }
        public static int E(string a) { return e(a); }
        public static string F(int a) { return f(a); }
        public static string[] G(int a, string b) { return g(a, b); }
        public static Dictionary<string, string> H(string a) { return h(a); }
        public static void I(int a, int b, int c, string d) { i(a, b, c, d); }



        private static int e(string a)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("G", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", a);

                int b = (int)cmd.ExecuteScalar();

                connection.Close();
                return b;
            }
        }

        private static string a()
        {
            int a = Site1.RAND.Next(1, e("Greetings") + 1);

            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("E", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", a);
                SqlDataReader reader = cmd.ExecuteReader();
                
                string b = "";
                while (reader.Read()) { b = "<h1>" + reader["Greeting"] + "(hello in " + reader["Language"] + "), "; }

                connection.Close();
                return b;
            }
        }

        private static bool b(string a)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("C", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", a);

                int b = (int)cmd.ExecuteScalar();

                connection.Close();

                return b > 0;
            }
        }

        private static int c(string a, string b, string c, string d, string e, string f, string g)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                SqlCommand z = new SqlCommand("J", connection);
                z.CommandType = System.Data.CommandType.StoredProcedure;
                z.Parameters.AddWithValue("@a", e);

                int y = (int)z.ExecuteScalar();
                if (y != 0) return 5;

                SqlCommand x = new SqlCommand("B", connection);
                x.CommandType = System.Data.CommandType.StoredProcedure;
                x.Parameters.AddWithValue("@a", a);
                x.Parameters.AddWithValue("@b", b);
                x.Parameters.AddWithValue("@c", c);
                x.Parameters.AddWithValue("@d", d);
                x.Parameters.AddWithValue("@e", e);
                x.Parameters.AddWithValue("@f", f);
                x.Parameters.AddWithValue("@g", g);
                x.Parameters.Add("@h", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                
                x.ExecuteNonQuery();
                int w = Convert.ToInt32(x.Parameters["@h"].Value);
               
                HttpContext C = HttpContext.Current;
                C.Session["u"] = w;

                connection.Close();

                return 0;
            }
        }

        private static int d(string a, string b)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                SqlCommand z = new SqlCommand("F", connection);
                z.CommandType = System.Data.CommandType.StoredProcedure;
                z.Parameters.AddWithValue("@a", a);
                SqlDataReader y = z.ExecuteReader();
                string x = "";

                while (y.Read()) { x = y["Salt"].ToString(); }
                y.Close();

                SqlCommand w = new SqlCommand("K", connection);
                w.CommandType = System.Data.CommandType.StoredProcedure;
                w.Parameters.AddWithValue("@a", a);
                string g = Security.B(Security.B(b + x));
                w.Parameters.AddWithValue("@b", g);
                int v = Convert.ToInt32(w.ExecuteScalar());

                connection.Close();

                return v;
            }
        }

        private static string f(int a)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                string z = "", y = "", x = "", w = "", v = "", u = "";

                SqlCommand b = new SqlCommand("H", connection);
                b.CommandType = System.Data.CommandType.StoredProcedure;
                b.Parameters.AddWithValue("@a", a);
                SqlDataReader c = b.ExecuteReader();

                while (c.Read())
                {
                    y = c["FirstName"].ToString();
                    x = c["LastName"].ToString();
                    w = c["Email"].ToString();
                    v = c["PhoneNumber"].ToString();
                    u = c["UserName"].ToString();
                }

                z =
                    "<p>First Name: " + y + "</p>\n\t\t" + 
                    "<p>Last Name : " + x + "</p>\n\t\t" + 
                    "<p>Full Name : " + y + " " + x + "</p>\n\t\t" + 
                    "<p>User Name : " + u + "</p>\n\t\t" +
                    "<br>\n\t\t" + 
                    "<p>Email: " + w + "</p>\n\t\t" +
                    "<p>Phone: " + v + "</p>\n\t\t" +
                    "<br>\n\t\t"
                ;

                connection.Close();

                return z;
            }
        }

        private static string[] g(int a, string b)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                string[]c = new string[3];

                SqlCommand d = new SqlCommand("I", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.AddWithValue("@a", a);
                d.Parameters.AddWithValue("@b", "");
                SqlDataReader e = d.ExecuteReader();

                StringBuilder f = new StringBuilder();
                int i = 0, g = 0;
                while (e.Read())
                {
                    int r = (int)e["NumRight"], s = (int)e["Total"], t = ((r * 100) / s);

                    f.AppendLine("\t<tr>\n\t\t<td>" + r + "</td>\n\t\t<td>" + s + "</td>\n\t\t<td>" + t + "%</td>\n\t\t<td>" + e["Type"] + "</td>\n\t\t<td>" + e["DateTaken"] + "</td>\n\t</tr>");

                    i++;
                    g += t;
                }
                e.Close();

                if(f.Length == 0)
                {
                    c[0] = "<p>Your past quizes will show up here. To start a quiz, slick the 'New Quiz' button above</p>";
                    c[1] = "<p>Num Quizes: 0<p>\n<p>Avg. Score: 0%</p>";
                    c[2] = "false";
                }
                else
                {
                    c[0] = "<table class=\"history\">\n\t<tr>\n\t\t<th>Num Right</th>\n\t\t<th>Num Total</th>\n\t\t<th>Score</th>\n\t\t<th>Type</th>\n\t\t<th>Quiz date</th>\n\t</tr>\n\t" + f.ToString() + "</table>";
                    c[1] = "<p>Num Quizes: " + i + "</p>\n<p>Avg. Score: " + (g / i) + "%</p>";
                    c[2] = "true";
                }

                connection.Close();

                return c;
            }
        }

        private static Dictionary<string, string> h(string a)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                SqlCommand d = new SqlCommand("D", connection);
                d.CommandType = System.Data.CommandType.StoredProcedure;
                d.Parameters.AddWithValue("@a", a);
                SqlDataReader r = d.ExecuteReader();

                Dictionary<string, string> c = new Dictionary<string, string>();
                while (r.Read()) c.Add(r["Name"].ToString(), r["Capital"].ToString());

                connection.Close();

                return c;
            }
        }

        private static void i(int a, int b, int c, string d)
        {
            using (SqlConnection connection = new SqlConnection(db))
            {
                connection.Open();

                SqlCommand f = new SqlCommand("A", connection);
                f.CommandType = System.Data.CommandType.StoredProcedure;
                f.Parameters.AddWithValue("@a", a);
                f.Parameters.AddWithValue("@b", b);
                f.Parameters.AddWithValue("@c", c);
                f.Parameters.AddWithValue("@d", DateTime.Now);
                f.Parameters.AddWithValue("@e", d);

                f.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}