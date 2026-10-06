USE QuanLyXuatHang;
GO

-- Thêm khách hàng mẫu
INSERT INTO KhachHang (TenKhachHang) 
VALUES (N'Nguyen Van A');

-- Lấy MaKH của 'Nguyen Van A' vừa thêm (thường là 1)
DECLARE @MaKHA INT = (SELECT TOP 1 MaKH FROM KhachHang WHERE TenKhachHang = N'Nguyen Van A');

-- Thêm danh sách đơn xuất hàng theo hình ảnh
INSERT INTO DonXuatHang (MaDon, NgayXuat, MaKH, TongTien, TrangThai) VALUES
('HD009', '2023-10-25', @MaKHA, 1200000, N'Chờ xử lý'),
('HD010', '2023-10-25', @MaKHA, 1200000, N'Chờ xử lý'),
('HD011', '2023-10-23', @MaKHA, 1200000, N'Chờ xử lý'),
('HD012', '2023-10-22', @MaKHA, 1200000, N'Đang giao'),
('HD013', '2023-10-21', @MaKHA, 1200000, N'Đang giao'),
('HD014', '2023-10-27', @MaKHA, 800000,  N'Đang giao'),
('HD015', '2023-10-06', @MaKHA, 700000,  N'Đang giao'),
('HD016', '2023-10-25', @MaKHA, 1200000, N'Đang giao'),
('HD017', '2023-10-22', @MaKHA, 1200000, N'Hoàn thành'),
('HD018', '2023-10-21', @MaKHA, 1200000, N'Hoàn thành'),
('HD019', '2023-10-27', @MaKHA, 800000,  N'Hoàn thành'),
('HD020', '2023-10-06', @MaKHA, 700000,  N'Hoàn thành'),
('HD021', '2023-10-25', @MaKHA, 1200000, N'Hoàn thành');
GO