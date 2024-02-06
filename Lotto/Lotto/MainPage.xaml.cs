﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
            List<TextBox>lottoNumbers = new List<TextBox>();
            lottoNumbers.Add(lotto1);
            lottoNumbers.Add(lotto2);
            lottoNumbers.Add(lotto3);
            lottoNumbers.Add(lotto4);
            lottoNumbers.Add(lotto5);
            lottoNumbers.Add(lotto6);
            lottoNumbers.Add(lotto7);

            int[] lottoArr = new int[7];
            int five; int six; int seven;
            List<int> row = new List<int>();
            row = ih.lottoRowInput(lottoNumbers);
            (five, six, seven) = ll.generateLotto(999999, row);
            string lottoString = string.Join(" ", lottoArr);
                        drawAmountBox.Text = lottoString;
            fiveText.Text = five.ToString();    
            sixText.Text = six.ToString();    
            sevenText.Text = seven.ToString();    
        }
    }
}
