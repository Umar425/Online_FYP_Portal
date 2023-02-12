create database FYPPortal

use FYPPortal

create table Organization
(
OrgID int primary key identity(1,1) not null,
OrgName varchar(50),
OrgAddress varchar(50),
OrgPhoneNo varchar(20),
OrgEmail varchar(50),
OrgLogo binary null,
OrgIsActive bit null
)

create table Department
(
DeptID int primary key identity(1,1) not null,
DeptName varchar(50),
OrgID int foreign key references Organization(OrgID),
DeptIsActive bit null
)

create table Position
(
PosID int primary key identity(1,1) not null,
PosTitle varchar(50),
PosIsActive binary null
)

create table Expertise
(
ExpID int primary key identity(1,1) not null,
ExpTitle varchar(50),
Abbreviation varchar(50),
ExpIsActive binary null
)

create table Qualification
(
QualID int primary key identity(1,1) not null,
QualTitle varchar(50),
QualIsActive binary null
)

create table Faculty
(
FaclID int primary key identity(1,1) not null,
FaclFirstName varchar(50),
FaclLastName varchar(50),
FaclPhoneNo varchar(20),
FaclEmail varchar(50),
FaclAddress varchar(50),
PosID int foreign key references Position(PosID),
ExpID int foreign key references Expertise(ExpID),
QualID int foreign key references Qualification(QualID),
DeptID int foreign key references Department(DeptID),
OrgID int foreign key references Organization(OrgID),
FaclImage binary null,
FaclIsActive bit null
)

create table Student
(
StdID int primary key identity (1,1) not null,
StdFirstName varchar(50),
StdLastName varchar(50),
StdPhoneNo varchar(50),
StdEmail varchar(50),
StdGender varchar(50),
DeptID int foreign key references Department(DeptID),
StdAddress varchar(50),
StdIsActive bit null
)

create table StudentGroup
(
SgID int primary key identity (1,1) not null,
SgGroupTitle varchar(50) not null,
SgIsActive bit,
SgIsLeader bit
)

create table StudentGroupMembers
(
SgmID int primary key identity (1,1) not null,
StdID int foreign key references Student(StdID),
SgID int foreign key references StudentGroup(SgID),
DeptID int foreign key references Department(DeptID),
ProjID int foreign key references Project(ProjID),
SgmIsActive binary
)

create table Supervisor
(
SupID int primary key identity (1,1) not null,
FaclID int foreign key references Faculty(FaclID),
SupIsActive bit
)


create proc Sp_SaveOrg
@OrgName varchar(50),
@OrgAddress varchar(50),
@OrgPhoneNo varchar(20),
@OrgEmail varchar(50)
as
begin
insert into Organization(OrgName,OrgAddress,OrgPhoneNo,OrgEmail) 
values (@OrgName,@OrgAddress,@OrgPhoneNo,@OrgEmail)
end

create proc Sp_GetOrg
as 
begin
select * from Organization
end

create proc Sp_DeleteOrg
@OrgID int
as 
begin
delete from Organization where OrgID=@OrgID
end





create proc Sp_SaveDept
@DeptName varchar(50),
@OrgID int
as
begin
insert into Department(DeptName,OrgID) 
values (@DeptName,@OrgID)
end

create proc Sp_GetDept
as 
begin
select * from Department
end

create proc Sp_DeleteDept
@DeptID int
as 
begin
delete from Department where DeptID=@DeptID
end





create proc Sp_SavePos
@PosTitle varchar(50)
as
begin
insert into Position(PosTitle) 
values (@PosTitle)
end

create proc Sp_GetPos
as 
begin
select * from Position
end

create proc Sp_DeletePos
@PosID int
as 
begin
delete from Position where PosID=@PosID
end





create proc Sp_SaveExp
@ExpTitle varchar(50),
@Abbreviation varchar(50)
as
begin
insert into Expertise(ExpTitle, Abbreviation) 
values (@ExpTitle,@Abbreviation)
end

create proc Sp_GetExp
as 
begin
select * from Expertise
end

create proc Sp_DeleteExp
@ExpID int
as 
begin
delete from Expertise where ExpID=@ExpID
end






create proc Sp_SaveQual
@QualTitle varchar(50)
as
begin
insert into Qualification(QualTitle) 
values (@QualTitle)
end

create proc Sp_GetQual
as 
begin
select * from Qualification
end

create proc Sp_DeleteQual
@QualID int
as 
begin
delete from Qualification where QualID=@QualID
end






create proc Sp_SaveFacl
@FaclFirstName varchar(50),
@FaclLastName varchar(50),
@FaclPhoneNo varchar(20),
@FaclEmail varchar(50),
@FaclAddress varchar(50),
@PosID int,
@ExpID int,
@QualID int,
@DeptID int,
@OrgID int
as
begin
insert into Faculty(FaclFirstName,FaclLastName,FaclPhoneNo,FaclEmail,FaclAddress,PosID,ExpID,QualID,DeptID,OrgID) 
values (@FaclFirstName,@FaclLastName,@FaclPhoneNo,@FaclEmail,@FaclAddress,@PosID,@ExpID,@QualID,@DeptID,@OrgID)
end

create proc Sp_GetFacl
as 
begin
select * from Faculty
end

create proc Sp_DeleteFacl
@FaclID int
as 
begin
delete from Faculty where FaclID=@FaclID
end





DELETE FROM Organization
DBCC CHECKIDENT ('FYPPortal.dbo.Organization', RESEED, 0)


DELETE FROM Department
DBCC CHECKIDENT ('FYPPortal.dbo.Department', RESEED, 0)


DELETE FROM Position
DBCC CHECKIDENT ('FYPPortal.dbo.Position', RESEED, 0)


DELETE FROM Expertise
DBCC CHECKIDENT ('FYPPortal.dbo.Expertise', RESEED, 0)


DELETE FROM Qualification
DBCC CHECKIDENT ('FYPPortal.dbo.Qualification', RESEED, 0)


DELETE FROM Faculty
DBCC CHECKIDENT ('FYPPortal.dbo.Faculty', RESEED, 0)

//ProjectDAL,Model,Razor

CREATE TABLE Projects (
    ProjectID INT PRIMARY KEY IDENTITY(1,1),
    ProjectName VARCHAR(50) NOT NULL,
    ProjectDetails VARCHAR(MAX) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL
);
INSERT INTO Projects (ProjectName, ProjectDetails, StartDate, EndDate)
VALUES
('Project 1', 'Details about project 1', '2022-01-01', '2022-12-31'),
('Project 2', 'Details about project 2', '2022-06-01', '2022-06-30'),
('Project 3', 'Details about project 3', '2022-07-01', '2022-12-31');

select * from Projects


create proc Sp_GetProjects
as 
begin
select * from Projects
end