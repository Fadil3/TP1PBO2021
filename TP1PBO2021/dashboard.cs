using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1PBO2021
{
    public partial class dashboard : Form
    {
        // membuat array of objek
       Barang[] barang = new Barang[5];
  
    public dashboard()
        {
            InitializeComponent();

            // inisialiasi value awal
            cbHarga.SelectedIndex = 0;
            cbJenis.SelectedIndex = 0;
            btnKembali.Visible = false;
            lblNotFound.Visible = false;
           
            // array yang berisi informasi barang
            String[] nama = new String[] { "Kentang", "Semangka", "Komputer", "Keyboard", "Koko" };
            String[] jenis = new String[] { "Makanan", "Makanan", "Elektronik", "Elektronik", "Baju" };
            String[] gambar = new String[] { "https://icons.iconarchive.com/icons/google/noto-emoji-food-drink/72/32360-potato-icon.png", "https://icons.iconarchive.com/icons/mcdo-design/japan-summer/72/Watermelon-cuts-icon.png", "https://icons.iconarchive.com/icons/prasilarts/claire-monitor/72/15-Computer-Lovers-icon.png", "https://icons.iconarchive.com/icons/3xhumed/tools-hardware-pack-3/72/Microsoft-Reclusa-Gaming-Keyboard-icon.png", "https://icons.iconarchive.com/icons/pixelkit/flat-jewels/72/T-Shirt-icon.png" };
            int[] harga = new int[] { 100000, 300000, 550000, 150000, 250000 };
            int[] range = new int[] { 1, 2, 3, 1, 2 };

            // mengisi array dengan objek
            for (int i = 0; i < 5; i++)
            {
                barang[i] = new Barang(nama[i], jenis[i], harga[i], gambar[i],range[i]);
            }

            // render normal barang
            render(99,0,"0");
        }

        // itemComponent digunakan untuk mencetak / render component form
        private void itemComponent(int i,int left)
        {
                //int left = 265;

                int index = i;
                PictureBox pbBarang = new PictureBox();
                this.Controls.Add(pbBarang);

                Label lblNamaBarang = new Label();
                this.Controls.Add(lblNamaBarang);

                Label lblHarga = new Label();
                this.Controls.Add(lblHarga);

                Button btnBeli = new Button();
                this.Controls.Add(btnBeli);

                // 
                // pbBarang
                // 
                pbBarang.Location = new System.Drawing.Point(left, 102);
                pbBarang.Name = "pbBarang";
                pbBarang.Size = new System.Drawing.Size(103, 98);
                pbBarang.TabIndex = 0;
                pbBarang.TabStop = false;
                pbBarang.ImageLocation = barang[i].gambar;

                // 
                // lblNamaBarang
                // 
                lblNamaBarang.AutoSize = true;
                lblNamaBarang.Location = new System.Drawing.Point(left, 216);
                lblNamaBarang.Name = "lblNamaBarang";
                lblNamaBarang.Size = new System.Drawing.Size(72, 13);
                lblNamaBarang.TabIndex = 5;
                lblNamaBarang.Text = barang[i].nama;

                // 
                // lblHarga
                // 
                lblHarga.AutoSize = true;
                lblHarga.Location = new System.Drawing.Point(left, 248);
                lblHarga.Name = "lblHarga";
                lblHarga.Size = new System.Drawing.Size(54, 13);
                lblHarga.TabIndex = 6;
                lblHarga.Text = "Rp. " + barang[i].harga;

                // 
                // btnBeli
                // 
                btnBeli.Location = new System.Drawing.Point(left, 274);
                btnBeli.Name = "btnBeli";
                btnBeli.Size = new System.Drawing.Size(75, 23);
                btnBeli.TabIndex = 7;
                btnBeli.Text = "Beli";
                btnBeli.UseVisualStyleBackColor = true;
                btnBeli.Click += new EventHandler((s, e) => btnBeli_Click(s, e, index));
                left += 150;
        }

        // render digunakan untuk mengatur item apa saja yang akan dirender
        private void render(int detail,int range,string jenis)
        {

            int left = 265;
            int counter = 0;

            if (detail == 99)
            {
                if(range!=0 && jenis != "0")
                {
                    
                    for (int i = 0; i < 5; i++)
                    {       
                        if (barang[i].range == range && barang[i].jenis == jenis)
                        {
                            itemComponent(i, left);
                            left += 150;
                            counter+=1;
                        }         
                    }

                    if (counter == 0)
                    {
                        lblNotFound.Visible = true;
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        itemComponent(i, left);
                        left += 150;
                    }
                }
                
            }
            else
            {
                itemComponent(detail,490);
            }
           
        }

        // action saat button beli diklik
        private void btnBeli_Click(object sender, EventArgs e,int index)
        {
            lblSemua.Text = "Detail Barang :";
            hideComponent();
            btnKembali.Visible = true;
            cbHarga.Visible = false;
            cbJenis.Visible = false;
            btnCari.Visible = false;
            render(index,0,"0");
        }

        // action saat button beli diklik
        private void btnCatalog_Click(object sender, EventArgs e)
        {
            //direct ke tokopedia.com
            System.Diagnostics.Process.Start("https://www.tokopedia.com");
        }

        // action saat button logout diklik
        private void btnLogout_Click(object sender, EventArgs e)
        {
            login l = new login();
            l.Show(); // membuka halaman login

            //menutup dashboard
            this.Hide();
            this.Close();
        }

        // action saat button cari diklik
        private void btnCari_Click(object sender, EventArgs e)
        {         
            hideComponent();
            btnKembali.Visible = true;
            cbHarga.Visible = false;
            cbJenis.Visible = false;
            btnCari.Visible = false;
            lblNotFound.Visible = false;

            int indexHarga = Convert.ToInt32(cbHarga.SelectedIndex);
            string jenis = Convert.ToString(cbJenis.SelectedItem);

            if(indexHarga != 0 && jenis != "Jenis Barang")
            {
                render(99, indexHarga, jenis);
            }
            else
            {
                MessageBox.Show(
                "Silahkan pilih jenis & harga untuk mencari",
                "Kategori / Harga Belum dipilih",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning 
                );
                reset();
            }
            
        }


        private void hideComponent()
        {
            //hide komponen item
            foreach (Control c in this.Controls)
            {
                if (c.Name == "pbBarang" || c.Name == "lblNamaBarang" || c.Name == "lblHarga" || c.Name == "btnBeli")
                {
                    c.Visible = false;
                }
            }
            lblNotFound.Visible = false;
        }

        // action saat button kembali diklik
        private void btnKembali_Click(object sender, EventArgs e)
        {
            reset();
        }

        // action saat button home diklik
        private void btnHome_Click(object sender, EventArgs e)
        {
            reset();
        }

        // reset form dan panggil render unutk semua barang
        private void reset()
        {
            hideComponent();
            cbHarga.SelectedIndex = 0;
            cbJenis.SelectedIndex = 0;
            btnKembali.Visible = false;
            cbHarga.Visible = true;
            cbJenis.Visible = true;
            btnCari.Visible = true;
            lblNotFound.Visible = false;
            lblSemua.Text = "Semua Barang :";
            render(99, 0, "0");
        }
    }

}
