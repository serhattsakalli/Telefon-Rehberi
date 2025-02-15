using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace Proje_Telefon_Rehberi
{
    internal class Program
    {
        static void Main(string[] args)
        {
             // Başlangıç verileri
            rehber.Add(new Kisi("Ahmet","Kara", "5531111111"));
            rehber.Add(new Kisi("Mehmet","Sakallı", "5522222222"));
            rehber.Add(new Kisi("Ayşe","Fatma", "5563333333"));
            rehber.Add(new Kisi("Fatma","Hayriye", "5584444444"));
            rehber.Add(new Kisi("Ali","Kara", "5599555555"));
            
            while (true)
            {
                Program.Giris();
            var secim=Console.ReadLine();
            switch (secim)
            {
                
                case "1":
                    Kaydet();
                    break;
                case "2":
                    Sil();
                    break;
                case "3":
                    Guncelle();
                    break;
                case "4":
                    Listele();
                    break;
                case "5":
                    Arama();
                    break;
                default:
                Console.WriteLine("Geçersiz Seçenek");
                break;
            }
            }            
            Console.ReadLine();            
        }

        //Listele
        static void Listele()
        {
            Console.Clear();
            List<Kisi> sortedRehber;
            sortedRehber = rehber.ToList();
            foreach (var kisi in sortedRehber)
            {
            Console.WriteLine($"{kisi.Ad} -{kisi.Soyad}- {kisi.TelefonNo}");
            }
        }
        //silme
        static void Sil()
        {                    
            Console.Clear();
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string girilenisim = Console.ReadLine();
        
            if (string.IsNullOrEmpty(girilenisim))
            {
                Console.WriteLine("Lütfen bir değer giriniz.");
                return; // Fonksiyonu sonlandır
            }
            bool kisiBulundu = false; // Bulunan kişi sayısını kontrol etmek için bir bayrak
            for (int i = 0; i < rehber.Count; i++)
            {
                // Ad veya soyad eşleşmesi
                if (rehber[i].Ad.Equals(girilenisim, StringComparison.OrdinalIgnoreCase) || 
                    rehber[i].Soyad.Equals(girilenisim, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)",rehber[i].Ad);
                    string answer=Console.ReadLine();
                    if(answer=="y"||answer=="Y")
                    {
                    rehber.RemoveAt(i); // Kişiyi rehberden çıkar
                    Console.WriteLine("Silme işlemi Başarılı.");
                    kisiBulundu = true;
                    break; // İlk bulduğumuzda döngüden çık
                    } 
                    else
                    break;// İlk bulduğumuzda döngüden çık
                }
            }
        
            if (kisiBulundu==false)
            {
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız");
            Console.WriteLine("* Silmeyi sonlandırmak için: (1)");
            Console.WriteLine("* Yeniden denemek için      : (2)");
            var secim = Console.ReadLine();
        
                switch (secim)
                {
                    case "1":
                        break;                  
                        Sil(); // Yeniden denemek
                    case "2":
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçenek.");
                        break;
                }
            }
        }
        static void Guncelle()
        {
            Console.Clear();
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string arananIsimSoyisim = Console.ReadLine();
            var kisi = rehber.FirstOrDefault(r => r.Ad.Equals(arananIsimSoyisim, StringComparison.OrdinalIgnoreCase) || r.Soyad.Equals(arananIsimSoyisim, StringComparison.OrdinalIgnoreCase));
                if (kisi != null)
                {
                    Console.WriteLine("Lütfen yeni telefon numarasını giriniz");
                    string yeniTelefonNo = Console.ReadLine();
                    kisi.TelefonNo = yeniTelefonNo;
                }
                else
                {
                    Console.WriteLine("isim veya soyisme eş değer bir kayıt bulunamadı");
                    return;
                }

        }
        static void Arama()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.**********************************************");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");
            var secim = Console.ReadLine();
            if (secim == "1")
            {
                Console.WriteLine("Aramak istediğiniz ismi veya soyismi giriniz:");
                string arananIsimSoyisim = Console.ReadLine();
                var kisi = rehber.FirstOrDefault(r => r.Ad.Equals(arananIsimSoyisim, StringComparison.OrdinalIgnoreCase) || r.Soyad.Equals(arananIsimSoyisim, StringComparison.OrdinalIgnoreCase));
                if (kisi != null)
                {
                    Console.WriteLine("Arama Sonuçlarınız: ********************************************** ");
                    Console.WriteLine("İsim: {0}, Soyisim: {1}, Telefon Numarası: {2}", kisi.Ad, kisi.Soyad, kisi.TelefonNo);
                }
                else
                {
                    Console.WriteLine("Aradığınız kişi rehberde bulunamadı.");
                }
            }
            else if (secim == "2")
            {
                Console.WriteLine("Aramak istediğiniz telefon numarasını giriniz:");
                string arananTelefon = Console.ReadLine();
                var kisi = rehber.FirstOrDefault(r => r.TelefonNo.Equals(arananTelefon));
                if (kisi != null)
                {
                    Console.WriteLine("Arama Sonuçlarınız: ********************************************** ");
                    Console.WriteLine("İsim: {0}, Soyisim: {1}, Telefon Numarası: {2}", kisi.Ad, kisi.Soyad, kisi.TelefonNo);
                }
                else
                {
                    Console.WriteLine("Aradığınız telefon numarası rehberde bulunamadı.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçenek.");
            }
        }
        static void Kaydet()
        {
            Console.Clear();
            Console.WriteLine("Lütfen isim giriniz             :");
            string isim=Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz          :");
            string soyisim=Console.ReadLine();
            Console.WriteLine("Lütfen telefon numarası giriniz :");
            string tno=Console.ReadLine();
            rehber.Add(new Kisi(isim,soyisim,tno));

        }
        //Güncelle
    
    // Rehberin listesi
    private static List<Kisi> rehber = new List<Kisi>(); 

     // Kayıtlar için olan sınıf
    public class Kisi
    {
        public string Ad { get; set; }
        public string Soyad{ get; set; }
        public string TelefonNo { get; set; }
        public Kisi(string ad, string soyad ,string telefonNo)
        {
            Ad = ad;
            Soyad=soyad;
            TelefonNo = telefonNo;
        }
    }
        static void Giris()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)******************************************* ");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
        }
    }
}