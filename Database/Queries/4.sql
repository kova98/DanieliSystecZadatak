INSERT INTO BorrowHistory (Movie, Member, IssueDate, ReturnDate)
SELECT Movie, Member, IssueDate, GETDATE()
FROM Borrow
WHERE Id = '4';

DELETE FROM Borrow
WHERE Id = '4'