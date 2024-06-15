
int asciiSum = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine().Split();

// базова функция която проверява дали даденото име има сума по-голяма или равна на дадената ни
Func<string, int, bool> filter = (name, sum) =>
name.Sum(x => x) >= sum;
// в работна обстановка ще използваме този начин на решаване
/*
string name1 = Console.ReadLine()
    .Split()
    .FirstOrDefault(x => x.Sum(c => c) >= asciiSum);

Console.WriteLine(name1);
*/

// използваме фунцкия съдържаща стринг масив и функция като подавани
Func<string[], Func<string, int, bool>, string> filterFirstName =
    // записваме 2те променливи за масива и функцията
    (allNames, funcFilter) =>
    // описваме вътрешната функция с нейната логика
    allNames.FirstOrDefault(x => funcFilter(x, asciiSum));

// намираме 1вото име с условието от функцията
Console.WriteLine(filterFirstName(names, filter));

// без да изпозлваме 2ра функция за да изкараме 1вото име
// Console.WriteLine(names.Where(x => filter(x, asciiSum)).ToArray()[0]);

/*
350
Rob Mary Paisley Spencer

result:
Mary

666
Paul Thomas William

result:
William
*/