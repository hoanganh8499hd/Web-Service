use master
go
create database DemoWebService
go
use DemoWebService
go
create table Category
(
	CategoryID int primary key,
	CategoryName nvarchar(50) 
)
go
create table Product
(
	ProductID int primary key,
	ProductName nvarchar(50),
	Price int,
	CategoryID int not null,
	foreign key(CategoryID) references Category(CategoryID)
)

go
use DemoWebService
go

select count(*) from Product where CategoryID=1