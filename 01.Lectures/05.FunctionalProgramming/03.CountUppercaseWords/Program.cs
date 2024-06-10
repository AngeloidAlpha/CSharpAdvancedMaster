
// ако искам да дебъгна 2рия ред трябва да оставя предиката => на 1вия ред и анонимната функция на 2рия ред
Predicate<string> checkUppercase = word => 
char.IsUpper(word[0]);

string[] capitalizedWords = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(w => checkUppercase(w))
    .ToArray();

foreach (string word in capitalizedWords)
{
    Console.WriteLine(word); 
}

/*
The following example shows how to use Function
result:
The
Function

Write a program that reads one line of text from console. Print count of words that start with Uppercase, 
after that print all those words in the same order like you find them in text.

result:
Write
Print
Uppercase,
*/