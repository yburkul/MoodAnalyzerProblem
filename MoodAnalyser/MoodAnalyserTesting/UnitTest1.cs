using MoodAnalyser;
using NUnit.Framework;

namespace MoodAnalyserTesting
{
    public class Tests
    {
        MoodAnalyser moodAnalyser;
        [SetUp]
        public void Setup()
        {
            string result = "";
            //Arrange
            moodAnalyser = new MoodAnalyser(result);
        }

        // TC-1.1 Given "I am in Sad mood" message should return SAD
        [Test]
        public void GivenMassage_When_ShouldReturnSad()
        {
            moodAnalyser = new MoodAnalyser("I am in SAD Mood");
            //Act
            string message = moodAnalyser.AnalyserMood();
            //Asser
            Assert.AreEqual("SAD", message);
        }

        // TC-1.2 Given "I am in Any mood" message should return HAPPY
        [Test]
        public void GivenMassage_When_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalyser("I am in ANY Mood");
            //Act
            string message = moodAnalyser.AnalyserMood();
            //Assert
            Assert.AreEqual("HAPPY", message);
        }

        // TC-2.1 Given Null Mood Should Return Happy
        [Test]
        public void GivenMessage_WhenNull_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalyser();
            //Act
            string message = moodAnalyser.AnalyserMood();
            //Assert
            Assert.AreEqual("HAPPY", message);
        }

        /// TC 3.1 Given Null Mood Should ThrowMoodAnalysisException
        [Test]
        public void GivenMessage_WhenNull_CustomException()
        {
            string message = null;
            string expected = "Mood should not be Null";
            try
            {
                //Act
                moodAnalyser = new MoodAnalyser(message);
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        // TC-3.2 Given EMPTY Mood Should Throw MoodAnalysisException
        [Test]
        public void GivenMessage_WhenEmpty_CustomException()
        {
            string message = " ";
            string expected = "Mood should not be Empty";
            try
            {
                //Act
                moodAnalyser = new MoodAnalyser(message);
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}