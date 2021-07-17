using System;
using System.Collections.Generic;

namespace Log_Importer
{
    public class LogImporterWithoutSRP
    {
        public void ImportLogs()
        {
            string[] logFiles = GetLogFiles();
            foreach (var logFile in logFiles)
            {
                var logEntries = ReadLogEntries(logFile);
                ShowLogEntries(logEntries);
            }
        }

        private void ShowLogEntries(IEnumerable<string> logEntries)
        {
            foreach(var entry in logEntries)
            {
                var logUnit = ParseLogEntry(entry);
                Console.WriteLine(logUnit.ToString());
            }
        }

        private object ParseLogEntry(string entry)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> ReadLogEntries(string logFile)
        {
            throw new NotImplementedException();
        }

        private string[] GetLogFiles()
        {
            throw new NotImplementedException();
        }
    }
}
