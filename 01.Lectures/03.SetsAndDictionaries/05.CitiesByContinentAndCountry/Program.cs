
int count = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, List<string>>> continents = new();

for (int i = 0; i < count; i++)
{
    string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string continent = tokens[0];
    string country = tokens[1];
    string city = tokens[2];

    if (!continents.ContainsKey(continent))
    {
        continents[continent] = new Dictionary<string, List<string>>();
    }
    if (!continents[continent].ContainsKey(country))
    {
        continents[continent].Add(country, new List<string>());
    }
    // библютека в библютеката в лист пъхаме град
    continents[continent][country].Add(city);
}

foreach ((string continent, Dictionary<string, List<string>> countries) in continents)
{
    Console.WriteLine($"{continent}:");
    foreach ((string country, List<string> city) in countries)
    {
        Console.WriteLine($"  {country} -> {String.Join(", ", city)}");
    }
}
/*
9
Europe Bulgaria Sofia
Asia China Beijing
Asia Japan Tokyo
Europe Poland Warsaw
Europe Germany Berlin
Europe Poland Poznan
Europe Bulgaria Plovdiv
Africa Nigeria Abuja
Asia China Shanghai

result:Europe:
  Bulgaria -> Sofia, Plovdiv
  Poland -> Warsaw, Poznan
  Germany -> Berlin
Asia:
  China -> Beijing, Shanghai
  Japan -> Tokyo
Africa:
  Nigeria -> Abuja

3
Europe Germany Berlin
Europe Bulgaria Varna
Africa Egypt Cairo

result:
Europe:
  Germany -> Berlin
  Bulgaria -> Varna
Africa:
  Egypt -> Cairo

8
Africa Somalia Mogadishu
Asia India Mumbai
Asia India Delhi
Europe France Paris
Asia India Nagpur
Europe Germany Hamburg
Europe Poland Gdansk
Europe Germany Danzig

result:
Africa:
  Somalia -> Mogadishu
Asia:
  India -> Mumbai, Delhi, Nagpur
Europe:
  France -> Paris
  Germany -> Hamburg, Danzig
  Poland -> Gdansk


*/