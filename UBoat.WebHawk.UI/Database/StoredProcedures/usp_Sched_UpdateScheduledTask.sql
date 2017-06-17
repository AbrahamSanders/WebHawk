UPDATE ScheduledTasks 
SET TaskName = @taskName, 
SequenceId = @sequenceId, 
Schedule = @schedule, 
RunDurationLimit = @runDurationLimit, 
Enabled = @enabled, 
IsDeleted = @isDeleted 
WHERE ScheduledTaskId = @scheduledTaskId