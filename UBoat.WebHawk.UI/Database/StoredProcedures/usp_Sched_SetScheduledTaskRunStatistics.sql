UPDATE ScheduledTasks 
SET LastRunStartTimeUtc = @lastRunStartTimeUtc, 
LastRunEndTimeUtc = @lastRunEndTimeUtc, 
LastRunStatusId = @lastRunStatusId, 
LastRunError = @lastRunError
WHERE ScheduledTaskId = @scheduledTaskId