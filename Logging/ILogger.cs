namespace Logging
{
    public interface ILogger<T>
    {
        void LogTrace
            (string message, System.Collections.Hashtable parameters = null);

        void LogDebug
            (string message, System.Collections.Hashtable parameters = null);

        void LogInformation
            (string message, System.Collections.Hashtable parameters = null);

        void LogWarning
            (string message, System.Collections.Hashtable parameters = null);

        void LogError
            (Exception exception = null, string message = null, System.Collections.Hashtable parameters = null);

        void LogCritical
            (Exception exception = null, string message = null, System.Collections.Hashtable parameters = null);
    }
}
