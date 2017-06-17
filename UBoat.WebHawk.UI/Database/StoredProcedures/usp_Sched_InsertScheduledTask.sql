INSERT INTO ScheduledTasks 
(TaskName, SequenceId, Schedule, RunDurationLimit, Enabled, IsDeleted) 
VALUES 
(@taskName, @sequenceId, @schedule, @runDurationLimit, @enabled, @isDeleted);

SELECT last_insert_rowid()