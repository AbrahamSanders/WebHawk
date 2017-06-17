UPDATE ScheduledTasks 
SET NextScheduledRunTimeUtc = @nextScheduledRunTimeUtc 
WHERE ScheduledTaskId = @scheduledTaskId