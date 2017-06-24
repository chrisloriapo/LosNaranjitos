﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LosNaranjitos.Tools
{
   public class PasswordPolicy
    {
        private static int Minimum_Length = 5;
        private static int Upper_Case_length = 1;
        private static int Lower_Case_length = 1;
       // private static int NonAlpha_length = 1;
     //   private static int Numeric_length = 1;
        public static int Score = 3;

        public static bool IsValid(string Password)
        {
            Score = 3;
            if (Password.Length < Minimum_Length)
            {
                Score = Score - 1;
                return false;
            }
            if (UpperCaseCount(Password) < Upper_Case_length)
            {
                Score = Score - 1;
                return false;
            }
            if (LowerCaseCount(Password) < Lower_Case_length)
            {
                Score = Score - 1;
                return false;
            }
            if (NumericCount(Password) < 1)
            {
                Score = Score - 1;
                return false;
            }
            Score = 4;
            return true;
        }

        private static int UpperCaseCount(string Password)
        {
            return Regex.Matches(Password, "[A-Z]").Count;
        }

        private static int LowerCaseCount(string Password)
        {
            return Regex.Matches(Password, "[a-z]").Count;
        }
        private static int NumericCount(string Password)
        {
            return Regex.Matches(Password, "[0-9]").Count;
        }
        private static int NonAlphaCount(string Password)
        {
            return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
        }
    
}
}
