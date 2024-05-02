namespace programozasi_tetelek
{
    public static class OsszetettTetelek
    {
        public static object[] Masolas(object[] objBe)
        {
            object[] objKi = new object[objBe.Length];
            for (int i = 0; i < objBe.Length; i++)
                objKi[i] = objBe[i];
            return objKi;
        }
        public static object[] Kivalogatas(object[] objects, Func<object, bool> func, out int outCount)
        {
            outCount = 0;
            object[] objectsOut = new object[objects.Length];
            for (int i = 0; i < objects.Length; i++)
                if (func(objects[i]))
                    objectsOut[outCount++] = objects[i];
            return objectsOut;
        }

        public static int VesztesegesKivalogatasHelyben(object[] objects, Func<object, bool> func)
        {
            int count = 0;
            for (int i = 0; i < objects.Length; i++)
                if (func(objects[i]))
                    objects[count++] = objects[i];
            return count;
        }

        public static int VestesegmentesKivalogatasHelyben(object[] objects, Func<object, bool> func)
        {
            int count = 0;
            for (int i = 0; i < objects.Length; i++)
                if (func(objects[i]))
                {
                    object tmp = objects[count];
                    objects[count] = objects[i];
                    objects[i] = tmp;
                    count++;
                }
            return count;
        }

        public static void Szetvalogatas(
            object[] objects,
            Func<object, bool> func,
            out object[] objectsTrue, out int countTrue,
            out object[] objectsFalse, out int countFalse
        )
        {
            objectsTrue = new object[objects.Length];
            objectsFalse = new object[objects.Length];
            countTrue = 0;
            countFalse = 0;

            for (int i = 0; i < objects.Length; i++)
                if (func(objects[i]))
                    objectsTrue[countTrue++] = objects[i];
                else
                    objectsFalse[countFalse++] = objects[i];
        }

        public static void SzetvalogatasEgyKimenetiTombbel
        (
            object[] objects, Func<object, bool> func,
            out object[] objectsOut, out int count
        )
        {
            objectsOut = new object[objects.Length];
            count = 0;
            int right = objects.Length;
            for (int i = 0; i < objects.Length; i++)
                if (func(objects[i]))
                    objectsOut[count++] = objects[i];
                else
                    objectsOut[--right] = objects[i];
        }

        public static int SzetvalogatasHelyben
            (
            object[] objects, Func<object, bool> func
            )
        {
            int leftPointer = 0, rightPointer = objects.Length - 1;
            object tmp = objects[0];
            while (leftPointer < rightPointer)
            {
                while (leftPointer < rightPointer && !func(objects[rightPointer]))
                    rightPointer--;

                if (leftPointer < rightPointer)
                {
                    objects[leftPointer] = objects[rightPointer];
                    leftPointer++;
                }

                while (leftPointer < rightPointer && func(objects[leftPointer]))
                    leftPointer++;

                if (leftPointer < rightPointer)
                {
                    objects[rightPointer] = objects[leftPointer];
                    rightPointer--;
                }
            }
            objects[leftPointer] = tmp;

            if (func(tmp))
                return leftPointer;
            return leftPointer - 1;
        }

        public static void Metszet
            (
            object[] objects1, object[] objects2,
            out object[] objectsOut, out int count

            )
        {
            objectsOut = new object[objects1.Length > objects2.Length ? objects2.Length : objects1.Length];
            count = 0;
            int Tomb1Pointer = 0, Tomb2Pointer;

            while (Tomb1Pointer < objects1.Length)
            {
                Tomb2Pointer = 0;

                while (Tomb2Pointer < objects2.Length && !objects1[Tomb1Pointer].Equals(objects2[Tomb2Pointer])) ;
                Tomb2Pointer++;

                if (Tomb2Pointer < objects2.Length)
                    objectsOut[count++] = objects1[Tomb1Pointer];
            }
        }

        public static bool KozosElem(object[] objects1, object[] objects2)
        {
            for (int i = 0; i < objects1.Length; i++)
                for (int j = 0; j < objects2.Length; j++)
                    if (objects1[i].Equals(objects2[j]))
                        return true;
            return false;
        }

        public static void Unio
            (
                object[] objects1, object[] objects2,
                out object[] objectsOut, out int count
            )
        {
            objectsOut = new object[objects1.Length + objects2.Length];
            count = 0;

            for (int i = 0; i < objects1.Length; i++)
                objectsOut[count++] = objects1[i];

            for (int i = 0; i < objects2.Length; i++)
            {
                int j;
                for (j = 0; j < objects1.Length; j++)
                {
                    if (objects1[j] == objects2[i])
                        break;
                }
                if (j == objects1.Length)
                    objectsOut[count++] = objects1[i];
            }
        }

        public static void IsmetlodesKiszurese(
            object[] objects,
            out object[] objectsOut, out int count)
        {
            objectsOut = new object[objects.Length];
            count = 0;

            for (int i = 0; i < objects.Length; i++)
            {
                int j = 0;

                for (;
                    j < objects.Length &&
                    objects[i] != objects[j];
                    j++) ;

                if (j >= objects.Length)
                    objectsOut[count++] = objects[i];
            }
        }

        public static void OsszeFuttatas
            (
                IComparable[] comparables1, IComparable[] comparables2,
                out IComparable[] comparablesOut, out int count
            ) 
        {
            comparablesOut = new IComparable[comparables1.Length + comparables2.Length];
            count = 0;
            int i = 0, j = 0;

            while (i < comparables1.Length && j < comparables2.Length)
            {
                if (comparables1[i].CompareTo(comparables2[j]) < 0)
                    comparablesOut[count++] = comparables1[i++];
                else if (comparables1[i].CompareTo(comparables2[j]) > 0)
                    comparablesOut[count++] = comparables2[j++];
                else 
                {
                    comparablesOut[count++] = comparables2[j++];
                    i++;
                }
            }
            while (i < comparables1.Length)
                comparablesOut[count++] = comparables1[i++];
            
            while (j < comparables2.Length)
                comparablesOut[count++] = comparables2[j++];
        
        }
    }
}
