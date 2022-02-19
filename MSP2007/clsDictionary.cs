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
using System.Collections.ObjectModel;

namespace MSP2007
{
    internal class clsDictionary : KeyedCollection<string, clsValuePair>
    {


        private int mp_lKey = 1;
        public clsDictionary()
            : base()
        {
        }

        public void Add(int Value, string Key)
        {
            clsValuePair oValuePair = new clsValuePair(Key, Value);
            base.Add(oValuePair);
        }

        public void Add(int Value)
        {
            clsValuePair oValuePair = new clsValuePair(mp_lKey.ToString(), Value);
            base.Add(oValuePair);
            mp_lKey = mp_lKey + 1;
        }

        public string StrItem(int Index)
        {
            return base[Index].IntValue.ToString();
        }

        new public int this[String Key]
        {
            get { return base[Key].IntValue; }
            set { base[Key].IntValue = value; }
        }

        protected override string GetKeyForItem(clsValuePair item)
        {
            return item.Key;
        }

    }

    internal class clsValuePair
    {
        private string mp_sKey;

        private int mp_lIntValue;

        public clsValuePair(string sKey, int lIntValue)
        {
            mp_sKey = sKey;
            mp_lIntValue = lIntValue;
        }

        public string Key
        {
            get { return mp_sKey; }
            set { mp_sKey = value; }
        }

        public int IntValue
        {
            get { return mp_lIntValue; }
            set { mp_lIntValue = value; }
        }
    }
}
