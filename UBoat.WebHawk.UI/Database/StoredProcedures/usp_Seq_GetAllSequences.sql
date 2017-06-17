SELECT 
SequenceId, 
SequenceName, 
SequenceTypeId, 
StepCount, 
IsDeleted AS SequenceIsDeleted 
FROM Sequences 
WHERE (@isDeleted IS NULL OR IsDeleted = @isDeleted)