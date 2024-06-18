using System;
using System.Collections.Generic;

// 2 хашсета за 2та типа гости
HashSet<string> vipGuests = new();
HashSet<string> regularGuests = new();

// добавяме хора в листа вип или регулар
string input;
while ((input = Console.ReadLine()) != "PARTY")
{
    // изкарваме 1вата буква ако е с цифра е вип
    if (char.IsDigit(input[0]))
    {
        vipGuests.Add(input);
    }
    else
    {
        regularGuests.Add(input);
    }
}
// започваме да приемаме тези които са се показали докато партито свърши
while ((input = Console.ReadLine()) != "END")
{
    // същото като горе само че ги премахваме
    if (char.IsDigit(input[0]))
    {
        vipGuests.Remove(input);
    }
    else
    {
        regularGuests.Remove(input);
    }
}
// изписваме колко не са ношли а са се резервирали
Console.WriteLine(vipGuests.Count + regularGuests.Count);
// заедно с output за 2та хашсета
foreach (var guest in vipGuests)
{
    Console.WriteLine(guest);
}
foreach (var guest in regularGuests)
{
    Console.WriteLine(guest);
}

/*
7IK9Yo0h
9NoBUajQ
Ce8vwPmE
SVQXQCbc
tSzE5t0p
PARTY
9NoBUajQ
Ce8vwPmE
SVQXQCbc
END

result:
2
7IK9Yo0h
tSzE5t0p

m8rfQBvl
fc1oZCE0
UgffRkOn
7ugX7bm0
9CQBGUeJ
2FQZT3uC
dziNz78I
mdSGyQCJ
LjcVpmDL
fPXNHpm1
HTTbwRmM
B5yTkMQi
8N0FThqG
xys2FYzn
MDzcM9ZK
PARTY
2FQZT3uC
dziNz78I
mdSGyQCJ
LjcVpmDL
fPXNHpm1
HTTbwRmM
B5yTkMQi
8N0FThqG
m8rfQBvl
fc1oZCE0
UgffRkOn
7ugX7bm0
9CQBGUeJ
END

result:
2
xys2FYzn
MDzcM9ZK
*/