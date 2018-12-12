SELECT * FROM Borrow
JOIN Movie ON Borrow.Movie=Movie.Id
WHERE Borrow.ReturnDate IS NULL AND Movie.Genre = 'Klasika'