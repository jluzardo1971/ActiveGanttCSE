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
using System.Collections.Generic;
using System.Text;

namespace AGCSE
{

    using System;
    using System.ComponentModel;
    using System.Reflection;

    public class MouseWheelEventArgs : System.EventArgs
    {
        public int X;
        public int Y;
        public E_MOUSEBUTTONS Button;
        public int Delta;

        internal MouseWheelEventArgs()
		{
			Clear();
		}

        internal void Clear()
        {
            X = 0;
            Y = 0;
            Button = E_MOUSEBUTTONS.BTN_NONE;
            Delta = 0;
        }



    }
}
