
Func<double, double> applyVAT = x => x * 1.2;

double[] prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(str => double.Parse(str))
    .Select(applyVAT)
    .ToArray();

// как да стрингосам т.е. да оставя до 2 цифри след десетичната запетая
Console.WriteLine(string.Join(Environment.NewLine, prices.Select(x => x.ToString("f2"))));

/*
1.38, 2.56, 4.4
result:
1.66
3.07
5.28

1, 3, 5, 7
result:
1.20
3.60
6.00
8.40
*/