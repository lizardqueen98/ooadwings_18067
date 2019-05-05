using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    class AvionUnutarZemlje : AvionPutnicki
    {
        public AvionUnutarZemlje(string vrsta, int brojSjedista, string iD) : base(vrsta, brojSjedista, iD)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override void obracunPlacanje(Let let)
        {
            let.Klijent.StanjeNaRacunu -= let.dajDaneKoristenja() * 120;
            if (let.iznajmljenZaVikend()) let.Klijent.StanjeNaRacunu -= 500;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
