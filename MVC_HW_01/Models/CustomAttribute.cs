using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MVC_HW_01.Models
{
    public class PhoneFormatAttribute : DataTypeAttribute 
    {
        Regex regex = new Regex(@"\d{4}-\d{6}");

        public PhoneFormatAttribute() : base(DataType.Text)
        {
            ErrorMessage = "手機格式錯誤！ e.g: 0912-345678";
        }

        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return true;
            }

            return regex.IsMatch(Convert.ToString(value));
        }
    }
}