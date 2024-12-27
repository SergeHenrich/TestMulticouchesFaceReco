using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestMulticouchesFaceReco
{
    public partial class Démarrage : Form
    {
        public Démarrage()
        {
            InitializeComponent();
        }

        private void btnME_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            Reconnaitre r1 = new Reconnaitre();
            r1.Show();
            this.Hide();
        }
    }
}
