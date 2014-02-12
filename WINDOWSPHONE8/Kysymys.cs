using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WINDOWSPHONE8
{
    public class Kysymys
    {
        // private kentät
        private int _kysymysNro;
        private string _kysymysTxt;
        private string[] _vastausVaihtoehdot;
        private string oikeaVastaus;

        // public ominaisuudet
        public int KysymysNro
        {
            get { return _kysymysNro; }
            set { _kysymysNro = value; }
        }
        public string KysymysTxt
        {
            get { return _kysymysTxt; }
            set { _kysymysTxt = value; }
        }
        public string[] VastausVaihtoehdot
        {
            get { return _vastausVaihtoehdot; }
            set { _vastausVaihtoehdot = value; }
        }
        public string OikeaVastaus
        {
            get { return oikeaVastaus; }
            set { oikeaVastaus = value; }
        }
     
        // konstruktorit
        public Kysymys()
        {

        }
        public Kysymys(int nro, string txt)
        {
            _kysymysNro = nro;
            _kysymysTxt = txt;
            _vastausVaihtoehdot = new string[4];
        }
    }
}
