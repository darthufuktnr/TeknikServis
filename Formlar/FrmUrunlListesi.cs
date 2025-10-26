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
    public partial class FrmUrunlListesi : Form
    {
        public FrmUrunlListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db  = new DbTeknikServisEntities();// modüldeki bütün yapıları tutan kısım
        void metot1()
        {
            var degerler = from u in db.TBLURUNs
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               u.ALISFIYAT,
                               u.SATISFIYAT,
                               u.STOK,
                               KATEGORI = u.TBLKATEGORI.AD,
                               u.DURUM
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunlListesi_Load(object sender, EventArgs e)
        {
            //listeleme işlemi ToList Add Remove
            // var degeler = db.TBLURUN.ToList();
            metot1();
            gridLookUpKategori.Properties.DataSource = db.TBLKATEGORIs.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAdi.Text;
            t.MARKA = TxtMarka.Text;
            t.ALISFIYAT = Decimal.Parse (TxtAlisFiyat.Text);
            t.SATISFIYAT = Decimal.Parse (TxtSatisFiyat.Text);
            t.STOK = short.Parse (TxtStok.Text);
            t.DURUM = false;
            t.KATEGORI = byte.Parse (gridLookUpKategori.EditValue.ToString());
            db.TBLURUNs.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void TxtUrunAdi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtAlisFiyat_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
           metot1();
        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtUrunAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            TxtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
            TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger =db.TBLURUNs.Find(id);
            db.TBLURUNs.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün Sistemden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLURUNs.Find(id);
            deger.AD = TxtUrunAdi.Text;
            deger.MARKA = TxtMarka.Text;
            deger.ALISFIYAT = Decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT = Decimal.Parse(TxtSatisFiyat.Text);
            deger.KATEGORI = byte.Parse(gridLookUpKategori.EditValue.ToString());
            deger.STOK = short.Parse(TxtStok.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
