public class NaruseniSRP
{
    public void GenerirajIzvjestaj(string podaci)
    {
       
    }

    public void PosaljiEmail(string poruka)
    {
        
    }
}
//klasa ima 2 fukcionalnosti 
//trebamo odvojiti to u 2 posebne klase da svaka ima samo 1 funkcionalnost

//narusen LSP
public class Pravokutnik
{
    public virtual void PostaviStranice(double sirina, double visina)
    {
        Sirina = sirina;
        Visina = visina;
    }

    public double Sirina { get; private set; }
    public double Visina { get; private set; }

    public double IzracunajPovrsinu()
    {
        return Sirina * Visina;
    }
}

public class Kvadrat : Pravokutnik
{
    public override void PostaviStranice(double stranica)
    {
        Sirina = stranica;
        Visina = stranica;
    }
}   
//kvadrat treba imat samo jednu vrijednost umjesto 2 kao pravokutnik
//metoda mu postavlja visinu sto je nepotreban podatak i u ovom primjeru nije bitno
//ali sa takvim stvarima zauzimamo vise memorije

public interface NaruseniISP
{
    public void Leti();
    public void Pliva();
}
public class Pingvin : NaruseniISP
{
    public void Leti() 
    {

    }
    public void Pliva()
    { 

    }
}
//inicijalizacijom intefacea moramo koristiti sve njegove metode a u ovom slucaju pingvin ne moze letjeti
//trebamo izdvojiti takve metode koje se ne odnose na sve koji ce nasljediti i napraviti jos jedan interface


Narušavanje Principa Jedinstvene Odgovornosti (SRP) u C#:
csharp
Copy code
public class NaruseniSRP
{
    public void GenerirajIzvjestaj(string podaci)
    {
        // Logika za generiranje izvještaja
    }

    public void PosaljiEmail(string poruka)
    {
        // Logika za slanje emaila
    }
}
U ovom primjeru klasa NaruseniSRP ima dvije odvojene odgovornosti - generiranje izvještaja i slanje emaila. To krši SRP jer klasa treba imati samo jedan razlog za promjenu, a ovdje postoje dva različita razloga (izvještaj i email). Problem je što, ako dođe do promjene u logici generiranja izvještaja ili slanja emaila, morat ćemo mijenjati istu klasu, što otežava održavanje i povećava rizik od pogrešaka.

Narušavanje Principa Otvorenosti/Zatvorenosti (OCP) u C#:
csharp
Copy code
public class NaruseniOCP
{
    public double Izracunaj(List<double> brojevi, string operacija)
    {
        if (operacija == "zbroji")
        {
            return brojevi.Sum();
        }
        else if (operacija == "pomnozi")
        {
            double rezultat = 1;
            foreach (var broj in brojevi)
            {
                rezultat *= broj;
            }
            return rezultat;
        }
        // Dodavanje nove operacije zahtijeva promjenu ove klase
        return 0;
    }
}
U ovom primjeru klasa NaruseniOCP krši OCP jer nije otvorena za proširenje. Ako želimo dodati novu operaciju poput "podijeli", moramo mijenjati postojeću klasu dodavanjem novog else if bloka. Bolje rješenje bilo bi koristiti strategijski oblikovani uzorak, gdje bi svaka operacija bila zasebna klasa koja implementira zajedničko sučelje.

Narušavanje Liskov Substitucijskog Principa (LSP) u C#:
csharp
Copy code
public class Pravokutnik
{
    public virtual void PostaviStranice(double sirina, double visina)
    {
        Sirina = sirina;
        Visina = visina;
    }

    public double Sirina { get; private set; }
    public double Visina { get; private set; }

    public double IzracunajPovrsinu()
    {
        return Sirina * Visina;
    }
}

public class Kvadrat : Pravokutnik
{
    public override void PostaviStranice(double stranica)
    {
        Sirina = stranica;
        Visina = stranica;
    }
}
Ovaj primjer krši LSP jer metoda PostaviStranice u klasi Kvadrat mijenja ponašanje naspram metode u baznoj klasi Pravokutnik. Očekivanje bi trebalo biti da nasljeđivanje ne mijenja ponašanje, ali u ovom slučaju mijenja (kvadrat bi trebao imati jednaku širinu i visinu, ali metoda postavljanja stranica mijenja i visinu).

Narušavanje Principa Razdvajanja Sučelja (ISP) u C#:
csharp
Copy code
public interface IPoslovniProces
{
    void PokreniProces();
    void ObradiPodatke();
}

public class NaruseniISP : IPoslovniProces
{
    public void PokreniProces()
    {
        // Logika pokretanja poslovnog procesa
    }

    public void ObradiPodatke()
    {
        // Logika obrade podataka
    }
}
Ovaj primjer krši ISP jer klasa NaruseniISP implementira sučelje koje sadrži dvije metode, ali možda neke klase koje implementiraju to sučelje neće trebati obe metode. Svaka klasa koja implementira sučelje mora implementirati sve njegove metode, što može dovesti do nepotrebnih ili praznih implementacija.

//naruseni dip
public class Svijetlo
{
    public void Upali()
    {
      
    }
}

public class Prekidac
{
    private Svijetlo svijetlo;

    public Prekidac()
    {
        svijetlo = new Svijetlo();
    }

    public void Pritisni()
    {
        
        svijetlo.Upali();
    }
}
//cvrsta sprega
//klase moraju ovisi o apstrakciji

