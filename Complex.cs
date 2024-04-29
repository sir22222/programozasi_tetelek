using System.Runtime.CompilerServices;

namespace programozasi_tetelek
{
    internal class Complex
    {
        static object[] Masolas(object[] objBe)
        {
            object[] objKi = new object[objBe.Length];
            for (int i = 0; i < objBe.Length; i++)
                objKi[i] = objBe[i];
            return objKi;
        }
        static object[] Kivalogatas(object[] objects, Func<object,bool> func,out int outCount)
        {
            outCount = 0;
            object[] objectsOut = new object[objects.Length];
            for (int i = 0; i < objects.Length; i++)
                if(func(objects[i]))
                    objectsOut[outCount++] = objects[i];
            return objectsOut;
        }

        static int VesztesegesKivalogatasHelyben(object[]objects,Func<object,bool> func)
        {
            int count = 0;
            for (int i = 0; i < objects.Length; i++)
                if(func(objects[i]))
                    objects[count++]= objects[i];
            return count;
        }

        static int VestesegmentesKivalogatasHelyben(object[] objects,Func<object, bool> func)
        {
            int count= 0;
            for (int i = 0; i < objects.Length; i++)
                if(func(objects[i]))
                     {
                        object tmp = objects[count];
                        objects[count]= objects[i];
                        objects[i] = tmp;
                        count++;
                     }
            return count;
        }

        static void Szetvalogatas(
            object[] objects, Func<object,bool> func,
            out object[] objectsTrue, out int countTrue,
            out object[] objectsFalse, out int countFalse
        )
        {
            objectsTrue = new object[objects.Length];
            objectsFalse = new object[objects.Length];
            countTrue = 0;
            countFalse = 0;

            for (int i = 0; i < objects.Length; i++)
                if(func(objects[i]))
                    objectsTrue[countTrue++] = objects[i];
                else
                    objectsFalse[countFalse++] = objects[i];
        }

        static void SzetvalogatasEgyKimenetiTombbel
        (
            object[] objects ,Func<object,bool> func,
            out object[] objectsOut ,out int count
        )
        {
            objectsOut = new object[objects.Length];
            count =0;
            int right = objects.Length;
            for (int i = 0; i < objects.Length; i++)
                if(func(objects[i]))
                    objectsOut[count++] = objects[i];
                else
                    objectsOut[--right] = objects[i];
        }

        static void SzetvalogatasHelyben(){}
    }
}
