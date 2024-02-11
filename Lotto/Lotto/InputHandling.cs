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
        public bool rowIsCorrect(List<TextBox> list)
        {
            List<int> lottoNums = new List<int>();
            int n = 0;
            for(int i = 0; i < 7; i++) {
                if (list[i] != null && isInt(list[i].Text))
                    n = int.Parse(list[i].Text);
                if (isValidInt(n))
                {

                    try
                    {
                        lottoNums.Add(int.Parse(list[i].Text));
                    }
                    catch
                    {
                        Console.WriteLine("Row is invalid");
                        return false;
                    }
                }
                else
                    return false;
            }
            if(!hasDuplicates(lottoNums))
                return true;    
            else
                return false;
        }
        public bool isInt(string s)
        {
            int value = 0;
             if(int.TryParse(s, out value))
                return true;
             return false;
        }

        public bool isValidInt(int n)
        {
            if (n < 1 || n > 35)
                return false;
            return true;
        } 

        public bool hasDuplicates(List<int> list)
        {
            //If amount of distinct elements is not == to total then theres duplicates
            if(list.Count != list.Distinct().Count())
                    return true;
            return false;
        }
        public List<int> convertList(List<TextBox> list)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < 7; i++) {
                if (isInt(list[i].Text) && isValidInt(int.Parse(list[i].Text)))
                    try
                    {
                        result.Add(int.Parse(list[i].Text));
                    }
                    catch { System.Diagnostics.Debug.WriteLine("Could not convert list"); }
            }
            return result; 
        }
    }
}