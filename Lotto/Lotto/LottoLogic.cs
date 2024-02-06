using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Printers;
namespace Lotto
{
	public class LottoLogic 
	{
		public int randomLottoNumber(int[] n)
		{
			Random r = new Random();
			int x = r.Next(1, 36);
			while (n.Contains(x))
				x = r.Next(1, 36);
			return x;
		}
		private int checkLotto(List<int> correct, int[] row)
		{
			int n = 0;
			Array.Sort(row);
			for (int j = 0; j < correct.Count; j++)
			{
				for (int i = 0; i < 7; i++)
				{
					if (correct[j] == row[i])
						n++;
				}
			}
			Console.WriteLine(n);
			return n;
		}
		public (int five, int six, int seven) generateLotto(int rows, List<int> correct)
		{
			correct.Sort();
			int[] lottoArr = new int[7];
			int five = 0;
			int six = 0;
			int seven = 0;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					lottoArr[j] = randomLottoNumber(lottoArr);
				}
				Console.WriteLine(correct);
				switch(checkLotto(correct, lottoArr)) {
					case 5:
						//System.Diagnostics.Debug.WriteLine("[{0}]", string.Join(", ", lottoArr));
						five++;
						break;
					case 6:
						System.Diagnostics.Debug.WriteLine("[{0}]", string.Join(", ", lottoArr));
						six++;
						break;
					case 7:
						System.Diagnostics.Debug.WriteLine("[{0}]", string.Join(", ", lottoArr));
						seven++;
						break;
					default:
						break;
				}
			}
			return (five, six, seven);
		}
	}
}
