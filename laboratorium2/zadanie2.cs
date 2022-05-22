using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorium2
{
    public class Aggregate2D2 : Aggregate
    {
        public double[][] matrice = new double[4][];
        public Aggregate2D2()
        {
            matrice[0] = new double[]{
                 -0.1 , 0.0 , 0.1, };
            matrice[1] = new double[]{
                -0.1 , 0.0 , 0.1  };
            matrice[2] = new double[]{
                -0.1 , 0.0 , 0.1 };
            matrice[3] = new double[]{
                -0.1 , 0.0 , 0.1 };
        }
        public override Iterator2D2 CreateIterator()
        {
            return new Iterator2D2(this);
        }
    }
    public class Iterator2D2 : Iterator
    {
        private int iteratorRow;
        private int iteratorColumn;
        private Aggregate2D2 _aggregate2D2;
        public Iterator2D2(Aggregate2D2 zad2)
        {
            _aggregate2D2 = zad2;
            iteratorRow = 0;
            iteratorColumn = 0;
        }

        public override double GetNext()
        {
            if (iteratorRow >= _aggregate2D2.matrice.GetLength(0))
            {
                iteratorRow = 0;
                iteratorColumn++;
                return _aggregate2D2.matrice[iteratorRow++][iteratorColumn];


            }
            return _aggregate2D2.matrice[iteratorRow++][iteratorColumn];
            
            
        }
        public override bool HasNext()
        {
            if (iteratorRow >= _aggregate2D2.matrice.GetLength(0) - 1)
            {
                if (iteratorColumn >=
                _aggregate2D2.matrice[iteratorRow-1].Length -1)
                {
                    return false;
                }
                return true;
                
            }
            return true;
        }
        
        


    }


}
