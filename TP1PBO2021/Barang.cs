using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1PBO2021
{
    //membuat class barang serta getter dan setter nya
    class Barang
    {
        public string nama { get; set; }
        public string jenis { get; set; }
        public int harga { get; set; }
        public string gambar { get; set; }
        public int range { get; set; }
        public Barang(string nama, string jenis, int harga, string gambar,int range)
        {
            this.nama = nama;
            this.jenis = jenis;
            this.harga = harga;
            this.gambar = gambar;
            this.range = range;
        }

        public Barang()
        {
        }
    }

   

}
