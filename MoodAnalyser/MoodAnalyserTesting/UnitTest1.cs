using MoodAnalysers;
using MoodAnalyserSpace;
using NUnit.Framework;

namespace MoodAnalyserTesting
{
    public class Tests
    {
        MoodAnalyser moodAnalyser;
        MoodAnalyserfactory moodAnalyserfactory;
        [SetUp]
        public void Setup()
        {
            string result = "";
            //Arrange
            moodAnalyser = new MoodAnalyser(result);
            moodAnalyserfactory = new MoodAnalyserfactory();
        }

        ///<summary>
        /// TC-1.1 Given "I am in Sad mood" message should return SAD
        /// </summary>
        [Test]
        public void GivenMassage_When_ShouldReturnSad()
        {
            moodAnalyser = new MoodAnalyser("I am in SAD Mood");
            //Act
            string message = moodAnalyser.AnalyserMood();
            //Assert
            Assert.AreEqual("SAD", message);
        }

        ///<summary>
        /// TC-1.2 Given "I am in Any mood" message should return HAPPY
        ///</summary>
        [Test]
        public void GivenMassage_When_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalyser("I am in ANY Mood");
            //Act
            string message = moodAnalyser.AnalyserMood();
            //Assert
            Assert.AreEqual("HAPPY", message);
        }

        ///<summary>
        /// TC-2.1 Given Null Mood Should Return Happy
        /// </summary>
        [Test]
        public void GivenMessage_WhenNull_ShouldReturnHappy()
        {
            moodAnalyser = new MoodAnalyser();
            //Act
            string message = moodAnalyser.AnalyserMood();
            //Assert
            Assert.AreEqual("HAPPY", message);
        }

        ///<summary>
        /// TC 3.1 Given Null Mood Should ThrowMoodAnalysisException
        /// </summary>
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

        /// <summary>
        /// TC-3.2 Given EMPTY Mood Should Throw MoodAnalysisException
        /// </summary>
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

        /// <summary>
        /// TC-4.1 Given MoodAnalyser Class Name Should Return MoodAnalyser Object
        /// </summary>
        [Test]
        public void MoodAnalyserClass_NameShouldReturnMood_AnalyserObject()
        {
            object expected = new MoodAnalyser();
            object obj = MoodAnalyserfactory.CreateMoodAnalyse("MoodAnalyserSpace.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        /// <summary>
        /// TC-4.2 Given Class Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [Test]
        public void MoodAnalyser_Improper_ClassNameShouldThrow_MoodAnalyserException()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserfactory.CreateMoodAnalyse("MoodAnalyserSpace.Mood", "Mood");
            }
            catch(MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC-4.3 Given Class When Improper Constructor name Should Throw MoodAnalysisException
        /// </summary>
        [Test]
        public void MoodAnalyser_Improper_ConstructorName_ShoulThrow_MoodAnalyserException()
        {
            object obj = null;
            string expected = "Constructor not found";
            try
            {
                obj = MoodAnalyserfactory.CreateMoodAnalyse("MoodAnalyserSpace.Moodanalyser", "AnalyserMood");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC 5.1 - Given MoodAnalyser When Proper Return MoodAnalyser Object
        /// </summary>
        [Test]
        public void MoodAnalyser_WhenProperReturn_MoodAnalyser_Object()
        {
            object expected = new MoodAnalyser("Happy");
            object obj = MoodAnalyserfactory.CreateMoodAnalyserWithParameterisedConstructor("MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }

        /// <summary>
        /// TC 5.2 - Given Class Name When Improper Should Throw MoodAnalysisException
        /// </summary>
        [Test]
        public void MoodAnalyser_When_ImproperClassName_ShouldThrowMoodAnalysis_Exception()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyserfactory.CreateMoodAnalyserWithParameterisedConstructor("ImproperClassname", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TC 5.3 - Given Class When Constructor Not Proper Should Throw MoodAnalysisException
        /// </summary>
        [Test]
        public void MoodAnalyser_When_ImproperConstructorName_ShouldThrowMoodAnalysis_Exception()
        {
            string expected = "Constructor not found";
            try
            {
                object obj = MoodAnalyserfactory.CreateMoodAnalyserWithParameterisedConstructor("MoodAnalyser", "MoodAnalaysers");
            }
            catch (MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC-6.1  Given Happy Message Using Reflection When Proper Should Return HAPPY Mood
        /// </summary>

        [Test]
        public void GivenHappyMessage_Proper_ShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserfactory.InvokeAnalyseMood("HAPPY", "AnalyserMood");
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// TC- 6.2 Given Happy Message When Improper Method Should Throw MoodAnalysis Exception
        /// </summary>

        [Test]
        public void GivenHappyMessage_WhenImproperMethod_Should_ThrowException()
        {
            string expected = "Constructor not found";
            try
            {
                string mood = MoodAnalyserfactory.InvokeAnalyseMood("Happy", "Analyser");
            }
            catch(MoodAnalyserCustomException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}