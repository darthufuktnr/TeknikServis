using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities  db= new DbTeknikServisEntities();

        private void labelControl20_Click(object sender, EventArgs e)
        {

        }

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
           labelControl2.Text=db.TBLURUNs.Count().ToString();
            labelControl3.Text = db.TBLKATEGORIs.Count().ToString();
            labelControl5.Text = db.TBLURUNs.Sum(x=>x.STOK).ToString();
            labelControl7.Text = "10";
            labelControl13.Text = (from x in db.TBLURUNs
                                    orderby x.SATISFIYAT descending
                                    select x.AD).FirstOrDefault();
            labelControl11.Text = (from x in db.TBLURUNs
                                    orderby x.SATISFIYAT ascending
                                    select x.AD).FirstOrDefault();
            labelControl19.Text = (from x in db.TBLURUNs 
                                   orderby x.STOK 
                                   descending select x.AD).FirstOrDefault();
            labelControl17.Text = (from x in db.TBLURUNs
                                   orderby x.STOK
                                   ascending
                                   select x.AD).FirstOrDefault();
            labelControl26.Text = db.TBLURUNs.Count(x => x.KATEGORI == 4).ToString();
            labelControl23.Text = db.TBLURUNs.Count(x => x.KATEGORI == 1).ToString();
            labelControl21.Text = db.TBLURUNs.Count(x => x.KATEGORI == 3).ToString();
            labelControl35.Text =(from x in db.TBLURUNs
                                  select x.MARKA).Distinct().Count().ToString();
        }

        private void labelControl19_Click(object sender, EventArgs e)
        {

        }
    }
}
