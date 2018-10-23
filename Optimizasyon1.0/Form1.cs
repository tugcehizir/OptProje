﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimizasyon1._0
{
    public partial class Form1 : Form
    {

        int str = 0, stn = 0;
        int[,] dizi;
        int[,] dizi2;
        TextBox[,] TextKutu;
        TextBox[,] TextKutu2;
        Label[,] LabelKutu;
        public Form1()
        {
            InitializeComponent();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }
        private void KutuOlustur()
        {
            str = Convert.ToInt32(textBox1.Text);
            stn = Convert.ToInt32(textBox2.Text);
            
            TextKutu = new TextBox[str, stn];
            TextKutu2 = new TextBox[str, stn];
            LabelKutu = new Label[str, stn];
            dizi = new int[str, stn];
            dizi2 = new int[str, stn];
            DiziDoldur(str, stn);

            int left = 100;
            int top = 120;
            int left2 = 155;
            
            for (int i = 0; i < str; i++)
            {
                for (int k = 0; k < stn; k++)
                {
                    TextKutu[i, k] = new TextBox();
                    TextKutu[i, k].Left = left;
                    TextKutu[i, k].Top = top;
                    TextKutu[i, k].Width = 50;
                    TextKutu[i, k].Text = "";
                    this.Controls.Add(TextKutu[i, k]);
                   

                    TextKutu2[i, k] = new TextBox();
                    TextKutu2[i, k].Left = left2;
                    TextKutu2[i, k].Top = top;
                    TextKutu2[i, k].Width = 20;
                    TextKutu2[i, k].Text = "";
                    this.Controls.Add(TextKutu2[i, k]);

                    left += 90;
                    left2 += 90;

                }
                top = top + 60;
                left = 100;
                left2 = 155;
            }

            int labeltop = 120;
            int labelleft = 20;
            for (int i = 0; i < str; i++)
            {
                int k = 0;
                LabelKutu[i, k] = new Label();
                LabelKutu[i, k].Left =labelleft;
                LabelKutu[i, k].Top = labeltop;
                LabelKutu[i, k].Width = 60;
                LabelKutu[i, k].Text = "Fabrika " + (i+1);
                this.Controls.Add(LabelKutu[i, k]);

                labeltop += 60;
            }

            labelleft = 100;
            for (int k = 0; k < stn; k++)
            {
                int i = 0;
                LabelKutu[i, k] = new Label();
                LabelKutu[i, k].Left = labelleft;
                LabelKutu[i, k].Top = 90;
                LabelKutu[i, k].Width = 60;
                LabelKutu[i, k].Text = "Pazar" + (k+1);
                this.Controls.Add(LabelKutu[i, k]);

                labelleft += 90;
            }
        }
        private void MatrisDoldur()
        {
            for (int i = 0; i < str; i++)
            {
                for (int k = 0; k < stn; k++)
                {

                    if(Convert.ToString(TextKutu[i, k].Text).Length != 0)
                    {
                        dizi[i, k] = Convert.ToInt32(TextKutu[i, k].Text);
                    }
                    else
                    {
                        var LabelHataEksik = new Label();
                        LabelHataEksik.Left = 20;
                        LabelHataEksik.Top = 60;
                        LabelHataEksik.Width = 300;
                        LabelHataEksik.Text = "Eksik matris değerleri girdiniz! Bu şekilde kontrol edemezsiniz.";
                        this.Controls.Add(LabelHataEksik);

                    }
                    if(Convert.ToString(TextKutu2[i, k].Text).Length != 0)
                    {
                        dizi2[i, k] = Convert.ToInt32(TextKutu2[i, k].Text);
                    }
                }           
            }
            //TextKutu[1, 1].Text = Convert.ToString(dizi[0, 0] + dizi2[1, 1]);
        }
        private void DiziDoldur(int a, int b)
        {
            for (int i = 0; i < a; i++)
            {
                for (int k = 0; k < b; k++)
                {
                    dizi[i, k] = -1;
                    dizi2[i, k] = -1;
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            KutuOlustur();
            button1.Hide();
            button2.Show();
            //MatrisHesapla();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MatrisDoldur();
        }
    }
}
