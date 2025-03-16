namespace DataAcess
{
    public class Bai4
    {
        private  List<SinhVien> danhSachSinhVien = new List<SinhVien>();
      public    void NhapSinhVien()
        {
            try
            {
                Console.Write("Nhap so luong sv ");
                int soLuong;
                int Id;
                float Grade;
                while (!int.TryParse(Console.ReadLine(), out soLuong) || soLuong <= 0)
                {
                    Console.WriteLine("Loi so luong ko hop le");
                }

                for (int i = 0; i < soLuong; i++)
                {
                    Console.WriteLine($"\n Nhap sv thu  {i + 1}:");
                    SinhVien sv = new SinhVien();

                    Console.Write("ID: ");
                    while (!int.TryParse(Console.ReadLine(), out Id))
                    {
                        Console.WriteLine("Loi vui long nhap lai id");
                    }
                    sv.Id = Id;

                    Console.Write("Ten: ");
                    sv.Name = Console.ReadLine();

                    Console.Write("Tuoi: ");
                    sv.Age = Console.ReadLine();

                    Console.Write("ĐDiem ");
                    while (!float.TryParse(Console.ReadLine(), out Grade) || sv.Grade < 0 || sv.Grade > 10)
                    {
                        Console.WriteLine("Diem ko hop le vui long nhap 1->10");
                    }
                    sv.Grade = Grade;

                    danhSachSinhVien.Add(sv);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }

     public    void HienThiSinhVien()
        {
            if (danhSachSinhVien.Count == 0)
            {
                Console.WriteLine("No Data");
                return;
            }

            Console.WriteLine("\n===== Danh sach sv =====");
            foreach (var sv in danhSachSinhVien)
            {
                Console.WriteLine($"ID: {sv.Id} - {sv.Name} - Tuoi: {sv.Age} - Diem: {sv.Grade:F2} - Xep loai: {sv.XepLoai}");
            }
        }



    }

    public class SinhVien
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public float Grade { get; set; }
  

        public XepLoaiHocLuc XepLoai
        {
            get
            {
                if (Grade >= 9) return XepLoaiHocLuc.XuatSac;
                if (Grade >= 8) return XepLoaiHocLuc.Gioi;
                if (Grade >= 6.5) return XepLoaiHocLuc.Kha;
                if (Grade >= 5) return XepLoaiHocLuc.TrungBinh;
                return XepLoaiHocLuc.Yeu;
            }
        }

    }

        public enum XepLoaiHocLuc
        {
            XuatSac,
            Gioi,
            Kha,
            TrungBinh,
            Yeu
        }


}
