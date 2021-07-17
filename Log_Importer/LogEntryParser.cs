using System;
using System.Collections.Generic;
using System.Text;

namespace Log_Importer
{
    class LogEntryParser
    {
        public bool TryParse(string line, out LogEntry logEntry)
        {
            if (line is null)
            {
                logEntry = null;
                return false;
            }

            int indexOfDate = line.IndexOf("Date: ", StringComparison.OrdinalIgnoreCase);
            int indexOfSeverity = line.IndexOf("Severity: ", StringComparison.OrdinalIgnoreCase);
            int indexOfMessage = line.IndexOf("Message: ", StringComparison.OrdinalIgnoreCase);
            DateTime dateTime = DateTime.Parse(line[indexOfDate..indexOfSeverity]);
            string severity = line[indexOfSeverity..indexOfMessage];
            string message = line[indexOfMessage..];
            logEntry = new LogEntry(dateTime, severity, message);

            return true;
        }
    }
}
