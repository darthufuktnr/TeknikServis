using DevExpress.XtraGrid;
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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        private void labelControl36_Click(object sender, EventArgs e)
        {

        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUNs.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                
                Marka=z.Key,
                Toplam=z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
        } 
    }
}
