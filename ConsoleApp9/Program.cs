using System;
using System.Collections;
using System.Collections.Generic;

class App
{
    public static void Main(string[] args)
    {
        Exercise1<string> team = new Exercise1<string>("Adam", "Ola", "Ewa");

        foreach(var member in team)
        {
          Console.WriteLine(member);
        }
        Console.WriteLine("*********************************");

        CurrencyRates rates = new CurrencyRates();
        rates[Currency.EUR] = 4.6m;
        Console.WriteLine(rates[Currency.EUR]);
        Console.WriteLine("*********************************");

        Exercise3 e3 = new Exercise3();
        e3.PrintNextHexNum();

    }

    
}
//Cwiczenie 1 (2 punkty)
//Zmodyfikuj klasę Exercise1 aby implementowała interfesj IEnumerable<T>
//Zdefiniuj metodę GetEnumerator, aby zwracał kolejno pola Manager, MemberA, MemberB
//Przykład
//Exercise1<string> team = new Exercise1(){ Manager: "Adam", MemberA: "Ola", MemberB: "Ewa"};
//foreach(var member in team){
//    Console.WriteLine(member);
//}
//otrzymamy na ekranie
//Adam
//Ola
//Ewa
public class Exercise1<T> : IEnumerable<T>
{
    public Exercise1(T manager, T memberA, T meberB)
        {
        Manager = manager;
        MemberA = memberA;
        MemberB = meberB;
        }
    public T Manager { get; init; }
    public T MemberA { get; init; }
    public T MemberB { get; init; }

    public IEnumerator<T> GetEnumerator()
    {
        yield return Manager;
        yield return MemberA;
        yield return MemberB;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

//Cwiczenie 2 (2 punkty)
//Zdefiniuj indekser dla klasy CurrencyRates, aby umożliwiał przypisania i pobierania notowania dla danej waluty.
//Zainicjuj tablice _rates, aby jej rozmiar byl równy liczbie stałych wyliczeniowych w klasie Currency i nie wymagał zmiany
//gdy zostaną dodane następne stałe.
//Przykład
//CurrencyRates rates = new CurrencyRates();
//rates[Currency.EUR] = 4.6m;
//Console.WriteLine(rates[Currency.EUR]);

public enum Currency
{
    PLN,
    USD,
    EUR,
    CHF
}

public class CurrencyRates
{
    //utwórz tablicę o rozmiarze równym liczbie stalych wyliczeniowych Currency
    private Dictionary<Currency, decimal> _rates = new Dictionary<Currency, decimal>();

    public decimal this[Currency i] { get { return _rates[i];  } set { _rates[i] = value;  } }

}

//Cwiczenie 3
//Zdefiniuj enumerator zwracający kolejne liczby szesnastowe zapisane w łańcuchu o długości 8 znaków plus znaki 0x jako prefiks
//Przykład 
//0x00000000 0x00000001 0x00000002 0x00000003 ... 0x0000000A ... 0x000000010 ... 0xFFFFFFFF 
//Zdefiniuj metodę GetLimitedHex(int digitCount), która zwraca enumerator z liczbami o podanej liczbie cyfr.
//Przykład wykorzystania metody
// var limitedHex = hex.GetLimitedHex(4);
// while (limitedHex.MoveNext())
// {
//     Console.WriteLine(limitedHex.Current);
// }
//Wyjście:
//0x0000
//0x0001
//...
//0x2c7b
//0x2c7c
//0x2c7d
//...
//0xffff
public class HexNum
{
    private char[] hexNums = { '0', '1', '2', '3', '4', '5', '6', '7', '8',
        '9', 'a', 'b', 'c', 'd', 'e', 'f' };
    private char Hex { get; set; }
    public HexNum PrecedingHexNum { get; set; }
    public HexNum(char hex)
    {
        Hex = hex;
    }

    public List<char> ProcessChainAdditionCommand(List<char> input)
    {
        List<char> processingInput = input;
        if(PrecedingHexNum != null)
        {
            processingInput = PrecedingHexNum.ProcessChainAdditionCommand(processingInput);
        }
        return ProcessAdditionCommand(processingInput);
    }
    public List<char> ProcessAdditionCommand(List<char> input)
    {
        bool increment = false;
        if (input.Count == 0) increment = true;//if its the first digit
        else if (input[input.Count - 1] == 'g') increment = true;//if were dealing with a carry
        if (increment == true)
        {
            if (Hex == 'f')
            {
                Hex = '0';
                input.Add('g');
                return input;
            }
            for (int i = 0; i < hexNums.Length; i++)
            {
                if (Hex == hexNums[i])
                {
                    Hex = hexNums[i + 1];
                    input.Add(Hex);
                    return input;
                }
            }
        }
        return input;

    }
}

class Exercise3 
{
    public HexNum FirstDigit;
    HexNum h1;
    HexNum h2;
    HexNum h3;
    public void PrintNextHexNum()
    {
        List<char> emptyHexNum = new List<char>();
        List<char> filledHexNum = FirstDigit.ProcessChainAdditionCommand(emptyHexNum);
        string nextHexNum = "";
        foreach (char item in filledHexNum)
        {
            nextHexNum += (" "+item+" ");
        }
        Console.WriteLine(nextHexNum);
    }
    public Exercise3()
    {
        h1 = new HexNum('0');
        h2 = new HexNum('0');
        h3 = new HexNum('0');
        h2.PrecedingHexNum = h1;
        h3.PrecedingHexNum = h2;
        FirstDigit = h3;
    }
}

/*class Exercise3 : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<string> GetLimitedHex(int digitCount)
    {
        throw new NotImplementedException();
    }
}
*/
enum ChessPiece
{
    Empty,
    King,
    Queen,
    Rook,
    Bishop,
    Knight,
    Pawn
}

enum ChessColor
{
    Black,
    White
}

//Cwiczenie 4 (4 punkty)
//Zdefiniuj klasę opisująca szachownicę z indekserem umożliwiającym dostęp do pola
//na podstawie indeksu w postaci łańcucha np.: "A5" oznacza pierwszą kolumnę i 5 wiersz (od dołu).
//W podanych współrzędnych należy umieścić krotkę z dwoma stałymi wyliczeniowymi (ChessPiece, ChessColor)
//Przykład
//Exercise4 board = new Exerceise4();
//board["A5"] = (ChessPiece.King, ChessColor.White);
//Console.WriteLine(board["A8"]); // pole bez figury w kolorze białym (ChessPiece.Empty, ChessColor.White)
//Console.WriteLine(board["A1"]); // pole bez figury w kolorze czarnym (ChessPiece.Empty, ChessColor.Black)
//Klasa powinna zachować zasadę, że nie można umieścić więcej niż dozwolona liczba figur danego typu:
//1 królowa i król, 2 wieże, gońce, skoczki, 8 pionów
//W sytuacji, gdy zostanie dodana nadmiarowa figura np. 3 skoczek w kolorze białym, klasa powinna zgłosić wyjątek InvalidChessPieceCount
//W sytuacji podania niepoprawnych współrzednych np. K9 lub AA44, klasa powinna zgłosić wyjątek InvalidChessBoardCoordinates 
class Exercise4
{
    private (ChessPiece, ChessColor)[,] _board = new (ChessPiece, ChessColor)[8, 8];
}

class InvalidChessPieceCount : Exception
{

}

class InvalidChessBoardCoordinates : Exception
{

}