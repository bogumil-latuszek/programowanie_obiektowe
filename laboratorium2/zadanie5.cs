using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorium2
{
    public class Aggregate2D5 : Aggregate
    {
        public double[][] matrice = new double[4][];
        public Aggregate2D5()
        {
            matrice[0] = new double[]{
                 0.1 , 0.2 , 0.3 };
            matrice[1] = new double[]{
                0.4 , 0.5 , 0.6  };
            matrice[2] = new double[]{
                0.7 , 0.8 , 0.9 };
            matrice[3] = new double[]{
                1.0 , 1.1 , 1.2 };
        }
        public override Iterator2D5 CreateIterator()
        {
            return new Iterator2D5(this);
        }
    }
    public class Iterator2D5 : Iterator
    {
        private int iteratorRow;
        private int iteratorColumn;
        private Aggregate2D5 Aggregate2D5;
        public Iterator2D5(Aggregate2D5 zad2)
        {
            Aggregate2D5 = zad2;
            iteratorRow = 0;
            iteratorColumn = 0;
        }
        public override double GetNext()
        {
            if (iteratorColumn > Aggregate2D5.matrice[iteratorRow].Length - 1)
            {
                iteratorRow++;
                iteratorColumn = 0;
                return Aggregate2D5.matrice[iteratorRow][iteratorColumn++];



            }
            return Aggregate2D5.matrice[iteratorRow][iteratorColumn++];


        }
        public override bool HasNext()
        {
            if (iteratorColumn >= Aggregate2D5.matrice[iteratorRow].Length -1)
            {
                if (iteratorRow >= Aggregate2D5.matrice.GetLength(0) - 1)
                {
                    return false;
                }
                return true;

            }
            return true;
        }


    }
}
