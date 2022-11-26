create database [SportStore]
go
use [SportStore]
go
create table [Role]
(
	Id int primary key identity,
	Name nvarchar(100) not null
)
go
create table [User]
(
	Id int primary key identity,
	Surname nvarchar(100) not null,
	Name nvarchar(100) not null,
	Patronymic nvarchar(100) not null,
	Login nvarchar(max) not null,
	Password nvarchar(max) not null,
	Role int foreign key references [Role](Id) not null
)
go
create table [Order]
(
	Id int primary key identity,
	Status nvarchar(max) not null,
	DeliveryDate date not null,
	PickupPoint nvarchar(max) not null
)
go
create table Product
(
    Id int primary key identity,
	ArticleNumber nvarchar(100) unique,
	Name nvarchar(max) not null,
	Description nvarchar(max) not null,
	Category nvarchar(max) not null,
	Photo varchar(max) not null,
	Manufacturer nvarchar(max) not null,
	Cost decimal(19,4) not null,
    DiscountAmount tinyint null,
	QuantityInStock int not null,
	Status nvarchar(max) not null,
)
go
create table OrderProduct
(
    Id int primary key identity,
	OrderId int foreign key references [Order](Id) not null,
	ProductId int foreign key references [Product](Id) not null,
)