using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Net.Configuration;

namespace PersonelIzin
{
    public partial class Form1 : Form
    {
        ArrayList personeller= new ArrayList();
        ArrayList izinler= new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        void listele()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            comboBox1.Items.Clear();

            for(int i = 0;i<personeller.Count;i++)
            {
                listBox1.Items.Add(personeller[i] + " - " + izinler[i]);
                listBox2.Items.Add(personeller[i] + " - " + izinler[i]);
                comboBox1.Items.Add(personeller[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Lütfen isim gir");
            else
            {
                personeller.Add(textBox1.Text);
                izinler.Add(numericUpDown1.Value);
                textBox1.Clear();
                numericUpDown1.Value = 1;
                listele();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilenindex = listBox1.SelectedIndex;
            if (secilenindex == -1)
                MessageBox.Show("Personel Seçiniz");
            else
            {
                personeller.RemoveAt(secilenindex);
                izinler.RemoveAt(secilenindex);
                listele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime bitis, baslangic;
            baslangic = dateTimePicker1.Value;
            bitis = dateTimePicker2.Value;
            if (baslangic >= DateTime.Today)
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    int secpers = comboBox1.SelectedIndex;
                    int secizin = Convert.ToInt32(izinler[secpers]);


                    if (bitis < baslangic)
                        MessageBox.Show("Başlangıç tarihi önce olmalı.");
                    else
                    {
                        TimeSpan zamanaraligi = bitis - baslangic;
                        int gunsayisi = zamanaraligi.Days;

                        if (secizin >= gunsayisi)
                        {
                            //izin ok
                            izinler[secpers] = secizin - gunsayisi;
                            listele();
                            MessageBox.Show("İzin kullanıldı.");
                        }
                        else
                        {
                            MessageBox.Show("Yeterli izin hakkınız yok.");
                        }
                    }
                }
                else MessageBox.Show("Personel Seçiniz");
            }
            else MessageBox.Show("İzin Başlangıç Tarihi bugünden önce olamaz");
        }
    }
}
