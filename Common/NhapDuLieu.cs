using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class NhapDuLieu
    {
        public static StrucPhanSo NhapPhanSo()
        {
            int tuSo, mauSo;
            while (true)
            {
                try
                {
                    Console.Write("Nhap tu so: ");
                    tuSo = int.Parse(Console.ReadLine());
                
                    Console.Write("Nhap Mau So ");
                    mauSo = int.Parse(Console.ReadLine());

                    if (mauSo == 0)
                    {
                        throw new ArgumentException("Mau So Khong the =0");
                    }

                    return new StrucPhanSo(tuSo, mauSo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}. Vui Long nha lai ");
                }
            }
        }

    }
}
