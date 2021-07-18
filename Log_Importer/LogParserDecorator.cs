using System;
using System.Collections.Generic;
using System.Text;

namespace Log_Importer
{
    abstract class LogParserDecorator : LogParser
    {
        protected LogParser _logParser;
        public LogParserDecorator(LogParser logParser) : base()
        {
            _logParser = logParser;
        }
    }
}
