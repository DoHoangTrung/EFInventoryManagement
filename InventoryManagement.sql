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
	IDCustomer VARCHAR(30) REFERENCES Customer(ID)
)
GO

CREATE TABLE DeliveryVoucherInfo
(
	IDProduct VARCHAR(30) REFERENCES Product(ID),
	IDDeliveryVoucher VARCHAR(30) REFERENCES DeliveryVoucher(ID),
	Quantity INT,
	PriceOutput INT,
	Note nvarchar (200),
	CONSTRAINT PK_DeliveryVoucherInfo PRIMARY KEY(IDProduct,IDDeliveryVoucher),
	IDReceiveVoucher VARCHAR(30)
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
INSERT INTO DeliveryVoucher(ID,IDCustomer,Date)
VALUES
('PX001','KHMinh','20210217'),
('PX002','KHFahasa','20210218')

GO

--THONG TIN PHIEU XUAT
INSERT INTO DeliveryVoucherInfo(IDDeliveryVoucher,IDProduct,Quantity,PriceOutput)
VALUES
('PX001','SPBXS100',700,20000),
('PX001','SPS6',1000,20000),
('PX002','SPS8',900,20000),
('PX002','SPTHEPHOP',700,20000),
('PX002','SPQHKT',900,20000)

GO

USE InventoryManagement
GO

-----------------------2)them san pham
CREATE PROC InsertProduct
	@ID VARCHAR(30), @Name NVARCHAR(100), @Unit NVARCHAR(20)
AS
BEGIN
	INSERT INTO Product (ID,Name,Unit) VALUES (@ID,@Name,@Unit)
END
go
--EXEC dbo.InsertProduct @ID = '@-/\70000001' , @Name='banh xe ben' , @Unit = 'qua'


------------------------3)DELETE GOOD
CREATE PROC DeleteProduct
	@ID VARCHAR(30)
AS
BEGIN
	DELETE FROM Product WHERE ID = @ID
END

GO

--EXEC dbo.DeleteProduct @ID = '002'


---------------------4)UPDATE GOOD Name
CREATE PROC UpdateProductName
	@ID VARCHAR(30), @Name NVARCHAR(100)
AS
BEGIN
	UPDATE Product SET Name = @Name WHERE ID = @ID
END

GO

--EXEC dbo.UpdateProductName @ID = '001', @Name = 'chan ghe'


------------------------------5)UPDATE GOOD unit
CREATE PROC UpdateProductUnit
	@ID VARCHAR(30), @unit NVARCHAR(20)
AS
BEGIN
	UPDATE Product SET Unit = @unit WHERE ID = @ID
END

GO

--EXEC dbo.UpdateProductUnit @ID = '00', @unit = 'nam'


--------------------------------6)UPDATE GOOD
CREATE PROC UpdateProduct
	@ID VARCHAR(30), @Name NVARCHAR(100), @unit NVARCHAR(20)
AS
BEGIN
	UPDATE Product SET Name = @Name, Unit = @unit WHERE ID = @ID
END
GO
--EXEC dbo.UpdateProduct @ID = '001', @Name='trung' , @unit ='trung'


--_________________________________________________________________ NHA CUNG CAP
--_________________________________________________________________

---------------------------- 7)INSERT supplier
CREATE PROC INSERTSupplier
	@ID VARCHAR(30) ,
	@Name NVARCHAR(100),
	@address NVARCHAR(100)=NULL,
	@phoneNumber VARCHAR(11)= NULL,
	@email CHAR(100)= NULL
AS
BEGIN
	INSERT INTO Supplier (ID,Name,Address,Phone,email) VALUES(@ID , @Name , @address , @phoneNumber , @email)
END

GO

--EXEC dbo.INSERTSupplier @ID = '002' , @Name = 'trung', @phoneNumber= '0123'


------------------- 8)DELETE supplier
CREATE PROC DELETESupplier
	@ID VARCHAR(30)
AS
BEGIN
	DELETE Supplier WHERE ID = @ID; 
END
GO
--EXEC dbo.DELETESupplier @ID = '000'


-------------------------------9)UPDATE supplier

CREATE PROC UPDATESupplier
	@idUPDATE VARCHAR(30),
	@nameUPDATE NVARCHAR(100) = NULL,
	@addressUPDATE NVARCHAR(100)=NULL,
	@phoneNumberUPDATE CHAR(11)= NULL,
	@emailUPDATE CHAR(100)= NULL
