using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalysers
{
    public class MoodAnalyserCustomException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            EMPTY_MOOD,
            EMPTY_NULL,
            NO_SUCH_FIELD,
            NO_SUCH_CLASS,
            NO_SUCH_CONSTRUCTOR,
            EMPTY_MESSAGE,
            NULL_MESSAGE,
            NULL_MOOD
        }
        public MoodAnalyserCustomException(ExceptionType type,string message): base(message)
        {
            this.type = type;
        }
    }
}