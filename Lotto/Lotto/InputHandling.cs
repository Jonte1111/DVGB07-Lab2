using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Input.Preview;
using Windows.Devices.Printers;
using Windows.UI.Xaml.Controls;
namespace Lotto
{
    public class InputHandling
    {
        public List<int> lottoRowInput(List<TextBox> list)
        {
            List<int> lottoNums = new List<int>();   
            for(int i = 0; i < 7; i++) {
                if (isInt(list[i].Text) && isValidInt(int.Parse(list[i].Text), lottoNums))
                    lottoNums.Add(int.Parse(list[i].Text));
                else
                {
                    throw new ArgumentException(list[i].Text, " is not a valid number");
                }
            }
            return lottoNums;    
        }
        private bool isInt(string s)
        {
             if(int.TryParse(s, out int value))
                return true;
             return false;
        }
        private bool isValidInt(int n, List<int> list)
        {
            if (list.Contains(n))
                return false;
            if (n < 1 || n > 35)
                return false;
            return true;
        }
    }
}