
using System;
using System.Reflection.Metadata.Ecma335;

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

    }
}

