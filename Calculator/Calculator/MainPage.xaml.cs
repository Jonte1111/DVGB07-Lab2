using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        List<char> buf = new List<char>();
        Logic logic = new Logic();

        private void checkInput(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            TextBlock txt = btn.Content as TextBlock;
            char c = txt.Text[0];
            buf.Add(c); 
            PrintList(buf);
            if (logic.isInt(c.ToString()))
            {
                System.Diagnostics.Debug.WriteLine("true");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("false");
            }
        }
        void PrintList<T> (List<T> list)
        {
            if(list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                        System.Diagnostics.Debug.Write(list[i].ToString() + ' ');
                    System.Diagnostics.Debug.Write('\n');
                }
        }
    }
}
