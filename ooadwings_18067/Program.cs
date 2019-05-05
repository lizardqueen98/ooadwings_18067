using System;
using System.Collections.Generic;

namespace ooadwings_18067
{
    class Program
    {
        public static OoadWings ooadWings = new OoadWings();
        static void Main(string[] args)
        {
            ooadWings.napuni();

            //unos vozila, unos klijenta, iznajmljivanje, povrat
            //aviona i plaćanje, ispis liste obavijesti

            bool nijeKraj = true;

            while (nijeKraj)
            {
                Console.WriteLine("Unesite:\n1-za unos aviona\n2-za unos klijenta\n3-za iznajmljivanje aviona\n4-za povrat aviona i placanje\n5-za ispis liste obavijesti\n6-za listu svih letova\n7-lista svih aviona i klijenata\n8-za izlaz iz programa");
                int n;
                Int32.TryParse(Console.ReadLine(), out n);
                //Console.WriteLine("Unesi {0} brojeva:", n);
                switch (n)
                {
                    case 1:
                        {
                            try
                            {
                                Console.WriteLine("Unesite vrstu:");
                                string vrsta = Console.ReadLine();
                                Console.WriteLine("Unesite broj sjedista:");
                                int brojSjedista;
                                Int32.TryParse(Console.ReadLine(), out brojSjedista);
                                Console.WriteLine("Unesite ID:");
                                string ID = Console.ReadLine();
                                Console.WriteLine("Unesite T za teretni, P za putnicki avion:");
                                string tip = Console.ReadLine();
                                if (tip.Equals("T"))
                                {
                                    Console.WriteLine("Unesite kapacitet u tonama:");
                                    int kapacitet;
                                    Int32.TryParse(Console.ReadLine(), out kapacitet);
                                    ooadWings.dodajAvion(new AvionTeretni(vrsta, brojSjedista, ID, kapacitet));
                                    foreach (Avion a in ooadWings.Avioni)
                                    {
                                        Console.WriteLine("{0}", a.Vrsta);
                                    }
                                }
                                else if (tip.Equals("P"))
                                {
                                    Console.WriteLine("Unesite:\n1-za avion za let u inostranstvo\n2-za avion za let unutar zemlje");
                                    int broj;
                                    Int32.TryParse(Console.ReadLine(), out broj);
                                    if (broj == 1)
                                    {
                                        List<string> drzave = new List<string>();
                                        Console.WriteLine("Unesite drzave u koje moze da leti, X za kraj liste drzava:");
                                        string drzava = Console.ReadLine();
                                        while (!drzava.Equals("X"))
                                        {
                                            drzave.Add(drzava);
                                            drzava = Console.ReadLine();
                                        }
                                        ooadWings.dodajAvion(new AvionInostranstvo(vrsta, brojSjedista, ID, drzave));
                                    }
                                    else if (broj == 2)
                                    {
                                        ooadWings.dodajAvion(new AvionUnutarZemlje(vrsta, brojSjedista, ID));
                                    }
                                    else throw new Exception("Pogresan broj.");
                                }
                                else
                                {
                                    throw new Exception("Pogresno slovo.");
                                }
                                /*foreach (Avion a in ooadWings.Avioni)
                                {
                                    Console.WriteLine("{0}", a.Vrsta);
                                }*/
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                Console.WriteLine("Unesite ime:");
                                string ime = Console.ReadLine();
                                Console.WriteLine("Unesite prezime:");
                                string prezime = Console.ReadLine();
                                Console.WriteLine("Unesite datum rodjenja kao dd.mm.yyyy:");
                                string datum = Console.ReadLine();
                                DateTime datumRodjenja = DateTime.Parse(datum);
                                Console.WriteLine("Unesite ID:");
                                string id = Console.ReadLine();
                                Console.WriteLine("Unesite stanje racuna:");
                                double stanjeRacuna;
                                Double.TryParse(Console.ReadLine(), out stanjeRacuna);
                                Console.WriteLine("Unesite:\n1-ako je klijent strani\n2-ako je klijent domaci");
                                int vrstaKlijenta;
                                Int32.TryParse(Console.ReadLine(), out vrstaKlijenta);
                                if (vrstaKlijenta == 1)
                                {
                                    Console.WriteLine("Unesite drzavu:");
                                    string drzava = Console.ReadLine();
                                    Console.WriteLine("Unesite grad:");
                                    string grad = Console.ReadLine();
                                    ooadWings.dodajKlijenta(new KlijentStrani(ime, prezime, datumRodjenja, id, stanjeRacuna, grad, drzava));
                                }
                                else if (vrstaKlijenta == 2)
                                {
                                    ooadWings.dodajKlijenta(new KlijentDomaci(ime, prezime, datumRodjenja, id, stanjeRacuna));
                                }
                                else throw new Exception("Pogresan broj.");
                                /*foreach(Klijent klijent in ooadWings.Klijenti)
                                {
                                    Console.WriteLine("{0}", klijent.DatumRodjenja);
                                }*/
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                Console.WriteLine("Unesite svoj ID:");
                                string id = Console.ReadLine();
                                Klijent klijent = ooadWings.dajKlijentaSaIdem(id);
                                Console.WriteLine("Unesite:\n1-za pretragu aviona po ID-u\n2-za pretragu aviona po ostalim atributima");
                                int vrstaPretrage;
                                Int32.TryParse(Console.ReadLine(), out vrstaPretrage);
                                List<Avion> avion = null;
                                if (vrstaPretrage == 1)
                                {
                                    Console.WriteLine("Unesite ID aviona:");
                                    string idAviona = Console.ReadLine();
                                    avion = ooadWings.nadjiAvionPoID(idAviona);
                                }
                                else if (vrstaPretrage == 2)
                                {
                                    Console.WriteLine("Unesite T za teretni, P za putnicki avion:");
                                    string tip = Console.ReadLine();
                                    Console.WriteLine("Unesite vrstu:");
                                    string vrsta = Console.ReadLine();
                                    Console.WriteLine("Unesite broj sjedista:");
                                    int brojSjedista;
                                    Int32.TryParse(Console.ReadLine(), out brojSjedista);
                                    if (tip.Equals("T"))
                                    {
                                        Console.WriteLine("Unesite kapacitet u tonama:");
                                        int kapacitet;
                                        Int32.TryParse(Console.ReadLine(), out kapacitet);
                                        avion = ooadWings.nadjiAvionPoInfo(new AvionTeretni(vrsta, brojSjedista, "xxxxxxxxx", kapacitet));
                                    }
                                    else if (tip.Equals("P"))
                                    {
                                        Console.WriteLine("Unesite:\n1-za avion za let u inostranstvo\n2-za avion za let unutar zemlje");
                                        int broj;
                                        Int32.TryParse(Console.ReadLine(), out broj);
                                        if (broj == 1)
                                        {
                                            List<string> drzave = new List<string>();
                                            Console.WriteLine("Unesite drzave u koje moze da leti, X za kraj liste drzava:");
                                            string drzava = Console.ReadLine();
                                            while (!drzava.Equals("X"))
                                            {
                                                drzave.Add(drzava);
                                                drzava = Console.ReadLine();
                                            }
                                            avion = ooadWings.nadjiAvionPoInfo(new AvionInostranstvo(vrsta, brojSjedista, "xxxxxxxxx", drzave));
                                        }
                                        else if (broj == 2)
                                        {
                                            avion = ooadWings.nadjiAvionPoInfo(new AvionUnutarZemlje(vrsta, brojSjedista, "xxxxxxxxx"));
                                        }
                                        else throw new Exception("Pogresan broj.");
                                    }
                                    else throw new Exception("Pogresno slovo.");
                                }
                                else throw new Exception("Pogresan broj.");
                                if (avion == null)
                                {
                                    Console.WriteLine("Avion ne postoji");
                                    Obavijest obavijest = new Obavijest("Avion ne postoji", klijent.ID, DateTime.Now);
                                    klijent.dodajObavijest(obavijest);
                                    break;
                                }
                                int redniBrojAviona = 1;
                                if (avion.Count > 1)
                                {
                                    Console.WriteLine("Izaberite redni broj aviona koji zelite.");
                                    foreach(Avion moguci in avion)
                                    {
                                        Console.WriteLine(redniBrojAviona + ". " + moguci);
                                        redniBrojAviona++;
                                    }
                                    Int32.TryParse(Console.ReadLine(), out redniBrojAviona);
                                }
                                //Console.WriteLine("{0}", avion.ID);
                                Console.WriteLine("Unesite datum polaska kao dd.mm.yyyy:");
                                string polazak = Console.ReadLine();
                                DateTime datumPolaska = DateTime.Parse(polazak);
                                Console.WriteLine("Unesite datum povratka kao dd.mm.yyyy:");
                                string povratak = Console.ReadLine();
                                DateTime datumPovratka = DateTime.Parse(povratak);
                                klijent.platiKauciju();
                                //Console.WriteLine("{0}", klijent.StanjeNaRacunu);
                                Let let = new Let(avion[redniBrojAviona-1], klijent, datumPolaska, datumPovratka);
                                ooadWings.dodajLet(let);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Unesite svoj ID:");
                            string id = Console.ReadLine();
                            Klijent klijent = ooadWings.dajKlijentaSaIdem(id);
                            List<Avion> avioniIznajmljeni = new List<Avion>();
                            foreach(Let let in ooadWings.Letovi)
                            {
                                if (let.Klijent.Equals(klijent)) avioniIznajmljeni.Add(let.Avion);
                            }
                            Console.WriteLine("Izaberite redni broj aviona koji zelite vratiti:");
                            int brojac = 1;
                            if (avioniIznajmljeni.Count == 0) Console.WriteLine("Nema iznajmljenih aviona.");
                            foreach(Avion a in avioniIznajmljeni)
                            {
                                Console.WriteLine(brojac + ". " + a);
                                brojac++;
                            }
                            Int32.TryParse(Console.ReadLine(), out brojac);
                            Avion avionZaVratiti = avioniIznajmljeni[brojac - 1];
                            Let letZaIzbrisati = null;
                            foreach(Let let in ooadWings.Letovi)
                            {
                                    //ista referenca
                                    if (let.Klijent == klijent && let.Avion == avionZaVratiti)
                                    {
                                        if (!let.DatumPovratka.Equals(DateTime.Today))
                                        {
                                            let.DatumPovratka = DateTime.Today;
                                        }
                                        avionZaVratiti.obracunPlacanje(let);
                                        klijent.povratNovca();
                                        letZaIzbrisati = let;
                                    }
                            }
                            ooadWings.Letovi.Remove(letZaIzbrisati);
                            break;
                        }
                    case 5:
                        {
                            foreach(Obavijest o in Klijent.Obavijesti)
                            {
                                Console.WriteLine(o);
                            }
                            break;
                        }
                    case 6:
                        {
                            foreach (Let let in ooadWings.Letovi)
                            {
                                Console.WriteLine(let);
                            }
                            break;
                        }
                    case 8:
                        {
                            nijeKraj = false;
                            break;
                        }
                    case 7:
                        {
                            foreach(Klijent k in ooadWings.Klijenti)
                            {
                                Console.WriteLine(k);
                            }
                            foreach(Avion a in ooadWings.Avioni)
                            {
                                Console.WriteLine(a);
                            }
                            break;
                        }

                }
            }
        }
    }

}
