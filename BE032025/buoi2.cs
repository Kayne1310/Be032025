﻿using Common;
using DataAcess;
using System;

namespace BE032025
{
    public class Buoi2
    {
        //   //ham validate
        //   public static int NhapSoNguyen(string message)
        //   {
        //       int n;
        //       while (true)
        //       {
        //           Console.Write(message);
        //           if (int.TryParse(Console.ReadLine(), out n))
        //               return n;
        //           Console.WriteLine("value not valid");
        //       }
        //   }


        //   // Bai 4


        //   public static void TinhGiaiThua()
        //   {
        //       int n = NhapSoNguyen("Nhap n de tinh dai thua");

        //       long giaiThua = 1;
        //       for (int i = 1; i <= n; i++)
        //       {
        //           giaiThua *= i;
        //       }
        //       Console.WriteLine($"Gia thua cua {n} la: {giaiThua}");
        //   }
        //   //bai 5
        //   public static bool IsPrime(int num)
        //   {
        //       if (num < 2) return false;
        //       for (int i = 2; i * i <= num; i++)
        //       {
        //           if (num % i == 0) return false;
        //       }
        //       return true;
        //   }

        //   public static void LietKeSoNguyenTo()
        //   {

        //       int n = NhapSoNguyen("Nhap n de liet ke cac so nt < n ");

        //       Console.WriteLine($"Cac so nt nho hon n la {n}:");
        //       for (int i = 2; i < n; i++)
        //       {
        //           if (IsPrime(i))
        //               Console.Write(i + " ");
        //       }
        //       Console.WriteLine();
        //   }

        ////Bai 6
        //   public static void KiemTraChanLe()
        //   {
        //       int n = NhapSoNguyen("Nhap n de kt chan le ");

        //       if (n % 2 == 0)
        //           Console.WriteLine($"{n} la so chan.");
        //       else
        //           Console.WriteLine($"{n} la so le.");
        //   }

        //   //Bai 7
        //   public static void KiemTraSoNguyenTo()
        //   {

        //       int n = NhapSoNguyen("check so nt: ");

        //       if (IsPrime(n))
        //           Console.WriteLine($"{n} la so nt.");
        //       else
        //           Console.WriteLine($"{n} khong la so nt");
        //   }



        static void Main(string[] args)
        {
            //TinhGiaiThua();
            //LietKeSoNguyenTo();
            //KiemTraChanLe();
            //KiemTraSoNguyenTo();

            //bai b3 

            /*

             Console.WriteLine("Moi ban nhap phan so");
              var res=  NhapDuLieu.NhapPhanSo();

             Console.WriteLine(res.ToString());

             //Cong
             Console.WriteLine("Moi ban nhap pso 1");
             var ps1 = NhapDuLieu.NhapPhanSo();

             Console.WriteLine("Moi ban nhap ps2");
             var ps2 = NhapDuLieu.NhapPhanSo();

             var cong=StrucPhanSo.Cong(ps1,ps2);
             var tru=StrucPhanSo.Tru(ps1,ps2);
             var nhan=StrucPhanSo.Nhan(ps1,ps2);
             var chia=StrucPhanSo.Chia(ps1,ps2);
             Console.WriteLine("Cong phan so la {0}" ,cong.ToString());
             Console.WriteLine("Tru phan so la {0}" ,tru.ToString());
             Console.WriteLine("Nhan phan so la {0}" ,nhan.ToString());
             Console.WriteLine("Chia phan so la {0}" ,chia.ToString());


             */

            //buoi 3 bai 2
            Bai4 bai4 = new Bai4();
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Nhap ds Sinh vien");
                Console.WriteLine("2. Hien Thi sv");
                Console.WriteLine("3. Thoat");
                Console.Write("Chon ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Loi");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        bai4.NhapSinhVien();
                        break;
                    case 2:
                        bai4.HienThiSinhVien();
                        break;
                    case 3:
                          return;


                    default: return;
                }
            }
        }
    }
}
