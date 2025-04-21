using DataAcess.Class;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System.Drawing;

namespace BE032025
{
    internal class Program
    {
        static void Main(string[] args)
        {

             List<NhanVien> danhSachNV = new List<NhanVien>();

            int choice;
            do
            {
                Console.WriteLine("\n===== QLNV =====");
                Console.WriteLine("1. ADD NV");
                Console.WriteLine("2.Tao san luong cong doan");
                Console.WriteLine("3.Xuat Bao cao");
                Console.WriteLine("4.Xuat Bao cao Excel");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon Chuc nang: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        NhanVien nv = new NhanVien();
                        nv.NhapThongTin();
                        danhSachNV.Add(nv);
                        break;
                    case 2:
                        TaoSanLuong();
                        break;
                    case 3:
                        foreach (var n in danhSachNV)
                        {
                            n.HienThiBaoCao();
                        }
                        break;
                    case 4:
                        XuatExcel(danhSachNV);
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Lua chon ko hop le.");
                        break;
                }
            } while (choice != 0);

             void TaoSanLuong()
            {
                Console.Write("Nhap Id nhan vien  ");
                string id = Console.ReadLine();
                var nv = danhSachNV.FirstOrDefault(n => n.Id == id);
                if (nv != null)
                {
                    nv.ThemCongDoan();
                }
                else
                {
                    Console.WriteLine("Id not found");
                }
            }
        }



        static void XuatExcel(List<NhanVien> danhSachNV)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var sortedList = danhSachNV.OrderBy(n => n.Ten).ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("BaoCaoChiTiet");


                string[] headers = { "Name", "Process", "Process_Name", "Qty", "Price", "Total" };
                for (int i = 0; i < headers.Length; i++)
                {
                    ws.Cells[1, i + 1].Value = headers[i];
                    ws.Cells[1, i + 1].Style.Font.Bold = true;
                    ws.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.Gold);
                }

                int row = 2;
                int tongTatCa = 0;
                int tongQty = 0;

                foreach (var nv in sortedList)
                {
                    int tongNhanVien = 0;
                    int tongQtyNV = 0;

                    foreach (var cd in nv.CongDoans)
                    {
                        ws.Cells[row, 1].Value = nv.Ten;
                        ws.Cells[row, 2].Value = cd.MaCongDoan;
                        ws.Cells[row, 3].Value = cd.TenCongDoan;
                        ws.Cells[row, 4].Value = cd.SoLuongSanPham;
                        ws.Cells[row, 5].Value = cd.DonGia;
                        ws.Cells[row, 6].Value = cd.ThanhTien;

                        tongNhanVien += cd.ThanhTien;
                        tongQtyNV += cd.SoLuongSanPham;

                        row++;
                    }


                    ws.Cells[row, 1].Value = nv.Ten;
                    ws.Cells[row, 2].Value = "Tong";
                    ws.Cells[row, 4].Value = tongQtyNV;
                    ws.Cells[row, 6].Value = tongNhanVien;

                    using (var range = ws.Cells[row, 1, row, 6])
                    {
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(Color.Gold);
                    }

                    tongTatCa += tongNhanVien;
                    tongQty += tongQtyNV;
                    row++;
                }


                ws.InsertRow(2, 1);
                ws.Cells[2, 2].Value = "Tong";
                ws.Cells[2, 4].Value = tongQty;
                ws.Cells[2, 6].Value = tongTatCa;

                using (var range = ws.Cells[2, 1, 2, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Gold);
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                package.SaveAs(new FileInfo("BaoCaoChiTiet.xlsx"));
                Console.WriteLine(" Xuat thanh cong BaoCaoChiTiet.xlsx ");
            }
        }

    }
}
