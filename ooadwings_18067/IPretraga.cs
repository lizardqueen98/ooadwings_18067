using System;
using System.Collections.Generic;
using System.Text;

namespace ooadwings_18067
{
    public interface IPretraga
    {
        List<Avion> nadjiAvionPoID(string ID);
        List<Avion> nadjiAvionPoInfo(Avion avion);
    }
}
