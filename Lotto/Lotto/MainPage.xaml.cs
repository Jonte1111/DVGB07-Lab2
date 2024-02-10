using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Lotto
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //int[] testRow = {7,6,5,4,3,2,1};
        LottoLogic ll = new LottoLogic();
        InputHandling ih = new InputHandling();
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void start_lotto(object sender, RoutedEventArgs e)
        {
            List<TextBox> lottoNumbers = new List<TextBox>();
            List<int> row;
            lottoNumbers.Add(lotto1);
            lottoNumbers.Add(lotto2);
            lottoNumbers.Add(lotto3);
            lottoNumbers.Add(lotto4);
            lottoNumbers.Add(lotto5);
            lottoNumbers.Add(lotto6);
            lottoNumbers.Add(lotto7);

            int five; int six; int seven;
            (five, six, seven) = (0, 0, 0);
            if (ih.rowIsCorrect(lottoNumbers) && ih.isInt(drawAmountBox.Text))
            {
                try
                {
                    row = ih.convertList(lottoNumbers);
                    (five, six, seven) = ll.generateLotto(int.Parse(drawAmountBox.Text), row);
                    fiveText.Text = five.ToString();
                    sixText.Text = six.ToString();
                    sevenText.Text = seven.ToString();
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Row is invalid");
                }
            }
            else
                    System.Diagnostics.Debug.WriteLine("Row is invalid or amount is invalid");

        }
        
        //Changes the border colors if value inside is not valid
        private void lotto_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox lottoBox= (TextBox)sender;
            int n = 0;
            if (lottoBox.Text != null && ih.isInt(lottoBox.Text))
            {
                n = int.Parse(lottoBox.Text);
                if(!ih.isValidInt(n)) 
                    lottoBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Crimson);
                else
                    lottoBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.White);
            }
            else
                    lottoBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Crimson);
        }

        private void drawAmountBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox amountBox = (TextBox)sender;
            if (amountBox.Text == null || !ih.isInt(amountBox.Text))
                    amountBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Crimson);
            else
                    amountBox.BorderBrush = new SolidColorBrush(Windows.UI.Colors.White);
        }
    }
}
