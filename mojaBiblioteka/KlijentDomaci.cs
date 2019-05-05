using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    public class KlijentDomaci : Klijent
    {
        
        public KlijentDomaci(string ime, string prezime, DateTime datumRodjenja, string iD, double stanjeNaRacunu) : base(ime, prezime, datumRodjenja, iD, stanjeNaRacunu)
        {
        }
        

        public override void platiKauciju()
        {
            StanjeNaRacunu -= 50;
        }
        public override void povratNovca()
        {
            StanjeNaRacunu += 50;
        }
    }
}
