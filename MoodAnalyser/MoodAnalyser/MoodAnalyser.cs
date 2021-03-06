using MoodAnalysers;
using System;

namespace MoodAnalyserSpace
{
    public class MoodAnalyser
    {
        public string message;
        public MoodAnalyser()
        {

        }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }
        public string AnalyserMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.EMPTY_MESSAGE, "Mood should not be Empty");
                }
                if (this.message.Contains("SAD"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                return "HAPPY";
            }
        }
    }
}