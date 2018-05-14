SELECT TOP 10 * FROM
  (SELECT TOP 30 * FROM Customers ORDER BY Id ASC) AS Table1
ORDER BY Id DESC


(select Top 30 * From
MainCircuitTable
Where City = 'Augusta' And State = 'GA' And Address Like '%Wash%'
ORDER BY Id ASC) AS Table1


 AS Table1
Order By Id DESC



Select Top 10 * From
(SELECT TOP 30 * From Southeast ORDER BY Id ASC) AS Table1
Order By Id DESC

--working in  city, state, zip
Select Top 10 * From

Select TOP 30 * From MainCircuitTable 
Where City = 'Augusta' And State = 'GA' And Address Like '%Wash%'
ORDER By Id ASC

) As Table1

ORDER BY Id ASC) AS Table1

Order By Id DESC




-- combining the original query and then wrapping it in another Top 10
-- query gets the results in the correct order
Select Top 10 * From
(Select Top 10 * From
(SELECT TOP 30 * From Southeast ORDER BY Id ASC) AS Table1
ORDER By Id DESC) AS Table2
Order By Id ASC


-- combining the original query and then wrapping it in another Top 10
-- query gets the results in the correct order
-- should I order by Address?
Select Top 10 * From
(Select Top 10 * From
(SELECT TOP 30 * From Southeast ORDER BY Id ASC) AS Table1
ORDER By Id DESC) AS Table2
Order By Address ASC

-- https:<removeSpaceBetweenBrackets>//msdn.microsoft.com/en-us/library/ms971481.aspx

-- Jeff's Execellent Solution!!!
Select Top 10 * From
(Select Top 10 * From
(SELECT TOP 30 * From MainCircuitTable 
Where City Like '%Augus%' And State = 'GA' And Address Like '%Wash%'
ORDER BY Id ASC) AS Table1
ORDER By Id DESC) AS Table2
Order By Id ASC


Select Top 10 * From
(Select Top 10 * From
(SELECT TOP 30 * From MainCircuitTable 
Where Address Like '%Wash%' And City Like '%Augus%' And State = 'GA' 
ORDER BY Id ASC) AS Table1
ORDER By Id DESC) AS Table2
Order By Id ASC

