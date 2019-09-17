using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClient_PLF1
{
    public partial class Form1 : Form
    {
        Presenter _presenter;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var proxy = new ServiceReference1.ServTraitEveneAutreSysClient();
            _presenter = new Presenter();
        }

        private void btnCallSce_AddNP_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_AjusterEngagAjouNonPartn();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else {
                txtMsg.Text = res;
            }

        }

        private void btnCallSce_Dec_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_DecesNonPartn();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }
        }

        private void btnCallSce_Spec_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_SepcialiteNonPartn();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }
        }

        private void btnCallSce_Ann_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_AjusterEngagAnnuleNonPartn();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }
        }

        private void btnCallSce_Modif_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_AjusterEngagModifNonPartn();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }
        }

        private void btnSpecBiztalk_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_SepcialiteNonPartnBiztalk();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }
        }

        private void btnDecBiztalk_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_DecesNonPartnBiztalk();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }
        }

        private void BtnAddNpBiztalk_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_AjusterEngagAjouNonPartnBiztalk();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }

        }

        private void btnResident_Click(object sender, EventArgs e)
        {
            var res = _presenter.Call_AjusterAvisConformiteMedResidents();
            if (res.Contains("OK"))
            {
                txtMsg.ForeColor = Color.Green;
                txtMsg.Text = res.Substring(3);
            }
            else
            {
                txtMsg.Text = res;
            }
        }
    }
}
