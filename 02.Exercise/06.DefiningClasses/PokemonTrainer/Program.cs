
// "{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
// "Tournament"

using PokemonTrainer;
Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
string command = Console.ReadLine();
while (command != "Tournament")
{
    string[] input = command.Split();

    string trainerName = input[0];
    string pokemonName = input[1];
    string pokemonElemnt = input[2];
    int pokemonHealth = int.Parse(input[3]);

    if (!trainers.ContainsKey(trainerName))
    {
        Trainer trainer = new Trainer(trainerName);
        trainers.Add(trainerName, trainer);
    }

    Pokemon pokemon = new Pokemon(pokemonName, pokemonElemnt, pokemonHealth);
    trainers[trainerName].Pokemons.Add(pokemon);

    command = Console.ReadLine();
}
command = Console.ReadLine();
while (command != "End")
{
    foreach (var (name, trainer) in trainers)
    {
        bool doesTrainerHavePokemonElement
            = trainer.Pokemons.Any(x => x.Element == command);

        if (doesTrainerHavePokemonElement)
        {
            trainer.Badges += 1;
        }
        else
        {
            foreach (var pokemon in trainer.Pokemons)
            {
                pokemon.Health -= 10;
            }

            trainer.Pokemons.RemoveAll(x => x.Health <= 0);
        }
    }

    command = Console.ReadLine();
}
foreach (var (name, trainer) in trainers
    .OrderByDescending(x => x.Value.Badges))
{
    Console.WriteLine($"{name} {trainer.Badges} {trainer.Pokemons.Count}");
}