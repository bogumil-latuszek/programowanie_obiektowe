using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;

class App
{
    public static void Main(string[] args)
    {
        List<Car> _cars = new List<Car>()
        {
            new Car(),
            new Car(Model: "Fiat", true),
            new Car(),
            new Car(Power: 100),
            new Car(Model: "Fiat", true),
            new Car(Power: 125),
            new Car()
        };
        Console.WriteLine(Exercise3.CarCounter(_cars, 0));

        Console.WriteLine("Zad4:");
        Student[] students = 
        {
            new Student("Kowal","Adam", 'A'),
            new Student("Nowak","Ewa", 'A')
        };

        Exercise4.AssignStudentId(ref students);
        foreach (var item in students)
        {
            Console.WriteLine(item);
        }

    }


}

enum Direction8
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    UP_LEFT,
    DOWN_LEFT,
    UP_RIGHT,
    DOWN_RIGHT
}

enum Direction4
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

//Cwiczenie 1
//Zdefiniuj metodę NextPoint, która powinna zwracać krotkę ze współrzędnymi piksela przesuniętego jednostkowo w danym kierunku względem piksela point.
//Krotka screenSize zawiera rozmiary ekranu (width, height)
//Przyjmij, że początek układu współrzednych (0,0) jest w lewym górnym rogu ekranu, a prawy dolny ma współrzęne (witdh, height) 
//Pzzykład
//dla danych wejściowych 
//(int, int) point1 = (2, 4);
//Direction4 dir = Direction4.UP;
//var point2 = NextPoint(dir, point1);
//w point2 powinny być wartości (2, 3);
//Jeśli nowe położenie jest poza ekranem to metoda powinna zwrócić krotkę z point
class Exercise1
{
    public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
    {
        (int, int) new_point = point;
        //choose function
        //do calculation
        switch (direction)
        {
            case Direction4.UP: new_point.Item2--; break;
            case Direction4.DOWN: new_point.Item2++; break;
            case Direction4.LEFT: new_point.Item1--; break;
            case Direction4.RIGHT: new_point.Item1++; break;
        }
        //check if new point is legal
        if (new_point.Item1<0||
            new_point.Item2 < 0 ||
            new_point.Item1 > screenSize.Item1 ||
            new_point.Item2 > screenSize.Item2)
        {
            return point;
        }
        return new_point;
        //return legal new point or previous point
    }
}
//Cwiczenie 2
//Zdefiniuj metodę DirectionTo, która zwraca kierunek do piksela o wartości value z punktu point. W tablicy screen są wartości
//pikseli. Początek układu współrzędnych (0,0) to lewy górny róg, więc punkt o współrzęnych (1,1) jest powyżej punktu (1,2) 
//Przykład
// Dla danych weejsciowych
// static int[,] screen =
// {
//    {1, 0, 0},
//    {0, 0, 0},
//    {0, 0, 0}
// };
// (int, int) point = (1, 1);
// po wywołaniu - Direction8 direction = DirectionTo(screen, point, 1);
// w direction powinna znaleźć się stała UP_LEFT
class Exercise2
{
    static int[,] screen =
    {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

    private static (int, int) point = (1, 1);

    private Direction8 direction = DirectionTo(screen, point, 1);

    public static Direction8 DirectionTo(int[,] screen, (int, int) point, int value)
    {
        //locate point2
        (int, int) p1 = point;
        (int item1, int item2) p2 = (0, 0);
        for (int i = 0; i < screen.GetLength(0); i++)
        {
            for (int a = 0; a < screen.GetLength(1); a++)
            {
                if (screen[i,a] == value)
                {
                    p2 = (i, a);
                }
            }

        }
        //compare them and find direction

        Direction8 d8 = Direction8.UP;
        if (p2.item1> p1.Item1)//right
        {
            if (p2.item2 > p1.Item2)//down
            {
                d8 = Direction8.DOWN_RIGHT;
            }
            else if (p2.item2 < p1.Item2)//up
            {
                d8 = Direction8.UP_RIGHT;
            }
        }
        else if (p2.item1 < p1.Item1)//left
        {
            if (p2.item2 > p1.Item2)//down
            {
                d8 = Direction8.DOWN_LEFT;
            }
            else if (p2.item2 < p1.Item2)//up
            {
                d8 = Direction8.UP_LEFT;
            }
        }
        else if (p2.item1 == p1.Item1)//0
        {
            if (p2.item2 > p1.Item2)//down
            {
                d8 = Direction8.DOWN;
            }
            else if (p2.item2 < p1.Item2)//up
            {
                d8 = Direction8.UP;
            }
        }
        else if (p2.item2 == p1.Item2)//0
        {
            if (p2.item1 > p1.Item1)//right
            {
                d8 = Direction8.RIGHT;
            }
            else if (p2.item1 < p1.Item1)//left
            {
                d8 = Direction8.LEFT;
            }
        }
        else { }
        return d8;
    }
}

//Cwiczenie 3
//Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
//Przykład
//dla danych wejściowych
// Car[] _cars = new Car[]
// {
//     new Car(),
//     new Car(Model: "Fiat", true),
//     new Car(),
//     new Car(Power: 100),
//     new Car(Model: "Fiat", true),
//     new Car(Power: 125),
//     new Car()
// };
//wywołanie CarCounter(Car[] cars) powinno zwrócić 3 //właściwie to powinno wrócić 4, czwarta instancja też ma defaultowe wartości
record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

class Exercise3
{
    public static int CarCounter(List<Car> cars, int Most_common_car_counter = 0)
    {
        int Type_counter = 0;
        Car Car_type = cars[0];
        List<Car> reduced_cars = new List<Car>();
        foreach (Car car in cars)
        {
            if (car == Car_type )
            {
                Type_counter++;
            }
            else
            {
                reduced_cars.Add(car);
            }
        }
        if (Type_counter > Most_common_car_counter) 
        { 
            Most_common_car_counter = Type_counter; 
        }
        if (reduced_cars.Count>0)
        {
            return CarCounter(reduced_cars, Most_common_car_counter);
        }
        else { return Most_common_car_counter; }
    }
}

record Student(string LastName, string FirstName, char Group, string StudentId = "");
//Cwiczenie 4
//Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
//Przykład
//dla danych wejściowych
//Student[] students = {
//  new Student("Kowal","Adam", 'A'),
//  new Student("Nowak","Ewa", 'A')
//};
//po wywołaniu metody AssignStudentId(students);
//w tablicy students otrzymamy:
// Kowal Adam 'A' - 'A001'
// Nowal Ewa 'A'  - 'A002'
//Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
public class IdCounter
{
    private int IdCount;
    public IdCounter()
    {
        IdCount = 0;
    }
    public int GetNext()
    {
        return IdCount++;
    }
}
class Exercise4
{
    public static void AssignStudentId(ref Student[] students)
    {
        IdCounter Id = new IdCounter();
        Student[] studentsWithId = new Student[students.Length];
        for (int i = 0; i < students.Length; i++)
        {
            studentsWithId[i] = students[i] with { StudentId = students[i].Group + Id.GetNext().ToString("000") };
        }
        students = studentsWithId;
    }
}