try
{
    const string PUZZLE_INPUT_PART1 = "PuzzleInput-Part1.txt";
    const string PUZZLE_INPUT_PART2 = "PuzzleInput-Part2.txt";
    const string PUZZLE_INPUT_PART3 = "PuzzleInput-Part3.txt";

    string puzzleInput1 = File.ReadAllText(PUZZLE_INPUT_PART1);
    string puzzleInput2 = File.ReadAllText(PUZZLE_INPUT_PART2);
    string puzzleInput3 = File.ReadAllText(PUZZLE_INPUT_PART3);

    static int PotionsRequired(char[] monsterGroup)
    {
        Dictionary<char, int> potion = new()
        {
            {'A',0},{'B',1},{'C',3},{'D',5},{'x',0}
        };


        int returnValue = monsterGroup.Sum(x => potion[x]);

        int numMonsters = monsterGroup.Length - monsterGroup.Count(x => x == 'x');
        returnValue += numMonsters switch
        {
            2 => 2,
            3 => 6,
            _ => 0
        };

        return returnValue;
    }

    int part1Answer = puzzleInput1.Chunk(1).Sum(PotionsRequired);
    int part2Answer = puzzleInput2.Chunk(2).Sum(PotionsRequired);
    int part3Answer = puzzleInput3.Chunk(3).Sum(PotionsRequired);

    Console.WriteLine($"Part 1: For the solo critters, {part1Answer} potions will be needed.");
    Console.WriteLine($"Part 2: When attacks come in pairs, {part2Answer} potions will be needed.");
    Console.WriteLine($"Part 3: Tripple combats will need {part3Answer} potions .");
}
catch (Exception e)
{
    Console.WriteLine(e);
}