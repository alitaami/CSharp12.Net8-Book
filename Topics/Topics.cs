using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using static System.Collections.Specialized.BitVector32;
using aliasedTuple = (string test1, string test2);

namespace LearnCSharp.Topics
{
    public class Topics
    {
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
            int d = c++; // post-increment: assign first, then increment
                         // c is 3, d is 2

            int a = 2;
            int b = ++a; // pre-increment: increment first, then assign
                         // a is 3, b is 3
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

        #region Arrays & Lists
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

        public class ListInitialization
        {
            public class Parent
            {
                public List<Person> persons1 = new();       // Field: single list instance
                public List<Person> persons2 => new();      // Property: returns new list on each access
            }

            public class Person
            {
            }

            private void Test()
            {
                int count = 0;

                // Initializing a list with a new instance
                var parent1 = new Parent();
                parent1.persons1.Add(new Person());
                count = parent1.persons1.Count; // returns 1

                // Initializing a list with a new instance every time
                var parent2 = new Parent();
                parent2.persons2.Add(new Person());
                count = parent2.persons2.Count; // returns 1
                count = parent2.persons2.Count; // returns 0 next time — it's a new list!
            }
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
            int h = Convert.ToInt32(g);
            // g is 9.8, h is 10 => it rounds up the number
        }
        #endregion

        #region Out, Ref, In
        private static void LearnOutKeyword(out string test1)
        {
            test1 = "test";
        }

        private static void LearnRefKeyword(ref string test2)
        {
            test2 = "test";
        }

        private static string LearnInKeyword(in string test3)
        {
            // The in keyword is used to pass a parameter by reference, but it is read-only.
            // This means that the method cannot modify the value of the parameter.
            // If we try to modify it, we will get a compile-time error.
            return test3;
        }

