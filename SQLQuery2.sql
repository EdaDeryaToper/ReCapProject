CREATE TABLE Users(
	UserID int NOT NULL PRIMARY KEY,
    FirstName varchar(255),
    LastName varchar(255),
    Email varchar(255),
    Passwords varchar(255),
);

CREATE TABLE Customers(
	CustomerID int NOT NULL PRIMARY KEY,
	UserID int FOREIGN KEY REFERENCES Users(UserID),
    CompanyName varchar(255)
);

CREATE TABLE Rentals(
	RentalID int NOT NULL PRIMARY KEY,
	CarID int FOREIGN KEY REFERENCES Cars(CarID),
	CustomerID int FOREIGN KEY REFERENCES Customers(CustomerID),
	RentDate datetime,
	ReturnDate datetime
    
);