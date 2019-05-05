using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    public class Obavijest
    {
        private string tekstObavijesti;
        private string IDKlijenta;
        private DateTime dateTimeObavijesti;

        public Obavijest(string tekstObavijesti, string iDKlijenta, DateTime dateTimeObavijesti)
        {
            this.tekstObavijesti = tekstObavijesti;
            IDKlijenta = iDKlijenta;
            this.dateTimeObavijesti = dateTimeObavijesti;
        }

        public string TekstObavijesti { get => tekstObavijesti; set => tekstObavijesti = value; }
        public string IDKlijenta1 { get => IDKlijenta; set => IDKlijenta = value; }
        public DateTime DateTimeObavijesti { get => dateTimeObavijesti; set => dateTimeObavijesti = value; }

        public override string ToString()
        {
            return TekstObavijesti + ", " + IDKlijenta + ", " + DateTimeObavijesti;
        }
    }
}
