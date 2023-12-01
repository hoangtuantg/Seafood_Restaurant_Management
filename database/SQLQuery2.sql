CREATE DATABASE QuanLyQuanHaiSan
GO

USE QuanLyQuanHaiSan
GO

-- Food
-- Table
-- FoodCategory
-- Account
-- Bill
-- BillInfo

CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người
)
GO

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Kter',
	PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
	Type INT NOT NULL  DEFAULT 0 -- 1: admin && 0: staff
)
GO

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán
	
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO


--Nhập dữ liệu bảng TableFood--
insert into TableFood values('Bàn 1','Trống')
insert into TableFood values('Bàn 2','Trống')
insert into TableFood values('Bàn 3','Trống')
insert into TableFood values('Bàn 4','Trống')
insert into TableFood values('Bàn 5','Trống')
insert into TableFood values('Bàn 6','Trống')
insert into TableFood values('Bàn 7','Trống')
insert into TableFood values('Bàn 8','Trống')
insert into TableFood values('Bàn 9','Trống')
insert into TableFood values('Bàn 10','Trống')
insert into TableFood values('Bàn 11','Trống')
insert into TableFood values('Bàn 12','Trống')
insert into TableFood values('Bàn 13','Trống')
insert into TableFood values('Bàn 14','Trống')
insert into TableFood values('Bàn 15','Trống')





CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO



select*from dbo.TableFood
