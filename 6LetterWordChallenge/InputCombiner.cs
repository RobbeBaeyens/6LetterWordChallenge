namespace _6LetterWordChallenge
{

    public class InputCombiner
    {
        private List<string> lines;
        private string word;
        private List<string> combinations = new List<string>();
        private int maxWordSize;

        public InputCombiner(List<string> lines, string word, int maxWordSize)
        {
            this.lines = lines;
            this.word = word;
            this.maxWordSize = maxWordSize;
        }

        private void AddCombinations(string previousLine = "", string ombinations = "")
        {
            lines.Distinct().OrderBy(x => x).Where(x => x.Length <= 6 - previousLine.Length).Where(x => word.StartsWith(previousLine + x)).ToList().ForEach(x =>
            {
                var newCombinations = ombinations + "+" + x;
                var newWord = previousLine + x;
                if (word == newWord)
                {
                    combinations.Add($"{newCombinations} = {word}");
                }
                if (newWord.Length <= maxWordSize)
                    AddCombinations(newWord, newCombinations);
            });
        }

        public List<string> GetCombinations()
        {
            lines.Distinct().OrderBy(x => x).Where(x => word.StartsWith(x)).ToList().ForEach(x =>
            {
                AddCombinations(x, x);
            });
            return combinations;
        }
    }
}
