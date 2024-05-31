
int[] operations = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int[] inputElements = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

Stack<int> stack = new Stack<int>();

// създаваме променливи за видовете елементи по условие
int elementsToPush = operations[0];
int elementsToPop = operations[1];
int elementsToLookup = operations[2];

for (int i = 0; i < elementsToPush; i++)
{
    stack.Push(inputElements[i]);
}
// проверка за stack and queues дали съдържат нещо
// stack.Any() е същото като stack.Count > 0
// препоръчване в някой случаи 1вото
while (stack.Any() && elementsToPop > 0)
{
    stack.Pop();
    elementsToPop--;
}

// проверка дали стака е празен
if (!stack.Any())
{
    Console.WriteLine(0);
}
// ако го съдържа елемента
else if (stack.Contains(elementsToLookup))
{
    Console.WriteLine("true");
}
// да изпише най-голямото число ако 1вите 2 условия не са верни
else
{
    Console.WriteLine(stack.Min());
}