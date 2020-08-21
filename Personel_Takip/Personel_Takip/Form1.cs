
/****************************************************************************
**                      SAKARYA ÜNİVERSİTESİ
**              BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                  NESNEYE DAYALI PROGRAMLAMA DERSİ
**                      2019-2020 YAZ DÖNEMİ
**
**                     ÖDEV NUMARASI..........: 01
**                     ÖĞRENCİ ADI............: Davud Günay
**                     ÖĞRENCİ NUMARASI.......: b171200031
**                     DERSİN ALINDIĞI GRUP...: A
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//System.Data.OleDb Kütüphanesini ekliyorum
using System.Data.OleDb;

namespace Personel_Takip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Veritabanının dosya yolu ile provider nesnesini belirledim:
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Personel.accdb");//dosya veriyolu
                                                                                                                        //değişkenleri tanımlıyorum (heme yerel hem formlar arası değişkenler)

        //formlar arası aktarımda kullandığım değişkenler:
        public static string tcno, adi, soyadi, yetki;

        //yerel değişkenler-yalnızca bu formda geçerli
        int hak = 3; bool durum = false; //kullanıcı eşleştirmesinde true-false

        private void button1_Click(object sender, EventArgs e)
        {
            if (hak!=0) //hak varsa
            {
                baglantim.Open();//veritabanını açıyorum
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar", baglantim);//command sorgu oluşturup,baglantim nesnesi ile ilişkilendiriyorum
               
                //veri okuyucu tanımlama:
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();//select sorgu sonuçlarını (*) hepsini getiriyor,saklıyor

                while(kayitokuma.Read())//okuttuğumda tabloda bilgi varsa true değeri döner,while çalışır
                {
                    if (radioButton1.Checked==true)//yönetici girişi için
                    {
                        //bu durumda girilen yetki,kul.adı ve şifre, veritabanı ile uyuşuyor mu bakıyorum
                        if (kayitokuma["kullaniciadi"].ToString()==textBox1.Text&&kayitokuma["parola"].ToString()==textBox2.Text
                            &&kayitokuma["yetki"].ToString()=="Yönetici")
                        {
                            durum = true;                            //başarılı ise giriş durumu true
                            tcno = kayitokuma.GetValue(0).ToString();//kaydın tcno(tabloda sıfırıncı alanı) verisini almaya yarıyor
                            adi = kayitokuma.GetValue(1).ToString();
                            soyadi = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(3).ToString();
                                                                     //bu bilgiler başka formda kullanılmak üzere aktarılacak
                            this.Hide();                             //giriş başarılı olduğunda bu formu gizle
                            Form2 frm2 = new Form2();                //form2 nesnesi oluşturdum
                            frm2.Show();                             //form2 yi açıyorum
                            break;                                   //while döngüsü loopa girmesin diye sonlandırdım
                        }
                       
                    }
                    if (radioButton2.Checked == true)//kullanıcı girişi için
                    {
                        //bu durumda girilen yetki,kul.adı ve şifre, veritabanı ile uyuşuyor mu bakıyorum
                        if (kayitokuma["kullaniciadi"].ToString() == textBox1.Text && kayitokuma["parola"].ToString() == textBox2.Text
                            && kayitokuma["yetki"].ToString() == "Kullanıcı")
                        {
                            durum = true;                            //başarılı ise giriş durumu true
                            tcno = kayitokuma.GetValue(0).ToString();//kaydın tcno(tabloda sıfırıncı alanı) verisini almaya yarıyor
                            adi = kayitokuma.GetValue(1).ToString();
                            soyadi = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(3).ToString();
                            //bu bilgiler başka formda kullanılmak üzere aktarılacak
                            this.Hide();                             //giriş başarılı olduğunda bu formu gizle
                            Form3 frm3 = new Form3();                //form3 nesnesi oluşturdum
                            frm3.Show();                             //form3 yi açıyorum
                            break;                                   //while döngüsü loopa girmesin diye sonlandırdım
                        }

                    }
                }

                if (durum==false) //kullanıcı adı veya şifre eşleşmesi yoksa hakkı azaltıyorum

                {
                    hak--;
                    baglantim.Close(); //bağlantıyı kapatıyorum

                }

            }
            label5.Text = Convert.ToString(hak); //hak sıfırlanınca mesaj gösterip programı kapatıyorum
            if (hak==0)
                {
                    button1.Enabled = false;         //hak kalmayınca giriş butonunu iptal ettim
                    MessageBox.Show("Giriş Hakkı Kalmadı");
                    this.Close();
                }
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi"; //formun başlık text'i
            this.AcceptButton = button1;//enter tuşuna bastığımda giriş butonuna basacak
            this.CancelButton = button2;//escape tuşu çıkış butonu işlevinde
            label5.Text = Convert.ToString(hak);//kalan hakkı string biçiminde yazacak
            radioButton1.Checked = true;//radiobutton1 default seçili
            this.StartPosition = FormStartPosition.CenterScreen;//form ekranın ortasında çıksın
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;//formun üst işaretlerini görünmez kıldım
        }
    }
}
