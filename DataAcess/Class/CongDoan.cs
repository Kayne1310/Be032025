using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Class
{
    public class CongDoan
    {
        public string MaCongDoan { get; set; }
        public string TenCongDoan { get; set; }
        public int SoLuongSanPham { get; set; }
        public int DonGia { get; set; } // thêm đơn giá
        public int ThanhTien => SoLuongSanPham * DonGia;

        public CongDoan(string ma, string ten, int sl, int gia)
        {
            MaCongDoan = ma;
            TenCongDoan = ten;
            SoLuongSanPham = sl;
            DonGia = gia;
        }
        public void HienThi()
        {
            Console.WriteLine($"  + Ma: {MaCongDoan}, Ten : {TenCongDoan}, SL: {SoLuongSanPham}");
        }
    }
}
