using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ooadwings_18067
{
    public abstract class Avion : IObracun
    {
        private string vrsta;
        private int brojSjedista;
        private string iD;
        private Regex rgx = new Regex("[a-z]|[1-5]*");

        public Avion(string vrsta, int brojSjedista, string iD)
        {
            this.vrsta = vrsta;
            this.brojSjedista = brojSjedista;
            if(!rgx.IsMatch(iD) || iD.Length!=9) throw new ArgumentException("Pogresan ID");
            this.iD = iD;
        }

        public string Vrsta { get => vrsta; set => vrsta = value; }
        public int BrojSjedista { get => brojSjedista; set => brojSjedista = value; }
        public string ID
        {
            get => iD; set
            {
                if (!rgx.IsMatch(iD) || iD.Length != 9) throw new ArgumentException("Pogresan ID");
                iD = value;
            }
        }

        public override bool Equals(object obj)
        {
            Avion avion = obj as Avion;
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            return avion != null &&
                   vrsta == avion.vrsta &&
                   brojSjedista == avion.brojSjedista;
        }

        abstract public void obracunPlacanje(Let let);

        public override string ToString()
        {
            return vrsta + ", " + brojSjedista + ", " + iD;
        }
    }
}
