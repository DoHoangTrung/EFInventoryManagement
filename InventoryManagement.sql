CREATE DATABASE InventoryManagement
GO

USE InventoryManagement
GO

CREATE TABLE Supplier
(
	ID VARCHAR(30) PRIMARY KEY,
	Name NVARCHAR(100),
	Address NVARCHAR(100),
	Phone CHAR(11),
	Email CHAR(100)
)
GO

create table ProductType(
	ID varchar(30) primary key,
	Name nvarchar(100)
)

CREATE TABLE Product
(
	ID VARCHAR(30) PRIMARY KEY,
	Name NVARCHAR(100) not null,
	Unit NVARCHAR(20),
	IdType varchar(30) references ProductType(id)
)
GO

CREATE TABLE Customer
(
	ID VARCHAR(30) PRIMARY KEY,
	Name NVARCHAR (100),
	Phone CHAR (11),
	Address NVARCHAR(100),
	Email VARCHAR(100)
)
GO

CREATE TABLE ReceiveVoucher
(
	ID VARCHAR(30) PRIMARY KEY,
	Date DATETIME DEFAULT GETDATE(),
	IDSupplier VARCHAR(30) REFERENCES Supplier(ID)
)

GO

CREATE TABLE ReceiveVoucherInfo
(
	IDProduct VARCHAR(30) REFERENCES Product(ID),
	IDReceiveVoucher VARCHAR(30) REFERENCES ReceiveVoucher(ID),
	QuantityInput INT DEFAULT(1),
	PriceInput INT DEFAULT(1),
	QuantityOutput INT DEFAULT (0),
	Note nvarchar(200),
	CONSTRAINT PK_ReceicveVoucherInfo PRIMARY KEY (IDProduct,IDReceiveVoucher)
)
GO

CREATE TABLE DeliveryVoucher
(
	ID VARCHAR(30) PRIMARY KEY,
	Date DATETIME DEFAULT GETDATE(),
	IDCustomer VARCHAR(30) REFERENCES Customer(ID),
	Note Nvarchar(200)
)
GO

CREATE TABLE DeliveryVoucherInfo
(
	IDProduct VARCHAR(30) REFERENCES Product(ID),
	IDDeliveryVoucher VARCHAR(30) REFERENCES DeliveryVoucher(ID),
	IDReceiveVoucher VARCHAR(30) REFERENCES ReceiveVoucher(ID),
	Quantity INT,
	PriceOutput INT,
	CONSTRAINT PK_DeliveryVoucherInfo PRIMARY KEY(IDProduct,IDDeliveryVoucher, IDReceiveVoucher)
)
GO

CREATE TABLE AccountType
(
	ID varchar(30) primary key,
	Name varchar(100)
)

go

CREATE TABLE Account
(
	UserName VARCHAR(30) PRIMARY KEY,
	PassWord VARCHAR(30) DEFAULT('1'),
	IDType varchar(30) references AccountType(ID)
)
GO

--INSERT INTO Account VALUES ('admin','1')

--INSERT data:
--AccountType:
INSERT INTO AccountType(ID,Name) 
VALUES 
	('0','user'),
	('1','admin')
go
--Account:
INSERT INTO Account(UserName, PassWord, IDType) 
VALUES
	('admin','1','1')

go
--Nha cung cap
INSERT INTO Supplier(ID,Name,Address) 
VALUES
('NCCDinhTrinh',N'Công ty TNHH Thương Mại Dịch Vụ Sắt Thép Đình Trình',N'142/25A Ấp Cầu Hang, Nguyễn Ái Quốc, Hóa An, TP.Biên Hòa, Tỉnh Đồng Nai'),
('NCCIS',N'Công Ty Cổ Phần I.S',N'493 Sư Vạn Hạnh, P12, Q10, TP.HCM'),
('NCCHongHa',N'Cty TNHH MTV TM Thép Hồng Hà',N'237 QL. 1K, Linh Xuân, Thủ Đức.TP.HCM'),
('NCCThanhTam',N'Công Ty TNHH Sắt Thép Thanh Tâm', N'222 Quốc Lộ 1K, Khu Phố 1, P.Linh Xuân, Q.Thủ Đức, TP.HCM'),
('NCCThuanAn',N'Công Ty Cổ Phần Thương Mại Tổng Hợp Thuận An',N'90 Châu Văn Tiếp, TT Lái Thiêu, H.Thuận An, Bình Dương'),
('NCCHanVinh',N'Công Ty TNHH Thương Mại Dịch Vụ Hán Vinh', N'84A Hòa Bình, Phường 5, Quận 11, TP.HCM'),
('NCC0TinNghia',N'Công Ty Cổ Phần Xăng Dầu Tín Nghĩa',N'95A Cách Mạng Tháng 8, Phường Quyết Thắng, TP.Biên Hòa, Đồng Nai'),
('NCCHungThinh',N'Công ty TNHH MTV Đoàn Hưng Thịnh',N'9/33 KP Bình Minh 2, P.Dĩ An, TX Dĩ an, Bình Dương'),
('NCCBaoHan',N'Công ty TNHH  MTV Tôn Thép Gia Bảo Hân',N'Tổ 04, Ấp Tân Hòa, Xã Đông Hòa, Huyện Dĩ An, tỉnh Bình Dương'),
('NCCTruongThinh',N'Công Ty TNHH Thương Mại Sản Xuất Tân Trường Thịnh',N'288 Cách Mạng Tháng 8, Phường 10, Quận 3, TP.HCM')
GO