AS
BEGIN
	declare @ID VARCHAR(30), @Name NVARCHAR(100),@address NVARCHAR(100),@phoneNumber VARCHAR(11), @email CHAR(100)

	SELECT @ID = ID, @Name = Name, @address = Address, @phoneNumber = Phone, @email = Email
	FROM Supplier
	WHERE ID = @idUPDATE

	SELECT @@ROWCOUNT
	IF(@@ROWCOUNT <> 0)
	BEGIN
		IF(@nameUPDATE = '' or @nameUPDATE is null ) 
		BEGIN
			SET @nameUPDATE = @Name
		END

		IF(@addressUPDATE = '' or @addressUPDATE is null ) 
		BEGIN
			SET @addressUPDATE = @address
		END

		IF(@phoneNumberUPDATE = '' or @phoneNumberUPDATE is null ) 
		BEGIN
			SET @phoneNumberUPDATE = @phoneNumber
		END

		IF(@emailUPDATE = '' or @emailUPDATE is null ) 
		BEGIN
			SET @emailUPDATE = @email
		END

		UPDATE Supplier SET Name = @nameUPDATE, Address = @addressUPDATE, Phone = @phoneNumberUPDATE, Email = @emailUPDATE
		WHERE ID = @idUPDATE 
	END
END
GO
--EXEC dbo.UPDATESupplier @idUPDATE = '003', @nameUPDATE = '', @addressUPDATE = '', @phoneNumberUPDATE ='', @emailUPDATE = 'boydatinh'


--__________________________________________________________________KHACH HANG
-----------------------------------10)INSERT khach hang
CREATE PROC ShowCustomer
AS 
BEGIN
	SELECT * FROM Customer
END

GO
--EXEC dbo.ShowCustomer


-----------------------------------11)INSERT khach hang
CREATE PROC AddCustomer
	@ID VARCHAR(30),
	@Name NVARCHAR(100),
	@Address NVARCHAR(100),
	@Phone CHAR(11),
	@Email VARCHAR(100)
AS
BEGIN
	INSERT INTO Customer (ID,Name,Address,Phone,Email) VALUES (@ID,@Name,@Address,@Phone,@Email)
END
GO


---------------------------12)DELETE khach hang
CREATE PROC DeleteCustomer
	@ID VARCHAR(30)
AS
BEGIN
	DELETE Customer WHERE ID = @ID
END

GO


--------------------------------13)UPDATE khach hang
CREATE PROC UpdateCustomer
	@ID VARCHAR(30),
	@Name NVARCHAR(100),
	@Address NVARCHAR(100),
	@Phone CHAR(11),
	@Email VARCHAR(100)
AS
BEGIN
	UPDATE Customer SET Name = @Name, Address = @Address, Phone = @Phone, Email= @Email
	WHERE ID = @ID
END

GO
--__________________________________________________________________
------------------------------------------------------------------report


------------------------------14) hien thi thong tin hang ton kho

--EXEC dbo.GetDataOfInventoryReport


------------------------- 15)phieu nhap xuat giua 2 Date
CREATE PROC GetDataOfInventoryReportBetweENDATE
	@FROMDATE DATETime,
	@toDATE DATETime
AS
BEGIN
	declare 
		@DATE_FROMDATE DATE,
		@DATE_toDATE DATE
	SET @DATE_FROMDATE = CONVERT(DATE,@FROMDATE)
	SET	@DATE_toDATE = CONVERT(DATE,@toDATE)

	IF @DATE_FROMDATE < @DATE_toDATE
	BEGIN
		SELECT sp.ID AS [ID san pham], sp.Name AS [Name san pham],sp.Unit AS [Don vi],
			sum(ttn.QuantityInput) AS [tong nhap], sum (ttx.Quantity) AS [tong xuat]
		FROM Product AS sp 
		join ReceicveVoucherInfo AS ttn ON sp.ID = ttn.IDProduct
		join DeliveryVoucherInfo AS ttx ON ttx.IDProduct = sp.ID
		join ReceiveVoucher pn ON ttn.IDReceiveVoucher = pn.ID
		join DeliveryVoucher px ON px.ID = ttx.IDDeliveryVoucher
		WHERE pn.Date between @DATE_FROMDATE and @DATE_toDATE 
		and
			 px.Date between @DATE_FROMDATE and @DATE_toDATE 
		group by sp.ID,sp.Name,sp.Unit
	END
END
GO

-- '2021-02-02 00:00:00.000'
--EXEC dbo.GetDataOfInventoryReportBetweENDATE @FROMDATE = '20210201' , @toDATE = '20210228'


------------------------------16)insert ReceiveVoucher
CREATE PROC InsertReceiveVoucher
	@ID VARCHAR(30),
	@IDSupplier VARCHAR(30),
	@Date DATETIME
AS
BEGIN
	DECLARE @newDate DATE
	SET @newDate= CAST(@Date AS DATE)
	INSERT INTO ReceiveVoucher (ID,IDSupplier,Date) VALUES(@ID,@IDSupplier,@newDate) 
END
go
--EXEC dbo.InsertPhieuNhap @ID = 'PN011', @IDSupplier = '003', @date = '2021-02-02 00:00:00.000'


