using TextInputAnalyser;
using TextInputAnalyser.Classes;
using TextInputAnalyser.Enums;
using static System.Int32;

var textAnalyser = new TextAnalyser();
var input = ConsoleIO.ReadInput("Enter text to be analysed: ");

ConsoleIO.WriteOutput(@"Enter which operations to do on the supplied text, ‘1’ for a duplicate character check,
 ‘2’ to count the number of vowels, ‘3’ to check if there are more vowels or non vowels, or any combination of ‘1’, ‘2’ 
and ‘3’ to perform multiple checks.");

var operationOptions = ConsoleIO.ReadInput();

if (operationOptions == null)
    return;

foreach (var operation in operationOptions)
{
    TryParse(operation.ToString(), out var result);

    switch (result)
    {
        case (int) Operation.Duplicates:
            var duplicates = textAnalyser.GetDuplicateLetters(input ?? "");
            ConsoleIO.WriteOutput(duplicates.Length > 1
                ? $"Found the following duplicates: {string.Concat(duplicates)}"
                : "No duplicate values were found");
            break;
        case (int) Operation.VowelsCount:
            var vowelsCount = textAnalyser.GetNumberOfVowels(input ?? "");
            ConsoleIO.WriteOutput(vowelsCount > 1
                ? $@"The number of vowels is {vowelsCount}"
                : "No vowels were found");
            break;
        case (int) Operation.VowelsOrNonVowelsCompare:
            var nonVowels = textAnalyser.GetNumberOfNonVowels(input ?? "");
            var vowels = textAnalyser.GetNumberOfVowels(input ?? "");
            var message = nonVowels > vowels
                ? "more non vowels than vowels"
                : nonVowels < vowels
                    ? "more vowels than non vowels"
                    : "an equal amount of vowels and non vowels";
            ConsoleIO.WriteOutput($"The text has {message}");
            break;
    }
}