--Khach hang
INSERT INTO Customer(ID,Name,Address)
VALUES
('KHMinh',N'Cửa Hàng Minh',N'77B/13 Nội Hóa 2, Dĩ An, Bình An , Bình Dương.'),
('KHHoangDao',N'Công ty TNHH  MTV TM Sản Xuất Hoàng Đạo',N'160 Quốc Lộ 1K, Khu Phố 1, Phường Linh Xuân, Quận Thủ Đức, TP.HCM'),
('KHFahasa',N'Công Ty Cổ Phần Phát Hành Sách Thành Phố Hồ Chí Minh  -Fahasa',N'60-62 Lê Lợi, Q1, TP.HCM')

GO
--Type of product
insert into ProductType (ID,Name) values
	('1',N'Vật liệu xây dựng'),
	('2',N'Nhiên liêu'),
	('3',N'Thực phẩm')
go
--Product
INSERT INTO Product(ID,Name,Unit, IdType)
VALUES
('SPBXS100',N'Bánh xe sắt 100',N'bộ','1'),
('SPS6',N'Sắt D6',N'kg','1'),
('SPTHACHCAO',N'Thạch cao lagyp mini (605x1210x8)',N'tấm','1'),
('SPS8',N'Sắt 8',N'kg','1'),
('SPTOVHMK',N'Thép ống vuông hộp mạ kẽm',N'kg','1'),
('SPSATLA',N'Sắt la các loại',N'kg','1'),
('SPTHEPHOP',N'Thép hộp các loại',N'kg','1'),
('SPX92',N'Xăng A92',N'lít','2'),
('SPQH421_3.2',N'Que hàn 421 3.2',N'kg','1'),
('SPQHKT',N'Que hàn KT 6013',N'kg','1'),
('SPQHKR',N'Que hàn KR3000 - 3.2x350',N'kg','1'),
('SPQH421_2.5',N'Que hàn 421 2.5',N'kg','1'),
('SPTLA',N'Thép lá',N'kg','1'),
('SPTVUONG',N'Thép vuông các loại',N'kg','1'),
('SPTL',N'Tôn lạnh',N'kg','1'),
('SPTOT',N'Thép ống tròn các loại',N'kg','1'),
('SPSDCC',N'Sơn màu DCC Dd Benzo (20kg)',N'thùng','1')

GO

--PHIEU NHAP

INSERT INTO ReceiveVoucher(ID,IDSupplier, Date)
VALUES
('PN001','NCCDinhTrinh','20210201'),
('PN002','NCCDinhTrinh','20210202'),
('PN003','NCCIS','20210202'),
('PN004','NCCDinhTrinh','20210203'),
('PN005','NCCDinhTrinh','20210204'),
('PN006','NCCHongHa','20210209'),
('PN007','NCCThanhTam','20210212'),
('PN008','NCCThuanAn','20210213'),
('PN009','NCCHanVinh','20210214'),
('PN010','NCCHanVinh','20210215')

--upDATE ReceiveVoucher set Date = DATEADD(MONTH,-1,[Date])
GO

--Thong tin phieu nhap
INSERT INTO ReceiveVoucherInfo(IDReceiveVoucher,IDProduct,QuantityInput,PriceInput)
VALUES
('PN001','SPBXS100', 988,16600),
('PN002','SPS6',1067,16700),
('PN003','SPTHACHCAO',112,20450),
('PN004','SPS6',1080,16600),
('PN005','SPS8',1080,16500),
('PN006','SPTOVHMK',564,18390),
('PN007','SPSATLA',259,14001),
('PN007','SPTHEPHOP',746,15832),
('PN008','SPX92',22,20818),
('PN009','SPQH421_3.2',900,19272),
('PN010','SPQHKT',900,19181)
GO

--PHIEU XUAT
--INSERT INTO DeliveryVoucher(ID,IDCustomer,Date)
--VALUES
--('PX001','KHMinh','20210217'),
--('PX002','KHFahasa','20210218')

GO

