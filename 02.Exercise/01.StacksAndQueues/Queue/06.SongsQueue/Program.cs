string[] inputSongs = Console.ReadLine()
   .Split(", ");

Queue<string> songsQueue = new Queue<string>(inputSongs);

while (true)
{
    // проверка дали имаме песни
    // преместена е горе защото като приключат песните с play нямаме проверка която да си каже опа няма песни
    // (може би в края също става да е?)
    if (songsQueue.Count == 0)
    {
        Console.WriteLine("No more songs!");
        break;
    }
    string[] commands = Console.ReadLine().Split();

    if (commands[0] == "Play")
    {
        songsQueue.Dequeue();
    }
    else if (commands[0] == "Add")
    {
        //["Add" "Watch" "Me"].Skip(1)
        // => ["watch" "Me"] = "Watch me"
        string songName = string.Join(" ", commands.Skip(1));
        if (songsQueue.Contains(songName))
        {
            Console.WriteLine($"{songName} is already contained!");
        }
        else
        {
            songsQueue.Enqueue(songName);
        }
    }
    else if (commands[0] == "Show")
    {
        Console.WriteLine(string.Join(", ", songsQueue));
    }
}
/*
All Over Again, Watch Me
Play
Add Watch Me
Add Love Me Harder
Add Promises
Show
Play
Play
Play
Play

Wake Up, Senorita, Best Song Ever, I Know You
Add Best Song Ever
Add Up Wake
Show
Play
Play
Play
Play
Show
Play
Add Watch Me Whip
Play
*/