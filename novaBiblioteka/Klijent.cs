using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    public abstract class Klijent : IKaucija
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private string iD;
        private double stanjeNaRacunu;
        private static List<Obavijest> obavijesti = new List<Obavijest>();

        public Klijent(string ime, string prezime, DateTime datumRodjenja, string iD, double stanjeNaRacunu)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            if (iD.Length!=6) throw new ArgumentException("Pogresan ID");
            this.iD = iD;
            this.StanjeNaRacunu = stanjeNaRacunu;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string ID
        {
            get => iD; set
            {
                if (iD.Length != 6) throw new ArgumentException("Pogresan ID");
                iD = value;
            }
        }
        public static List<Obavijest> Obavijesti { get => obavijesti; set => obavijesti = value; }
        public double StanjeNaRacunu { get => stanjeNaRacunu; set => stanjeNaRacunu = value; }
        abstract public void platiKauciju();
        abstract public void povratNovca();
        public void dodajObavijest(Obavijest o)
        {
            obavijesti.Add(o);
        }

        public override bool Equals(object obj)
        {
            Klijent klijent = obj as Klijent;
            return klijent != null &&
                   ime == klijent.ime &&
                   prezime == klijent.prezime &&
                   datumRodjenja == klijent.datumRodjenja &&
                   iD == klijent.iD &&
                   stanjeNaRacunu == klijent.stanjeNaRacunu;
        }

        public override string ToString()
        {
            return ime + " " + prezime + " " + iD + " " + datumRodjenja + " " + stanjeNaRacunu;
        }
    }
}
