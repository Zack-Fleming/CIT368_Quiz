using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace CIT368_Quiz_App.Util
{
    public class Security
    {
        public static string A() { return a(); }
        public static string B(string a) { return b(a); }
        public static int C(string a, TextBox b, string d, TextBox e) { return c(a, b, d, e); }
        public static int D(string a, TextBox b, int c) { return d(a, b, c); }



        private static string a()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] s = new byte[32];
            StringBuilder sb;

            bool a = true;
            do
            {
                rng.GetBytes(s);
                sb = new StringBuilder();
                for (int i = 0; i < s.Length; i++) sb.Append(s[i].ToString("X2"));
                a = DB.B(sb.ToString());
            } while (a);

            return sb.ToString();
        }

        private static string b(string a)
        {
            using (SHA256 r = SHA256.Create())
            {
                byte[] g = r.ComputeHash(Encoding.UTF8.GetBytes(a));
                StringBuilder u = new StringBuilder();
                for (int i = 0; i < g.Length; i++) u.Append(g[i].ToString("X2"));
                return u.ToString();
            }
        }

        private static int c(string a, TextBox b, string c, TextBox d)
        {
            bool e = Regex.IsMatch(a, "^[a-zA-Z0-9-_@$!%*?&#|]{16,}$") & Regex.IsMatch(c, "^[a-zA-Z0-9-_@$!%*?&#|]{16,}$");
            bool f = a.Equals(c);
            b.BackColor = (e & f) ? Site1.reg_background : Site1.error_background;
            d.BackColor = (e & f) ? Site1.reg_background : Site1.error_background;
            return (e & f) ? 0 : e ? 2 : 3;
        }

        private static int d(string a, TextBox b, int c)
        {
            bool d;

            switch (c) 
            {
                case 0:  d = Regex.IsMatch(a, "^[ a-zA-Z`-]{1,100}$"); break;
                case 1:  d = Regex.IsMatch(a, "^([(]?[0-9]{3}[)]?-)?[0-9]{3}-[0-9]{4}$"); break;
                case 2:  d = Regex.IsMatch(a, "^.+@.+\\..+$"); break;
                case 3:  d = Regex.IsMatch(a, "^[a-zA-Z0-9-_]{1,100}$"); break;
                default: d = false; break;
            }

            b.BackColor = d ? Site1.reg_background : Site1.error_background;
            return d ? 0 : 6;
        }
    }
}