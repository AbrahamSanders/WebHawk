SELECT 
COUNT(ScheduledTaskId) 
FROM ScheduledTasks 
WHERE LOWER(TaskName) = LOWER(@taskName) AND
IsDeleted = 0