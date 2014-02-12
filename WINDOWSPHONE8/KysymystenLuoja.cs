using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINDOWSPHONE8
{
    public static class KysymystenLuoja
    {
        static public List<Kysymys> LuoKysymykset()
        {
            List<Kysymys> kysymysLista = new List<Kysymys>();
            
            kysymysLista.Add(new Kysymys(1, "Mikä on aakkosten neljäs kirjain?"));
            kysymysLista[0].VastausVaihtoehdot[0] = "A";
            kysymysLista[0].VastausVaihtoehdot[1] = "B";
            kysymysLista[0].VastausVaihtoehdot[2] = "C";
            kysymysLista[0].VastausVaihtoehdot[3] = "D";
            kysymysLista[0].OikeaVastaus = "D";

            kysymysLista.Add(new Kysymys(2, "Minä vuonna Porin kaupunki on perustettu?"));
            kysymysLista[1].VastausVaihtoehdot[0] = "1677";
            kysymysLista[1].VastausVaihtoehdot[1] = "1558";
            kysymysLista[1].VastausVaihtoehdot[2] = "1766";
            kysymysLista[1].VastausVaihtoehdot[3] = "1477";
            kysymysLista[1].OikeaVastaus = "1558";

            kysymysLista.Add(new Kysymys(3, "Mitä tarkoittaa Porin ruotsinkielinen nimi Björneborg?"));
            kysymysLista[2].VastausVaihtoehdot[0] = "Metsäkaupunki";
            kysymysLista[2].VastausVaihtoehdot[1] = "Merikaupunki";
            kysymysLista[2].VastausVaihtoehdot[2] = "Karhukaupunki";
            kysymysLista[2].VastausVaihtoehdot[3] = "Kesäkaupunki";
            kysymysLista[2].OikeaVastaus = "Karhukaupunki";

            kysymysLista.Add(new Kysymys(4, "Mikä oli Porin väkiluku vuonna 1910?"));
            kysymysLista[3].VastausVaihtoehdot[0] = "30 482";
            kysymysLista[3].VastausVaihtoehdot[1] = "3 482";
            kysymysLista[3].VastausVaihtoehdot[2] = "348";
            kysymysLista[3].VastausVaihtoehdot[3] = "13 482";
            kysymysLista[3].OikeaVastaus = "13 482";
            
            return kysymysLista;
        }
    }
}
