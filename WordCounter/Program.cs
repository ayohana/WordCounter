using System;
using WordCounter.Models;

namespace WordCounter
{
  public class Program
  {
    public static RepeatCounter newRepeatCounter { get; set; }
    public static bool searchIsOver = false;

    public static void Main()
    {
      try
      {
        Welcome();
        while(!searchIsOver)
        {
          AskUser();
          DisplayMatches();
          AskBackToSearch();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Message = {0}", ex.Message);
        Console.WriteLine("Source = {0}", ex.Source);
        Console.WriteLine("StackTrace = {0}", ex.StackTrace);
        Console.WriteLine("TargetSite = {0}", ex.TargetSite);
      }
    }

    public static void Welcome()
    {
      Console.WriteLine(Environment.NewLine + "   _      __            __  _____               __         ");
      Console.WriteLine("  | | /| / /__  _______/ / / ___/__  __ _____  / /____ ____");
      Console.WriteLine("  | |/ |/ / _ \\/ __/ _  / / /__/ _ \\/ // / _ \\/ __/ -_) __/");
      Console.WriteLine("  |__/|__/\\___/_/  \\_,_/  \\___/\\___/\\_,_/_//_/\\__/\\__/_/   " + Environment.NewLine);
    }

    public static void AskUser()
    {
      Console.WriteLine(">>> Enter a word to search for:");
      string searchFor = Console.ReadLine();
      newRepeatCounter = new RepeatCounter(searchFor);
      if (newRepeatCounter.IsValidInput())
      {
        Console.WriteLine(">>> Enter a sentence:");
        string sentence = Console.ReadLine();
        newRepeatCounter = new RepeatCounter(searchFor, sentence);
      }
      else
      {
        Console.WriteLine(">>> Invalid input. Please enter only 1 word.");
        AskUser();
      }
    }

    public static void DisplayMatches()
    {
      if (!newRepeatCounter.ContainsWord())
      {
        Console.WriteLine(">>> Sorry, there is absolutely none matching your sentence. :(");
      }
      else if (newRepeatCounter.ContainsWord())
      {
        Console.WriteLine($">>> {newRepeatCounter.FindWord()} match(es) found for {newRepeatCounter.SearchFor}");
      }
      else
      {
        Console.WriteLine(">>> Search failed. Please try again.");
      }
    }

    public static void AskBackToSearch()
    {
      Console.WriteLine(">>> Would you like to use WORD COUNTER again? (Y/N)");
      string answer = Console.ReadLine().ToLower();
      if (answer == "y" || answer == "yes")
      {
        searchIsOver = false;
      }
      else if (answer == "n" || answer == "no")
      {
        searchIsOver = true;
        Console.WriteLine(">>> Thanks for using WORD COUNTER. See you next time!");
      }
      else
      {
        Console.WriteLine(">>> Invalid input. Please try again.");
        AskBackToSearch();
      }
    }
  }
}
