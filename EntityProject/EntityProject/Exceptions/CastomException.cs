namespace EntityProject.Exceptions
{
    /// <summary>
    /// Модель ошибок.
    /// </summary>
    public class CastomException : Exception
    {
        public CastomException(string message, CastomExceptionTypes exceptionType) : base(message)
        {
            ExceptionType = exceptionType;
        }

        public CastomExceptionTypes ExceptionType { get; }
    }
}
