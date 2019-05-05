using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    public class AvionTeretni : Avion
    {
        private int kapacitet;

        public AvionTeretni(string vrsta, int brojSjedista, string iD, int kapacitet) : base(vrsta, brojSjedista, iD)
        {
            this.kapacitet = kapacitet;
        }

        public int Kapacitet { get => kapacitet; set => kapacitet = value; }

        public override bool Equals(object obj)
        {
            AvionTeretni teretni = obj as AvionTeretni;
            return base.Equals(obj) &&
                   kapacitet == teretni.kapacitet;
        }

        public override void obracunPlacanje(Let let)
        {
            let.Klijent.StanjeNaRacunu -= let.dajDaneKoristenja() * 350;
            //sa hiljadu se mnozi jer je kapacitet u tonama
            let.Klijent.StanjeNaRacunu -= kapacitet * 1000 * 0.02;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + kapacitet;
        }
    }
}
