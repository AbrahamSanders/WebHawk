SELECT 
SequenceId, 
SequenceName, 
SequenceTypeId, 
StepCount, 
IsDeleted AS SequenceIsDeleted 
FROM Sequences 
WHERE SequenceId = @sequenceId AND 
(@isDeleted IS NULL OR IsDeleted = @isDeleted)