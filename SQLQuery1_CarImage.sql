CREATE TABLE CarImages(
CarImageID int IDENTITY(1,1) NOT NULL  PRIMARY KEY,
CarID int FOREIGN KEY REFERENCES Cars(CarID),
ImagePath varchar(255),
Dates DateTime
);