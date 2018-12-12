using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivali
{
    class Program
    {
        static List<Festival> festivali = new List<Festival>();

        static void Main(string[] args)
        {
            int brojFestivala;

            do
            {
                Console.WriteLine("Koliko festivala? ");
            }
            while (!int.TryParse(Console.ReadLine(), out brojFestivala)); // validacija

            Unos(brojFestivala);

            Ispis(festivali);

            Console.ReadLine();
        }

        static void Ispis(List<Festival> festivali)
        {
            Console.Write("FILM = ");

            foreach (var f in festivali)
            {
                Console.Write($"\n{f.Ime}: ");

                foreach (var o in f.Odrzavanja)
                {
                    Console.Write($"<{o.GodinaOdrzavanja}, {o.BrojFilmova}>, ");
                }

                Console.Write($"Avg={f.ProsjekFilmova};");
            }
        }

        static void Unos(int brojFestivala)
        {
            // Unos festivala
            for (int i = 0; i < brojFestivala; i++)
            {
                int brojOdrzavanja;
                Festival festival = new Festival();

                Console.WriteLine($"Ime {i + 1}. festivala?");
                festival.Ime = Console.ReadLine();

                do
                {
                    Console.WriteLine($"Broj odrzavanja {i + 1}. festivala ({festival.Ime}): ");
                } while (!int.TryParse(Console.ReadLine(), out brojOdrzavanja)); // validacija

                // Unos godine odrzavanja i broja filmova prikazanih te godine 
                // za svaku pojedinacnu godinu odrzavanja festivala
                for (int j = 0; j < brojOdrzavanja; j++)
                {
                    string godinaOdrzavanja = "";
                    int brojFilmova;

                    do
                    {
                        Console.WriteLine($"{j + 1}. godina odrzavanja festivala \"{festival.Ime}\":");
                        godinaOdrzavanja = Console.ReadLine();
                    } while (string.IsNullOrWhiteSpace(godinaOdrzavanja)); // validacija

                    do
                    {
                        Console.WriteLine($"Broj filmova prikazanih {i + 1}. godine:");
                    } while (!int.TryParse(Console.ReadLine(), out brojFilmova)); // validacija

                    festival.Odrzavanja.Add(new Odrzavanje
                    {
                        GodinaOdrzavanja = godinaOdrzavanja,
                        BrojFilmova = brojFilmova
                    });
                }

                festivali.Add(festival);
            }
        }
    }

    class Festival
    {
        public string Ime { get; set; }
        public List<Odrzavanje> Odrzavanja { get; set; } = new List<Odrzavanje>();
        public float ProsjekFilmova
        {
            get
            {
                float sum = 0f;

                foreach (var o in Odrzavanja)
                {
                    sum += o.BrojFilmova;
                }

                return sum / Odrzavanja.Count;
            }
        }
    }

    class Odrzavanje
    {
        public string GodinaOdrzavanja { get; set; }
        public int BrojFilmova { get; set; }
    }
}
