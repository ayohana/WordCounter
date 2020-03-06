using System;
using WordCounter.Models;

namespace WordCounter
{
  public class Program
  {
    public static RepeatCounter newRepeatCounter { get; set; }

    public static void Main()
    {
      try
      {
        Welcome();
        AskUser();
        DisplayMessage();
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
      Console.WriteLine(Environment.NewLine + "  _      __            __  _____               __         ");
      Console.WriteLine(" | | /| / /__  _______/ / / ___/__  __ _____  / /____ ____");
      Console.WriteLine(" | |/ |/ / _ \\/ __/ _  / / /__/ _ \\/ // / _ \\/ __/ -_) __/");
      Console.WriteLine(" |__/|__/\\___/_/  \\_,_/  \\___/\\___/\\_,_/_//_/\\__/\\__/_/   " + Environment.NewLine);
    }

    public static void AskUser()
    {
      Console.WriteLine("Enter a word you'd like to search for:");
      string searchFor = Console.ReadLine();
      Console.WriteLine("Enter a sentence:");
      string sentence = Console.ReadLine();
      newRepeatCounter = new RepeatCounter(searchFor, sentence);
    }

    public static void DisplayMessage()
    {
      if (!newRepeatCounter.ContainsWord())
      {
        Console.WriteLine("Sorry, this sentence does not contain the word you are looking for.");
      }
      else if (newRepeatCounter.ContainsWord())
      {
        Console.WriteLine(newRepeatCounter.FindWord());
      }
      else
      {
        Console.WriteLine("Invalid input. Please try again.");
      }
    }
  }
}
