using System;
using System.Windows.Forms;

namespace SqlProfilerQueryCleaner
{
    public partial class MainForm : Form
    {
        public MainForm()
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
                txtOutputSql.Text = Cleaner.Clean(txtInputSql.Text);
            }
            catch
            {
                txtOutputSql.Text = "It didn't work.";
            }
        }

    }
}
