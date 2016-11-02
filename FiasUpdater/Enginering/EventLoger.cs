using System.Diagnostics;

namespace FiasUpdater
{
    class EventLoger
    {
        private static string serviceName = "Actualisation Fias";
        private static string sLog = "FiasActial";
        private static EventLog log = new EventLog();

        public static void configEventlog()
        {
            log = new EventLog()
            {
                Source = serviceName,
                Log = sLog,

            };
            ((System.ComponentModel.ISupportInitialize)(log)).BeginInit();
            if (!EventLog.SourceExists(serviceName))
            {
                EventLog.CreateEventSource(serviceName, sLog);
            }
            ((System.ComponentModel.ISupportInitialize)(log)).EndInit();
        }

        public static void setEvent(string message, EventLogEntryType type)
        {
            log.WriteEntry(message, type);
        }

    }
}