--THONG TIN PHIEU XUAT
--INSERT INTO DeliveryVoucherInfo(IDDeliveryVoucher,IDProduct,Quantity,PriceOutput,IDReceiveVoucher)
--VALUES
--('PX001','SPBXS100',700,20000,'PN001'),
--('PX001','SPS6',1000,20000,'PN002'),
--('PX002','SPS8',900,20000,'PN005'),
--('PX002','SPTHEPHOP',700,20000,'PN007'),
--('PX002','SPQHKT',900,20000,'PN010')

--GO

create view ProductCanSellView
as 
	select pt.Name as [TypeName], p.ID as [ProductID],p.Name as [ProductName],p.Unit,sum(i.PriceInput) as [SumPriceInput],sum(i.QuantityInput) as [SumQuantityInput] , sum(i.QuantityOutput) as [SumQuantityOutput], count(p.ID) as [Count], pt.ID as[IDType]
	from ReceiveVoucherInfo i
	join Product p on p.ID = i.IDProduct
	join ProductType pt on pt.id = p.IdType
	group by p.ID,pt.Name,p.Name,p.Unit,pt.ID

USE InventoryManagement
GO


--view deliveryVoucherView

alter view [DeliveryVoucherView]
as
	select 
		v.ID as [VoucherID],
		v.Date	,
		i.IDProduct as [ProductID],
		p.Name as [ProductName],
		p.Unit,
		sum(i.Quantity) as[SumQuantity],
		i.PriceOutput,
		c.Name as[CustomerName],
		c.Phone,
		c.Email,
		c.ID as[CustomerID]
	from DeliveryVoucher v
	left join DeliveryVoucherInfo i on v.ID = i.IDDeliveryVoucher
	join Product p on i.IDProduct = p.ID
	join Customer c on v.IDCustomer = c.ID
	group by v.ID, i.IDProduct,i.PriceOutput,p.Name,p.Unit,v.Date,c.Name,c.Phone,c.Email,c.ID

--view deliveryvoucherinfo
create view [DeliveryVoucherInfoView]
as 
select 
	p.id as [ProductID],
	p.name as [ProductName],
	sum(i.Quantity) as [SumQuantity],
	i.PriceOutput,
	i.IDDeliveryVoucher as[DeliveryVoucherID]
from DeliveryVoucherInfo i
join Product p on i.IDProduct = p.id
group by  p.id,p.name,i.PriceOutput,i.IDDeliveryVoucher
-----------------------2)them san pham
CREATE PROC InsertProduct
	@ID VARCHAR(30), @Name NVARCHAR(100), @Unit NVARCHAR(20)
AS
BEGIN
	INSERT INTO Product (ID,Name,Unit) VALUES (@ID,@Name,@Unit)
END
go
--EXEC dbo.InsertProduct @ID = '@-/\70000001' , @Name='banh xe ben' , @Unit = 'qua'

--create trigger insert deliveryvoucherinfo
create trigger InsertDeliveryVoucherInfo
on deliveryvoucherInfo
after insert
as
begin
	set nocount on;
	
	declare @idReceiveVoucher varchar(30)
	declare @idProduct varchar(30)
	declare @quantityOutput int
	
	select 
		@idReceiveVoucher = i.IDReceiveVoucher,
		@idProduct= i.IDProduct,
		@quantityOutput = i.Quantity
	from inserted i
	
	update ReceiveVoucherInfo 
	set QuantityOutput += @quantityOutput
	where IDReceiveVoucher = @idReceiveVoucher 
		and IDProduct = @idProduct
end
--create trigger for delete delivery voucher info
create trigger DeleteDeliveryVoucherInfo
on DeliveryVoucherInfo
after Delete
as 
begin
	declare @idReceiveVoucher varchar(30)
	declare @idProduct varchar(30)
	declare @quantityOutput int
	
	select 
		@idReceiveVoucher = d.IDReceiveVoucher,
		@idProduct= d.IDProduct,
		@quantityOutput = d.Quantity
	from deleted d

	update ReceiveVoucherInfo 
	set QuantityOutput -=@quantityOutput
	where IDReceiveVoucher = @idReceiveVoucher and IDProduct = @idProduct
end


-- view report 
--create view [Report]
--as
--select p.ID as ProductID,
--p.Name as ProductName,
--p.Unit as ProductUnit,
--reInfo.QuantityInput as [ReceiveQuantity],
--reInfo.PriceInput as [ReceivePrice],
--reInfo.QuantityInput*reInfo.PriceInput as [ReceiveTotalPrice],
--deInfo.Quantity as [DeliveryQuantity],
--deInfo.PriceOutput as [DeliveryPrice],
--deInfo.Quantity*deInfo.PriceOutput as [DeliveryTotalPrice],
--reInfo.QuantityInput- reInfo.QuantityOutput as [InventoryNumber]
--from ReceiveVoucherInfo reInfo 
----join DeliveryVoucher deVoucher on deInfo.IDDeliveryVoucher = deVoucher.ID
--left join DeliveryVoucherInfo deInfo on deInfo.IDReceiveVoucher = reInfo.IDReceiveVoucher and deInfo.IDProduct = reInfo.IDProduct
----join ReceiveVoucher rVoucher on rVoucher.ID = reInfo.IDReceiveVoucher
--join Product p on reInfo.IDProduct = p.ID
----join Supplier s on s.ID = rVoucher.IDSupplier

