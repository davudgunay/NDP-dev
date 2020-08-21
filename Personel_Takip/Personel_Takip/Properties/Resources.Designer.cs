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


namespace Personel_Takip.Properties {
    using System;
    
    
    
    ///   Yerelleştirilmiş dizeleri aramak gibi işlemler için, türü kesin olarak belirtilmiş kaynak sınıfı.
    
    // Bu sınıf ResGen veya Visual Studio gibi bir araç kullanılarak StronglyTypedResourceBuilder
    // sınıfı tarafından otomatik olarak oluşturuldu.
    // Üye eklemek veya kaldırmak için .ResX dosyanızı düzenleyin ve sonra da ResGen
    // komutunu /str seçeneğiyle yeniden çalıştırın veya VS projenizi yeniden oluşturun.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        
        ///   Bu sınıf tarafından kullanılan, önbelleğe alınmış ResourceManager örneğini döndürür.
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Personel_Takip.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        
        ///   Bu türü kesin olarak belirtilmiş kaynak sınıfını kullanarak geçerli iş parçacığının
        ///   CurrentUICulture özelliğini tüm kaynak aramaları için geçersiz kılar.
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
    }
}
