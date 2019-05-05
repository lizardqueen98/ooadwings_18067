using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    abstract class AvionPutnicki : Avion
    {
        public AvionPutnicki(string vrsta, int brojSjedista, string iD) : base(vrsta, brojSjedista, iD)
        {
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            return base.Equals(obj);
        }

        public abstract override void obracunPlacanje(Let let);

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
