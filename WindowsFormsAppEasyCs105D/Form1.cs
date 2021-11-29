using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs105D
{
    public partial class Form1 : Form
    {
        private Label lb;
        private RichTextBox rt;
        private TextBox tb;
        private Button bt;
        private TableLayoutPanel tlp;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Search a word";
            this.Width = 300;
            this.Height = 300;

            lb = new Label();
            lb.Dock = DockStyle.Fill;

            rt = new RichTextBox();
            rt.Dock = DockStyle.Fill;

            tb = new TextBox();
            tb.Dock = DockStyle.Fill;

            bt = new Button();

            tlp = new TableLayoutPanel();
            tlp.ColumnCount = 2;
            tlp.RowCount = 3;
            tlp.Dock = DockStyle.Fill;

            lb.Text = "Type or paste any sentence.";
            tlp.SetColumnSpan(lb, 2);

            rt.Multiline = true;
            rt.Height = 100;
            tlp.SetColumnSpan(rt, 2);

            bt.Text = "Search";
            tlp.SetColumnSpan(bt, 2);

            lb.Parent = tlp;
            rt.Parent = tlp;
            tb.Parent = tlp;
            bt.Parent = tlp;

            tlp.Parent = this;

            bt.Click += new EventHandler(BtClick);
        }

        public void BtClick(Object sender, EventArgs e)
        {
            Regex rx = new Regex(tb.Text);
            Match m = null;
            
            // Keep to change the word color to Red as long as search succeed
            // for (m = rx.Match(rt.Text); m.Success; m.NextMatch())
            for (m = rx.Match(rt.Text); m.Success; m = m.NextMatch())
            {
                rt.Select(m.Index, m.Length);
                rt.SelectionColor = Color.Red;
            }
        }
    }
}