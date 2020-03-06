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
      string expected = "my black cat loves me";
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", expected);

      string actual = newRepeatCounter.Sentence;

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ContainsWord_ReturnsTrueForSentenceContainingWord_Boolean()
    {
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "My black cat loves me");
      bool actual = newRepeatCounter.ContainsWord();

      Assert.IsTrue(actual);
    }

    [TestMethod]
    public void ContainsWord_ReturnsFalseForSentenceNotContainingWord_Boolean()
    {
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "My black dog loves me");
      bool actual = newRepeatCounter.ContainsWord();

      Assert.IsFalse(actual);
    }

    [TestMethod]
    public void FindWord_ReturnsSingleMatch_MatchCount()
    {
      int expected = 1;
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "My black cat loves me");

      int actual = newRepeatCounter.FindWord();
      
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FindWord_ReturnsMultipleMatches_MatchCount()
    {
      int expected = 2;
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "My black cat and my white cat love their toys more than me");

      int actual = newRepeatCounter.FindWord();
      
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FindWord_ReturnsFullWordMatchesOnly_MatchCount()
    {
      int expected = 0;
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "I'm walking to the cathedral");

      int actual = newRepeatCounter.FindWord();
      
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FindWord_SearchIsNotCaseSensitive_MatchCount()
    {
      int expected = 1;
      RepeatCounter newRepeatCounter = new RepeatCounter("Cat", "My black cAt loves me");

      int actual = newRepeatCounter.FindWord();
      
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsInvalidInput_ReturnsFalseForSingleWordInput_Boolean()
    {
      RepeatCounter newRepeatCounter = new RepeatCounter("cat", "My black cat loves me");
      bool actual = newRepeatCounter.IsInvalidInput();

      Assert.IsFalse(actual);
    }

    [TestMethod]
    public void IsInvalidInput_ReturnsTrueForMultipleWordsInput_Boolean()
    {
      RepeatCounter newRepeatCounter = new RepeatCounter("black cat", "My black cat loves me");
      bool actual = newRepeatCounter.IsInvalidInput();

      Assert.IsTrue(actual);
    }

  }
}
