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
//System.Data.OleDb kütüphanesini tanımlıyorum
using System.Data.OleDb;
//System.Text.RegularExpression-REGEX Kütüphanesini tanımlıyorum-güvenli parola oluşturan hazır kodlar var
using System.Text.RegularExpressions;
//giriş çıkış işlemleri için kütüphane ekliyorum.Input-output amacıyla
using System.IO;

namespace Personel_Takip
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //veritabanı dosya yolu ve provider nesnesi belirlenecek
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Personel.accdb");
       
        //metod tanımlıyorum
        private void kullanicilari_goster()
        {
            //görevi, yeni kullanıcı eklendiğinde datagriidview'de görmemi sağlayacak
            try
            {
                baglantim.Open();
                OleDbDataAdapter kullanicilari_listele = new OleDbDataAdapter("Select tcno AS[TC KİMLİK NO],ad AS[ADI],soyad AS[SOYADI],yetki AS[YETKİ],kullaniciadi AS[KULLANICI ADI],parola AS[PAROLA] from kullanicilar Order By ad ASC", baglantim);
                //tcno,ad soyad gibi sorguları, datagrid'de köşeli parantez içinde belirlediğim şekilde
                //ekleyecek ve ada göre a-z sıralayacak

                DataSet dshafiza = new DataSet(); //bellekte hafıza oluşturdum
                kullanicilari_listele.Fill(dshafiza);  //listeyi bu verilerle doldurmak istiyorum
                dataGridView1.DataSource = dshafiza.Tables[0]; //sorgu sonucunda ilk tabloyu data kaynağına aktarıyıorum
                baglantim.Close();
            }
            catch (Exception hatamsj) //try'da hata oluşursa hatamsj değişkeninde sakla
            {
                MessageBox.Show(hatamsj.Message,"Personel Takip "+MessageBoxIcon.Error);
                baglantim.Close();
            }


        }

        private void personelleri_goster()
        {
            //görevi, yeni kullanıcı eklendiğinde datagriidview'de görmemi sağlayacak
            try
            {
                baglantim.Open();
                OleDbDataAdapter personelleri_listele = new OleDbDataAdapter("Select tcno AS[TC KİMLİK NO],ad AS[ADI],soyad AS[SOYADI],cinsiyet AS[CİNSİYETİ],mezuniyet AS[MEZUNİYETİ],dogumtarihi AS[DOĞUM TARİHİ],gorevi AS[GÖREVİ],gorevyeri AS[GÖREV YERİ],maasi AS[MAAŞI] from personeller Order By ad ASC", baglantim);
                //tcno,ad soyad gibi sorguları, datagrid'de köşeli parantez içinde belirlediğim şekilde
                //ekleyecek ve ada göre a-z sıralayacak

                DataSet dshafiza = new DataSet(); //bellekte hafıza oluşturdum
                personelleri_listele.Fill(dshafiza);  //listeyi bu verilerle doldurmak istiyorum
                dataGridView2.DataSource = dshafiza.Tables[0]; //sorgu sonucunda ilk tabloyu data kaynağına aktarıyıorum
                baglantim.Close();
            }
            catch (Exception hatamsj) //try'da hata oluşursa hatamsj değişkeninde sakla
            {
                MessageBox.Show(hatamsj.Message, "Personel Takip " + MessageBoxIcon.Error);
                baglantim.Close();
            }


        }

        

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //personelleri_goster(); //oluşturduğum metodu çağırıyorum

            //FORM 2 LOADER DÜZENLİYORUM
            //picturebox1 ayarları
            pictureBox1.Height = 150;                                //yükseklik
            pictureBox1.Width = 150;                                 // genişlik
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; //çerçeveye sığdır

            //fotoğraf çağırıyorum

            try
            {
                //form1 deki tcnosu ne ise ilişkilendirilmiş o foto gelecek-foto alımında sorun yaşıyorum
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg");

            }
            catch
            {
                MessageBox.Show("resim yok");
                //pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\resimyok.jpg");
                //hata alırsam resimyok.jpg gelecek
                
            }

            //**************************************KULLANICI İŞLEMLERİ SEKME AYARLARI**********************************************************
            this.Text = "YÖNETİCİ İŞLEMLERİ";
            label12.Text = Form1.adi + Form1.soyadi; //giriş yapanın form1 den adını alacak

            textBox1.MaxLength = 11;//max karakter sınırı
            textBox4.MaxLength = 8; //kullanıcı adı
            toolTip1.SetToolTip(this.textBox1, "TC Kimlik No 11 Karakter olmalı"); //imleci getirince bu uyarıyı verecek
            radioButton1.Checked = true; //yönetici default geldi

            textBox2.CharacterCasing = CharacterCasing.Upper; //ufak bile yazılsa büyük harfe çeviriyor
            textBox3.CharacterCasing = CharacterCasing.Upper;

            textBox5.MaxLength = 10; //parola max. 10 karakter
            textBox6.MaxLength = 10; //parola doğrulama da aynı

            progressBar1.Maximum = 100; //max değeri
            progressBar1.Value = 0; //başlangıç değeri

            kullanicilari_goster(); //kullanıcıları göster metodu çalışsın

            //**************************************PERSONEL İŞLEMLERİ SEKMESİNİN AYARLARI*****************************************************

            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Width = 100; pictureBox2.Height = 100;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;

            maskedTextBox1.Mask = "0000000000"; //benim istediğim biçimde (11 hane) girecek-0 zorunlu rakam demek
            maskedTextBox2.Mask = "LL????????????????????"; //L'ler iki harf karakter, soru işaretleri istediği biçim
            maskedTextBox4.Mask = "0000"; //maaş 4 karakter olmalı
            maskedTextBox2.Text.ToUpper(); //buraya girilen harfleri büyütecek
            maskedTextBox3.Text.ToUpper();

            comboBox1.Items.Add("İLKÖĞRETİM"); //combobox'larda ne seçileceğini belirliyorum
            comboBox1.Items.Add("ORTAÖĞRETİM");
            comboBox1.Items.Add("LİSE");
            comboBox1.Items.Add("LİSANS");

            comboBox2.Items.Add("YÖNETİCİ");
            comboBox2.Items.Add("MEMUR");
            comboBox2.Items.Add("ŞOFÖR");
            comboBox2.Items.Add("İŞÇİ");

            comboBox3.Items.Add("AR-GE");
            comboBox3.Items.Add("BİLGİ İŞLEM");
            comboBox3.Items.Add("MUHASEBE");
            comboBox3.Items.Add("ÜRETİM");
            comboBox3.Items.Add("İNSAN KAYNAKLARI");
            comboBox3.Items.Add("NAKLİYE");

            DateTime zaman = DateTime.Now; //şimdiki zamanı aldı
            int yil = int.Parse(zaman.ToString("yyyy")); //yukarıdan aldığım tarihin yıl kısmını yyyy biçiminde aldım
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            dateTimePicker1.MinDate = new DateTime(1960, 1, 1); //çalışan minimum 1960 yılının birinci ayı ve gününde doğmuş olmalı
            dateTimePicker1.MaxDate =  new DateTime(yil-18,ay,gun);//günümüz tarihinden en fazla 18 yıl önce
            dateTimePicker1.Format = DateTimePickerFormat.Short; //tarih formatı short
            radioButton3.Checked= true; //cinsiyet bay olarak default
            //**********************************************************************************************************************************
                        
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length<11) //tc kimlik no bölümü için kısıtlar giriyorum.11karakterden az girerse error provider devreye giriyor
            {
                errorProvider1.SetError(textBox1, "11 karakter olmalı");
            }

            else
            {
                errorProvider1.Clear(); //hata yoksa kapat
            }


        }

        int parola_skoru = 0; //başlangıç değeri sıfır
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //parola belirlenirken kısıtlamalar yapıyorum
            //parola skoru için değişkenler oluşturuyorum

            string parola_seviyesi = ""; //parolanın güçlü olup olmadığı
            int kucuk_harf_skoru = 0;
            int buyuk_harf_skor = 0;
            int rakam_skoru = 0;
            int sembol_skor = 0;

            string sifre = textBox5.Text;

            //regex kütüphanesinin kullanıldığı kısma geldim
            //türkçe karakterlerde sorun yaşıyor bu nedenle ingilizce karakterlere dönüşmem gerekiyor
            //bu nedenle düzeltilmiş şifre değişkeni tanımlıyorum.
            string duzeltilmis_sifre ="";
            duzeltilmis_sifre = sifre;
           
            //düzeltme işlemi-replace: hangi harfi hangi harfe dönüştürdüğüm:
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('İ', 'I');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ç', 'c');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ğ', 'g');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ı', 'i');
            duzeltilmis_sifre = duzeltilmis_sifre.Replace('ö', 'o');

            //bu harfler çoğaltılabilir...bir kısmını yazdım.çünkü yoruldum ve üşendim.

            if (sifre!=duzeltilmis_sifre)
                 {
                            sifre = duzeltilmis_sifre; //değişiklik yapıldıysa,bu halini al
                            textBox5.Text = sifre;
                            MessageBox.Show("Türkçe karakterler,İngilizceye dönüştürüldü");
                   }

            //parola skorlamada 1 küçük harf 10, daha fazlası 20 puan
            int az_karakter_sayisi = (sifre.Length) - (Regex.Replace(sifre, "[a-z]", "").Length);

            //açıklama: şifrenin toplam uzunluğundan küçük harf karakterler olan uzunluğunu çıkartınca
            //küçük harf karakter sayısını buluyorum ki doğru skorlama yapabileyim.
            //şimdi küçük harf skoru için Math kütüphanesini kullanacağım

            kucuk_harf_skoru = Math.Min(2, az_karakter_sayisi) * 10;
            //küçük harf sayısı x 10 puan

            //büyük harf için:
            int AZ_karakter_sayisi= (sifre.Length) - (Regex.Replace(sifre, "[A-Z]", "").Length);
            buyuk_harf_skor = Math.Min(2, AZ_karakter_sayisi) * 10;

            //sembol ve rakam için de yapılabilir ancak gerek görmedim, bu kısımda kestim
            //yani sadece büyük harf ve küçük harften skorlama yapıyorum
            //programın genel çalışması eklenmeyecek, sadece skorlamaya sembol ve rakamlar girmeyecek
            //sembol bulmak için şifre uzunluğundan bu sefer, hem küçük harf hem de byük harf çıakrırsam
            //sembollerin sayısına ulaşabilirim.
        
                     if (sifre.Length==9)
                        {
                            parola_skoru += 10;
                        }

                    else if (sifre.Length==10)
                         {
                        parola_skoru += 20;
                         }

                    if (kucuk_harf_skoru==0||buyuk_harf_skor==0)
                        {
                            label22.Text = "küçük ve büyük harf kullanmalısın";
                        }

                    if (kucuk_harf_skoru != 0 || buyuk_harf_skor != 0)
                        {
                            label22.Text = "";
                        }

                     if (parola_skoru<50)
                        {
                            parola_seviyesi = "düşük";
                        }
                    else if (parola_skoru>50)
                        {
                            parola_seviyesi = "Uygun";
                        }

            label9.Text = "%" + Convert.ToString(parola_skoru);
            progressBar1.Value = parola_skoru;


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // parolalar eşleşiyor mu, denetimi

            if (textBox6.Text!=textBox5.Text)
                {
                    errorProvider1.SetError(textBox6, "Parola eşleşmiyor");
                }
            else
                {
                    errorProvider1.Clear(); //parola eşleşiyorsa errorprovider'ı temizle
                }


        }

        //***************SEKME TEMİZLEME METODLARI***********************************************
        //kaydet butonuna event ekleme
        //önce metod yazmalıyım: metod,textbox'ların içini temizliyor

        private void topPage1_temizle() //kullanıcı sekmesi
        {
            textBox1.Clear(); textBox2.Clear();textBox3.Clear();textBox4.Clear();
            textBox5.Clear();textBox6.Clear();
        }

        private void topPage2_temizle() //personel sekmesi
        {
            pictureBox2.Image = null;
            maskedTextBox1.Clear(); maskedTextBox2.Clear(); maskedTextBox3.Clear();
            maskedTextBox4.Clear();

            comboBox1.SelectedIndex = -1; //boş olması için eksi 1 atanır
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }
        //**********SEKMELERDEKİ ALANLARIN TEMİZLENME İŞLEMLERİ YAPILMIŞ OLUYOR***********

        //********KAYDET BUTONUNA İŞLEV EKLEME****************
        private void button1_Click(object sender, EventArgs e)
        {
            string yetki = ""; //yetki belirliyorum
            bool kayitkontrol = false; //başlangıç değeri, kayıt yaparken daha önce var mı diye kontrol etsin diye
                                       // false ile başlıyor

            //***************VERİTABANI İŞLEMLERİ******************************************************************************************
            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar where tcno='" + textBox1.Text+ "'",baglantim);

            //kullanıcılar tablosundan tcno nun textbox1'e eşit olan kayıt seçmesini sağladım
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();//sorgu sonucunu aktarma işlemi

                   while (kayitokuma.Read()) //eğer kayıt varsa true yap
                     {
                        kayitkontrol = true;
                        break;
                    }

            baglantim.Close(); //bağlantıyı kapat

                if (kayitkontrol==false) //girilen tcno herhangi bir kayıtta yoksa,kayıt yapılacak
                {
                    //tc no kontrolü yap, yoksa kırmızıya döndür
                    if (textBox1.Text.Length<11 ||textBox1.Text=="")
                        {
                            label1.ForeColor = Color.Red; //kırmızı yap
                        }
                    else 
                        {
                            label1.ForeColor = Color.Black;
                        }

                //ad ve soyadı için veri kontrolünde de
                if (textBox2.Text.Length < 2 || textBox2.Text == "")
                    {
                        label2.ForeColor = Color.Red; //kırmızı yap
                    }
                else
                    {
                        label2.ForeColor = Color.Black;
                    }

                if (textBox3.Text.Length < 2 || textBox3.Text == "")
                    {
                        label3.ForeColor = Color.Red; //kırmızı yap
                    }
                else
                    {
                        label3.ForeColor = Color.Black;
                    }

                //**************KAYIT İŞLEMLERİNİN YAPILMASI*****************

                if (textBox1.Text.Length==11&&textBox1.Text!=""&&textBox2.Text!=""&&textBox2.Text.Length>1
                    &&textBox3.Text!=""&&textBox5.Text!=""&&textBox6.Text!=""&&textBox5.Text==textBox6.Text)

                    //yukarıdakiler sağlanıyorsa kayıt işlemlerini gerçekleştir
                {
                    if (radioButton1.Checked==true)
                        {
                            yetki = "Yönetici";
                        }
                    else if (radioButton2.Checked == true)
                        {
                            yetki = "Kullanıcı";
                        }

                    try
                        {
                            baglantim.Open();
                            OleDbCommand eklekomutu=new OleDbCommand("insert into kullanicilar values ('"+textBox1.Text+ "','" + textBox2.Text + "','"+textBox3.Text + "','" + textBox4.Text+ "','"+ textBox5.Text+ "')",baglantim);
                            eklekomutu.ExecuteNonQuery(); //ekle komutu sonuçlarını işlemek için
                            baglantim.Close();

                            MessageBox.Show("yeni kullanıcı oluşturuldu","Personel Takip Programı",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); //mesaj uygulandığını söyler
                            topPage1_temizle();//yukarıda oluşturduğum temizleme metodunu kullanıyorum. sürekli kullanacağım.

                        }

                    catch (Exception hatamsj)
                        {

                            MessageBox.Show(hatamsj.Message);
                            baglantim.Close();

                            //hata oluşsa da oluşmasa da veritabanı bağlantısını kapatmam lazım
                        }

                }

                //en üstteki if'in else'sine devam; en üstteki kriterler sağlanmamışsa else blogu girer

                   else
                        {
                            MessageBox.Show("Verileri istenen şekilde giriniz");
                        }

            }
                    else
                    {
                        MessageBox.Show("Girilen TC Kimlok No, daha önceden kayıtlı");
                    }




        }
    }
}
