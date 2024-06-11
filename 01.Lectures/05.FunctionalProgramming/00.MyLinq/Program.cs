
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static class Program
{
    public static void Main()
    {
        // Functional Programing - създаване на напи функции - принципи и правила:
        // ***** Functional style
        // Sequance of functional transformations

        Console.WriteLine(Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .Max()
            );

        // ***** Imperative style
        // Describes an algorithm (steps)
        var input = Console.ReadLine();
        var items = input.Split(" ");
        var nums = items.Select(int.Parse);
        var maxNum = nums.Max();

        // =======================================================================================//

        // ***** First-class functions: functions can be stored in variables and passed as arguments
        //  Instead of statements, it makes use of expressions
        Func<int, int> twice = x => 2 * x;
        var d = twice(5); // 10

        // Higher-order functions: Приемат функция като данни или отдават функция като резултат (Linq)

        // take other functions as arguments or return them as results

        // int aggregate(int start, int end, func) { }
        // int sum = aggregate(1, 10, (a, b) => a + b); //55


        // =======================================================================================//


        // ***** Pure Functional Programing

        // *** Pure FP treats computation as the evaluation of:
        // * mathematical functions (защото са точни с точни резултати)
        // * avoiding state (ако две нишки използват един метод единия може да свърши преди другия и това го няма тук)
        // * mutable data (непроменлива информация, всичко е такова каквото е, променливите не се променят )
        // * side effects избягване на странични ефекти като (console.WriteLine), външни променливи, и други 
        // (variables are immutable)
        // *** Always produce the same output with the same arguments disregard of other factors (deterministic)
        // * No other input data besides the input parameters
        // * The output value of a function depends only on the arguments that are passed to the function

        Console.WriteLine(Sum(5, 10));
        static int Sum(int x, int y)
        {
            if (x == 5)
            {
                return 42;
            }
            if (y == 10)
            {
                return x + y;
            }
            return x + y;
        }

        int countDays = 0;
        Console.WriteLine(GetPriceWithPromotions(5, DayOfWeek.Monday));
        Console.WriteLine(GetPriceWithPromotions(15, DayOfWeek.Monday));
        Console.WriteLine(GetPriceWithPromotions(30, DayOfWeek.Monday));
        // Do ще вдигне брояча с +1 също
        Do();

        // decimal GetPriceWithPromotions(decimal price, DayOfWeek dayOfWeek)
        // създаваме метод който трябва винаги да връща един вид данни. не може да имаме в този метод (горен ред)
        // if (който да изписва допълнителна информация като string или да изисква още данни, или да пише допълнителни редове)

        // static decimal GetPriceWithPromotions(decimal price, DayOfWeek dayOfWeek)
        // static ще рече това което вътре живе само, не знае нищо извън него (не може да вкарваме променливи в него
        decimal GetPriceWithPromotions(decimal price, DayOfWeek dayOfWeek)
        {
            countDays++;
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                return 12;
            }
            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                return price / 2;
            }
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                return price / 3;
            }
            return price;
        }
        void Do()
        {
            countDays++;
        }
        // *** No "for" and "while" loops, instead, functional languages rely on recursion for iteration
        // Защо без "for" и "while"?

        PrintNumbers(1, 10);
        /*
        void PrintNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine( );
            }
        }
        */

        // Recursion рекурсия - това е когато метода се извиква сам във себе си
        void PrintNumbers(int start, int end)
        {
            Console.WriteLine(start);
            // (new)
            if (start == end)
            {
                return;
            }
            // (new)
            PrintNumbers(start + 1, end);
        }
        // така метода няма дъно (за да го спре и като паметта свъши ще блокира)
        // StackOverflow - препълване на програмния стек (менюто се казва Call Stack като дебъгваме)
        // за да се спре ще изглежда така между (new) коментарите
        // така финално програмата не използва state/променливи само входните си данни
        // PrintNumbers метода започна да прилича на for цикъл

        // =======================================================================================//

        // *** Purely functional languages are unpractical and rarely used
        // ▪ The program is pure function without side effects, e.g.Haskell
        // *** Impure functional languages
        // ▪ Emphasize functional style, but allow side effects, e.g.Clojure
        // *** Multi - paradigm languages
        // ▪ Combine multiple programing paradigms: functional, structured, object-oriented, …
        // ▪ Examples: JavaScript, C#, Python, Java


        // =======================================================================================//

        // Lambda Expressions 
        // Lambda Expressions are anonymous functions containing expressions and statements
        // **** Lambda syntax in C#
        // ▪ Use the lambda operator "=>"(goes to)
        // ▪ Parameters can be enclosed in parentheses()
        // ▪ The body holds the expression or statement and can be enclosed in braces { }

        // ***Lambda Expressions in C#
        // * Implicit lambda expression
        // msg => Console.WriteLine(msg);
        // * Explicit lambda expression
        // (String msg) => { Console.WriteLine(msg); }
        // * Zero parameters
        // () => { Console.WriteLine("hi"); }
        // * Multiple parameters
        // (int x, int y) => { return x + y; }

        List<int> numbers = new() { 12, 3, 56 };
        numbers = numbers.Where(n => n % 2 == 0).ToList();
        // (n => n % 2 == 0) това е ламбда функция
        Console.WriteLine(string.Join(", ", numbers));

        // =======================================================================================//

        // ****** Delegates, Functions, Actions, Predicates ******
        // ***** Func<T, TResult>, Action<T>, Predicate<T>

        // *** Generic Delegates: Func<T, TResult>
        // Func = return
        //                              // {            lambda expression           }
        // <input type, output type> name = input parameter "n" => return expression
        Func<int, string> func = n => n.ToString();
        // ▪ Initialization of a function
        // ▪ Input and output type can be different types
        // ▪ Input and output type must be from the declared type
        // ▪ Func <…> delegate uses type parameters to define the number and types of input parameters and returns the type of the delegate

        // *** Generic Delegates: Action<T>

        // Action = void може да върне нищо
        // ▪ In.NET Action<T> is a void method:
        // private void Print(string message)
        //     { Console.WriteLine(message); }

        // ▪ Instead of writing the method we can do:
        // Action<string> print =
        //     message => Console.WriteLine(message);

        // ▪ Then we use it like that:
        // print("Peter"); // Peter
        //     print(5.ToString()); // 5

        // това става като малка анонимна функция
        Action<string> printName = name => Console.WriteLine(name);
        //горното и долното са идентични
        static void PrintName(string name)
        {
            Console.WriteLine(name);
        }

        /*
        *** когато са повече от 1 променливи ни трябват скоби
        Action<string, string> printName = (string firstName, string lastName) =>
        {
            Console.WriteLine(firstName + " " + lastName);
        };

        //горното и долното са идентични
        PrintName("Ivan", "Atanasov");
        static void PrintName(string firstName, string lastName)
        {
            Console.WriteLine(firstName + " " + lastName);
        }

        *** Друг пример
        
        Func<int, int, int> sum = (x, y) => x + y;

        Console.WriteLine(Sum(5, 10));

        int Sum(int x, int y)
        {
            return x + y;
        }
        */

        // *** Generic Delegates: Predicate<T>

        // ▪ In .NET Predicate<T> is a Boolean method:
        // приема само един параметър и изкарва bool
        Predicate<int> isNegative = x => x < 0;
        Console.WriteLine(isNegative(5)); // false
        Console.WriteLine(isNegative(-5)); // true
        var numbrs = new List<int> { 3, 5, -2, 10, 0, -3 };
        var negs = numbrs.FindAll(isNegative);
        Console.WriteLine(string.Join(", ", negs)); // -2, -3

        // ***** Delegates
        // всичките гореспоменати функции са делегати направени и готови за използване (ние може да си създадем собствени такива)

        // *** A delegate in C# is a data type that holds a method with a certain parameter list and return type
        // ▪ Used to pass methods as arguments to other methods
        // ▪ Can be used to define callback methods

        // ---това не е много четимо спрямо
        Func<int, int, int> multiply = (x, y) => x * y;
        // ---това тук, правят едно и също
        MathOperation multiply1 = (x, y) => x * y;
        MathOperation add = (x, y) => x + y;

        int mult = multiply1(3, 5); // 15
        int sum = add(3, 5); // 8



        // =======================================================================================//


        // ****** Higher - Order Functions ******

        // ***** Functions as Parameters to Other Functions

        // *** We can pass Func<T> to methods:
        int Operation(int number, Func<int, int> operation)
        {
            return operation(number);
        }
        // Higher-order function: take a function as parameter

        // *** We pass lambda function to the higher-order function
        int a = 5;
        int b = Operation(a, number => number * 5); // 25
        int c = Operation(a, number => number - 3); // 2
        int D = Operation(b, number => number % 2); // 1
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(D);

        // *** more examples
        long Aggregate(int start, int end, Func<long, long, long> op)
        {
            long result = start;
            for (int i = start + 1; i <= end; i++)
                result = op(result, i);
            return result;
        }
        Aggregate(1, 10, (a, b) => a + b); // 55
        Aggregate(1, 10, (a, b) => a * b); // 3628800
        Aggregate(1, 10, (a, b) => long.Parse("" + a + b)); // 12345678910
    }
    // --- създаваме делегат който приема 2 стойности и връща един int MathOperation е изход типа
    // трябва да е извън мейн метода
    // ако нямаме допълнителните скоби с програм и мейн метод то е правилно да го поставим най-отдолу за да разбере програмата че е извън скрития мейн метод
    public delegate int MathOperation(int x, int y);
}
