using DataAcess.Enum;
using DataAcess.Struct;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace DataAcess
{
    public class Buoi4
    {
        List<Employee> empl = new List<Employee>();
        public void Employeer_Insert(Employee employee)
        {
            //var ketqua = 0;
            try
            {
                //Bước 1 : Kiểm tra dữ liệu đầu vào 

                if (!Common.ValidateDataInput.CheckValidateString(employee.MaNV)
                    || !Common.ValidateDataInput.CheckXSSInput(employee.MaNV))
                {
                    //ketqua = (int)EmployeStatus.MA_NHAN_VIEN_KHONG_HOP_LE;
                    Console.WriteLine("Ma nv khong hop le");
                    return;
                }

                if (!Common.ValidateDataInput.CheckValidateString(employee.TenNV)
                     || !Common.ValidateDataInput.CheckXSSInput(employee.TenNV))
                {
                    //ketqua = (int)EmployeStatus.TEN_KHONG_HOP_LE;
                    Console.WriteLine("Ten nv khong hop le");
                    return;
                }

                if (!Common.ValidateDataInput.CheckValidateString(employee.viTri)
                     || !Common.ValidateDataInput.CheckXSSInput(employee.viTri))
                {
                    //ketqua = (int)EmployeStatus.VI_TRI_KHONG_HOP_LE;
                    Console.WriteLine("Vi tri khong hop le");
                    return;
                }
                if (!Common.ValidateDataInput.ValidateDateTime(employee.ngayvao)
                     || !Common.ValidateDataInput.CheckXSSInput(employee.ngayvao))
                {
                    //ketqua = (int)EmployeStatus.NGAY_VAO_KHONG_HOP_LE;
                    Console.WriteLine("Ngay vao ko hop le");
                    return;
                }

                // Bước 2: Check trùng trong List chưa

                //C2 : 
                var isdup = empl.FindAll(s => s.MaNV == employee.MaNV).FirstOrDefault();

                if (isdup.MaNV != null)
                {
                    //ketqua = (int)EmployeStatus.DA_TON_TAI;
                    Console.WriteLine("Nhan vien da ton tai");
                    return;
                }


                //  Bước 3 : Thêm vào danh sách và nhận kết quả
                var new_emp = new Employee()
                {
                    MaNV = employee.MaNV,
                    TenNV = employee.TenNV,
                    viTri = employee.viTri,
                    ngayvao = employee.ngayvao
                };



                empl.Add(new_emp);
                //ketqua = (int)EmployeStatus.THANH_CONG;
                Console.WriteLine("Add thanh cong");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ngoại lệ:" + ex.Message);
            }
        }


        public string Employeer_Insert_FromExcelFile(string filePath)
        {
            var ketqua = string.Empty;
            var errName = new StringBuilder();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {

                        var code = worksheet.Cells[row, 1].Text;
                        var name = worksheet.Cells[row, 2].Text;
                        var startDate = worksheet.Cells[row, 3].Text;
                        var viTri = worksheet.Cells[row, 4].Text;

                        if (!Common.ValidateDataInput.CheckValidateString(code)
                          || !Common.ValidateDataInput.CheckXSSInput(code)
                         )
                        {
                            errName.Append("Hang : " + row + "| Cot 1 du lieu khong hop le");
                            continue;
                        }
                        if (!Common.ValidateDataInput.CheckValidateString(name)
                         || !Common.ValidateDataInput.CheckXSSInput(name)
                          )
                        {
                            errName.Append("Hang : " + row + "| Cot 2 du lieu khong hop le");
                            continue;
                        }
                        if (!Common.ValidateDataInput.CheckValidateString(viTri)
                       || !Common.ValidateDataInput.CheckXSSInput(viTri))
                        {
                            errName.Append("Hang : " + row + "| Cot 3 du lieu khong hop le");
                            continue;
                        }
                        if (!Common.ValidateDataInput.ValidateDateTime(startDate)
                             || !Common.ValidateDataInput.CheckXSSInput(startDate))
                        {
                            errName.Append("Hang : " + row + "| Cot 4 du lieu khong hop le");
                            continue;
                        }
                        var new_emp = new Employee()
                        {
                            MaNV = code,
                            TenNV = name,
                            viTri = viTri,
                            ngayvao = startDate
                        };
                        empl.Add(new_emp);

                        Console.WriteLine("Insert "+row+" Thanh cong");
                    }

                }

                if (errName != null)
                {
                    return errName.ToString();
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ketqua;
        }


        public void DisplayAllEmployees()
        {
            try
            {
            if (empl.Count == 0)
            {
                Console.WriteLine("Danh sach nhan vien trong !.");
                return;
            }

            Console.WriteLine("Danh Sach Nhan Vien :");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Ma NV\t Ten NV\t\t Ngay vao \t Vi Tri ");

            foreach (var emp in empl)
            {
                Console.WriteLine($"{emp.MaNV}\t{emp.TenNV}\t    {emp.ngayvao}\t      {emp.viTri}");
            }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void FindEmployeesBySeniority()
        {
            try
            {
                Console.WriteLine("Danh sach nhan vien co tham nien 5 nam hoac 10 nam");
                Console.WriteLine("--------------------------------------------------------");

                DateTime today = DateTime.Now;
                bool found = false;

                foreach (var emp in empl)
                {
                    if (DateTime.TryParse(emp.ngayvao, out DateTime ngayVao))
                    {
                        int yearsWorked = today.Year - ngayVao.Year;
                        if (today < ngayVao.AddYears(yearsWorked)) // Kiểm tra nếu chưa đến ngày kỷ niệm
                        {
                            yearsWorked--;//giam xuong 1 de ko chay vao if kia
                        }

                        if (yearsWorked == 5 || yearsWorked == 10)
                        {
                            Console.WriteLine($"{emp.MaNV}\t{emp.TenNV}\t{emp.ngayvao}\t{emp.viTri}");
                            found = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Loi ngay vao khong hop le {emp.MaNV}");
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Khong co nhan vien 5 nam hoac 10 nam ");
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

     public   static void NhapNhanVienTuBanPhim(Buoi4 employeeManager)
        {
            Console.Write("Nhap so luong nhan vien: ");
            bool isValidNumber = int.TryParse(Console.ReadLine(), out int soLuongNV);

            if (!isValidNumber || soLuongNV <= 0)
            {
                Console.WriteLine("So luong nhan vien khong hop le!");
                return;
            }

            for (int i = 0; i < soLuongNV; i++)
            {
                Console.WriteLine($"\nNhap thong tin nhan vien {i + 1}:");
                Console.Write("Ma nhan vien: ");
                string maNV = Console.ReadLine();

                Console.Write("Ten nhan vien: ");
                string tenNV = Console.ReadLine();

                Console.Write("Ngay vao lam (dd-MM-yyyy): ");
                string ngayVao = Console.ReadLine();

                Console.Write("Vi tri cong viec: ");
                string viTri = Console.ReadLine();

                Employee emp = new Employee
                {
                    MaNV = maNV,
                    TenNV = tenNV,
                    ngayvao = ngayVao,
                    viTri = viTri
                };

                employeeManager.Employeer_Insert(emp);
            }
        }


    }



}
