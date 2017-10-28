select * from tbPurchaseOrder
select * from tbPurchaseOrderItemDetails

delete from tbPurchaseOrder
delete from tbPurchaseOrderItemDetails

select * from tbProducts

insert into tbPurchaseOrderItemDetails values(740840,4,56,736062)
insert into tbPurchaseOrderItemDetails values(736062,4,56,740840)

select * from tbProducts

alter proc spGetProductDescription
@ProductCode int
as
begin
	select ProductDesc, UnitsInStock from tbProducts where ProductCode=@ProductCode
end



alter Proc spGetProductCodes 
@PONumber int
as
begin
	select distinct b.ProductCode,b.Qty
	from tbPurchaseOrder a inner join tbPurchaseOrderItemDetails b
	on a.OrderID=b.OrderID
	where a.PONumber=@PONumber 
end

create proc spGetQty
@ProductCode int,
@PONumber int
as
begin
	select distinct b.ProductCode,b.Qty
	from tbPurchaseOrder a inner join tbPurchaseOrderItemDetails b
	on a.OrderID=b.OrderID
	where b.ProductCode=@ProductCode  and a.PONumber=@PONumber
end

alter proc spInsertPO

@POnumber int,
@PODate datetime,
@DispatchDate datetime,
@clientID int,
@OrderId int out
as
begin
	insert into tbPurchaseOrder values(@POnumber,cast(@PODate as date) ,Cast(@DispatchDate as date) ,@clientID)
	select @OrderId=SCOPE_IDENTITY()
end

Declare @OrderID1 int
exec spInsertPO 123,'27-04-2017','02-05-2017',1,@OrderID1 
print @OrderID1

select * from check_date

insert into check_date values(Cast('27-04-2017' as date))
insert into check_date values(Convert(Date,'27-04-2017'))


alter proc spInsertPOItemDetails

@ProductCode int,
@Qty int,
@Amount int,
@OrderId int

as
begin
	insert into tbPurchaseOrderItemDetails values(@ProductCode,@Qty,@Amount,@OrderId)
end