------------------------------17)insert thong tin phieu nhap
create proc InsertReceiveVoucherInfo
	@idPhieu varchar(30),
	@IDProduct varchar(30),
	@QuantityInput int,
	@PriceInput int,
	@PriceOutput int
as
begin
	insert into ReceicveVoucherInfo (IDProduct,IDReceiveVoucher,QuantityInput,PriceInput,PriceOutput)
	values(@IDProduct,@idPhieu,@QuantityInput,@PriceInput,@PriceOutput)
end
GO
--exec dbo.InsertThongTinPhieuNhap @idPhieu = 'PN011' ,@IDProduct='001',@QuantityInput = 2,@PriceInput = 10000,@PriceOutput = 20000


------------------------------18)hien thi ReceiveVoucher va ReceicveVoucherInfo va Supplier
CREATE PROC ShowReceiveVoucher
AS
BEGIN
	SELECT 
		sp.ID AS [ID San pham],
		sp.Name AS [Name San pham],
		sp.Unit,
		pn.Date,
		ttn.QuantityInput,
		ttn.PriceInput,
		ttn.QuantityOutput,
		ncc.Name AS [Nha cung cap],
		ncc.Address,
		ncc.Phone,
		ncc.Email,
		ncc.ID AS [ID NCC],
		pn.ID AS [ID phieu nhap]
	FROM ReceiveVoucher pn
	join ReceicveVoucherInfo ttn ON pn.ID = ttn.IDReceiveVoucher
	join Supplier ncc ON ncc.ID = pn.IDSupplier
	join Product sp ON sp.ID = ttn.IDProduct
END
GO
--EXEC dbo.ShowReceiveVoucher


---------------------------19)them phieu nhap: ID, Date, [cac san pham], 1 nha cung cap
CREATE PROC AddInputVoucher
	@IDReceiveVoucher VARCHAR(30),
	@IDSupplier VARCHAR(30),
	@ngayNhap DATE,
	@IDSanPham VARCHAR(30),
	@QuantityInput INT,
	@PriceInput INT,
	@PriceOutput INT
AS
BEGIN
	INSERT INTO ReceiveVoucher(ID, IDSupplier, Date) VALUES(@IDReceiveVoucher,@IDSupplier,@ngayNhap)
	INSERT INTO ReceicveVoucherInfo(IDReceiveVoucher,IDProduct,QuantityInput,PriceInput,PriceOutput) VALUES(@IDReceiveVoucher,@IDSanPham,@QuantityInput,@PriceInput,@PriceOutput)
END
GO


---------------------------20)hien thi phieu xuat
CREATE PROC HienThiPhieuXuat
AS
BEGIN
	SELECT 
		sp.Name AS [TenSanPham], 
		sp.Unit,ttx.Quantity AS [QuantityOutput],
		px.Date AS [NgayXuat], 
		k.Name AS[TenKhachHang], 
		k.Address, k.Phone ,
		ttx.IDDeliveryVoucher 
	FROM DeliveryVoucherInfo ttx
	join DeliveryVoucher px ON px.ID = ttx.IDDeliveryVoucher
	join Customer k ON k.ID = px.IDCustomer
	join Product sp ON sp.ID = ttx.IDProduct
END

--EXEC dbo.HienThiPhieuXuat

---FORM INPUTVOUCHER INFO UPDATE
--_______________________________
-----21) lay thong tin phieu nhap by ID (form inputVoucher)
--IDProduct, Name sp, soNhap, gia nhap, gia xuat, so xuat
alter proc GetInputVoucherInfoById
	@IDReceiveVoucher varchar(30)
as
begin
	select 
		ttn.IDProduct,
		sp.Name as [Name san pham],
		ttn.QuantityInput,
		ttn.PriceInput,
		ttn.QuantityOutput, 
		ttn.PriceOutput
	from ReceicveVoucherInfo ttn
		join Product sp on sp.ID = ttn.IDProduct
	where IDReceiveVoucher = @IDReceiveVoucher
end

exec dbo.GetInputVoucherInfoById @IDReceiveVoucher='003'

--22)get IDSupplier by IDReceiveVoucher
create proc GetIdSupplierByIdInputVoucher
	@idVoucher varchar(30)
as
begin
	select IDSupplier from ReceiveVoucher where ID = @idVoucher
end

exec dbo.GetIdSupplierByIdInputVoucher @idvoucher = '003'

--23) lấy thông tin sản phẩm không có trong phiếu nhập
create proc GoodNotInInputVoucher
	@idVoucher varchar(30)
as
begin
	select * from Product sp
	where sp.ID not in(
		select ttn.IDProduct
		from ReceicveVoucherInfo ttn
		where ttn.IDReceiveVoucher = @idVoucher
	)
end

exec dbo.GoodNotInInputVoucher @idVoucher = '003'
