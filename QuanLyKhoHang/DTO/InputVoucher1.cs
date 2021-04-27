using QuanLyKhoHang.DAT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class InputVoucher1
    {
        private string iDPhieuNhap;
        private DateTime ngayNhap;
        private string iDSanPham;
        private string tenSanPham;
        private string donVi;
        private int soLuongNhap;
        private int giaNhap;
        private int soLuongXuat;
        private string tenNCC;
        private string diaChi;
        private string sdt;
        private string email;
        private string iDNCC;

        public string IDPhieuNhap { get => iDPhieuNhap; set => iDPhieuNhap = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }
        public string IDSanPham { get => iDSanPham; set => iDSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public int SoLuongNhap { get => soLuongNhap; set => soLuongNhap = value; }
        public int GiaNhap { get => giaNhap; set => giaNhap = value; }
        public int SoLuongXuat { get => soLuongXuat; set => soLuongXuat = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string IDNCC { get => iDNCC; set => iDNCC = value; }

        public InputVoucher1(string iDSanPham, string tenSanPham, string donVi, DateTime ngayNhap, int soLuongNhap, int giaNhap, int tonKho, string tenNCC, string diaChi, string sdt, string email, string iDNCC, string iDPhieuNhap)
        {
            this.iDSanPham = iDSanPham;
            this.tenSanPham = tenSanPham;
            this.donVi = donVi;
            this.ngayNhap = ngayNhap;
            this.soLuongNhap = soLuongNhap;
            this.giaNhap = giaNhap;
            this.soLuongXuat = tonKho;
            this.tenNCC = tenNCC;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.email = email;
            this.iDNCC = iDNCC;
            this.iDPhieuNhap = iDPhieuNhap;
        }

        public InputVoucher1(DataRow row)
        {
            this.iDSanPham = row["ID San pham"].ToString();
            this.tenSanPham = row["Ten San pham"].ToString();
            this.donVi = row["DonVi"].ToString();
            this.ngayNhap = (DateTime)row["Ngay"];
            this.soLuongNhap = (int)row["Soluongnhap"];
            this.giaNhap = (int)row["GiaNhap"];
            this.soLuongXuat = (int)row["SoLuongXuat"];
            this.tenNCC = row["Nha cung cap"].ToString();
            this.diaChi = row["DC"].ToString();
            this.sdt = row["SDT"].ToString();
            this.email = row["Email"].ToString();
            this.iDNCC = row["ID NCC"].ToString();
            this.iDPhieuNhap = row["ID phieu nhap"].ToString();
        }

        
    }
}
