using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Interface
{
    public interface  INhanVien
    {
        void NhapThongTin();
        void ThemCongDoan();
        void HienThiBaoCao();
        double TinhTongLuong();
    }
}
