﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Log_Importer
{
    class LogEntryParser : LogParser
    {
        public override bool TryParse(string line, out LogEntry logEntry)
        {
            if (line is null)
            {
                logEntry = null;
                return false;
            }

            int indexOfDate = line.IndexOf("Date: ", StringComparison.OrdinalIgnoreCase) + 6;
            int indexOfSeverity = line.IndexOf("Severity: ", StringComparison.OrdinalIgnoreCase) + 10;
            int indexOfMessage = line.IndexOf("Message: ", StringComparison.OrdinalIgnoreCase) + 9;
            DateTime dateTime = DateTime.Parse(line.Substring(indexOfDate, indexOfSeverity - indexOfDate - 13));
            string severity = line.Substring(indexOfSeverity, indexOfMessage - indexOfSeverity - 11);
            string message = line[indexOfMessage..];
            logEntry = new LogEntry(dateTime, severity, message);

            return true;
        }
    }
}
