using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YONETMENLER_VE_FILMLER_2D_ARRAY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Yönetmen: Quentin Tarantino - Filmler: Pulp Fiction, Kill Bill, Desperado

            //Yönetmen: Steven Spielberg - Filmler: Shindler's List, E.T, Saving Private Ryan

            //Yönetmen: Nuri Bilge Ceylan - Filmler: Kış Uykusu, Ahlat Ağacı, Uzak

            //Yönetmen: Clint Eastwood - Filmler: Million Dollar Baby


            string[] yonetmenler = YonetmenDizisiOlustur("Quentin Tarantino", "Steven Spielberg", "Nuri Bilge Ceylan", "Clint Eastwood");
            string[,] yonetmenlerVeFilmleri = YonetmenVeFilmleriDizisiOlustur(ref yonetmenler);
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Quentin Tarantino", "Pulp Fiction", "Kill Bill", "Desperado");
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Steven Spielberg", "Shindler's List", "E.T", "Saving Private Ryan");
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Nuri Bilge Ceylan", "Kış Uykusu", "Ahlat Ağacı", "Uzak");
            YonetmenlereFilmEkle(ref yonetmenlerVeFilmleri, "Clint Eastwood", "Million Dollar Baby");
            string girilen = string.Empty;
            do
            {
                EkranaYonetmenYaz("Lütfen bir yönetmen seçiniz (Birden fazla yönetmen seçerken , kullanabilrisiniz 'büyük-küçük harf önemli değildir'): \n", yonetmenler);
                Console.WriteLine(new string('-', 100));
                girilen = Console.ReadLine().ToLower().Trim();
                Console.WriteLine(new string('-', 100));
                string[] girilenDizisi = girilen.Split(',');
                for (int i = 0; i < girilenDizisi.Length; i++)
                {
                    girilenDizisi[i] = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(girilenDizisi[i].Trim());
                }
                if (yonetmenler.Intersect(girilenDizisi).Count() > 0)
                {
                    EkranaYonetmeninFilmleriniYaz(yonetmenlerVeFilmleri, girilenDizisi);
                }
                else if (girilen == "çık")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Böyle bir yönetmen bulunmamaktadır. Çıkmak için çık yazabilirsiniz!");
                    Console.WriteLine(new string('-', 100));
                }
            } while (girilen != "çık");

            Console.WriteLine("Uygulamamızı kullandığınız için teşekkür ederiz!");


        }

        private static void EkranaYonetmeninFilmleriniYaz(string[,] yonetmenlerVeFilmleri, params string[] yonetmenadi)
        {
            bool breakLoops = false;
            for (int i = 0; i < yonetmenlerVeFilmleri.GetLength(0); i++)
            {
                for (int index = 0; index < yonetmenadi.Length; index++)
                {
                    if (yonetmenlerVeFilmleri[i, 0] == yonetmenadi[index])
                    {
                        Console.WriteLine(yonetmenadi[index] + "'in filmleri : ");
                        Console.WriteLine(new string('-', 100));
                        for (int j = 0; j < yonetmenlerVeFilmleri.GetLength(1) - 1; j++)
                        {
                            if (!string.IsNullOrEmpty(yonetmenlerVeFilmleri[i, j + 1]))
                            {
                                Console.WriteLine(yonetmenlerVeFilmleri[i, j + 1]);
                                Console.WriteLine(new string('-', 100));
                            }
                        }
                    }
                }
            }
                
           
        }

        static string[] YonetmenDizisiOlustur(params string[] yonetmenler)
        {
            return yonetmenler;
        }

        static string[,] YonetmenVeFilmleriDizisiOlustur(ref string[] yonetmenler)
        {
            string[,] yonetmenlerVeFilmleri = new string[yonetmenler.Length,1];

            for (int i = 0; i < yonetmenler.GetLength(0); i++)
            {
                yonetmenlerVeFilmleri[i,0] =  yonetmenler[i];
            }

            return yonetmenlerVeFilmleri;

        }

        static void YonetmenlereFilmEkle(ref string[,] yonetmenlerVeFilmleri, string yonetmenadi, params string[] filmler)
        {
            string[,] yeniDizi = yonetmenlerVeFilmleri;
            int index;
            for (index = 0; index < yonetmenlerVeFilmleri.GetLength(0); index++)
            {
                if (yonetmenlerVeFilmleri[index, 0] == yonetmenadi)
                {
                    break;
                }
            }

            int filmEklenmedenOncekiHal = yonetmenlerVeFilmleri.GetLength(1);
            int bosluklariSay = 0;
            for (int i = 0; i < filmEklenmedenOncekiHal; i++)
            {
                if (string.IsNullOrEmpty(yonetmenlerVeFilmleri[index, i]))
                {
                    bosluklariSay++;
                }
            }
            int gerekenBosluk = 0;
            if (bosluklariSay < filmler.Length)
            {
                gerekenBosluk = filmler.Length - bosluklariSay;
                yeniDizi = new string[yonetmenlerVeFilmleri.GetLength(0), yonetmenlerVeFilmleri.GetLength(1) + gerekenBosluk];
                for (int i = 0; i < yonetmenlerVeFilmleri.GetLength(0); i++)
                {
                    for (int j = 0; j < yonetmenlerVeFilmleri.GetLength(1); j++)
                    {
                        yeniDizi[i, j] = yonetmenlerVeFilmleri[i, j];
                    }
                }
            }

            int filmSayaci = 0;
            for (int i = 0; i < yeniDizi.GetLength(1); i++)
            {
                if (string.IsNullOrEmpty(yeniDizi[index, i]))
                {
                    yeniDizi[index, i] = filmler[filmSayaci];
                    filmSayaci++;
                    if (filmSayaci == filmler.Length)
                    {
                        break;
                    }
                }
                yonetmenlerVeFilmleri = yeniDizi;

            }

        }
        static void EkranaYonetmenYaz(string mesaj, params string[] yonetmenler)
        {
            string yonetmenlerSiralandi = string.Empty;
            for (int i = 0; i < yonetmenler.Length; i++)
            {
                if (i < yonetmenler.Length - 1)
                {
                    yonetmenlerSiralandi += yonetmenler[i] + ", ";
                }
                else
                {
                    yonetmenlerSiralandi += yonetmenler[i];
                }

            }

            Console.WriteLine(mesaj + yonetmenlerSiralandi);
        }


    }
}
