using System;
namespace Lotto
{
	public class LottoLogic 
	{
		public int randomLottoNumber()
		{
			Radnom r = new Random();
			return r.Next(0,36);
		}
		public int[] generateLotto()
		{
			int[] lottoArr = [6];
			for (int i = 0; i < 7; i++) {
				lottoArr[i]	= randomLottoNumber();
			}
			return lottoArr;
		}
	}
}
