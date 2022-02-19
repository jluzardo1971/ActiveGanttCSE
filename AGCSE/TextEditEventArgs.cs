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
    public class TextEditEventArgs : System.EventArgs
    {

        public E_TEXTOBJECTTYPE ObjectType;
        public int ObjectIndex;
        public int ParentObjectIndex;
        public string Text;

        internal TextEditEventArgs()
        {
            Clear();
        }

        internal void Clear()
        {
            ObjectType = 0;
            ObjectIndex = 0;
            ParentObjectIndex = 0;
            Text = "";
        }

    }
}
