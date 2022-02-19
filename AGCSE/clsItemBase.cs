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
	public abstract class clsItemBase
	{
		public String mp_sKey;
		public int mp_lIndex;

		public clsItemBase()
		{
			mp_sKey = "";
			mp_lIndex = 0;
		}

		public int Index 
		{
			get 
			{
				return mp_lIndex;
			}
			set 
			{
				mp_lIndex = value;
			}
		}
	}
}
