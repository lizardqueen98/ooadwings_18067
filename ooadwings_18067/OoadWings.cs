using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    class OoadWings : IPretraga
    {
        private List<Avion> avioni = new List<Avion>();
        private List<Klijent> klijenti = new List<Klijent>();
        private List<Let> letovi = new List<Let>();

        public List<Avion> Avioni { get => avioni; set => avioni = value; }
        public List<Klijent> Klijenti { get => klijenti; set => klijenti = value; }
        public List<Let> Letovi { get => letovi; set => letovi = value; }

        public List<Avion> nadjiAvionPoID(string ID)
        {
            List<Avion> moguciAvioni = new List<Avion>();
            foreach(Avion a in avioni)
            {
                if (a.ID.Equals(ID)) moguciAvioni.Add(a);
            }
            if (moguciAvioni.Count != 0) return moguciAvioni;
            return null;
        }

        public List<Avion> nadjiAvionPoInfo(Avion avion)
        {
            List<Avion> moguciAvioni = new List<Avion>();
            foreach (Avion a in avioni)
            {
                if (a.Equals(avion)) moguciAvioni.Add(a);
            }
            if (moguciAvioni.Count != 0) return moguciAvioni;
            return null;
        }
        public void dodajKlijenta(Klijent klijent)
        {
            Klijenti.Add(klijent);
        }
        public void dodajAvion(Avion avion)
        {
            Avioni.Add(avion);
        }
        public void dodajLet(Let let)
        {
            Letovi.Add(let);
        }
        public Klijent dajKlijentaSaIdem(string id)
        {
            foreach(Klijent klijent in klijenti)
            {
                if (klijent.ID.Equals(id)) return klijent;
            }
            throw new ArgumentException("Niste klijent kompanije.");
        }
        public void napuni()
        {
            List<string> drzave = new List<string>();
            drzave.Add("BiH");
            drzave.Add("UK");
            drzave.Add("USA");
            Avion teretni = new AvionTeretni("Lufthansa", 200, "12e332vre", 3);
            Avion inostranstvo = new AvionInostranstvo("Easy Jet", 100, "adai2n699", drzave);
            Avion domaciAvion = new AvionUnutarZemlje("FlyBosnia", 300, "227gqw4op");
            dodajAvion(teretni);
            dodajAvion(inostranstvo);
            dodajAvion(domaciAvion);
            Klijent domaciKlijent = new KlijentDomaci("Nadija", "Borovina", new DateTime(1998, 8, 21), "nb1998", 11500);
            Klijent strani = new KlijentStrani("Liam", "Alford", new DateTime(1998, 5, 13), "la1998", 12000, "Dublin", "UK");
            dodajKlijenta(domaciKlijent);
            dodajKlijenta(strani);
            domaciKlijent.platiKauciju();
            strani.platiKauciju();
            Let let1 = new Let(inostranstvo, strani, new DateTime(2019, 5, 1), new DateTime(2019, 5, 10));
            Let let2 = new Let(domaciAvion, domaciKlijent, new DateTime(2019, 5, 3), new DateTime(2019, 5, 6));
            dodajLet(let1);
            dodajLet(let2);
        }
    }
}
