namespace programozasi_tetelek
{
    public static class OsszeEpitettTetelek
    {
        #region MasolasEsSorozat
        public static double MasolasEsSorozatSzamitasDoublere
            (
            double[] doubles,
            Func<double, double> func
            )
        {
            double output = 0;
            for (int i = 0; i < doubles.Length; i++)
                output += func(doubles[i]);
            return output;
        }
        public static int MasolasEsSorozatSzamitasIntre
            (
            int[] ints,
            Func<int, int> func
            )
        {
            int output = 0;
            for (int i = 0; i < ints.Length; i++)
                output += func(ints[i]);
            return output;
        }
        public static string MasolasEsSorozatSzamitasStringre
            (
            string[] strings,
            Func<string, string> func
            )
        {
            string output = "";
            for (int i = 0; i < strings.Length; i++)
                output += func(strings[i]);
            return output;
        }
        #endregion

        #region MasolasEsMaximumKivalasztas
        public static void MasolasEsMaximumKivalasztasDoublere
            (
            double[] doubles,
            Func<double, double> func,
            out double output, out int output_index
            )
        {
            output_index = 0;
            output = func(doubles[0]);
            for (int i = 0; i < doubles.Length; i++)
                if (output.CompareTo(func(doubles[i])) < 0)
                {
                    output_index = i;
                    output = func(doubles[output_index]);
                }
        }
        public static void MasolasEsMaximumKivalasztasIntre
            (
            int[] ints,
            Func<int, int> func,
            out int output, out int output_index
            )
        {
            output_index = 0;
            output = func(ints[0]);
            for (int i = 0; i < ints.Length; i++)
                if (output.CompareTo(func(ints[i])) < 0)
                {
                    output_index = i;
                    output = func(ints[output_index]);
                }
        }
        #endregion

        public static void MegszamolasEsKereses
            (
            object[] objects, Func<object, bool> func, int targetCount,
            out int targetIndex, out bool isTargetHit
            )
        {
            targetIndex = -1;
            int outCount = 0;
            isTargetHit = false;
            for (int i = 0; i < objects.Length; i++)
                if (func(objects[i]))
                    if (++outCount == targetCount)
                    {
                        targetIndex = i;
                        isTargetHit = true;
                    }
        }

        public static void MaximumEsKivalogatas
            (
            IComparable[] values,
            out int[] outputIndexes, out int count, out IComparable maxValue
            )
        {
            count = 0;
            maxValue = values[0];
            outputIndexes = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (maxValue.CompareTo(values[i]) > 0)
                {
                    count = 0;
                    outputIndexes[count] = i;
                    maxValue = values[i];
                }
                else if (maxValue.CompareTo(values[i]) == 0)
                    outputIndexes[count++] = i;
            }
        }

        public static object KivalogatasEsSorozatszamitas(object[] objects, Func<object, bool> func,Func<object, object, object> sum)
        {
            object output= new();
            for (int i = 0; i < objects.Length; i++)
                if (func(objects[i]))
                    output = sum(output, objects[i]);
            return output;
        }

        public static void KivalogatasEsMax
            (
            double[] values ,Func<double, bool> func,
            out bool exists, out double maxValue,out int maxIndex
            )
        {
            exists = false;
            maxIndex = -1;
            maxValue = double.MinValue;

            for (int i = 0; i < values.Length; i++)
                if (func(values[i]) && values[i] > maxValue)
                    maxValue = values[maxIndex = i];
            if(maxIndex != -1)
                exists = true;
        }

        public static void KivalogatasEsMasolas
            (
            object[] objects,
            Func<object, bool> logikaiFg, Func<object, object> futatasiFg,
            out object[] objectsOut, out int count
            )
        {
            objectsOut = new object[objects.Length];
            count = 0;
            for (int i = 0; i < objects.Length; i++)
                if (logikaiFg(objects[i]))
                    objectsOut[count++] = futatasiFg(objects[i]);
        }

    }
}
