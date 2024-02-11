using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Devices.Haptics;

namespace Calculator
{
    public class Logic {
    
        public bool isInt(char c)
        {
            string s = c.ToString(); 
            return !int.TryParse(s, out var val) ? false: true;
        }

        private void number()
        {
            System.Diagnostics.Debug.WriteLine("its a number");
        }

        private int multiply(int sum, int x) {
            return sum * x;
        }
        private int add(int sum, int x) { 
            return sum + x;
        }
        private int subtract(int sum, int x) { 
            return sum - x;
        }
        private int divide(int sum, int x) {
            return sum / x; 
        }
        
        public void determineInput(char c, int sum, int x)
        {
            if (isInt(c))
                number();
            switch (c)
            {
                case '*':
                    multiply(sum, x);
                    break;
                case '/':
                    divide(sum, x);
                    break;
                case '+':
                    add(sum, x);
                    break;
                case '-':
                    subtract(sum, x);
                    break;
                default:
                    break;
            }

        }
    }

}