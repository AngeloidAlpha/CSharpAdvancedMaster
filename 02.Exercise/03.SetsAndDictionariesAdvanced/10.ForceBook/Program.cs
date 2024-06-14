//Darker | DCay           forceSide | forceUser
//John Johnys -> Lighter  forceUser -> forceSide

// създаваме библзтека със стринг за имената на силите и хашсет за хората
Dictionary<string, HashSet<string>> forces
    = new Dictionary<string, HashSet<string>>();
// 1вия ред от конзолата който трябва да проверим
string input = Console.ReadLine();

// питаме дали е командата за край
while (input != "Lumpawaroo")
{
    // въвеждаме нов масив със съдържание input разделен от | или ->
    // после питаме дали в първоначалния стринг input имаме | или ->
    // присвояваме на тяхно място дали 1вото е джедай или сила?
    string[] inputInfo = input.Split(
        new string[] { " | ", " -> ", },
        StringSplitOptions.RemoveEmptyEntries);

    // тука питаме на първото място за човека ако е с условие | то той ще приеме inputInfo[1]
    // тука питаме на второто място за страна на силата ако е с условие | то той ще приеме inputInfo[0]
    string forceUser = input.Contains("|") ? inputInfo[1] : inputInfo[0];
    // тука питаме на първото място за страна на силата ако е с условие -> то той ще приеме inputInfo[1]
    // тука питаме на второто място за човека ако е с условие -> то той ще приеме inputInfo[0]
    string forceSide = input.Contains("->") ? inputInfo[1] : inputInfo[0];

    // започваме да питаме 1вото условие по задачата дали я имаме тази сила записана в библютеката
    if (!forces.ContainsKey(forceSide))
    {
        forces.Add(forceSide, new HashSet<string>());
    }
    // питаме дали гореспоменатия user е вече в някоя от страните? ако не да го прибавим
    if (input.Contains("|") && !forces.Any(x => x.Value.Contains(forceUser)))
    {
        forces[forceSide].Add(forceUser);
    }
    // питаме 2рата част на задачата дали в първоначалния стринг имаме ->
    else if (input.Contains("->"))
    {
        // преминаваме през 2те сили в колекцията и питаме дали съществува споменатия човек на силата
        foreach (var force in forces)
        {
            // бъркаме във всяка сила и питаме дали има човек с value(името) в обратното на зададената сила(в която искаме да го преместим)
            if (force.Value.Contains(forceUser) && force.Key != forceSide)
            {
                // премахваме го (с .Remove) защото force.Value е HashSet
                force.Value.Remove(forceUser);
                break;
            }
        }
        // добавяме го от нея страна на силата (forces[forceSide] е HashSet за това ползваме .Add(forceuser);
        forces[forceSide].Add(forceUser);
        // изписваме на конзолата към кого сме присъединили човека (от условие 2 ->)
        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
    }
    // приемаме следваща линия от конзолата
    input = Console.ReadLine();
}
// въртим цикъл с за 2та видя сила като също ги подреждаме по низходящ ред
// изкарваме по този начин и колко хора има item.Value.Count
        // вътрешния цикъл върти броя на user-ите в HashSet-a
foreach (var item in forces
    .Where(x => x.Value.Count > 0)
    .OrderByDescending(x => x.Value.Count)
    .ThenBy(x => x.Key))
{
    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

    foreach (var user in item.Value.OrderBy(x => x))
    {
        Console.WriteLine($"! {user}");
    }
}
/*
Light | George
Dark | Peter
Lumpawaroo

result:
Side: Dark, Members: 1
! Peter
Side: Light, Members: 1
! George

Lighter | Royal
Darker | DCay
John Johnys -> Lighter
DCay -> Lighter
Lumpawaroo

result:
John Johnys joins the Lighter side!
DCay joins the Lighter side!
Side: Lighter, Members: 3
! DCay
! John Johnys
! Royal
*/