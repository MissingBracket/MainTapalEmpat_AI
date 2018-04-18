using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainTapalEmpat
{
    class Ruch
    {
        public Pozycja skad = new Pozycja();
        public Pozycja dokad = new Pozycja();
        public int poziom;
        public Pozycja bityPionek = new Pozycja();
        public bool bicie = false;//gdy wykonywanym ruchem  jest bicie ustawiana jest wartosc na true, przydatne przy funkcji oceniającej
    }
}
