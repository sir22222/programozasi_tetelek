using System.Reflection.Metadata.Ecma335;

namespace programozasi_tetelek
{
    public static class RekurzivAlgoritmusok
    {
        public static int Faktorialis(int n) => n == 0 ? 1 : n * Faktorialis(n - 1);

        public static int FibonacciXedikEleme(int x) => (x == 1) ? 1 : (x == 2 ? 2 : FibonacciXedikEleme(x - 1) + FibonacciXedikEleme(x - 2));

        /// <summary>
        /// Az a-nak az x-edik hatványát adja vissza
        /// </summary>
        /// <returns></returns>
        public static double Hatvanyozas(double a, int x) => x == 0 ? 1 : (x == 1 ? a : a * Hatvanyozas(a, x - 1));

        public static double SorozatSzamitas(double[] doubles, int vege) => vege == 0 ? doubles[0] : SorozatSzamitas(doubles, vege - 1)+ doubles[vege];

        public static object LinearisKereses(object[] values, Func<object, bool> LgFunc) => LinearisKeresesSeged(values, 0, LgFunc);
        private static object LinearisKeresesSeged(object[] values, int index, Func<object, bool> LgFunc)
            => index >= values.Length ?
                -1 :
                (LgFunc(values[index]) ?
                        index : 
                        LinearisKeresesSeged(values, ++index, LgFunc));

        public static int Megszamlalas(object[] values, Func<object, bool> LgFunc) => MegszamlalasSeged(values, LgFunc, 0);
        private static int MegszamlalasSeged(object[] values, Func<object, bool> LgFunc, int index)
            => index >= values.Length ?
                0 :
                (LgFunc(values[index]) ?
                    MegszamlalasSeged(values: values, index: ++index, LgFunc: LgFunc) + 1 :
                    MegszamlalasSeged(values: values, index: ++index, LgFunc: LgFunc));


        public static int MaximumKivalasztas(IComparable[] values) => MaximumKivalasztasSeged(values, 0);

        private static int MaximumKivalasztasSeged(IComparable[] values, int index)
            => index >= values.Length ?
                0 :
            //#WhoNeedsEfficency
                (values[index].CompareTo(values[MaximumKivalasztasSeged(values, ++index)]) > 0 ?
                    index : 
                    MaximumKivalasztasSeged(values, ++index));


    }
}
