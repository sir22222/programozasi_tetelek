namespace programozasi_tetelek
{
    public static class RendezesiAlgoritmusok
    {
        public static void EgyszeruCseres(ref IComparable[] values)
        {
            for (int i = 0; i < values.Length; i++)
                for (int j = i + 1; j < values.Length; j++)
                    if (values[i].CompareTo(values[j]) > 0)
                        (values[j], values[i]) = (values[i], values[j]);
        }

        public static void Minimumkivalasztasos(ref IComparable[] values) 
        {
            for (int i = 0; i < values.Length; i++)
            {
                int min = i;
                for (int j = 0; j < values.Length; j++)
                    if (values[min].CompareTo(values[j]) > 0) 
                        min = j;
                (values[min], values[i]) = (values[i], values[min]);
            }
        }

        public static void Buborek(ref IComparable[] values) 
        {
            for (int i = values.Length - 1; i >= 1; i--)
                for (int j = 0; j < values.Length - 1; j++)
                    if (values[j].CompareTo(values[j + 1]) > 0)
                        (values[j+1], values[j]) = (values[j], values[j+1]);
        }

        public static void JavitottBuborek(ref IComparable[] values) 
        {
            for (int i = values.Length - 1; i >= 1; i--)
            {
                int id = 0;
                for (int j = 0; j < values.Length; j++)
                    if (values[j].CompareTo(values[j + 1]) > 0)
                    {
                        (values[j + 1], values[j]) = (values[j], values[j + 1]);
                        id = i;
                    }
                i = id;
            }
        }

        public static void Beilleszteses(ref IComparable[] values) 
        {
            for (int i = 1; i < values.Length; i++)
                for (int j = 0; j > 0 && values[j].CompareTo(values[j+1])> 0; j--)
                    (values[j + 1], values[j]) = (values[j], values[j + 1]);
        }

        public static void JavitottBeillesztes(ref IComparable[] values) 
        {
            for (int i = 1; i < values.Length; i++)
            {
                int j = i - 1;
                IComparable tmp = values[j];
                for (; j >= 0  && values[j].CompareTo(tmp)> 0; j--)
                    values[j+1] = values[j];
                values[j] = tmp;
            }
        }

        public static void Shell(ref IComparable[] values) 
        {
            int d = values.Length / 2;
            while (d >= 1) 
            {
                for (int i = d+1; i < values.Length; i++)
                {
                    int j = i - d;
                    IComparable tmp = values[i];
                    for (; j >= 0 && values[j].CompareTo(tmp) > 0;)
                    {
                        values[j + d] = values[j];
                        j -= d;
                    }
                }
                d /= 2;
            }
        }
    }
}
