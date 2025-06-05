using System.Globalization;
namespace CSharp1_zaverecny_projekt_Trida_Studentu;

class Program
{
    public static int NahodneCislo(int a, int b)
    {
        Random generator = new Random();
        return generator.Next(a, b);
    }

    static void Main(string[] args)
    {
        char[] Samohlaska = new char[]
            {
                'a',
                'e',
                'i',
                'o',
                'u',
                'y',
                'a',// v čj nejčastější samohlásky a a e - pro zvýšení pravděpodobnosti výskytu
                'e',
                'a',
                'e',
                'a',
                'a',
                'é',
                'í',
                'á',
            };

            char[] Souhlaska = new char[]
            {
                'b',
                'c',
                'd',
                'h',
                'j',
                'k',
                'l',
                'm',
                'n',
                'p',
                'r',
                's',
                't',
                'v',
                'z',
            };

            int PocetZnakuSlova;
            int SamohlNeboSouhl;
            string Jmeno;
            string Prijmeni;

            Console.WriteLine("Kolik chcete mít ve třídě studentů?");
            int PocetStudentu;
            while (!Int32.TryParse(Console.ReadLine(), out PocetStudentu) || PocetStudentu <= 0)
            
                // pokud uživatel nezadá celé číslo, nebo zadá záporné číslo, tak se program zeptá znovu
            {
                Console.WriteLine("Nezadal/a jste celé kladné číslo počtu studentů.");
            }

            for (int j = 1; j <= PocetStudentu; j++)
            {
                Jmeno = "";
                Prijmeni = "";

                SamohlNeboSouhl = NahodneCislo(0, 2);
                PocetZnakuSlova = NahodneCislo(3, 8);
                Jmeno = PrvniSamNeboSouhl(Samohlaska, Souhlaska, PocetZnakuSlova, SamohlNeboSouhl, Jmeno);
                PocetZnakuSlova = NahodneCislo(3, 8);
                Prijmeni = PrvniSamNeboSouhl(Samohlaska, Souhlaska, PocetZnakuSlova, SamohlNeboSouhl, Prijmeni);

                string SpojeneJmPrijm = Jmeno + " " + Prijmeni;
                TextInfo JmenoPrijmeni = CultureInfo.CurrentCulture.TextInfo;
                SpojeneJmPrijm = JmenoPrijmeni.ToTitleCase(SpojeneJmPrijm);
                Console.WriteLine(SpojeneJmPrijm);
                //SpojeneJmPrijm = "";
            }



            Console.ReadLine();
        }

        private static string PrvniSamNeboSouhl(char[] Samohlaska, char[] Souhlaska, int PocetZnakuSlova, int SamohlNeboSouhl, string Slovo)
        {
            if (SamohlNeboSouhl == 0)
            {
                for (int i = 1; i < PocetZnakuSlova; i += 2)
                {
                    Slovo += Samohlaska[NahodneCislo(0, 12)];// eliminace dlouhých samohlásek na začátku
                    Slovo += Souhlaska[NahodneCislo(0, 15)];
                    Thread.Sleep(73);
                }
                if (PocetZnakuSlova % 2 == 1)
                {
                    Slovo += Samohlaska[NahodneCislo(0, 15)];
                }
            }
            else
            {
                for (int i = 1; i < PocetZnakuSlova; i += 2)
                {
                    Slovo += Souhlaska[NahodneCislo(0, 15)];
                    Slovo += Samohlaska[NahodneCislo(0, 15)];
                    Thread.Sleep(60);
                }
                if (PocetZnakuSlova % 2 == 1)
                {
                    Slovo += Souhlaska[NahodneCislo(0, 15)];
                }
            }

            return Slovo;

    }
}
