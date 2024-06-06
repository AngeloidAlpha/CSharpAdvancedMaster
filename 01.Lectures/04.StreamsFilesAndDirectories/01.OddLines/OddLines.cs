
string inputFilePath = @"..\..\..\Files\input.txt";
string outputFilePath = @"..\..\..\Files\output.txt";

ExtractOddLines(inputFilePath, outputFilePath);

static void ExtractOddLines(string inputFilePath, string outputFilePath)
{
    // TODO: write your code here…
    using (StreamReader reader = new StreamReader(inputFilePath))
    {
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            int counter = 0;

            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (counter % 2 != 0)
                {
                    writer.WriteLine(line);
                }
                counter++;
            }
        }
    }
}
    