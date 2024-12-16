-- Create database QuanLyQuanNuoc
CREATE DATABASE QuanLyQuanNuoc;

USE QuanLyQuanNuoc;

-- Create table NhanVien
CREATE TABLE NhanVien (
    MaNhanVien INT IDENTITY(1, 1), 
    TenNhanVien NVARCHAR(100) NOT NULL, 
    UserName VARCHAR(20) NOT NULL UNIQUE, -- Đảm bảo không trùng username
    Passcode VARCHAR(16) NOT NULL,
    ChucVu NVARCHAR(100) NOT NULL,
    trangThaiHoatDong BIT NOT NULL,

    CONSTRAINT pk_MaNhanVien_NV PRIMARY KEY (MaNhanVien)
);

-- Create table LoaiMon
CREATE TABLE LoaiMon (
    MaLoaiMon VARCHAR(4), 
    TenLoaiMon NVARCHAR(10) NOT NULL UNIQUE,

    CONSTRAINT pk_MaLoaiMon_LM PRIMARY KEY (MaLoaiMon)
);

-- Create table DonHang
CREATE TABLE DonHang (
    MaDonHang INT IDENTITY(1, 1),
    MaNhanVien INT,
    NgayDatHang DATETIME, 
    TongTien FLOAT,

    CONSTRAINT pk_MaDonHang_DH PRIMARY KEY (MaDonHang),
    CONSTRAINT fk_MaNhanVien_DH FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Create table DanhSachMon
CREATE TABLE DanhSachMon (
    MaMon VARCHAR(4), 
    MaLoaiMon VARCHAR(4), 
    TenMon NVARCHAR(100), 
    Gia FLOAT DEFAULT 10000.0, 
    SoLuong INT DEFAULT 0,

    CONSTRAINT pk_MaMon_DSM PRIMARY KEY (MaMon),
    CONSTRAINT fk_MaLoaiMon_DSM FOREIGN KEY (MaLoaiMon) REFERENCES LoaiMon(MaLoaiMon)
);

-- Create table ChiTietDonHang
CREATE TABLE ChiTietDonHang (
    MaChiTietDonHang INT IDENTITY(1, 1), 
    MaMon VARCHAR(4), 
    MaDonHang INT, 
    SoLuongMon INT, 
    TongPhu FLOAT,

    CONSTRAINT pk_MaChiTietDonHang_CTDH PRIMARY KEY (MaChiTietDonHang),
    CONSTRAINT fk_MaMon_CTDH FOREIGN KEY (MaMon) REFERENCES DanhSachMon(MaMon),
    CONSTRAINT fk_MaDonHang_CTDH FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
);

-- Create table Ban
CREATE TABLE Ban (
    MaBan INT IDENTITY(1, 1),
    TenBan NVARCHAR(10),
    TrangThai BIT DEFAULT 0,

    CONSTRAINT pk_MaBan_B PRIMARY KEY (MaBan)
);

-- Select data from tables for validation
SELECT * FROM NhanVien;
SELECT * FROM DanhSachMon;
SELECT * FROM ChiTietDonHang;
SELECT * FROM DonHang;
SELECT * FROM LoaiMon;






-- Validate data after insertion
SELECT * FROM dbo.ChiTietDonHang;
SELECT * FROM dbo.Ban;


-- Them thong bao
CREATE TABLE ThongBao (
    TieuDe NVARCHAR(255), -- Định nghĩa chiều dài cụ thể
    MoTa NVARCHAR(MAX),   -- Để lưu mô tả dài
    Ngay DATE DEFAULT GETDATE(), -- Giá trị mặc định là ngày hiện tại
    CONSTRAINT pk_TieuDe_ThongBao PRIMARY KEY (TieuDe)
);

select *
from Ban
SELECT name, definition
FROM sys.default_constraints
WHERE parent_object_id = OBJECT_ID('Ban') AND parent_column_id = COLUMNPROPERTY(OBJECT_ID('Ban'), 'TrangThai', 'ColumnId');

ALTER TABLE Ban DROP CONSTRAINT DF__Ban__TrangThai__5AEE82B9;

ALTER TABLE Ban DROP COLUMN TrangThai;

alter table Ban add TrangThai Nvarchar(20) default(N'Còn Trống')

delete from Ban where MaBan between 1 and 10



-- 
alter table ChiTietDonHang drop constraint fk_MaDonHang_CTDH

alter table [dbo].[ChiTietDonHang] drop column MaDonHang

alter table DonHang drop constraint pk_MaDonHang_DH

alter table DonHang drop column MaDonHang
delete from DonHang
alter table DonHang add MaDonHang UNIQUEIDENTIFIER not null



alter table DonHang add constraint pk_MaDonHang_DH primary key(MaDonHang)

delete from ChiTietDonHang

alter table ChiTietDonHang add MaDonHang UNIQUEIDENTIFIER

alter table ChiTietDonHang add constraint fk_MaChiTietDonHang_CTDH foreign key (MaDonHang) references DonHang(MaDonHang)




delete from ChiTietDonHang

delete from DanhSachMon

alter table DanhSachMon add  TrangThai bit default(1) not null



delete from ChiTietDonHang
delete from DanhSachMon
delete from Ban
delete from DonHang
delete from LoaiMon
delete from NhanVien
delete from ThongBao
ALTER TABLE DanhSachMon DROP COLUMN SoLuong;

ALTER TABLE DanhSachMon DROP CONSTRAINT DF__DanhSachM__SoLuo__534D60F1;


INSERT INTO NhanVien (TenNhanVien, UserName, Passcode, ChucVu, trangThaiHoatDong) VALUES
(N'Nguyễn Văn Dũ', 'nvd', 'pass1234', N'Quản lý', 1),
(N'Đặng Lê Hoàng Danh', 'dlhd', 'pass1236', N'Nhân viên', 1),
(N'Vũ Huy Minh', 'vhminh', 'pass1237', N'Nhân viên', 1),
(N'Trương Trường Giang', 'ttgiang', 'pass123', N'Quản lý', 1);

INSERT INTO LoaiMon (MaLoaiMon, TenLoaiMon) VALUES
('TS00', N'Trà Sữa'),
('CF00', N'Cà Phê'),
('NE00', N'Nước Ép'),
('ST00', N'Sinh Tố'),
('TR00', N'Trà');



INSERT INTO DanhSachMon (MaMon, MaLoaiMon, TenMon, Gia, _Image)
VALUES ('MN01', 'CF00', N'Cafe Sữa', 35000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\cafeSua.png', SINGLE_BLOB) AS img)),
		('MN02', 'ST00', N'Sinh Tố Dứa', 49000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\sinhToDua.png', SINGLE_BLOB) AS img)),
		('MN03', 'TS00', N'Trà Sữa Trân Châu', 59000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\traSua.png', SINGLE_BLOB) AS img)),
		
		('MN04', 'TR00', N'Trà Gừng', 35000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\traGung.png', SINGLE_BLOB) AS img)),
		('MN05', 'TR00', N'Trà Trái Cây', 55000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\traTraiCay.png', SINGLE_BLOB) AS img)),
		('MN06', 'TS00', N'Trà Sữa Matcha Latte', 65000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\matchaLatte.png', SINGLE_BLOB) AS img)),
		('MN07', 'CF00', N'Cafe Đen', 35000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\cafeDen.png', SINGLE_BLOB) AS img));
		
	--('MN08', 'ST00', N'Sinh Tố Việt Quất', 59000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\cafeDen.png', SINGLE_BLOB) AS img)),


delete from DanhSachMon
delete from LoaiMon

INSERT INTO LoaiMon (MaLoaiMon, TenLoaiMon) VALUES
('TS00', N'Trà Sữa'),
('CF00', N'Cà Phê'),
('NE00', N'Nước Ép'),
('ST00', N'Sinh Tố'),
('TR00', N'Trà');



INSERT INTO DanhSachMon (MaMon, MaLoaiMon, TenMon, Gia, _Image)
VALUES ('MN01', 'CF00', N'Cafe Sữa', 35000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\cafeSua.png', SINGLE_BLOB) AS img)),
		('MN02', 'ST00', N'Sinh Tố Dứa', 49000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\sinhToDua.png', SINGLE_BLOB) AS img)),
		('MN03', 'TS00', N'Trà Sữa Trân Châu', 59000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\traSua.png', SINGLE_BLOB) AS img)),
		
		('MN04', 'TR00', N'Trà Gừng', 35000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\traGung.png', SINGLE_BLOB) AS img)),
		('MN05', 'TR00', N'Trà Trái Cây', 55000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\traTraiCay.png', SINGLE_BLOB) AS img)),
		('MN06', 'TS00', N'Trà Sữa Matcha Latte', 65000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\matchaLatte.png', SINGLE_BLOB) AS img)),
		('MN07', 'CF00', N'Cafe Đen', 35000.0, (SELECT * FROM OPENROWSET(BULK 'C:\Users\Yan\source\repos\LTWINDOW_\image\cafeDen.png', SINGLE_BLOB) AS img));
		
alter table LoaiMon add TrangThai bit default (1) not null


DELETE FROM ThongBao;
truncate table ThongBao



CREATE TABLE ThongBao (
	ID INT PRIMARY KEY,
    TieuDe NVARCHAR(255), -- Định nghĩa chiều dài cụ thể
    MoTa NVARCHAR(MAX),   -- Để lưu mô tả dài
    Ngay DATE DEFAULT GETDATE() -- Giá trị mặc định là ngày hiện tại
 
);



	
INSERT INTO ThongBao (ID,TieuDe,MoTa,Ngay) VALUES
(1,N'Mua 1 tặng 1',N'Nhân ngày khai chương','2023-11-01'),
(2,N'Free 500 Đơn Đầu',N'Nhân ngày đặc biệt','2024-09-02'),
(3,N'Thầy Cô giảm 25%',N'Nhân ngày nhà giáo ','2024-11-20'),
(4,N'Giảm 20%' , N'Giảm 20% đơn trên 200k trong 2 ngày','2024-12-26')


select *
from dbo.ThongBao


