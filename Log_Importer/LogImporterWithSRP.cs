using System;
using System.Collections.Generic;
using System.IO;

namespace Log_Importer
{
    class LogImporterWithSRP
    {
        public delegate void LogHandler (LogEntry logEntry);
        public event LogHandler Notify;

        private readonly ICollection<string> _logFiles;
        private readonly LogEntryParser _parser = new LogEntryParser();

        public LogImporterWithSRP(ICollection<string> logFiles)
        {
            _logFiles = logFiles;
        }

        public void ImportLogs()
        {
            foreach (var logFile in _logFiles)
            {
                var logEntries = ReadLogEntries(logFile);
                ShowLogEntries(logEntries);
            }
        }

        private IEnumerable<string> ReadLogEntries(string logFile)
        {
            List<string> list = new List<string>();
            using (StreamReader file = File.OpenText(logFile))
            {
                
                string line;
                while((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            return list;
        }

        private void ShowLogEntries(IEnumerable<string> logEntries)
        {
            foreach (var entry in logEntries)
            {
                var logUnit = ParseLogEntry(entry);
                Notify?.Invoke(logUnit);
            }
        }

        private LogEntry ParseLogEntry(string entry)
        {
            if (_parser.TryParse(entry, out LogEntry logEntry))
                return logEntry;

            return null;
        }

    }
}
