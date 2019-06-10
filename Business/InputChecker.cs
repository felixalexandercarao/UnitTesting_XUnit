using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class InputChecker
    {
        public bool passwordCheck(string newPassword)
        {
            bool upperResult = false;
            bool numberResult = false;
            foreach (char letter in newPassword.ToCharArray())
            {
                if (Char.IsUpper(letter) == true)
                {
                    upperResult = true;
                }
                if (Char.IsDigit(letter) == true)
                {
                    numberResult = true;
                }

            }
            if (newPassword.Length < 8)
            {
                upperResult = false;
            }
            return (numberResult&&upperResult);
        }
    }
}
