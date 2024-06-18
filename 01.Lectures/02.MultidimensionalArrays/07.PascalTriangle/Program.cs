int size = int.Parse(Console.ReadLine());

// числата вътре могат да станат изключително големи много бързо заради това използваме long[][]
long[][] pascalTriangle = new long[size][];

// изписваме 1вия ред от масива със стойност 1
// той има индекс 0 въпреки че е 1ви ред
pascalTriangle[0] = new long[1] { 1 };

// създаваме цикъл броящ размера (редовете) на масива който ще запълним
// тук започваме да броим от индекс 1 което ще рече че е 2ри ред
for (int row = 1; row < size; row++)
{
    // броим индексите на редовете за да получим равния брой колони го събираме с + 1
    pascalTriangle[row] = new long[row + 1];

    // създаваме цикъл който ще правилогиката на паскаловия триъгълник
    // след всеки цикъл сумата трябва да се занулира
    // описваме събирането на сумите и тяхното записваме 
    // 1вото е за всички останали елементи от настоящия ред така че да не излиза извън масива (при гледането на предишния ред)
    // 2рото е за да запълним 1вия елемент от настоящия ред
    for (int col = 0; col < pascalTriangle[row].Length; col++)
    {
        long sum = 0;

        if (col > 0)
        {
            sum += pascalTriangle[row - 1][col - 1];
        }

        if (col < pascalTriangle[row - 1].Length)
        {
            sum += pascalTriangle[row - 1][col];
        }
        pascalTriangle[row][col] = sum;
    }
}

// изписване на този 2д масив с непознати размери
for (int row = 0; row < size; row++)
{
    for (int col = 0; col < pascalTriangle[row].Length; col++)
    {
        Console.Write($"{pascalTriangle[row][col]} ");
    }
    Console.WriteLine();
}