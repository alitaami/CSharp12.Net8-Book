using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

public class Solution
{

    public static void Main(string[] args)
    {

    }

    #region ConstAndReadOnly
    public void ConstAndReadOnly()
    {
        //const

        //const int x = 5;	
        //At compile-time	
        //Immutable and cannot be changed ever	
        //Universal constants like Pi, fixed values	
        //Faster (inlined at compile time)	
        //Implicitly static	
        //Only primitive types, strings, or enums	


        //------------------------------------------


        //readonly

        //At run-time (in constructor or at declaration)
        //Can be assigned once, but at run-time
        //Not static by default
        //Slightly slower (accessed at run time)
        //Instance-specific or runtime-known values
        //readonly string path = GetPath();
        //Any type (objects, lists, etc.)

    }
    #endregion

    #region UnaryOperators usage
    private static void UnaryOperators()
    {
        int c = 2;
        int d = c++; // first assign and then increment
        // c is 3, d is 2

        int a = 2;
        int b = ++a; // first assign and then increment
        // a is 3 , b is 3
    }
    #endregion

    #region PatternMatching
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
    #endregion

    #region SwitchCase
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
    #endregion

    #region Loops
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

    #endregion

    #region Arrays
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
    #endregion

    #region Casting
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
    #endregion

    #region Out and Ref
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
    #endregion


    #region Interface & AbstractClass
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
        #endregion

        #region InstantiatingClasses
        public class Person()
        {

        }

        public void InstantiatingClasses()
        {
            Person bob = new(); // C# 9 or later
        }
        #endregion

        #region AccessModifiers
        public void AccessModifiers()
        {
            //private => The member is accessible inside the type only.This is the default.

            //internal => The member is accessible inside the type and any type in the same assembly.

            //protected => The member is accessible inside the type and any type that inherits from the type.

            //public => The member is accessible everywhere.

            //internal protected =>
            //The member is accessible inside the type, any type in the same assembly, and any
            //type that inherits from the type.Equivalent to a fictional access modifier named
            //internal_or_protected.

            //private protected =>
            //The member is accessible inside the type and any type that inherits from the
            //type and is in the same assembly.Equivalent to a fictional access modifier named
            //internal_and_protected.This combination is only available with C# 7.2 or later.
        }
        #endregion

        #region Enums
        public enum Days
        {
            [Display(Name = "Sunday")]
            Sun = 1,
            [Display(Name = "Monday")]
            Mon = 2,
            [Display(Name = "Tuesday")]
            Tue = 3,
            [Display(Name = "Wednesday")]
            Wed = 4,
            [Display(Name = "Thursday")]
            Thu = 5,
            [Display(Name = "Friday")]
            Fri = 6,
            [Display(Name = "Saturday")]
            Sat = 7
        }

        // A way to assign bytes for enum values
        [Flags]
        public enum Days_ : byte
        {
            Sun = 0b_0000_0000,
            Mon = 0b_0000_0001,
            Tue = 0b_0000_0010,
            Wed = 0b_0000_0100,
            Thu = 0b_0000_1000,
            Fri = 0b_0001_0000,
            Sat = 0b_0010_0000
        }
        #endregion

        #region RequiredFields
        public class RequiredFields()
        {
            public required string? Name;
            public string? Title;
        }
        public void RequiredField()
        {
            var class_ = new RequiredFields()
            {
                Name = null, //We should assign sth to it even it`s nullable   
                Title = "Mr."
            };
        }
        #endregion

    }
}
