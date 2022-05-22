using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorium2
{
    public class Aggregate2D3 : Aggregate
    {
        public double[][] matrice = new double[4][];
        public Aggregate2D3()
        {
            matrice[0] = new double[]{
                 -0.1 , 0.0 , 0.1, };
            matrice[1] = new double[]{
                -0.1 , 0.0 , 0.2  };
            matrice[2] = new double[]{
                -0.1 , 0.0 , 0.3 };
            matrice[3] = new double[]{
                -0.1 , 0.0 , 0.4 };
        }
        public override Iterator2D3 CreateIterator()
        {
            return new Iterator2D3(this);
        }
    }
    public class Iterator2D3 : Iterator
    {
        private int iteratorRow;
        private int iteratorColumn;
        private Aggregate2D3 _aggregate2D2;
        public Iterator2D3(Aggregate2D3 zad2)
        {
            _aggregate2D2 = zad2;
            iteratorRow = _aggregate2D2.matrice.GetLength(0)-1;
            iteratorColumn = _aggregate2D2.matrice[iteratorRow].Length-1;
        }

        public override double GetNext()
        {
            if (iteratorRow < 0)
            {
                iteratorRow = _aggregate2D2.matrice.GetLength(0) - 1;
                iteratorColumn--;
                return _aggregate2D2.matrice[iteratorRow--][iteratorColumn];


            }
            return _aggregate2D2.matrice[iteratorRow--][iteratorColumn];


        }
        public override bool HasNext()
        {
            if (iteratorRow <= 0)
            {
                if (iteratorColumn <= 0)
                {
                    return false;
                }
                return true;

            }
            return true;
        }




    }
}
