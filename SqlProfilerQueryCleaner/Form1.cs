using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SqlProfilerQueryCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtOutputSql.KeyDown += allowCtrlA;
            txtInputSql.KeyDown += allowCtrlA;
        }

        void allowCtrlA(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox) sender;
            if(e.Control && e.KeyCode == Keys.A)
                textBox.SelectAll();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            try
            {
                txtOutputSql.Text = Clean(txtInputSql.Text);
            }
            catch
            {
                txtOutputSql.Text = "It didn't work.";
            }
        }

        string Clean(string sql)
        {
            // remove executesql call
            string resultSql = sql.Replace("exec sp_executesql N'", "");

            // split between sql and params
            var splitSql = resultSql.Split(new[] {"',N'"}, StringSplitOptions.None);
            resultSql = splitSql[0];
            resultSql = resultSql.Replace("''", "'");

            var parameters = GetParameters(splitSql[1]);

            return parameters + "\r\n\r\n" + resultSql;
        }

        // @StartDate datetime,@EndDate datetime,@ForumId uniqueidentifier,@GroupId uniqueidentifier,@RoleId0 bigint,@RoleId1 bigint,@RoleId2 bigint',@StartDate='2009-02-11 00:00:00',@EndDate='2013-03-15 23:59:59.997',@ForumId='00000000-0000-0000-0000-000000000000',@GroupId='592204FD-B816-461A-8715-80DC345C9AF0',@RoleId0=2321,@RoleId1=4,@RoleId2=1078
        string GetParameters(string sqlParams)
        {
            var csv = sqlParams.Split(',');
            var declares = new List<string>();
            var i = 0;
            while (!csv[i].Contains("="))
            {
                declares.Add(csv[i].Trim('\''));
                i++;
            }

            var values = new List<string>();
            for(int j=i;j<csv.Length;j++)
            {
                var token = csv[j].Split('=')[1];
                values.Add(token);
            }

            var paramSb = new StringBuilder();
            for (int k = 0; k < declares.Count; k++)
                paramSb.AppendFormat("DECLARE {0}={1}", declares[k], values[k]).AppendLine();
            return paramSb.ToString();
        }
    }
}
