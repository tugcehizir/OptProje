using System;
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
        string strdeger, stndeger;
        int str = 0, stn = 0;
        int[,] dizi;
        int[,] dizi2;
        TextBox[,] TextKutu;
        TextBox[] TextKutuBos;
        TextBox[,] TextKutu2;
        Label[,] LabelKutu;
        Label[] LabelArz;
        Label[] LabelTalep;
        int[] U,V,O;
        int arztplm = 0, taleptplm = 0;
       
        public Form1()
        {
            InitializeComponent();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }
        private void ZminHesap()
        {
            //Yeni label oluşturmak***
            //Label label = new Label();
            //label.Top = 100;
            //label.Left = 100;
            //label.Width = 100;
            //label.Text = "label1";

            //this.Controls.Add(label);

            int toplam = 0;
            for (int i = 0; i < str; i++)
            {
                for (int k = 0; k < stn; k++)
                {
                    if (dizi2[i, k] != -1)
                    {
                       
                        toplam += dizi2[i, k] * dizi[i, k];
                    }
                    label3.Text = Convert.ToString("Zmin: " + toplam);
                }
            }
            
        }
        private void KutuOlustur()
        {
            str = Convert.ToInt32(textBox1.Text);
            stn = Convert.ToInt32(textBox2.Text);
            strdeger = Convert.ToString(textBox3.Text);
            stndeger = Convert.ToString(textBox4.Text);
            //Dizileri oluşturuyor
            TextKutu = new TextBox[str, stn];
            TextKutuBos = new TextBox[str + stn];
            TextKutu2 = new TextBox[str, stn];
            LabelKutu = new Label[str, stn];
            LabelArz = new Label[stn+1];
            LabelTalep = new Label[str + 1];
            U = new int[str];
            V = new int[stn];
            O = new int[str * stn];

            dizi = new int[str, stn];
            dizi2 = new int[str, stn];
            DiziDoldur(str, stn);
            
            //Formdaki Textboxlar oluşturuluyor
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
           //arz talep satır sütunu1
                TextKutuBos[i] = new TextBox();
                TextKutuBos[i].Left = left;
                TextKutuBos[i].Top = top;
                TextKutuBos[i].Width = 50;
                TextKutuBos[i].Text = "";
                this.Controls.Add(TextKutuBos[i]);


                top = top + 60;
                left = 100;
                left2 = 155;

            }
            
            //arz talep satır sütunu
            for (int i = 0; i < str+1 ; i++)
            {

                TextKutuBos[i] = new TextBox();
                TextKutuBos[i].Left = left;
                TextKutuBos[i].Top = top;
                TextKutuBos[i].Width = 50;
                TextKutuBos[i].Text = "";
                this.Controls.Add(TextKutuBos[i]);

                left += 90;
               
            }
            
         
            //Formdaki labellar oluşturuluyor
            int labeltop = 120;
            int labelleft = 20;
            for (int i = 0; i < str; i++)
            {
                int k = 0;
                LabelKutu[i, k] = new Label();
                LabelKutu[i, k].Left =labelleft;
                LabelKutu[i, k].Top = labeltop;
                LabelKutu[i, k].Width = 60;
                LabelKutu[i, k].Text = strdeger + (i+1) ;
                this.Controls.Add(LabelKutu[i, k]);
                
                labeltop += 60;
            }
            for (int k = str; k < str + 1; k++)
            {
                
                LabelArz[k] = new Label();
                LabelArz[k].Left = labelleft;
                LabelArz[k].Top = labeltop;
                LabelArz[k].Width = 60;
                LabelArz[k].Text = "Talep";
                this.Controls.Add(LabelArz[k]);

            }
            labelleft = 100;
            for (int k = 0; k < stn; k++)
            {

                int i = 0;
                LabelKutu[i, k] = new Label();
                LabelKutu[i, k].Left = labelleft;
                LabelKutu[i, k].Top = 90;
                LabelKutu[i, k].Width = 60;
                LabelKutu[i, k].Text = stndeger + (k+1);
                this.Controls.Add(LabelKutu[i, k]);

                labelleft += 90;
                
            }
            for (int i = stn; i < stn+1; i++)
            {
               
                LabelArz[i] = new Label();
                LabelArz[i].Left = labelleft;
                LabelArz[i].Top = 90;
                LabelArz[i].Width = 60;
                LabelArz[i].Text = "Arz";
                this.Controls.Add(LabelArz[i]);
                
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
            // TextKutu[1, 1].Text = Convert.ToString(dizi[0, 0] + dizi2[1, 1]);
            for (int i = 0; i < str; i++)
            {
                U[i] = -25;
            }
            for (int i = 0; i < stn; i++)
            {
                V[i] = -25;
            }
            MatrisHesapla();
            OptimumHesapla();
            ZminHesap();
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
        private void MatrisHesapla()
        {
            //Buraya geldi1
            U[0] = 0;
            
            for (int p = 0; p < 5; p++)
            {
                for (int i = 0; i < str; i++)
                {
                    for (int k = 0; k < stn; k++)
                    {
                        if (dizi2[i,k] != -1)
                        {
                           
                            if (-25 != U[i]) {
                                V[k] = dizi[i, k] - U[i];
                             //   TextKutu[i,k].Text = Convert.ToString(V[k] + "+" + k );
                            }
                            if (-25 != V[k])
                            {
                                U[i] = dizi[i, k] - V[k];
                              // TextKutu[i, k].Text = Convert.ToString(U[i] + "-" + i);
                            }
                        }
                    }
                }
               
            }//u0 u 1 v1 v3
            //LabelKutu[0, 0].Text = Convert.ToString(U[0]);
            //LabelKutu[1, 0].Text = Convert.ToString(U[1]);
            //LabelKutu[2, 0].Text = Convert.ToString(U[2]);
            //LabelKutu[3, 0].Text = Convert.ToString(U[3]);
            //LabelKutu[0, 0].Text = Convert.ToString(V[0]);
            //LabelKutu[0, 1].Text = Convert.ToString(V[1]);
            //LabelKutu[0, 2].Text = Convert.ToString(V[2]);
            //LabelKutu[0, 3].Text = Convert.ToString(V[3]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult tus;
            tus = colorDialog1.ShowDialog();
            if (tus == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

      

        private void OptimumHesapla()
        {
            int a = 0;
            for (int i = 0; i < str; i++)
            {
                for (int k = 0; k < stn; k++)
                {
                    if (dizi2[i, k] == -1)
                    {
                        O[a] = dizi[i, k] - (U[i] + V[k]);

                      //  TextKutu[i, k].Text = Convert.ToString(O[a]);
                        a++;
                    }
                }
            }
            for (int i = 0; i < a; i++)
            {
                if(O[a] < 0)
                {
                    var LabelHata = new Label();
                    LabelHata.Left = 20;
                    LabelHata.Top = 60;
                    LabelHata.Width = 500;
                    LabelHata.Text = "Bu çözüm optimum yol değildir. En iyi sonuç bulunamadı. Negatif değer var.";
                    this.Controls.Add(LabelHata);
                }
            }
            var LabelDogru = new Label();
            LabelDogru.Left = 20;
            LabelDogru.Top = 60;
            LabelDogru.Width = 500;
            LabelDogru.Text = "Bu çözüm optimum yoldur. En iyi sonuç bulundu. Tüm değerler pozitif ya da 0.";
            this.Controls.Add(LabelDogru);
            
        }
                        
        private void button1_Click(object sender, EventArgs e)
        {
            KutuOlustur();
            button1.Hide();
            button2.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MatrisDoldur();
           
        }
    }
}
