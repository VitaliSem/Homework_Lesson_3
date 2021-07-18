using System;
using System.Collections.Generic;
using System.Text;

namespace Log_Importer
{
    abstract class LogParser
    {
        public abstract bool TryParse(string line, out LogEntry logEntry);
    }
}
