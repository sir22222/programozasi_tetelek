namespace programozasi_tetelek
{
    public static class AlgoritmusokRendezettTombon
    {
        #region Kereses
        public static bool LinearisKereses(
            object[] values, object target,
            out int targetIndex
            )
        {
            for (int i = 0; i < values.Length; i++)
                if (values[i].Equals(target))
                {
                    targetIndex = i;
                    return true;
                }
            targetIndex = -1;
            return false;
        }
        public static bool LogaritmikusKereses(
            IComparable[] values, IComparable target,
            out int targetIndex)
        {
            int pLeft = 0,
                pRight = values.Length - 1,
                pCenter = (pLeft + pRight) / 2;

            while (pLeft <= pRight && !target.Equals(values[pCenter]))
            {
                pCenter = (pLeft + pRight) / 2;
                if (target.CompareTo(values[pCenter]) > 0)
                    pRight = pCenter - 1;
                else
                    pLeft = pCenter + 1;
            }

            if (pLeft <= pRight)
            {
                targetIndex = pCenter;
                return true;
            }
            targetIndex = -1;
            return false;
        }
        public static bool RekurzivLogaritmikusKereses(
            IComparable[] values, IComparable target,
            out int targetIndex)
        {

            targetIndex = RekurzivLogaritmikusKereses(values, target, 0, values.Length);
            if (targetIndex == -1) return false;
            return true;
        }
        private static int RekurzivLogaritmikusKereses(
            IComparable[] values, IComparable target,
            int pLeft, int pRight) =>
            pLeft > pRight ?
                -1 : (
                (target.CompareTo(values[(pLeft + pRight) / 2]) == 0)
                    ? (pLeft + pRight) / 2 : (
                    (target.CompareTo(values[(pLeft + pRight) / 2]) > 0) ?
                        RekurzivLogaritmikusKereses(values, target, ((pLeft + pRight) / 2) + 1, pRight) :
                        RekurzivLogaritmikusKereses(values, target, pLeft, ((pLeft + pRight) / 2) - 1)));


#endregion
#region Programozasi Tetelek Rendezet Tombon
        public static bool Eldontes(IComparable[] values, IComparable target)
        {
            // return LogaritmikusKereses(values, target,out int a);
            int pLeft = 0,
                   pRight = values.Length - 1,
                   pCenter = (pLeft + pRight) / 2;

            while (pLeft <= pRight && !target.Equals(values[pCenter]))
            {
                pCenter = (pLeft + pRight) / 2;
                if (target.CompareTo(values[pCenter]) > 0)
                    pRight = pCenter - 1;
                else
                    pLeft = pCenter + 1;
            }
            if (pLeft <= pRight)
                return true;
            return false;
        }
        public static bool EldontesRange(IComparable[] values, IComparable lowerBound,IComparable upperBound)
        {
            // return LogaritmikusKereses(values, target,out int a);
            int pLeft = 0,
                   pRight = values.Length - 1,
                   pCenter = (pLeft + pRight) / 2;

            while ( pLeft <= pRight &&
                    !(upperBound.CompareTo(values[pCenter]) > 0) &&
                    !(lowerBound.CompareTo(values[pCenter]) < 0 ))

            if (pLeft <= pRight)
                return true;
            return false;
        }


        public static int Kivalasztas(IComparable[] values, IComparable target){
            //int output;
            //LogaritmikusKereses(values, target, out output);
            //return output;
            
            int pLeft = 0,
                pRight = values.Length - 1,
                pCenter = (pLeft + pRight) / 2;

            while (pLeft <= pRight && !target.Equals(values[pCenter])){
                pCenter = (pLeft + pRight) / 2;
                if (target.CompareTo(values[pCenter]) > 0)
                    pRight = pCenter - 1;
                else
                    pLeft = pCenter + 1;
            }
            
            if (pLeft <= pRight)
                return pCenter;
            return -1;
        }

        public static bool Kivalogatas(IComparable[] values, IComparable target,out int pLeft, out int pRight){
            pLeft = 0;
            pRight = values.Length - 1;
            int pCenter = (pLeft + pRight) / 2;
            while (pLeft <= pRight && !target.Equals(values[pCenter]))
                if (target.CompareTo(values[pCenter]) > 0)
                    pLeft = pCenter + 1;
                else
                    pRight = pCenter - 1;
            if (pLeft > pRight)
                return false;

            pLeft = pCenter;
            pRight = pCenter;
            while (pLeft >= 0 && target.Equals(values[pLeft - 1])) pLeft--;
            while (pRight < values.Length && target.Equals(values[pRight + 1])) pRight++;

            return true;
        }

         public static bool ModositottKivalogatas(IComparable[] values, IComparable targetRangeMin,IComparable targetRangeMax, out int pLeft, out int pRight){
            pLeft = 0;
            pRight = values.Length - 1;
            int pCenter = (pLeft + pRight) / 2;

            while(pLeft <= pRight && !(targetRangeMin.CompareTo(values[pCenter])<= 0 && targetRangeMax.CompareTo(values[pCenter])>=0)){
                pCenter = (pLeft + pRight)/2;
                if(targetRangeMax.CompareTo(values[pCenter])<0)
                    pRight =pCenter -1;
                else
                    pLeft = pCenter+1;
            }
            if(pLeft>pRight)
                return false;
            
            pLeft =pCenter;
            pRight = pCenter;

            while(pLeft>= 0 && targetRangeMin.CompareTo(values[pLeft-1]) <= 0)
                pLeft--;

            while(pRight< 0 && targetRangeMax.CompareTo(values[pRight +1])>=0)
                pRight++;
                
            return true;
        }       


        public static int Megszamlalas(IComparable[] values, IComparable target){
            int pLeft,pRight;
            ModositottKivalogatas(values,target,target,out pLeft,out pRight);
            return pRight-pLeft;
        }
#endregion


#region halmazok
        public static bool HalmazTulajdonsagVizsgalat(IComparable[] values){
            if (values.Length<2) return true;
            int i = 1;
            for (; i < values.Length && !(values[i-1].CompareTo(values[i])== 0); i++);
            return i == values.Length;
        }

        public static IComparable[] HalmazLétrehozzás(IComparable[] values){
            int size = 0;

            if(values.Length< 2) return values;

            IComparable[] valuesOut = new IComparable[values.Length];


            for (int i = 1; i < values.Length; i++)
                if(values[i-1].CompareTo(values[i])!= 0)
                    valuesOut[size++] = values[i];

            return valuesOut.Take(size).ToArray();
        }

        public static bool TartalmazasVizsgalat(IComparable[] values, IComparable target) => LinearisKereses(values,target,out int i);


        /// <summary>
        /// chech if all elements of set A are contained in set B.
        /// </summary>
        /// <param name="setA"></param>
        /// <param name="setB"></param>
        /// <returns>if A is a subset of B</returns>
        public static bool ReszhalmazVizsgalat(IComparable[] setA, IComparable[]setB){
            int pA = 0, pB = 0;
            while(
                pA < setA.Length &&
                pB < setB.Length &&
                setA[pA].CompareTo(setB[pB]) >= 0){
                    if(setA[pA].Equals(setB[pB]))
                        pA++;
                    pB++;
                }
                return pB == setB.Length;
        }

    public static IComparable[] Unio(IComparable[] setA,IComparable[] setB){
        IComparable[] output = new IComparable[setA.Length+setB.Length];
        int pA = 0, pB = 0, outCount = 0;;
        while(pA<setA.Length && pB< setB.Length){
            if(setA[pA].CompareTo(setB[pB])== 0){
                output[outCount++] = setA[pA++];
                pB++;
            }
            else if(setA[pA].CompareTo(setB[pB])<0)
                output[outCount++] = setA[pA++];
            else
                output[outCount++] = setA[pB++];

        }
        return output.Take(outCount).ToArray();
    }


    public static IComparable[] Metszet(IComparable[] setA,IComparable[] setB){
        IComparable[] output = new IComparable[setA.Length.CompareTo(setB.Length) <= 0 ? setA.Length : setB.Length];
        int pA = 0, pB = 0, outCount = 0;;
        while(pA<setA.Length && pB< setB.Length){
            if(setA[pA].CompareTo(setB[pB])== 0){
                output[outCount++] = setA[pA++];
                pB++;
            }
            else if(setA[pA].CompareTo(setB[pB])<0)
                pA++;
            else
                pB++;

        }
        return output.Take(outCount).ToArray();
    }
    /// <summary>
    /// Creates a new array containing the values of set A that are not in set B;
    /// </summary>
    /// <param name="setA"></param>
    /// <param name="setB"></param>
    /// <returns>IComparable array containg values of A that</returns>
    public static IComparable[] Kulonbseg(IComparable[] setA,IComparable[] setB){
        IComparable[] output = new IComparable[setA.Length];
        int pA = 0, pB = 0, outCount = 0;;
        while(pA<setA.Length && pB< setB.Length){
            if(setA[pA].CompareTo(setB[pB])== 0){
                pA++;
                pB++;
            }
            else if(setA[pA].CompareTo(setB[pB])<0)
                output[outCount++] = setA[pA++];
            else
                pB++;
        }
        while(pA<setA.Length)
            output[outCount++] = setA[pA++];

        return output.Take(outCount).ToArray();
    }
    //public static IComparable[] SzimetrikusDifferencia(IComparable[] setA ,IComparable[] setB) => Unio(Kulonbseg(setA,setB),Kulonbseg(setB,setA));
    public static IComparable[] SzimetrikusDifferencia(IComparable[] setA,IComparable[] setB){
        IComparable[] output = new IComparable[setA.Length];
        int pA = 0, pB = 0, outCount = 0;;
        while(pA<setA.Length && pB< setB.Length){
            if(setA[pA].CompareTo(setB[pB])== 0){
                pA++;
                pB++;
            }
            else if(setA[pA].CompareTo(setB[pB])<0)
                output[outCount++] = setA[pA++];
            else
                output[outCount++] = setA[pB++];
        }
        while(pA<setA.Length)
            output[outCount++] = setA[pA++];
        while(pB<setB.Length)
            output[outCount++] = setB[pB++];

        return output.Take(outCount).ToArray();
    }
#endregion
    }
}
