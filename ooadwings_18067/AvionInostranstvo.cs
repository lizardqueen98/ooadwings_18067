using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ooadwings_18067
{
    class AvionInostranstvo : AvionPutnicki
    {
        private List<string> drzave = new List<string>();

        public AvionInostranstvo(string vrsta, int brojSjedista, string iD, List<string> drzave) : base(vrsta, brojSjedista, iD)
        {
            this.drzave = drzave;
        }

        public List<string> Drzave { get => drzave; set => drzave = value; }

        public override bool Equals(object obj)
        {
            AvionInostranstvo inostranstvo = obj as AvionInostranstvo;
            bool iste = true;
            if (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            if (drzave.Count == inostranstvo.drzave.Count)
            {
                foreach (string drzava in drzave)
                {
                    if (!inostranstvo.drzave.Contains(drzava))
                    {
                        iste = false;
                    }
                }
            }
            else
            {
                iste = false;
            }
            return base.Equals(obj) && iste;
        }

        public override void obracunPlacanje(Let let)
        {
            let.Klijent.StanjeNaRacunu -= let.dajDaneKoristenja() * 200;
            if (let.iznajmljenZaVikend()) let.Klijent.StanjeNaRacunu -= 1000;
        }

        public override string ToString()
        {
            return base.ToString() + ", Drzave:" + ispisiDrzave();
        }
        public string ispisiDrzave()
        {
            string drz = "";
            foreach(string drzava in drzave)
            {
                drz += " " + drzava;
            }
            return drz;
        }
    }
}
