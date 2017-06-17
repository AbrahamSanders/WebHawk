SELECT 
COUNT(SequenceId) 
FROM Sequences 
WHERE LOWER(SequenceName) = LOWER(@sequenceName) AND
IsDeleted = 0