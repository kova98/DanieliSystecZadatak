UPDATE Member 
SET Status = 'Frequent'
FROM Member JOIN (SELECT Member, COUNT(Id) AS Counter 
					FROM BorrowHistory 
					GROUP BY Member)
AS tmp ON Member.Id = tmp.Member 
WHERE tmp.COUNTER > 50