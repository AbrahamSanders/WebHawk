UPDATE Sequences 
SET SequenceName = @sequenceName, 
SequenceTypeId = @sequenceTypeId, 
Sequence = @sequence,
StepCount = @stepCount, 
IsDeleted = @isDeleted 
WHERE SequenceId = @sequenceId