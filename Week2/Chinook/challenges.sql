USE MyDatabase;

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'MyDatabase';

SELECT * FROM Employee;

-- List all customers (full name, customer id, and country) who are not in the USA
SELECT TOP 10 * FROM Customer;
SELECT (FirstName + ' ' + LastName) as FullName, CustomerId, Country 
FROM Customer
WHERE Country != 'USA'; 

-- List all customers from Brazil
SELECT * FROM Customer WHERE Country = 'Brazil';

-- List all sales agents
SELECT * FROM Employee WHERE Title = 'Sales Support Agent';

-- Retrieve a list of all countries in billing addresses on invoices
SELECT DISTINCT BillingCountry FROM Invoice;

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Invoice';

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
SELECT COUNT(*) as totalInvoices, SUM(Total)
FROM Invoice WHERE YEAR(InvoiceDate) = 2009;

    -- (challenge: find the invoice count sales total for every year using one query)
    SELECT YEAR(InvoiceDate), COUNT(*) as totalInvoices, SUM(Total) as totalSales
    FROM Invoice GROUP BY YEAR(InvoiceDate);

-- how many line items were there for invoice #37
SELECT InvoiceId, SUM(Quantity) AS LineItems
FROM InvoiceLine
WHERE InvoiceId = 37
GROUP BY InvoiceId;

-- how many invoices per country? BillingCountry  # of invoices -
SELECT BillingCountry, COUNT(InvoiceId) as InvoiceCount
FROM Invoice
GROUP BY BillingCountry;

-- Retrieve the total sales per country, ordered by the highest total sales first.
SELECT BillingCountry, SUM(Total) as TotalSales
FROM Invoice
GROUP BY BillingCountry
ORDER BY TotalSales DESC;


-- JOINS CHALLENGES
-- Every Album by Artist
SELECT Artist.Name, Album.Title
FROM Artist
JOIN Album
ON Artist.ArtistId = Album.ArtistId;

-- All songs of the rock genre
SELECT Genre.Name, Track.Name
FROM Track
JOIN Genre
ON Track.GenreId = Genre.GenreId
WHERE Genre.Name = 'Rock';

-- LIST COLUMNS FOR THE FOLLOWING TABLES
-- SELECT TABLE_NAME, COLUMN_NAME 
-- FROM INFORMATION_SCHEMA.COLUMNS 
-- WHERE TABLE_NAME IN ('Genre', 'Album', 'Artist', 'MediaType', 'Playlist', 'PlaylistTrack', 'Track');

-- Show all invoices of customers from brazil (mailing address not billing)

SELECT Customer.Country AS CustomerCountry, Invoice.*
FROM Invoice
JOIN Customer
ON Customer.CustomerId = Invoice.InvoiceId
WHERE Customer.Country = 'Brazil';

-- Show all invoices together with the name of the sales agent for each one
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'MyDatabase';

SELECT TABLE_NAME, COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE COLUMN_NAME = 'InvoiceId';

SELECT (Employee.FirstName + ' ' + Employee.LastName) AS SalesAgent, Invoice.*
FROM Invoice
JOIN Customer
ON Invoice.CustomerId = Customer.CustomerId
JOIN Employee
ON Employee.EmployeeId = Customer.SupportRepId;


-- Which sales agent made the most sales in 2009?
SELECT TOP 1 (Employee.FirstName + ' ' + Employee.LastName) AS SalesAgent, SUM(Invoice.Total) AS TotalSales
FROM Invoice
JOIN Customer
ON Invoice.CustomerId = Customer.CustomerId
JOIN Employee
ON Employee.EmployeeId = Customer.SupportRepId
WHERE YEAR(Invoice.InvoiceDate) = 2009
GROUP BY Employee.EmployeeId, Employee.FirstName, Employee.LastName
ORDER BY TotalSales DESC;

-- How many customers are assigned to each sales agent?
SELECT (Employee.FirstName + ' ' + Employee.LastName) AS SalesAgent, COUNT(Customer.CustomerId) AS CustomerCount
FROM Employee
JOIN Customer
ON Employee.EmployeeId = Customer.SupportRepId
GROUP BY Employee.EmployeeId, Employee.FirstName, Employee.LastName;

