﻿using System;
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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            // mengubah field password menjadi *
            tbPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = tbUsername.Text;
            pass = tbPassword.Text;

            // mencocokan user dan pass yang sudah di setting
            if(user == "mrayhanfadil" && pass == "pbo123")
            {
                dashboard d = new dashboard();
                d.Show(); // membuka dashboard /  home
                this.Hide(); // menutup halaman login
                           
            }
            else
            {
                // warning message jika authentikasi gagal
                MessageBox.Show(
                "Username / Password salah",
                "Login Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                );
            }
        }
    }
}
