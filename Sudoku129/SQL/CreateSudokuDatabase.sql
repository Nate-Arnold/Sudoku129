CREATE TABLE SudokuPuzzles 
(
 ID int PRIMARY KEY IDENTITY(1,1),
 PuzzleName varchar(256) not null,
 PuzzleAuthor varchar(256) not null,
 PuzzleDescription varchar(256) not null,
 PuzzleDifficulty int,
 PuzzleData varchar(max) not null,
 Timestamp datetime default(getdate())
)
GO
CREATE PROCEDURE Sudoku_Puzzles_GetList
AS
SELECT ID, PuzzleName, PuzzleAuthor, PuzzleDescription, PuzzleDifficulty, PuzzleData
FROM SudokuPuzzles
ORDER BY Timestamp DESC;
GO
CREATE PROCEDURE Sudoku_Puzzles_SavePuzzle
(
	@PuzzleName varchar(256),
	@PuzzleAuthor varchar(256),
	@PuzzleDescription varchar(256),
	@PuzzleDifficulty int,
	@PuzzleData varchar(max)
)
AS
INSERT INTO SudokuPuzzles(PuzzleName, PuzzleAuthor, PuzzleDescription, PuzzleDifficulty, PuzzleData)
VALUES(@PuzzleName, @PuzzleAuthor, @PuzzleDescription, @PuzzleDifficulty, @PuzzleData)
GO
CREATE PROCEDURE Sudoku_Puzzles_GetByID
(
	@ID int
)
AS
SELECT ID, PuzzleName, PuzzleAuthor, PuzzleDescription, PuzzleDifficulty, PuzzleData FROM SudokuPuzzles WHERE ID=@ID
GO
CREATE PROCEDURE Sudoku_Puzzles_RemoveByID
(
	@ID int
)
AS
DELETE FROM SudokuPuzzles WHERE ID=@ID
GO