-- Which track was purchased the most ing 20010?
SELECT TABLE_NAME, COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS;
SELECT COUNT(TrackId)
FROM InvoiceLine
JOIN Invoice
ON Invoice.InvoiceId = InvoiceLine.InvoiceId
WHERE YEAR(Invoice.InvoiceDate) = 2010
GROUP BY TrackId
ORDER BY COUNT(TrackId) DESC;

-- Show the top three best selling artists.
SELECT Artist.ArtistId, Artist.Name, SUM(InvoiceLine.Quantity) AS TracksSold
FROM InvoiceLine
JOIN Track ON InvoiceLine.TrackId = Track.TrackId
JOIN Album ON Track.AlbumId = Album.AlbumId
JOIN Artist ON Album.ArtistId = Artist.ArtistId
GROUP BY Artist.ArtistId, Artist.Name
ORDER BY SUM(InvoiceLine.Quantity) DESC;


-- Which customers have the same initials as at least one other customer?
SELECT 
    (c1.FirstName + ' ' + c1.LastName) AS Customer1, 
    (c2.FirstName + ' ' + c2.LastName) AS Customer2
FROM Customer c1
JOIN Customer c2 
ON SUBSTRING(c1.FirstName, 1, 1) = SUBSTRING(c2.FirstName, 1, 1)
    AND SUBSTRING(c1.LastName, 1, 1) = SUBSTRING(c2.LastName, 1, 1)
WHERE c1.CustomerId != c2.CustomerId;

-- ADVACED CHALLENGES
-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?
SELECT Artist.Name
FROM Artist
LEFT JOIN Album ON (Artist.ArtistId = Album.ArtistId)
GROUP BY Artist.ArtistId, Artist.Name
HAVING COUNT(Album.AlbumId) = 1;

-- 2. which artists did not record any tracks of the Latin genre?
SELECT *
FROM Artist
WHERE Artist.ArtistId NOT IN 
(SELECT DISTINCT Artist.ArtistId
FROM Artist
JOIN Album ON (Artist.ArtistId = Album.ArtistId)
JOIN Track ON (Album.AlbumId = Track.AlbumId)
JOIN Genre ON (Track.GenreId = Genre.GenreId)
WHERE Genre.Name = 'Latin');

SELECT A.*
FROM Artist AS A
LEFT JOIN Album AS B ON A.ArtistId = B.ArtistId
LEFT JOIN Track AS C ON B.AlbumId = C.AlbumId
LEFT JOIN Genre AS D ON C.GenreId = D.GenreId AND D.Name = 'Latin'
WHERE D.Name IS NULL;

-- 3. which video track has the longest length? (use media type table)
SELECT TOP 1 *
FROM Track
JOIN MediaType ON (Track.MediaTypeId = MediaType.MediaTypeId)
WHERE MediaType.Name LIKE '%video%'
ORDER BY Track.Milliseconds DESC;

SELECT DISTINCT Name
FROM MediaType;

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)
SELECT Customer.FirstName, Customer.LastName
FROM Customer
WHERE City = (SELECT Employee.City
FROM Employee
WHERE Employee.ReportsTo IS NUll);


-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?
SELECT SUM(InvoiceLine.Quantity)
FROM Customer
JOIN Invoice ON (Customer.CustomerId = Invoice.CustomerId)
JOIN InvoiceLine ON (Invoice.InvoiceId = InvoiceLine.InvoiceId)
JOIN Track ON (InvoiceLine.TrackId = Track.TrackId)
JOIN MediaType ON (Track.MediaTypeId = MediaType.MediaTypeId)
WHERE Customer.Country = 'Germany'
    AND MediaType.Name LIKE '%audio%'
GROUP BY Customer.Country

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.

SELECT 
    Customer.FirstName, 
    Customer.LastName, 
    Employee.EmployeeId, 
    Employee.BirthDate
FROM Customer
JOIN Employee ON Customer.SupportRepId = Employee.EmployeeId
WHERE YEAR(GETDATE()) - YEAR(Employee.BirthDate) < 55;

SELECT * FROM Artist;