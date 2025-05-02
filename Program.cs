using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public class Solution
{
    public static void Main(string[] args)
    {

    }

    private static void UnaryOperators()
    {
        int c = 2;
        int d = c++; // first assign and then increment
        // c is 3, d is 2

        int a = 2;
        int b = ++a; // first assign and then increment
        // a is 3 , b is 3
    }
    private static void PatternMatching()
    {
        object o = "3";
        int j = 4;
        if (o is int i)
        {
            Console.WriteLine($"{i} x {j} = {i * j}");
        }
        else
        {
            Console.WriteLine("o is not an int so it cannot multiply!");
        }
    }
    private static void SwitchCase()
    {
        int number = Random.Shared.Next(minValue: 1, maxValue: 3);
        string result;

        result = number switch
        {
            1 => "One",
            2 => "Two",
            3 => "Two",
            _ => "Unknown"
        };

        // ---------------- Newer Version ----------------

        switch (number)
        {

            case 1:
                result = "One";
                break;

            case 2:
                result = "Two";
                break;

            case 3:
                result = "Three";
                break;

            case 11 or 12 or 13:
                result = "eleven or twelve or thirteen";
                break;

            default:
                break;
        }
    }
    private static void Do_While()
    {
        string pass = "password";
        string rePass = "passowrd";

        do
        {
            // do sth;
            throw new Exception("Pass is wrong!");
        }
        while (pass != rePass);
    }
    private static void Foreach_Structure()
    {
        string[] names = { "Adam", "Barry", "Charlie" };

        foreach (string name in names)
        {
            Console.WriteLine($"{name} has {name.Length} characters.");
        }

        //-----------------------------------

        IEnumerator e = names.GetEnumerator();

        while (e.MoveNext())
        {
            string name = (string)e.Current;
        }
    }

    private static void TwoDimensionalArray()
    {
        string[,] array = new string[3, 3]
        {
            {"a","b","c"},
            {"d","e","f" },
            {"g","h","i" }
        };

        for (int row = 0; row <= array.GetUpperBound(0); row++)
        {
            for (int col = 0; col <= array.GetUpperBound(1); col++)
            {
                Console.WriteLine($"Row {row}, Column {col}: {array[row, col]}");
            }
        }
    }

    private static void TwoDimensionalJaggedArray()
    {
        string[][] jagged =  // An array of string arrays.
        {
         new[] { "Alpha", "Beta", "Gamma" },
         new[] { "Anne", "Ben", "Charlie", "Doug" },
         new[] { "Aardvark", "Bear" }
        };

        for (int row = 0; row <= jagged.GetUpperBound(0); row++)
        {
            for (int col = 0; col <= jagged.GetUpperBound(1); col++)
            {
                Console.WriteLine($"Row {row}, Column {col}: {jagged[row][col]}");
            }
        }
    }
    private static void ListPatternMatching()
    {
        static string CheckSwitch(int[] values) => values switch
        {
            [] => "Empty array", // []
            [1, 2, _, 10] => "Contains 1, 2, any single number, 10.", // [1,2,3,10] Or [1,3,3,10]
            [1, 2, .., 10] => "Contains 1, 2, any range including empty, 10.",  //  [1, 2, 10]   Or   [1, 2, 3, 4, 5, 10] // 
            [1, 2] => "Contains 1 then 2.", // [1,2]
            [int item1, int item2, int item3] => $"Contains {item1} then {item2} then {item3}.", // exactly 3 having item
            [0, _] => "Starts with 0, then one other number.", // [0,111] Or [0,99]
            [0, ..] => "Starts with 0, then any range of numbers.", // [0,111]  Or [0, 2, 3, 4 ,10]    
            [2, .. int[] others] => $"Starts with 2, then {others.Length} more numbers.", // [2, 9, 3]  
            [..] => "Any items in any order.", // [1, 5, 9] Or [100]
        };
    }

    private static void CastDoubleToInt()
    {
        double c = 10.2;
        int b = (int)c;
    }
    private static void CastLongToInt()
    {
        long e = long.MaxValue;
        int f = (int)e;
        // e is 10, f is 10
        //e is 9,223,372,036,854,775,807, f is -1 => for very big numbers it is not able to cast it in a true way!
    }
    private static void ConvertLongToInt()
    {
        double g = 9.8;
        int h = System.Convert.ToInt32(g);
        // g is 9.8, h is 10 => it rounds up the number
    }

    private static void LearnOutKeyword(out string test1)
    {
        test1 = "test";
    }

    private static void LearnRefKeyword(ref string test2)
    {
        test2 = "test";
    }

    private static void LearnToUseRefAndOut()
    {
        // We don`t need to declare the variable before using it with out keyword
        LearnOutKeyword(out string test1);


        // We need to declare the variable before using it with ref keyword
        var test2 = "test2";
        LearnRefKeyword(ref test2);
    }

    public interface Interface
    {
        public void test();
    }
    public abstract class Abstract()
    {
        public abstract void test();
        public virtual void test1()
        {

        }
        public void test2()
        {

        }
    }
    public class UseInterfaceAndAbstract()
    {
        public class UseInterface : Interface
        {
            public void test()
            {
                // bla bla
            }
        }

        public class UseAbstract : Abstract
        {
            public override void test()
            {
                // bla bla
            }

            // Optional ( We can ignore it and not override it)
            public override void test1()
            {
                // bla bla
            }
        }

        public class Person()
        {

        }

        public void InstantiatingClasses()
        {
            Person bob = new(); // C# 9 or later
        }
    }
}
