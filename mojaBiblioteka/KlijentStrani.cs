using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    public class KlijentStrani : Klijent
    {
        private string grad;
        private string drzava;
        

        public KlijentStrani(string ime, string prezime, DateTime datumRodjenja, string iD, double stanjeNaRacunu, string grad, string drzava) : base(ime, prezime, datumRodjenja, iD, stanjeNaRacunu)
        {
            this.grad = grad;
            this.drzava = drzava;
        }

        public string Grad { get => grad; set => grad = value; }
        public string Drzava { get => drzava; set => drzava = value; }
        

        public override void platiKauciju()
        {
            StanjeNaRacunu -= 100;
        }
        public override void povratNovca()
        {
            StanjeNaRacunu += 100;
        }
    }
}
