create database Dhanalaxmi

use Dhanalaxmi

create table Login
(
	username nvarchar(10) primary key,
	[password] nvarchar(10),
	confirmpswd nvarchar(10),
	Ques nvarchar(20),
	Answer nvarchar(20)

)

create proc spLogin
@userID varchar(10),
@password1 varchar(10),
@password2 varchar(10),
@Ques varchar(20),
@ans varchar(20)
as
begin
	insert into Login values(@userID,@password1,@password2,@Ques,@ans)
end

select * from Login

create table tbClients
(
	ClientID int Primary Key identity,
	ClientName nvarchar(50),
	Phone nvarchar(15),
	Email nvarchar(20),
	Address nvarchar(50)
)



select * from tbClients

create proc spGetClients
as
begin
	select distinct ClientID,ClientName from tbClients
end


create proc getClientDetails 
@clientid int
as
begin
	select distinct * from tbClients where ClientID=@clientid
end

create proc spgetItemDetails
@productcode int
as
begin
	select * from tbProducts where ProductCode=@productcode
end


create table tbProducts
(
	ProductCode int Primary Key,
	ProductDesc nvarchar(100),
	UnitsRate int ,
	UnitsInStock int
)
select * from tbProducts


create proc spgetAllItems
as
begin
	select distinct ProductCode, ProductDesc from tbProducts 
end
use Dhanalaxmi
create table tbPurchaseOrder
(
	PONumber int Primary Key,
	PODate date,
	DispatchDate date,
	Quantity int,
	Amount bigint,
	ClientID int,
	ProductCode int,
	Foreign Key(ClientID) References tbClients(ClientID),
	Foreign Key(ProductCode) References tbProducts(ProductCode)

)

select * from tbPurchaseOrder

