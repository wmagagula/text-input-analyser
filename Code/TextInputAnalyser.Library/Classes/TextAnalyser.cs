namespace TextInputAnalyser.Classes;

public class TextAnalyser
{
    private static readonly List<int> VowelAsciiMap = new() 
        { 'a', 'e', 'i', 'o', 'u' };

    public char[] GetDuplicateLetters(string text)
    {
        var startLettersKey = 0;
        var lettersDictionary = text.ToLower()
            .Where(char.IsLetter)
            .ToDictionary(_ => startLettersKey+=1,
                value => value); 
        
        var duplicateLetters = lettersDictionary.GroupBy(letter => lettersDictionary[letter.Key])
            .Where(letterGroup => letterGroup.Count() > 1)
            .Select(letterGroup => letterGroup.Key)
            .ToArray();

        return duplicateLetters;
    }

    public int GetNumberOfVowels(string textInput)
    {
        return textInput.ToLower()
            .Where(letter => char.IsLetter(letter) && VowelAsciiMap.Contains(letter))
            .Distinct()
            .Count();
    }

    public int GetNumberOfNonVowels(string textInput)
    { 
        return textInput.ToLower()
            .Where(letter => char.IsLetter(letter) && !VowelAsciiMap.Contains(letter))
            .Distinct()
            .Count();
    }
}