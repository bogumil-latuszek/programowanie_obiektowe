using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorium2
{
    /*
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
    public abstract class Iterator
    {
        public abstract int GetNext();
        public abstract bool HasNext();
    }
    public class ArrayIntAggregate : Aggregate
    {
        internal int[] array = { 1, 2, 3, 4, 5 };

        public override Iterator CreateIterator()
        {
            return new ArrayIntIterator(this);
        }
    }
    public sealed class ArrayIntIterator : Iterator
    {
        private int _index = 0;
        private ArrayIntAggregate _aggregate;
        public ArrayIntIterator(ArrayIntAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        public override int GetNext()
        {
            return _aggregate.array[_index++];
        }
        public override bool HasNext()
        {
            return _index < _aggregate.array.Length;
        }
    }
    */
    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
    public abstract class Iterator
    {
        public abstract double GetNext();
        public abstract bool HasNext();
    }
    public class Aggregate2D : Aggregate
    {
        public double[][] matrice = new double[4][];
        public Aggregate2D()
        {
            matrice[0] = new double[]{
                 -0.1 , 0.0 , 0.1, 0.3 };
            matrice[1] = new double[]{
                -0.1 , 0.0 , 0.1  };
            matrice[2] = new double[]{
                -0.1 , 0.0 , 0.1 };
            matrice[3] = new double[]{
                -0.1 , 0.0 , 0.1 , 0.0, 0.0 };
        }
        public override Iterator2D CreateIterator()
        {
            return new Iterator2D(this);
        }
    }
    public class Iterator2D : Iterator
    {
        private int iteratorRow;
        private int iteratorColumn;
        private Aggregate2D Aggregate2D;
        public Iterator2D(Aggregate2D zad2)
        {
            Aggregate2D = zad2;
            iteratorRow = Aggregate2D.matrice.GetLength(0) - 1;
            iteratorColumn = Aggregate2D.matrice[iteratorRow].Length - 1;
        }

        /*public double GetNext()
        {
            if (iteratorColumn >= Aggregate2D.matrice[iteratorRow].Length - 1)
            {
                iteratorColumn = 0;
                iteratorRow++;
                return Aggregate2D.matrice[iteratorRow][iteratorColumn];
                iteratorColumn++;


            }
            return Aggregate2D.matrice[iteratorRow][iteratorColumn];
            iteratorColumn++;
            
        }
        public bool HasNext()
        {
            if (iteratorColumn >= Aggregate2D.matrice[iteratorRow].Length-1)
            {
                if (iteratorRow >=
                Aggregate2D.matrice.GetLength(0) - 1)
                {
                    return false;
                }
                return true;
                
            }
            return true;
        }
        */
        public override double GetNext()
        {
            if (iteratorColumn < 0)
            {
                iteratorRow--;
                iteratorColumn = Aggregate2D.matrice[iteratorRow].Length - 1;
                return Aggregate2D.matrice[iteratorRow][iteratorColumn--];



            }
            return Aggregate2D.matrice[iteratorRow][iteratorColumn--];


        }
        public override bool HasNext()
        {
            if (iteratorColumn <= 0)
            {
                if (iteratorRow <=
                0)
                {
                    return false;
                }
                return true;

            }
            return true;
        }


    }
}
