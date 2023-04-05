using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace dattnt
{
    public partial class frmR : Form
    {
        int tong = 0;
        int dang = 0;
        int xyly = 0;
        int g = 0;

        public frmR(int t , int d, int x, int g)
        {
            InitializeComponent();
            this.tong = t;
            this.dang = d;
            this.xyly = x;
            this.g = g;
        }
        private void hien()
        {
            txtCho.Text = dang.ToString();
            txtDaxuly.Text = xyly.ToString();
            txtG.Text = g.ToString();
            txtTong.Text = tong.ToString();
            string s = File.ReadAllText("file.txt");
            txtketqua.Text = s;
        }
        private void frmR_Load(object sender, EventArgs e)
        {
            hien();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
