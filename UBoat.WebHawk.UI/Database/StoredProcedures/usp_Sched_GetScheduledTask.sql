SELECT 
st.ScheduledTaskId, 
st.TaskName,
st.Schedule, 
st.RunDurationLimit, 
st.Enabled, 
st.LastRunStartTimeUtc, 
st.LastRunEndTimeUtc, 
st.LastRunStatusId, 
st.LastRunError, 
st.NextScheduledRunTimeUtc, 
st.IsDeleted AS ScheduledTaskIsDeleted,
seq.SequenceId,
seq.SequenceName,
seq.SequenceTypeId,
seq.StepCount,
seq.IsDeleted AS SequenceIsDeleted
FROM ScheduledTasks st
LEFT JOIN Sequences seq ON st.SequenceId = seq.SequenceId AND seq.IsDeleted = 0
WHERE st.ScheduledTaskId = @scheduledTaskId AND 
(@isDeleted IS NULL OR st.IsDeleted = @isDeleted)