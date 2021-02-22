CREATE SCHEMA PhoneStore

CREATE TABLE PhoneStore.Customers
(
	ID INT NOT NULL IDENTITY,
	Firstname NVARCHAR(100) NOT NULL,
	Lastname NVARCHAR(100) NOT NULL,
	CardNumber NVARCHAR(20) NULL,
	CONSTRAINT PK_PS_CustomerID PRIMARY KEY CLUSTERED (ID)
)
GO
CREATE TABLE PhoneStore.Products
(
	ID INT NOT NULL IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	Price FLOAT NOT NULL,
	CONSTRAINT PK_PS_ProductID PRIMARY KEY CLUSTERED (ID)
)
GO
CREATE TABLE PhoneStore.Orders
(
	ID INT NOT NULL IDENTITY,
	ProductID INT NOT NULL,
	CustomerID INT NOT NULL,
	CONSTRAINT PK_PS_OrderID PRIMARY KEY CLUSTERED (ID)
)


ALTER TABLE PhoneStore.Orders ADD CONSTRAINT FK_Orders_ProductId
	FOREIGN KEY (ProductID) REFERENCES PhoneStore.Products (ID)
GO

ALTER TABLE PhoneStore.Orders ADD CONSTRAINT FK_Orders_CustomerId
	FOREIGN KEY (CustomerID) REFERENCES PhoneStore.Customers (ID)
GO

-- 1.
INSERT INTO PhoneStore.Products (Name, Price) VALUES ('IPhone1', 399)
INSERT INTO PhoneStore.Products (Name, Price) VALUES ('IPhone2', 499)
INSERT INTO PhoneStore.Products (Name, Price) VALUES ('Android1', 299)

INSERT INTO PhoneStore.Customers (Firstname, Lastname, CardNumber) VALUES ('James', 'Brown', '092309021')
INSERT INTO PhoneStore.Customers (Firstname, Lastname, CardNumber) VALUES ('Mike', 'Brown', '23719872')
INSERT INTO PhoneStore.Customers (Firstname, Lastname, CardNumber) VALUES ('Jennifer', 'Orange', '298792817')

DECLARE @Customer1 INT;
DECLARE @Customer2 INT;
DECLARE @Customer3 INT;
DECLARE @Product1 INT;
DECLARE @Product2 INT;
DECLARE @Product3 INT;
SET @Customer1 = (SELECT ID FROM PhoneStore.Products WHERE Name = 'IPhone1')
SET @Product1 = (SELECT ID FrOM PhoneStore.Customers WHERE Firstname = 'James' AND Lastname = 'Brown')
SET @Customer2 = (SELECT ID FROM PhoneStore.Products WHERE Name = 'IPhone2')
SET @Product2 = (SELECT ID FrOM PhoneStore.Customers WHERE Firstname = 'Mike' AND Lastname = 'Brown')
SET @Customer3 = (SELECT ID FROM PhoneStore.Products WHERE Name = 'Android1')
SET @Product3 = (SELECT ID FrOM PhoneStore.Customers WHERE Firstname = 'Jennifer' AND Lastname = 'Orange')

INSERT INTO PhoneStore.Orders(ProductID, CustomerID) VALUES (@Product1, @Customer1)
INSERT INTO PhoneStore.Orders(ProductID, CustomerID) VALUES (@Product2, @Customer2)
INSERT INTO PhoneStore.Orders(ProductID, CustomerID) VALUES (@Product3, @Customer3)

-- 2.
INSERT INTO PhoneStore.Products(Name, Price) Values('IPhone', 200)

-- 3.
INSERT INTO PhoneStore.Customers (Firstname, Lastname, CardNumber) VALUES ('Tina', 'Smith', '231221233')

-- 4.
INSERT INTO PhoneStore.Orders(ProductID, CustomerID) VALUES (4, 4)

-- 5.
SELECT o.*, c.Firstname + ' ' + c.Lastname AS 'FullName'
FROM PhoneStore.Orders AS o
INNER JOIN PhoneStore.Customers AS c ON o.CustomerID = c.ID
WHERE c.Firstname = 'Tina' AND c.Lastname = 'SMITH'

-- 6.
SELECT p.Name, SUM(p.Price)
FROM PhoneStore.Orders AS o
INNER JOIN PhoneStore.Products AS p ON o.ProductID = p.ID
WHERE p.Name = 'IPhone'
GROUP BY p.Name

-- 7.
UPDATE PhoneStore.Products
SET Price = 250
WHERE Name = 'IPhone'