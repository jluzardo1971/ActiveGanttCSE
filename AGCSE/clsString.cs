using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace AGCSE
{
	public class clsString
	{
		private static System.Text.RegularExpressions.Regex _isNumber = new System.Text.RegularExpressions.Regex(@"^\d+$");

		private ActiveGanttCSECtl mp_oControl;

		public clsString(ActiveGanttCSECtl Value)
		{
			mp_oControl = Value;
		}

		public String StrFormat(float Expression, String sFormat)
		{
			return Expression.ToString(sFormat, mp_oControl.Culture.NumberFormat);
		}

		public String StrFormat(int Expression, String sFormat)
		{
			return Expression.ToString(sFormat, mp_oControl.Culture.NumberFormat);
		}

		public String StrLeft(String Expression, int Length)
		{
			if (Length > StrLen(Expression))
			{
				return "";
			}
			else
			{
				return Expression.Substring(0, Length);
			}
		}

		public String StrRight(String Expression, int Length)
		{
			if (Length > StrLen(Expression))
			{
				return "";
			}
			else
			{
				return Expression.Substring(Expression.Length - Length, Length);
			}
		}

		public String StrMid(String Expression, int Start, int Length)
		{
			return Expression.Substring(Start - 1, Length);
		}

		public String StrLowerCase(String Expression)
		{
			return Expression.ToLower();
		}

		public String StrUpperCase(String Expression)
		{
			return Expression.ToUpper();
		}

		public bool StrIsNumeric(String Expression)
		{
			double dDummy;
			return StrIsNumericAux(Expression, out dDummy);
		}

		private bool StrIsNumericAux(String Expression, out double dResult)
		{
			return double.TryParse(Expression, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,out dResult);
		}

		public int StrCLng(String Expression)
		{
			return System.Convert.ToInt32(Expression);
		}

		public String StrCStr(int Expression)
		{
			return System.Convert.ToString(Expression);
		}

		public String StrCStr(float Expression)
		{
			return Expression.ToString();
		}

		public String StrCStr(String Expression)
		{
			return Expression;
		}

		public String StrTrim(String Expression)
		{
			return Expression.Trim();
		}

		public String StrReplace(String Expression, String String1, String String2)
		{
			return Expression.Replace(String1, String2);
		}

		internal String GetDecimalSeparator()
		{
			return System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
		}

		public int StrLen(String Expression)
		{
			return Expression.Length;
		}

	}
}
