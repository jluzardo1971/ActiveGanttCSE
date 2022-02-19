using System;
using System.ComponentModel;
using System.Reflection;

namespace MSP2003
{

    public enum SYS_ERRORS
    {
        ERR_ADDMODE_G = 51141,
        MP_REMOVE_1 = 51596,
        MP_REMOVE_2 = 51597,
        MP_REMOVE_3 = 51598,
        MP_REMOVE_4 = 51599,
        MP_ITEM_1 = 51600,
        MP_ITEM_2 = 51601,
        MP_ITEM_3 = 51602,
        MP_ITEM_4 = 51603,
        MP_ADD_1 = 51604,
        MP_ADD_2 = 51605,
        MP_ADD_3 = 51606,
        MP_SET_KEY = 51607
    }

    public static class Globals
    {
        static internal void g_ErrorReport(SYS_ERRORS ErrNumber, string ErrDescription, string ErrSource)
        {
            ////MessageBox.Show(System.Convert.ToString(ErrNumber) & ": " & ErrDescription & " (" & ErrSource & ")", "AGVBN Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        }

        static internal bool g_StrIsNumeric(string Expression)
        {
            double dDummy = 0;
            return double.TryParse(Expression, out dDummy);
        }

        public static string g_Format(int Expression, string sFormat)
        {
            return Expression.ToString(sFormat);
        }
    }

}
