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
    public class PredecessorExceptionEventArgs : System.EventArgs
    {
        public int PredecessorIndex;
        public E_CONSTRAINTTYPE PredecessorType;

        internal PredecessorExceptionEventArgs()
        {
            Clear();
        }

        internal void Clear()
        {
            PredecessorIndex = 0;
            PredecessorType = 0;
        }
    }
}
