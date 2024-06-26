using System;

public class Program {
    public static void Main(string[] args) {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";

        Scripture scripture = new Scripture(reference, scriptureText);

        while (true) {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit") {
                break;
            }

            if (scripture.IsCompletelyHidden()) {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }

            int wordsToHide = 3;
            int visibleWordsCount = scriptureText.Split(' ').Length - scriptureText.Split(new[] { "_____" }, StringSplitOptions.None).Length;
            if (visibleWordsCount < 3) {
                wordsToHide = visibleWordsCount;
            }

            scripture.HideRandomWords(wordsToHide); 
        }
    }
}
