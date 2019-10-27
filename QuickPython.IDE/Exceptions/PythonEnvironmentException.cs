using System;

namespace QuickPython.IDE.Exceptions
{
    public class PythonEnvironmentException : Exception
    {
        public PythonEnvironmentException(string message)
            : base(message)
        { }
    }
}
