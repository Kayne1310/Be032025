using DataAcess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using OfficeOpenXml.Style;
using System.Drawing;
namespace DataAcess.Class

{
    public class NhanVien : INhanVien
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public double LuongCoBan { get; set; }
        public double HeSoLuong { get; set; }
        public double PhuCap { get; set; }
        public List<CongDoan> CongDoans { get; set; } = new List<CongDoan>();
        public void HienThiBaoCao()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"ID: {Id} | Ten: {Ten} | Gioi Tinh: {GioiTinh} | Tuoi: {Tuoi}");
            Console.WriteLine($"Luong co ban: {LuongCoBan} | He so: {HeSoLuong} | Phu Cap: {PhuCap}");
            Console.WriteLine($"==> Tong Luon: {TinhTongLuong()}");
            Console.WriteLine("Cong Doan san xuat:");
            foreach (var cd in CongDoans)
            {
                cd.HienThi();
            }
            Console.WriteLine("==================================================");
        }

        public void NhapThongTin()
        {
            Console.Write("Nhap ID: ");
            Id = Console.ReadLine();
            Console.Write("Nhap ten: ");
            Ten = Console.ReadLine();
            Console.Write("Nhap gioi tinh: ");
            GioiTinh = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.Write("nhap luon co ban : ");
            LuongCoBan = double.Parse(Console.ReadLine());
            Console.Write("Nhap he so luong: ");
            HeSoLuong = double.Parse(Console.ReadLine());
            Console.Write("Nhap phu cap: ");
            PhuCap = double.Parse(Console.ReadLine());
        }

        public void ThemCongDoan()
        {
            Console.Write("Nhập số lượng công đoạn: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Công đoạn {i + 1}:");
                Console.Write("  Nhập mã: ");
                string ma = Console.ReadLine();
                Console.Write("  Nhập tên: ");
                string ten = Console.ReadLine();
                Console.Write("  Nhập số lượng sản phẩm: ");
                int sl = int.Parse(Console.ReadLine());
                Console.Write("  Nhập đơn giá: ");
                int gia = int.Parse(Console.ReadLine());

                CongDoans.Add(new CongDoan(ma, ten, sl, gia));
            }
        }

        public double TinhTongLuong()
        {
            return LuongCoBan * HeSoLuong + PhuCap;
        }

    }
}
