namespace TextInputAnalyser.Tests;

public class TextAnalyserTests
{
    [Theory]
    [InlineData("this is it right", new []{'t', 'h', 'i', 's'})]
    [InlineData("lets see", new []{'e', 's'})]
    [InlineData("I like eating apples", new []{'i', 'l', 'e', 'a', 'p'})]
    [InlineData("no duplicates", new char[0])]
    [InlineData("‘abcd4’", new char[0])]
    public void TextAnalyser_WhenGivenTextWithDuplicates_ShouldReturnDuplicatedLetters(string textInput, char[] expectedDuplicateAlphas)
    {
        //Arrange
        var textAnalyser = new TextAnalyser();

        //Act
        var duplicateAlphas = textAnalyser.GetDuplicateLetters(textInput);

        //Assert
        duplicateAlphas.ShouldBe(expectedDuplicateAlphas);
    }
    
    [Theory]
    [InlineData("I like eating apples", 3)]
    [InlineData("vowels found here", 3)]
    [InlineData("abcd4", 1)]
    [InlineData("jkl kkjh", 0)]
    public void TextAnalyser_WhenGivenTextWithVowels_ShouldReturnCountForVowelsFound(string textInput, int expectedVowelsFound)
    {
        //Arrange
        var textAnalyser = new TextAnalyser();

        //Act
        var vowelsFoundCount = textAnalyser.GetNumberOfVowels(textInput);

        //Assert
        vowelsFoundCount.ShouldBe(expectedVowelsFound);
    }
    
    [Theory]
    [InlineData("I like eating apples", 7)]
    [InlineData("non vowels found here", 9)]
    [InlineData("abcd4", 3)]
    [InlineData("jkl kkjh", 4)]
    public void TextAnalyser_WhenGivenTextWithNonVowels_ShouldReturnCountForNonVowelsFound(string textInput, int expectedNonVowelsFound)
    {
        //Arrange
        var textAnalyser = new TextAnalyser();

        //Act
        var vowelsFoundCount = textAnalyser.GetNumberOfNonVowels(textInput);

        //Assert
        vowelsFoundCount.ShouldBe(expectedNonVowelsFound);
    }
}