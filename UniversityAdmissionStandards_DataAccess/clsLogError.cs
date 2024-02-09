using System;
using System.Diagnostics;

namespace UniversityAdmissionStandards_DataAccess
{
    public static class clsLogError
    {
        public static void LogError(string errorType, Exception ex)
        {
            // Specify the source name for the event log
            string sourceName = "UniversityAdmissionStandards";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            string errorMessage = $"{errorType} in {ex.Source}\n\nException Message:" +
                    $" {ex.Message}\n\nException Type: {ex.GetType().Name}\n\nStack Trace:" +
                    $" {ex.StackTrace}\n\nException Location: {ex.TargetSite}";

            // Log an error event
            EventLog.WriteEntry(sourceName, errorMessage, EventLogEntryType.Error);
        }
    }
}