alter proc [ShowReportByDuration]
	@fromDate DateTime , @toDate DateTime
as
begin
select p.ID as ProductID,
	p.Name as ProductName,
	p.Unit as ProductUnit,
	sum(reInfo.QuantityInput) as [ReceiveQuantity],
	sum(reInfo.QuantityInput*reInfo.PriceInput)/sum(reInfo.QuantityInput) as [ReceivePrice],
	sum(reInfo.QuantityInput*reInfo.PriceInput) as [ReceiveTotalPrice],
	sum(deInfo.Quantity) as [DeliveryQuantity],
	sum(deInfo.Quantity*deInfo.PriceOutput)/sum(deInfo.Quantity) as [DeliveryPrice],
	sum(deInfo.Quantity*deInfo.PriceOutput) as [DeliveryTotalPrice],
	sum(reInfo.QuantityInput- ISNULL(deInfo.Quantity,0)) as [InventoryNumber],
	sum(ISNULL(deInfo.Quantity*deInfo.PriceOutput,0) - reInfo.QuantityInput*reInfo.PriceInput) as [Profit]
	from (
		select * 
		from ReceiveVoucherInfo ri
		join ReceiveVoucher rv on ri.IDReceiveVoucher = rv.ID
		where rv.Date between @fromDate and @toDate	) reInfo
	left join (
		select *
		from DeliveryVoucherInfo di 
		join DeliveryVoucher dv on di.IDDeliveryVoucher = dv.ID
		where dv.date between @fromDate and @toDate	) deInfo 
	on deInfo.IDReceiveVoucher = reInfo.IDReceiveVoucher and deInfo.IDProduct = reInfo.IDProduct
	join Product p on reInfo.IDProduct = p.ID
	group by p.id,p.Name, p.Unit
end

--exec ShowReportByDuration '20210201', '20210515'

create proc ShowReport
as
begin
	select p.ID as ProductID,
	p.Name as ProductName,
	p.Unit as ProductUnit,
	sum(reInfo.QuantityInput) as [ReceiveQuantity],
	sum(reInfo.QuantityInput*reInfo.PriceInput)/sum(reInfo.QuantityInput) as [ReceivePrice],
	sum(reInfo.QuantityInput*reInfo.PriceInput) as [ReceiveTotalPrice],
	sum(deInfo.Quantity) as [DeliveryQuantity],
	sum(deInfo.Quantity*deInfo.PriceOutput)/sum(deInfo.Quantity) as [DeliveryPrice],
	sum(deInfo.Quantity*deInfo.PriceOutput) as [DeliveryTotalPrice],
	sum(reInfo.QuantityInput- ISNULL(deInfo.Quantity,0)) as [InventoryNumber],
	sum(ISNULL(deInfo.Quantity*deInfo.PriceOutput,0) - reInfo.QuantityInput*reInfo.PriceInput) as [Profit]
	from ReceiveVoucherInfo reInfo 
	left join DeliveryVoucherInfo deInfo on deInfo.IDReceiveVoucher = reInfo.IDReceiveVoucher and deInfo.IDProduct = reInfo.IDProduct
	left join DeliveryVoucher deVoucher on deInfo.IDDeliveryVoucher = deVoucher.ID
	join ReceiveVoucher rVoucher on rVoucher.ID = reInfo.IDReceiveVoucher
	join Product p on reInfo.IDProduct = p.ID
	--join Supplier s on s.ID = rVoucher.IDSupplier
	group by p.id,p.Name, p.Unit
end

--view receive voucher dto
create view ReceiveVoucherDTO
as
	select 
		rv.ID as [ReceiveVoucherID],
		p.ID as [ProductID],
		p.Name as [ProductName],
		p.Unit,
		rv.Date,
		ri.QuantityInput,
		ri.PriceInput,
		ri.Note,
		s.Name as [SupplierName],
		s.Address,
		s.Phone
	from ReceiveVoucher rv
	join ReceiveVoucherInfo ri 
		on rv.ID = ri.IDReceiveVoucher
	join Supplier s 
		on rv.IDSupplier = s.ID
	join Product p 
		on p.ID = ri.IDProduct

--create view productDTO
alter view ProductDTO
as
	select p.ID,p.Name,p.Unit,t.Name as [TypeName], t.ID as [TypeID]
	from Product p
	join ProductType t 
		on p.IdType = t.id