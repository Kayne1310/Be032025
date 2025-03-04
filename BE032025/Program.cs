namespace BE032025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //goi ham tinh tong
            Sum(7, 10);
            //goi ham  tich
            Tich(7, 8);
            //goi ham hieu
             Hieu(5, 10);

            //goi ham ptb1 2x+6=9
            ptb1(2, 6);
            //goi ham ptb2  2x^2 +3x+1=0
            ptb2(2, 3, 1);

            //goi ham chuyen doi do C sang F,K
            chuyenDoiDoCSangKVaF(30);
        }

        //Cong
        public static void Sum(int numberA, int numberB)
        {
            Console.WriteLine("Tong la {0}",(numberB + numberA));
        }

        // Tich
        public static void Tich(int numberA, int numberB)
        {
            Console.WriteLine("Tich la {0}",( numberA * numberB));
        }

        //Hieu
        public static void Hieu(int numberA, int numberB)
        {
            Console.WriteLine("Hieu la {0}",( numberA-numberB));
        }

        //pt bac 1 ax+b=0
        public static void ptb1(int a, int b)
        {
            if (a == 0) Console.WriteLine("Pt vo nghiem");
            Console.WriteLine("pt co nghiem la {0}",(float) (-b / a));
        }

        //pt bac 2 ax^2+bx+c=0
        public static void ptb2(int a, int b, int c)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("pt vo nghiem ");
                }
                else
                {
                    Console.WriteLine("pt co 1 nghiem", (float)-c / b);
                }
                return;
            }

            float denta = (b * b) - (4 * a * c);
            if (denta > 0)
            {
                float x1 = (float)(-b + Math.Sqrt(denta)) / (2 * a);
                float x2 = (float)(-b - Math.Sqrt(denta)) / (2 * a);

                Console.WriteLine("pt co 2 nghiem la x1={0} x2={1}", x1, x2);
            }
            else if (denta == 0)
            {
                Console.WriteLine("pt co nghiem kep", -b / (2 * a));
            }
            else
            {
                Console.WriteLine("pt vo nghiem");
            }
        }

        //chuyen do C sang K va F
        public static void chuyenDoiDoCSangKVaF(float doC)
        {
            float doF = (float)((doC * 1.8) + 32);
            float doK = (float)(doC + 273.15);
            Console.WriteLine("Do C Sang F la {0}", doF);
            Console.WriteLine("Do C Sang K la {0} ", doK);
        }


    }
}
