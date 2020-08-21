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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Takip
{
    static class Program
    {      
        /// Uygulamanın ana girdi noktası.     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
