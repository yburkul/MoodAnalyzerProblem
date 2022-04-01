using System;

namespace MoodAnalyserTesting
{
    public class MoodAnalyser
    {
        public string Message;
        public MoodAnalyser()
        {

        }
        public MoodAnalyser(string Message)
        {
            this.Message = Message;
        }
        public string AnalyserMood()
        {
            if (Message.Contains("SAD"))
                return "SAD";
            else return "HAPPY";
        }
        static void Main(string[] args)
        {

        }
    }
}