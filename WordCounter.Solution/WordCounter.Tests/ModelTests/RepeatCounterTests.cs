using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Models;

namespace WordCounter.Tests
{
  [TestClass]
  public class RepeatCounterTests
  {

    [TestMethod]
    public void RepeatCounterConstructor_CreatesInstanceOfRepeatCounter_RepeatCounter()
    {
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "My black cat loves me");
      Assert.AreEqual(typeof(RepeatCounter), newRepeatCounter.GetType());
    }

    [TestMethod]
    public void GetSearchFor_ReturnsSearchFor_String()
    {
      string expected = "cat";
      RepeatCounter newRepeatCounter = new RepeatCounter(expected, "My black cat loves me");

      string actual = newRepeatCounter.SearchFor;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void GetSentence_ReturnsSentence_String()
    {
      string expected = "My black cat loves me";
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", expected);

      string actual = newRepeatCounter.Sentence;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FindWord_ReturnsSingleMatch_MatchCount()
    {
      int expected = 1;
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "My black cat loves me");

      int actual = newRepeatCounter.FindWord();
      
      Assert.AreEqual(expected, actual);
    }
  }
}
