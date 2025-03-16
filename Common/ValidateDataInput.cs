using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ValidateDataInput
    {
        public static bool CheckValidInputNumber(string inputNumber)
        {
            if (string.IsNullOrEmpty(inputNumber))
            {
                return false;
            }

            inputNumber = inputNumber.Trim();

            if (!int.TryParse(inputNumber, out int num))
            {
                return false;
            }

            int numberInput = int.Parse(inputNumber); // Nhập số nguyên từ bàn phím

            if (numberInput > int.MaxValue)
            {
                return false;
            }
            return true;


        }
    }

}
