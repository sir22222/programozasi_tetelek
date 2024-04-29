using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace programozasi_tetelek
{
    internal class Simple
    {
        /// <summary>
        /// Lista elemeinek összegét kiszámolja
        /// </summary>
        /// <param name="list">számokból álló lista amely összegét keresük</param>
        /// <returns>a lista értékeinek az összege</returns>
        public static double SorozatSzamitas (double[] list)
        {
            double sum = 0;
            for (int i = 0; i < list.Length; i++)
                sum += list[i];
            return sum;
        }

        /// <summary>
        /// Adott lista tartalmaz-e a logiaki paraméternek megfelelő elemet
        /// </summary>
        /// <param name="list">elenörizendö lista</param>
        /// <param name="Logic">ellenörzési logikai fg</param>
        /// <returns>igazat ha van benne, hamisat ha nincs benne</returns>
        public static bool EldontesTetel(object[] list,Func<object,bool> Logic) 
        {
            foreach (var item in list)
                if(Logic(item))
                    return true;
            return false;
        }

        /// <summary>
        /// Adott lista minden eleme megfelel-e egy logikai feltételnek
        /// </summary>
        /// <param name="list">ellenörzendö lista</param>
        /// <param name="Logic">logikai feltétel</param>
        /// <returns>igazat ha mindre igaz a feltétel, hamisat ha valamelyikre hamis a feltétel</returns>
        public static bool EldontesMindenTetel(object[] list, Func<object, bool> Logic)
        {
            foreach (var item in list)
                if (!Logic(item))
                    return false;
            return true;
        }

        /// <summary>
        /// Tests if the value is a prime
        /// </summary>
        /// <param name="v">tested int</param>
        /// <returns>
        /// true if it's an prime
        /// false if it's not a prime 
        /// </returns>
        public static bool PrimTest(int value) 
        {
            if (value < 2) return false;
            int sqrt = (int)Math.Sqrt(value);
            for (int i = 2; i < sqrt; i++)
                if (value%i==0)
                    return false;
            return true;
        }

        /// <summary>
        /// checks if input list is in ascending order
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool RendezetNovekvoSorrend(IComparable[] list)
        {
            if (list.Length < 2) return true;
            for (int i = 0; i < list.Length - 1; i++)
                if (list[i].CompareTo(list[i + 1]) > 0)
                    return false;
            return true;
        }
        public static bool RendezetCsokkenoSorrend(IComparable[] list)
        {
            if (list.Length < 2) return true;
            for (int i = 0; i < list.Length - 1; i++)
                if (list[i].CompareTo(list[i + 1]) < 0)
                    return false;
            return true;
        }
        /// <summary>
        /// A kiválasztás programozási tételt olyan feladatok esetén használjuk, amikor tudjuk, hogy egy tömbben
        /// van vizsgált tulajdonságú elem és keressük ennek első előfordulását.Könnyen belátható,
        /// hogy a megfelelő algoritmus nagyon hasonlít az eldöntés tétel megvalósítására.Különbség csak abban van, hogy
        /// nem a tulajdonság legalább egyszeri teljesülését kell vizsgálnunk, hanem az első előfordulás indexét kell
        /// megadnunk, tudva, hogy legalább egy elem esetén biztosan teljesül a tulajdonság.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="LogikaiFg"></param>
        /// <returns>elso logikai fgnek megfelelo index vagy -1 ha nincs ilyen elem</returns>
        public static int Kivalasztas(object[] list, Func<object, bool> LogikaiFg)
        {
            int i = 0;
            for (; i < list.Length && !LogikaiFg(list[i]); i++) ;
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="LogikaiFg"></param>
        /// <param name="index">retuns the index of the value</param>
        /// <returns>
        /// true if it contains the 
        /// 
        /// </returns>
        public static bool LinearisKeres(object[] values, Func<object, bool> LogikaiFg, out int index)
        {
            for (int i = 0; i < values.Length; i++)
                if (LogikaiFg(values[i]))
                {
                    index = i;
                    return true;
                }
            index = -1;
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="LogikaiFg"></param>
        /// <returns>A logikai Fg-nek megfelelo listalemek darabszamat</returns>
        public static int Megszamalas(object[] list, Func<object,bool> LogikaiFg) 
        {
            int count = 0;
            foreach (var item in list)
                if (LogikaiFg(item))
                    count++;
            return count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IComparable MaximumErtek(IComparable[] list) 
        {
            IComparable max = list[0];
            foreach (var item in list)
                if(max.CompareTo(item) < 0)
                    max = item; 
            return max;
        }
        public static IComparable MinimumErtek(IComparable[] list) 
        {
            IComparable min = list[0];
            foreach (var item in list)
                if (min.CompareTo(item) > 0)
                    min = item;
            return min;
        }

    }
}
