using System;
using System.Collections.Generic;

// хашсет за номерата на колите
HashSet<string> cars = new();

// въртим цикъл за края на програмата
string input;
while ((input = Console.ReadLine()) != "END")
{
    // сплитваме стринга
    string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

    string action = tokens[0];
    string licencePlate = tokens[1];
    // питаме дали имаме IN or OUT
    switch (action)
    {
        // използваме .Add .Remove за да изваждаме номерата на колите от хашсета
        case "IN":
            cars.Add(licencePlate);
            break;
        case "OUT":
            cars.Remove(licencePlate);
            break;
        default:
            break;
    }
}
// изписваме ако няма коли
if (cars.Count == 0)
{
    Console.WriteLine("Parking Lot is Empty");
    // ползваме return за да не изписваме следващото?
    return;
}
// изписваме ако са останали коли 
Console.WriteLine(string.Join(Environment.NewLine, cars));
/*
IN, CA2844AA
IN, CA1234TA
OUT, CA2844AA
IN, CA9999TT
IN, CA2866HI
OUT, CA1234TA
IN, CA2844AA
OUT, CA2866HI
IN, CA9876HH
IN, CA2822UU
END

result:
CA9999TT
CA2844AA
CA9876HH
CA2822UU

IN, CA2844AA
IN, CA1234TA
OUT, CA2844AA
OUT, CA1234TA
END
result:
Parking Lot is Empty

*/