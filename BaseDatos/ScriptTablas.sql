Use Taxi;
go
-------------------------------------------------------------------------------------------------------------
CREATE TABLE Taxis
(
Id int Identity(1,1), --Llave Primaria
Plaque varchar(50) Unique,

CONSTRAINT PK_Taxis_Id PRIMARY KEY(Id) --Llave Primaria
)
GO
-------------------------------------------------------------------------------------------------------------
CREATE TABLE Trip
(
Id int Identity(1,1), --Llave Primaria
StartDate datetime,
EndDate datetime,
Source varchar(50),
Target varchar(50),
Qualification float,
SourceLatitude decimal(18,0),
SourceLongitude decimal(18,0),
TargetLatitude decimal(18,0),
Remarks varchar(50),
IdTaxis int

CONSTRAINT PK_Trip_Id PRIMARY KEY(Id), --Llave Primaria
CONSTRAINT FK_Trip_IdTaxis FOREIGN KEY (Id) REFERENCES Taxis(Id)
)
GO
-------------------------------------------------------------------------------------------------------------
CREATE TABLE TripDetail
(
Id int Identity(1,1), --Llave Primaria
Date datetime,
Latitude float,
Longitude float,
IdTrip int

CONSTRAINT PK_TripDetail_Id PRIMARY KEY(Id), --Llave Primaria
CONSTRAINT FK_TripDetail_IdTrip FOREIGN KEY (Id) REFERENCES Trip(Id),
)
GO
-----------------------------------------------------------------------