using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhoHang.DTO
{
    public class OutputReport1
    {
        private string tenSanPham;
        private string donVi;
        private int soLuongXuat;
        private DateTime ngayXuat;
        private string tenKhachHang;
        private string diaChi;
        private string sdt;
        private string iDPhieuXuat;

        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public int SoLuongXuat { get => soLuongXuat; set => soLuongXuat = value; }
        public DateTime NgayXuat { get => ngayXuat; set => ngayXuat = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string IDPhieuXuat { get => iDPhieuXuat; set => iDPhieuXuat = value; }

        public OutputReport1(string tenSanPham, string donVi, int soLuongXuat, DateTime ngayXuat, string tenKhachHang, string diaChi, string sdt, string iDPhieuXuat)
        {
            this.tenSanPham = tenSanPham;
            this.donVi = donVi;
            this.soLuongXuat = soLuongXuat;
            this.ngayXuat = ngayXuat;
            this.tenKhachHang = tenKhachHang;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.iDPhieuXuat = iDPhieuXuat;
        }

        public OutputReport1(DataRow row)
        {
            this.tenSanPham = row["TenSanPham"].ToString();
            this.donVi = row["DonVi"].ToString();
            this.soLuongXuat = (int)row["SoLuongXuat"];
            this.ngayXuat = (DateTime)row["NgayXuat"];
            this.tenKhachHang = row["TenKhachHang"].ToString();
            this.diaChi = row["DC"].ToString();
            this.sdt = row["SDT"].ToString();
            this.iDPhieuXuat = row["IDPhieuXuat"].ToString();
        }

    }
}
