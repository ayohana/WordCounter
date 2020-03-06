using System;

namespace WordCounter.Models
{
  public class RepeatCounter
  {
    public string SearchFor { get; set; }
    public string Sentence { get; set; }
    public RepeatCounter(string searchFor, string sentence)
    {

    }

    public int FindWord()
    {
      return 10;
    }
    
  }
}
