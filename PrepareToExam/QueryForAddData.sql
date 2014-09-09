DECLARE @RowCount int = 100
WHILE @RowCount > 0
BEGIN
  DECLARE @Number nchar(10) = 'BG ' + CONVERT(nchar(10), @RowCount)
  DECLARE @Pin nchar(4) = CONVERT(nchar(4), @RowCount)
  DECLARE @Cash money = @RowCount
  INSERT INTO CardAccounts(CardNumber, CardPIN, CardCash)
  VALUES(@Number, @Pin, @Cash)
  SET @RowCount = @RowCount - 5
END