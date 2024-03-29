﻿CREATE TABLE Brands(
	BrandID int NOT NULL PRIMARY KEY,	
    BrandName varchar(255)
);

CREATE TABLE Colors(
	ColorID int NOT NULL PRIMARY KEY,	
    ColorName varchar(255)
);

CREATE TABLE Cars(
	CarID int NOT NULL PRIMARY KEY,
	BrandID int FOREIGN KEY REFERENCES Brands(BrandID),
    ColorID int FOREIGN KEY REFERENCES Colors(ColorID),
    ModelYear int,
    DailyPrice money,
    Descriptions varchar(255)
);

