using System;

namespace Log_Importer
{
    public class LogEntry
    {
        private readonly DateTime _dateTime;
        private readonly string _severity;
        private readonly string _message;

        public LogEntry(DateTime dateTime, string severity, string message)
        {
            _dateTime = dateTime;
            _severity = severity;
            _message = message;
        }
    }
}