INSERT INTO Sequences 
(SequenceName, SequenceTypeId, Sequence, StepCount, IsDeleted)
VALUES 
(@sequenceName, @sequenceTypeId, @sequence, @stepCount, @isDeleted);

SELECT last_insert_rowid()