        private static void LearnToUseRefAndOut()
        {
            // We don`t need to declare the variable before using it with out keyword
            LearnOutKeyword(out string test1);


            // We need to declare the variable before using it with ref keyword
            var test2 = "test2";
            LearnRefKeyword(ref test2);

            // We need to declare the variable before using it with in keyword
            var test3 = "test3";
            var result = LearnInKeyword(test3);
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
                public int name { get; set; }

                public void WriteToConsole()
                {
                }
                public void Greet()
                {

                }
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


            public class Book
            {
                public required string? Isbn { get; set; }
                public required string? Title { get; set; }
                public string Author { get; set; }

                public Book()
                {

                }

                // [Required] is validating the data in runtime 
                public Book([Required] string isbn, [Required] string title)
                {
                    // assign them to the properties
                }

                // [SetsRequiredMembers] is validating the data in compile time
                [SetsRequiredMembers]
                public Book(string? isbn, string? title, string? author)
                {
                    // assign them to the properties
                }
            }

            public class TestRequiredFields
            {
                public void Test()
                {
                    // This will throw an exception at runtime if the required fields are not set
                    var book = new Book()
                    {
                        Isbn = "123-456-789",
                        Title = "C# Programming"
                    };

                    // This will throw an exception at compile time if the required fields are not set
                    var book2 = new Book("123-456-789", "C# Programming", "");
                }
            }
            #endregion

            #region Tuples
            public class Tuple()
            {
                public void Tuples()
                {
                    (double, int) tuple1 = (4.5, 3);

                    (double t, int s) = (4.5, 3);

                    var tuple2 = (s: "s", d: "d");

                    // name our tuples
                    var (getTuple1, getTuple2) = tuple1;

                    // use them without naming them
                    var x = (tuple2.Item1, tuple2.Item2);

                    // You can define tuples with an arbitrary large number of elements
                    var tuple3 =
                    (1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18,
                    19, 20, 21, 22, 23, 24, 25, 26);

                    var test = tuple3.Item26;

                    (double, int, int) tuple4 = (4.5, 3, 5);

                    #region Aliasing Tuples
                    // You can use tuples as method parameters
                    aliasedTuple aliasedTuple1 = GetAliasedTuple();
                    #endregion
                }
                private (string test1, string test2) GetAliasedTuple()
                {
                    return (test1: "test1", test2: "test2");
                }
            }
            #endregion

            #region LocalFunctions

            public void LocalFunctions()
            {
                LocalFunction();

                // Local functions are methods defined inside other methods
                // They can be used to encapsulate logic that is only relevant to the containing method
                // They can access variables from the containing method
                void LocalFunction()
                {
                    Console.WriteLine("This is a local function.");
                }
            }
            #endregion

            #region Partial Classes

            // Partial classes allow you to split the definition of a class into multiple files
            partial class testPartial
            {
                public void test_()
                {
                    Console.WriteLine("This is a partial class.");
                }

            }
            partial class testPartial
            {
                public void test__()
                {
                    Console.WriteLine("This is a partial class.");
                }
            }

            public static void test_Partial()
            {
                var partial = new testPartial();

                partial.test_();
                partial.test__();
            }
            #endregion

            #region Overloading 
            public class Overloading()
            {
                // Overloading is the ability to define multiple methods with the same name but different parameters
                // It can be used to create methods that perform similar operations on different types of data
                int Add(int a, int b)
                {
                    return a + b;
                }
                double Add(double a, double b)
                {
                    return a + b;
                }
                string Add(string a, string b)
                {
                    return a + b;
                }
            }
            #endregion

            #region RecordStructs & Records & DTOs

            public class AnimalDTO
            {
                public string? Name { get; set; }
            }
            public record AnimalRecord(string? Name);
            public record struct AnimalRecordStruct(string? Name);

            public class DTOs_vs_Records
            {
                public void Test()
                {
                    #region Introduction

                    // DTOs are used to transfer data between layers of an application
                    // They are usually simple classes with properties and no methods
                    AnimalDTO animalDTO = new AnimalDTO() { Name = "Dog" };
                    animalDTO.Name = "Cat"; // DTOs can be mutable, meaning their properties can be changed after creation

                    // Records are immutable data structures that can be used to represent data
                    // They are similar to DTOs but have some additional features like value equality
                    AnimalRecord animalRecord = new AnimalRecord("Cat");
                    //animalRecord.Name = ""; => This will not compile because records are immutable, meaning their properties cannot be changed after creation

                    #endregion

                    #region Comparison
                    // DTOs are compared by reference, meaning two different instances with the same data are not equal
                    AnimalDTO animalDTO1 = new AnimalDTO() { Name = "Dog" };
                    AnimalDTO animalDTO2 = new AnimalDTO() { Name = "Dog" };

                    AnimalRecord animalRecord1 = new AnimalRecord("Dog");
                    AnimalRecord animalRecord2 = new AnimalRecord("Dog");

                    // This will return false because they compared by reference
                    bool areDTOsEqual = animalDTO1 == animalDTO2; // false

                    // This will return true because records are compared by value, meaning two instances with the same data are equal
                    bool areRecordsEqual = animalRecord1 == animalRecord2; // true

                    var a1 = new AnimalRecordStruct("Dog");
                    var a2 = new AnimalRecordStruct("Dog");

                    bool areRecordStructsEqual = a1 == a2; // true

                }
                #endregion
            }
            #endregion

            #region Important Interfaces 

            public class ImportantInterfaces : IComparable, IComparer, IDisposable //and many others..
            {
                private bool disposedValue;

                //This defines a comparison method that a secondary type implements to order or sort instances of a primary type.
                public int Compare(object? x, object? y) => this.Compare(1, 2);

                //This defines a comparison method that a type implements to order or sort its instances
                public int CompareTo(object? obj) => this.CompareTo(new object[1, 2]);

                //This defines a disposal method to release unmanaged resources more efficiently than waiting for a finalizer.See the Releasing unmanaged resources section later in this chapter for more details
                protected virtual void Dispose(bool disposing)
                {
                    if (!disposedValue)
                    {
                        if (disposing)
                        {
                            // TODO: dispose managed state (managed objects)
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                        // TODO: set large fields to null
                        disposedValue = true;
                    }
                }

                // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
                // ~ImportantInterfaces()
                // {
                //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                //     Dispose(disposing: false);
                // }

                public void Dispose()
                {
                    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                    Dispose(disposing: true);
                    GC.SuppressFinalize(this);
                }

                #endregion

                #region Boxing & UnBoxing
                public class BoxingAndUnboxing
                {
                    // Boxing is the process of converting a value type to an object type
                    // Unboxing is the process of converting an object type back to a value type
                    public void BoxingAndUnboxingExample()
                    {
                        int x = 4;
                        object o = x; // Boxing: converting int to object
                        int y = (int)o; // Unboxing: converting object back to int
                    }
                }
                #endregion

                #region Equality in ReferenceTypes and ValueTypes

                public class EqualityInTypes
                {
                    public void EqualityExample()
                    {
                        int a = 5;
                        int b = 5;
                        bool areEqualValueTypes = a == b; // true

                        // string literals are interned, so references are the same
                        string str1 = "Hello";
                        string str2 = "Hello";
                        bool areEqualReferenceTypes = str1 == str2; // true (value and reference equal due to interning)

                        var test1 = new EqualityTest(1);
                        var test2 = new EqualityTest(1);
                        var test3 = test1;
                        bool areEqualReferenceTypes2 = test1 == test2; // false (different references)
                        bool areEqualReferenceTypes2_1 = test1 == test3; // true (same references)

                        // To compare by value, override Equals and GetHashCode or use 'record'
                    }

                    public class EqualityTest(int test)
                    {
                        public int Test { get; set; } = test;
                    }
                }

                #endregion

                #region Nullability

                public class nullability
                {
                    public int? id { get; set; }
                    public string? test { get; set; } //new
                    public string test2 { get; set; } //old - we get nullability warn
                }

                public void _nullability()
                {
                    var n = new nullability();
                    int? length;

                    // old
                    if (!(n is null)) { }

                    //new
                    if (n is not null) { }


                    // The following throws a NullReferenceException.
                    length = n.test.Length;

                    // Instead of throwing an exception, null is assigned.
                    length = n.test?.Length;

                    // And aldo we can use the null-coalescing operator to provide a default value.
                    length = n.test?.Length ?? 0;

                }
                public void _nullability2(nullability nullability)
                {
                    // old
                    if (nullability is null)
                    {
                        throw new ArgumentNullException(paramName: nameof(nullability));
                    }

                    // new - C# 10
                    ArgumentNullException.ThrowIfNull(nullability);
                }
                #endregion

                #region Extending classes to add functionality
                public class Employee : Person
                {
                    public int age { get; set; }

                    // Hiding the function in base class
                    public new void WriteToConsole()
                    {
                    }
                    public void Work()
                    {

                    }
                    public void this_and_base()
                    {
                        base.WriteToConsole(); // BaseClass one
                        this.WriteToConsole(); // DerivedClass one
                    }
                }

                public void ExtendingClasses()
                {
                    // --- Hiding Members ---

                    Person obj = new Employee();  // Upcasting
                    obj.WriteToConsole(); // Calls BaseClass version!

                    Employee obj2 = new Employee();
                    obj2.WriteToConsole(); // Calls DerivedClass version!


                    // --- Upcasting & Downcasting

                    // Allowed, because Greet() is in Person
                    obj.Greet();
                    obj2.Greet();

                    // ❌ Error: Work() is not defined in Person
                    // obj.Work();    
                    
                    Employee emp1 = (Employee)obj; // Downcasting
                    emp1.Work();


                    Employee emp2 = obj as Employee; // Downcasting
                    if (emp2 != null)
                        emp2.Work();
                }
                #endregion

            }
        }
    }
}
