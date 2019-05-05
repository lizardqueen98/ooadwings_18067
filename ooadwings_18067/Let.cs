using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    public class Let
    {
        private Avion avion;
        private Klijent klijent;
        private readonly DateTime datumPolaska;
        private DateTime datumPovratka;

        public Let(Avion avion, Klijent klijent, DateTime datumPolaska, DateTime datumPovratka)
        {
            this.avion = avion;
            this.klijent = klijent;
            this.datumPolaska = datumPolaska;
            this.datumPovratka = datumPovratka;
        }

        public Avion Avion { get => avion; set => avion = value; }
        public Klijent Klijent { get => klijent; set => klijent = value; }
        public DateTime DatumPovratka { get => datumPovratka; set => datumPovratka = value; }

        public DateTime DatumPolaska => datumPolaska;
        public int dajDaneKoristenja()
        {
            return (DatumPovratka - DatumPolaska).Days;
        }
        public bool iznajmljenZaVikend()
        {
            if (dajDaneKoristenja() > 5) return true;
            DayOfWeek danPolaska = DatumPolaska.DayOfWeek;
            DayOfWeek danPovratka = DatumPovratka.DayOfWeek;
            if (danPolaska == DayOfWeek.Saturday || danPovratka == DayOfWeek.Saturday || danPolaska == DayOfWeek.Sunday || danPovratka == DayOfWeek.Sunday) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            Let let = obj as Let;
            return let != null &&
                   avion == let.avion &&
                   klijent == let.klijent &&
                   datumPolaska == let.datumPolaska &&
                   datumPovratka == let.datumPovratka;
        }

        public override string ToString()
        {
            return avion + "\n " + klijent + "\n " + datumPolaska + "\n " + datumPovratka;
        }
    }
}
