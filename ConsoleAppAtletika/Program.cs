List<Eredmeny> eredmenyek =new List<Eredmeny>(); //ebbe a listába kerülnek majd a beolvasott és szétdarabolt adatok

Beolvasas();

//hány eredmény van a listában
Console.WriteLine($"1.feladat: A listában {eredmenyek.Count} eredmeny van.");


//rúdugrásban hány első helyezett van
int rudugrasElsoHelyezettjei = eredmenyek.Where(x=>x.Versenyszam=="rúdugrás")
                                         .Where(x=>x.Helyezes==1)
                                         .Count();
Console.WriteLine($"2.feladat: A rúdugrás első helyet {rudugrasElsoHelyezettjei} értek el.");


//sportáganként hány eredmény van a listában /szótár
Dictionary<string, int> szotar = new Dictionary<string, int>();
int darabszam = 0; //ez a versenyszámok darabszámának eltárolására kell

List<string> versenyszamok =eredmenyek.Select(x=>x.Versenyszam)
                                      .Distinct() //csak1szer
                                      .ToList(); //kikeresek minden eredményt egy listába, de úgy, h csak 1szer forduljon elő

foreach (string versenyszam in versenyszamok) //megkeressük, h az eredmények halmazban hányszor fordul elő egy-egy versenyszám
{ 
    darabszam = eredmenyek.Count(x=>x.Versenyszam==versenyszam); //végignézzük az eredmények listát és megállunk minden kigyűjtött versenyszámnál és megszámoljuk az előfordulását a teljes eredmények listában
    szotar.Add(versenyszam, darabszam);     //hozzáadjuk az egyes versenyszámokat és a hozzájuk tartozó dbszámokat a szótárhoz

}
Console.WriteLine($"3.feladat: Versenyszámok száma:");
foreach(KeyValuePair<string, int> elem in szotar)
{
    Console.WriteLine($"-{elem.Key} : {elem.Value}");
}


//másik megoldás szótár nélkül:
Console.WriteLine($"3.feladat: Versenyszámok száma:");

int darabszam2 = 0;

List<string> versenyszamok2 = eredmenyek.Select(x => x.Versenyszam)
                                        .Distinct() 
                                        .ToList(); 
foreach (string versenyszam2 in versenyszamok) 
{
    darabszam2 = eredmenyek.Count(x => x.Versenyszam == versenyszam2);
    Console.WriteLine($"-{versenyszam2} : {darabszam2}");

}



Console.ReadKey();

void Beolvasas()
{
    Eredmeny eredmeny = null; //minden sorból kell csinálni egy eredményt, vagyis tovább kell bontani
    string[] egySorAdatai = null; //string típusú tömb


    string[] allLines = File.ReadAllLines("eredmenyek.txt"); //beolvassa a szöveges állomány minden egyes sorát, minden egyes elem ebben a tömbben egy sor 

    foreach (string line in allLines) //végig kell lépkedni az összes soron egyesével és minden egyes sort szét kell darabolni
    {
        egySorAdatai = line.Split('\t'); //a tabulátornál darabolom fel, mert az exportálásnál így állítottam be, hogy tabulátor legyen az egyes adatok között

        eredmeny = new Eredmeny(); //megmondom, hogy az Eredmeny osztály melyik adattagja a sor hányadik eleme.
        eredmeny.Nev = egySorAdatai[0];
        eredmeny.Ev = int.Parse(egySorAdatai[1]); //alapból stringek érkeznek, tehát amitől azt várjuk, hogy szám legyen, azt át kell alakítani számmá
        eredmeny.Orszag = egySorAdatai[2];
        eredmeny.Varos = egySorAdatai[3];
        eredmeny.Versenyszam = egySorAdatai[4];
        eredmeny.Helyezes = int.Parse(egySorAdatai[5]);

        eredmenyek.Add(eredmeny);
    }
}
