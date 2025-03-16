namespace Common
{
    public struct StrucPhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public StrucPhanSo( int TuSo,int MauSo) {
            if (MauSo == 0)
            {
                throw new ArgumentException("Mau so khong the bang 0");
            }
            this.TuSo = TuSo;
           this.MauSo = MauSo;
            RutGon();
        }


        private int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        private void RutGon()
        {
            int ucln = UCLN(TuSo, MauSo);
            TuSo /= ucln;
            MauSo /= ucln;
            if (MauSo < 0)
            {
                TuSo = -TuSo;
                MauSo = -MauSo;
            }
        }

        public static StrucPhanSo  Cong(StrucPhanSo a, StrucPhanSo b)
        {
            return new StrucPhanSo(a.TuSo * b.MauSo + b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        }

        public static StrucPhanSo Tru(StrucPhanSo a, StrucPhanSo b)
        {
            return new StrucPhanSo(a.TuSo * b.MauSo - b.TuSo * a.MauSo, a.MauSo * b.MauSo);
        }

        public static StrucPhanSo Nhan(StrucPhanSo a, StrucPhanSo b)
        {
            return new StrucPhanSo(a.TuSo * b.TuSo, a.MauSo * b.MauSo);
        }

        public static StrucPhanSo Chia(StrucPhanSo a, StrucPhanSo b)
        {
            if (b.TuSo == 0)
            {
                throw new DivideByZeroException("Không thể chia cho phân số có tử số bằng 0");
            }
            return new StrucPhanSo(a.TuSo * b.MauSo, a.MauSo * b.TuSo);
        }

        public override string ToString()
        {
            return $"{TuSo}/{MauSo}";
        }



    }
}
