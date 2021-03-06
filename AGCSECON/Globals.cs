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

namespace AGCSECON
{

    public enum PRG_DIALOGMODE
    {
        DM_ADD = 0,
        DM_EDIT = 1
    }

    internal enum E_DATASOURCETYPE
    {
        DST_NONE = 0,
        DST_ACCESS = 1,
        DST_XML = 2
    }

    public class AG_CR_Row
    {
        public int lRowID { get; set; }
        public int lDepth { get; set; }
        public int lOrder { get; set; }
        public string sLicensePlates { get; set; }
        public int lCarTypeID { get; set; }
        public string sNotes { get; set; }
        public double dRate { get; set; }
        public string sACRISSCode { get; set; }
        public string sCity { get; set; }
        public string sBranchName { get; set; }
        public string sState { get; set; }
        public string sPhone { get; set; }
        public string sManagerName { get; set; }
        public string sManagerMobile { get; set; }
        public string sAddress { get; set; }
        public string sZIP { get; set; }
    }


    public class AG_CR_Rental
    {
        public int lTaskID { get; set; }
        public int lRowID { get; set; }
        public int yMode { get; set; }
        public string sName { get; set; }
        public string sAddress { get; set; }
        public string sCity { get; set; }
        public string sState { get; set; }
        public string sZIP { get; set; }
        public string sPhone { get; set; }
        public string sMobile { get; set; }
        public DateTime dtPickUp { get; set; }
        public DateTime dtReturn { get; set; }
        public double dRate { get; set; }
        public double dALI { get; set; }
        public double dCRF { get; set; }
        public double dERF { get; set; }
        public double dGPS { get; set; }
        public double dLDW { get; set; }
        public double dPAI { get; set; }
        public double dPEP { get; set; }
        public double dRCFC { get; set; }
        public double dVLF { get; set; }
        public double dWTB { get; set; }
        public double dTax { get; set; }
        public double dEstimatedTotal { get; set; }
        public bool bGPS { get; set; }
        public bool bFSO { get; set; }
        public bool bLDW { get; set; }
        public bool bPAI { get; set; }
        public bool bPEP { get; set; }
        public bool bALI { get; set; }
    }

    public class CON_File
    {
        public string sDescription { get; set; }
        public string sFileName { get; set; }
    }

    public class AG_CR_Car_Type
    {

        public int lCarTypeID { get; set; }
        public string sDescription { get; set; }
        public string sACRISSCode { get; set; }
        public double dStdRate { get; set; }
    }

    public class AG_CR_US_State
    {
        public string sState { get; set; }
        public string sName { get; set; }
        public string dCarRentalTax { get; set; }
    }

    public class AG_CR_ACRISS_Code
    {
        public int lID { get; set; }
        public string sLetter { get; set; }
        public string sDescription { get; set; }
        public int lPosition { get; set; }
    }

    public class AG_CR_Tax_Surcharge_Option
    {
        public string sID { get; set; }
        public string sDescription { get; set; }
        public double dRate { get; set; }
    }

    public class AG_CR_US_City
    {
        public int lID { get; set; }
        public string sName { get; set; }
        public string sState { get; set; }
    }

    public class AG_CR_LastName
    {
        public int lID { get; set; }
        public string sLastName { get; set; }
    }

    public class AG_CR_FirstName
    {
        public int lID { get; set; }
        public string sName { get; set; }
        public string sSex { get; set; }
    }

    public class AG_CR_US_Street
    {
        public int lID { get; set; }
        public string sName { get; set; }
        public string sUSPS { get; set; }
    }


    public static class Globals
    {




 



        public static int GetRnd(int lLowerBound, int lUpperBound)
        {
            System.Random oRnd = null;
            string sGUID = System.Guid.NewGuid().ToString("N").Replace("a", "").Replace("b", "").Replace("c", "").Replace("d", "").Replace("e", "").Replace("f", "");
            int iSeed = System.Convert.ToInt32(sGUID.Substring(0, 5));
            oRnd = new Random(iSeed);
            return oRnd.Next(lLowerBound, lUpperBound);
        }

        public static string g_Format(double dParam, string sFormat)
        {
            return dParam.ToString(sFormat);
        }

        static internal string g_GenerateRandomName(bool IncludePrefix, E_DATASOURCETYPE yDataSourceType)
        {
            string sReturn = "";
            if (yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                List<AG_CR_FirstName> oAG_CR_FirstNames = new List<AG_CR_FirstName>();
                List<AG_CR_LastName> oAG_CR_LastNames = new List<AG_CR_LastName>();
                AG_CR_FirstName oFirstName;
                NoDataSource_Add_First_Names(oAG_CR_FirstNames);
                NoDataSource_Add_Last_Names(oAG_CR_LastNames);
                oFirstName = oAG_CR_FirstNames[GetRnd(1, oAG_CR_FirstNames.Count) - 1];
                if (IncludePrefix == true)
                {
                    if (oFirstName.sSex == "F")
                    {
                        sReturn = "Ms. ";
                    }
                    else
                    {
                        sReturn = "Mr. ";
                    }
                }
                sReturn = sReturn + oFirstName.sName;
                sReturn = sReturn + " " + oAG_CR_LastNames[GetRnd(1, oAG_CR_LastNames.Count) - 1].sLastName;
            }
            return sReturn;
        }

        static internal string g_GenerateRandomAddress(E_DATASOURCETYPE yDataSourceType)
        {
            string sReturn = "";
            int i = 0;
            int Max = 0;

            Max = GetRnd(1, 3);
            for (i = 1; i <= Max; i++)
            {
                sReturn = sReturn + System.Convert.ToChar(GetRnd(49, 57));
            }
            if (yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO

            else if (yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                List<AG_CR_LastName> oAG_CR_LastNames = new List<AG_CR_LastName>();
                List<AG_CR_US_Street> oAG_CR_US_Streets = new List<AG_CR_US_Street>();
                NoDataSource_Add_Last_Names(oAG_CR_LastNames);
                NoDataSource_Add_US_Streets(oAG_CR_US_Streets);
                sReturn = sReturn + " " + oAG_CR_LastNames[GetRnd(1, oAG_CR_LastNames.Count) - 1].sLastName;
                sReturn = sReturn + " " + oAG_CR_US_Streets[GetRnd(1, oAG_CR_US_Streets.Count) - 1].sName;
            }
            return sReturn;
        }

        static internal void g_GenerateRandomCity(ref string sCityName, ref string sState, ref int lID, E_DATASOURCETYPE yDataSourceType)
        {
            if (yDataSourceType == E_DATASOURCETYPE.DST_ACCESS)
            {
            }
            ////TODO
            else if (yDataSourceType == E_DATASOURCETYPE.DST_XML)
            {
            }
            ////TODO
            else if (yDataSourceType == E_DATASOURCETYPE.DST_NONE)
            {
                List<AG_CR_US_City> oAG_CR_US_Cities = new List<AG_CR_US_City>();
                AG_CR_US_City oCity;
                NoDataSource_Add_US_Cities(oAG_CR_US_Cities);
                oCity = oAG_CR_US_Cities[GetRnd(1, oAG_CR_US_Cities.Count) - 1];
                sCityName = oCity.sName;
                sState = oCity.sState;
                lID = oCity.lID;
                sCityName = sCityName.Trim();
                sState = sState.Trim();
            }
        }

        public static string g_GenerateRandomPhone(string AreaCode)
        {
            int i = 0;
            string sBuff = "";
            if (string.IsNullOrEmpty(AreaCode))
            {
                for (i = 1; i <= 3; i++)
                {
                    if (i == 1)
                    {
                        sBuff = sBuff + System.Convert.ToChar(GetRnd(49, 57));
                    }
                    else
                    {
                        sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
                    }
                }
                sBuff = "(" + sBuff + ") ";
            }
            else
            {
                sBuff = AreaCode + " ";
            }
            for (i = 1; i <= 3; i++)
            {
                if (i == 1)
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(49, 57));
                }
                else
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
                }
            }
            sBuff = sBuff + "-";
            for (i = 1; i <= 4; i++)
            {
                sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
            }
            return sBuff;
        }

        public static string g_GenerateRandomZIP()
        {
            int i = 0;
            string sBuff = "";
            for (i = 1; i <= 5; i++)
            {
                if (i == 1)
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(49, 57));
                }
                else
                {
                    sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
                }
            }
            return sBuff;
        }

        public static string g_GenerateRandomLicense()
        {
            int i = 0;
            string sBuff = "";
            for (i = 1; i <= 3; i++)
            {
                sBuff = sBuff + System.Convert.ToChar(GetRnd(65, 90));
            }
            sBuff = sBuff + "-";
            for (i = 1; i <= 4; i++)
            {
                sBuff = sBuff + System.Convert.ToChar(GetRnd(48, 57));
            }
            return sBuff;
        }

        private static void NoDataSource_Add_First_Names(List<AG_CR_FirstName> oAG_CR_FirstNames)
        {
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 1, "Fidelia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 2, "Eladia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 3, "Elizabet", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 4, "Elsy", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 5, "Estefana", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 6, "Eulah", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 7, "Carylon", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 8, "Mae", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 9, "Misty", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 10, "Julio", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 11, "Cody", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 12, "Lance", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 13, "Kelly", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 14, "Tyrone", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 15, "Darren", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 16, "Lonnie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 17, "Mathew", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 18, "Ted", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 19, "Toni", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 20, "Javier", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 21, "Kristina", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 22, "Violet", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 23, "Jessie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 24, "Christian", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 25, "Fernando", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 26, "Bobbie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 27, "Clinton", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 28, "Neil", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 29, "Miriam", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 30, "Velma", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 31, "Jamie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 32, "Becky", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 33, "Darryl", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 34, "Sonia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 35, "Claude", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 36, "Cory", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 37, "Jenny", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 38, "Erik", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 39, "Felicia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 40, "Adrian", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 41, "Karl", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 42, "Mae", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 43, "Misty", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 44, "Julio", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 45, "Cody", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 46, "Lance", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 47, "Kelly", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 48, "Tyrone", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 49, "Darren", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 50, "Lonnie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 51, "Mathew", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 52, "Ted", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 53, "Toni", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 54, "Javier", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 55, "Kristina", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 56, "Violet", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 57, "Jessie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 58, "Christian", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 59, "Fernando", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 60, "Bobbie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 61, "Clinton", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 62, "Neil", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 63, "Miriam", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 64, "Velma", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 65, "Jamie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 66, "Becky", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 67, "Darryl", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 68, "Sonia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 69, "Claude", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 70, "Cory", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 71, "Jenny", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 72, "Erik", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 73, "Felicia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 74, "Adrian", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 75, "Margy", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 76, "Lenita", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 77, "Mae", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 78, "Misty", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 79, "Julio", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 80, "Cody", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 81, "Lance", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 82, "Kelly", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 83, "Tyrone", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 84, "Darren", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 85, "Lonnie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 86, "Mathew", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 87, "Ted", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 88, "Toni", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 89, "Mae", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 90, "Misty", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 91, "Julio", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 92, "Cody", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 93, "Lance", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 94, "Kelly", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 95, "Tyrone", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 96, "Darren", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 97, "Lonnie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 98, "Mathew", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 99, "Ted", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 100, "Toni", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 101, "Javier", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 102, "Kristina", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 103, "Violet", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 104, "Jessie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 105, "Christian", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 106, "Fernando", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 107, "Bobbie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 108, "Clinton", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 109, "Neil", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 110, "Miriam", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 111, "Velma", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 112, "Jamie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 113, "Becky", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 114, "Darryl", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 115, "Sonia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 116, "Claude", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 117, "Naomi", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 118, "Priscilla", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 119, "Kay", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 120, "Penny", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 121, "Jared", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 122, "Carole", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 123, "Leah", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 124, "Roland", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 125, "Ron", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 126, "Nina", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 127, "Mitchell", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 128, "Arnold", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 129, "Harvey", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 130, "Margie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 131, "Cassandra", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 132, "Nora", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 133, "Brad", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 134, "Gabriel", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 135, "Jennie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 136, "Elmer", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 137, "Gwendolyn", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 138, "Hilda", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 139, "Andre", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 140, "Deanna", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 141, "Patsy", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 142, "Duane", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 143, "Franklin", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 144, "Lena", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 145, "Christy", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 146, "Myrtle", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 147, "Marsha", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 148, "Mabel", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 149, "Ben", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 150, "Chester", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 151, "Cecil", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 152, "Raul", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 153, "Maxine", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 154, "Irma", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 155, "Terry", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 156, "Edgar", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 157, "Milton", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 158, "Leslie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 159, "Rafael", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 160, "Nathaniel", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 161, "Mattie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 162, "Vickie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 163, "Angel", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 164, "Ruben", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 165, "Brett", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 166, "Jo", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 167, "Dora", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 168, "Reginald", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 169, "Caroline", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 170, "Stella", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 171, "Lydia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 172, "Viola", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 173, "Courtney", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 174, "Marian", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 175, "Gene", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 176, "Marc", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 177, "Marlene", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 178, "Glenda", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 179, "Heidi", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 180, "Nellie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 181, "Tanya", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 182, "Tyler", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 183, "Gilbert", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 184, "Minnie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 185, "Jackie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 186, "Claudia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 187, "Lillie", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 188, "Brent", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 189, "Ramon", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 190, "Charlie", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 191, "Marcia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 192, "Georgia", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 193, "Joy", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 194, "Rick", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 195, "Lester", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 196, "Constance", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 197, "Tamara", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 198, "Allison", "F");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 199, "Sam", "M");
            NoDataSource_Add_First_Name(oAG_CR_FirstNames, 200, "Colleen", "F");
        }

        private static void NoDataSource_Add_First_Name(List<AG_CR_FirstName> oAG_CR_FirstNames, int lID, string sName, string sSex)
        {
            AG_CR_FirstName oFirstName = new AG_CR_FirstName();
            oFirstName.lID = lID;
            oFirstName.sName = sName;
            oFirstName.sSex = sSex;
            oAG_CR_FirstNames.Add(oFirstName);
        }

        private static void NoDataSource_Add_US_Cities(List<AG_CR_US_City> oAG_CR_US_Cities)
        {
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 9270, "Merrydale", "LA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21822, "Hale Center", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10652, "St. Helen", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15221, "Morris village", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13115, "Missoula", "MT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6839, "Rosedale", "IN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22607, "Sundown", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 5964, "Orland Park village", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15543, "Syosset", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13081, "Joplin", "MT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22220, "New Boston", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13569, "Oak village", "NE");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19009, "Courtdale borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15720, "Bethlehem", "NC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19680, "Park Forest Village", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13819, "Winchester", "NV");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 508, "Anaktuvuk Pass", "AK");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 12567, "Monett", "MO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 25146, "Woods Landing-Jelm", "WY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 14295, "Somerset", "NJ");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22991, "Pleasant Grove", "UT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2359, "Pleasant Hill", "CA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6315, "Wenona", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20599, "Burke", "SD");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21676, "El Campo", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20310, "Hartsville", "SC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10906, "Chickamaw Beach", "MN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23591, "Central Park", "WA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 12347, "Hall village", "MO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13685, "Superior", "NE");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15552, "Thornwood", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22017, "Laredo Ranchettes", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20345, "Lakewood", "SC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 4568, "Raoul", "GA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23395, "North Springfield", "VA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6374, "Yorkville", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21774, "Gholson", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 17052, "Grand River village", "OH");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21946, "Kendleton", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 3601, "Islamorada, Village of Islands village", "FL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16464, "Golva", "ND");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19452, "McKeesport", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10111, "Waltham", "MA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 227, "Homewood", "AL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16935, "Deer Park", "OH");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 740, "Pilot Station", "AK");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22386, "Ralls", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16669, "Upham", "ND");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6989, "Alburnett", "IA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 1083, "Williams", "AZ");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16176, "Sanford", "NC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 7000, "Alvord", "IA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 1549, "Summit", "AR");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 11075, "Golden Valley", "MN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19922, "Springdale borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21041, "Greenfield", "TN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10150, "Allen village", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19427, "Loganton borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23215, "Claremont", "VA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10350, "Freeport village", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 12197, "Dalton", "MO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 54, "Brewton", "AL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 4491, "Montezuma", "GA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6178, "Sparland village", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 11687, "Chunky", "MS");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15506, "Sodus Point village", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2715, "Basalt", "CO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21026, "Garland", "TN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 12699, "Purdy", "MO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19465, "Manheim borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8966, "Stanford", "KY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 24287, "Sylvester", "WV");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 18566, "Hood River", "OR");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 25019, "Fort Bridger", "WY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 17232, "Malvern village", "OH");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23788, "Marblemount", "WA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 4670, "Trion", "GA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 5919, "North village", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22535, "Shady Hollow", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21146, "Newbern", "TN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 3665, "Lake Sarasota", "FL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16330, "Alexander", "ND");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 7881, "Waverly", "IA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19281, "Hokendauqua", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10102, "Teaticket", "MA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10632, "Rochester", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22926, "Lindon", "UT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6493, "Crown Point", "IN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8082, "Durham", "KS");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 24415, "Cascade village", "WI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 14634, "Alexandria Bay village", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 5607, "Holiday Hills village", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23059, "Virgin", "UT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 4708, "White", "GA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13506, "Lorton village", "NE");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8934, "Salt Lick", "KY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 14223, "Perth Amboy", "NJ");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20181, "Woonsocket", "RI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 18804, "Avonmore borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 1080, "Wickenburg", "AZ");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 17976, "Forest Park", "OK");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10591, "Peck village", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2921, "Monument", "CO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23961, "Sunnyside", "WA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 25053, "La Grange", "WY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19143, "Fairfield borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 7506, "Manilla", "IA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23780, "Malden", "WA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16435, "Fessenden", "ND");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8675, "Drakesboro", "KY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23124, "Orleans village", "VT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15695, "Ayden", "NC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13633, "Rockville village", "NE");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22198, "Muleshoe", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 292, "Mentone", "AL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20120, "Windsor borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21309, "Alvin", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 5420, "Elkhart village", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 4069, "Wausau", "FL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22210, "Natalia", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21353, "Bailey's Prairie village", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 24541, "Glendale", "WI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 14991, "Greenvale", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20540, "Willington", "SC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20942, "Burns", "TN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21412, "Blossom", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8506, "Turon", "KS");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22280, "Orange", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21402, "Bishop", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 5737, "Litchfield", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 17499, "Riverlea village", "OH");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6522, "Eaton", "IN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 3820, "Ormond Beach", "FL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 3365, "Chuluota", "FL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23193, "Burkeville", "VA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22338, "Pittsburg", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13158, "Saddle Butte", "MT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 9008, "Whitesville", "KY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16915, "Coshocton", "OH");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 18269, "River Bottom", "OK");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2600, "Twain Harte", "CA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23629, "Deer Park", "WA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 4606, "Sandy Springs", "GA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 3051, "Bethlehem Village", "CT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 1941, "Florence-Graham", "CA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 12046, "Bigelow village", "MO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16805, "Bradner village", "OH");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6707, "Michigan", "IN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 20790, "Parmelee", "SD");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21160, "Oak Ridge", "TN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13813, "Tonopah", "NV");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 9026, "Worthington", "KY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8238, "Lake Quivira", "KS");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22573, "South Padre Island", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15667, "Yorkshire", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 18015, "Guthrie", "OK");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 3289, "Belle Glade Camp", "FL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8799, "Ledbetter", "KY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 14463, "Fort Sumner village", "NM");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2310, "Orange Cove", "CA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 12538, "Matthews", "MO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22034, "La Ward", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6873, "Shoals", "IN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16131, "Ranlo", "NC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2257, "Mountain Ranch", "CA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 5963, "Orland Hills village", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 3841, "Palm River-Clair Mel", "FL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 5903, "New Salem village", "IL");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10563, "Norway", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2834, "Gleneagle", "CO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 12196, "Dadeville village", "MO");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 11052, "Freeborn", "MN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2406, "Ridgemark", "CA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6767, "New", "IN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21508, "Central Gardens", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15010, "Harris Hill", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19538, "Moosic borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 21758, "Galena Park", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 2459, "San Geronimo", "CA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13231, "Arlington village", "NE");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10075, "Salem", "MA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8488, "Summerfield", "KS");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 7495, "Macedonia", "IA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 9616, "Clinton", "MD");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 18709, "Sutherlin", "OR");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10771, "Zilwaukee", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 23793, "Martha Lake", "WA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 16002, "Long View", "NC");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 15493, "Shrub Oak", "NY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8153, "Goodland", "KS");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8874, "Okolona", "KY");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 8193, "Hoisington", "KS");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 17149, "Kettlersville village", "OH");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 13049, "Grass Range", "MT");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 10391, "Harper Woods", "MI");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22615, "Sweeny", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 6927, "Versailles", "IN");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 22311, "Pearland", "TX");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 19630, "North East borough", "PA");
            NoDataSource_Add_US_City(oAG_CR_US_Cities, 940, "Kachina Village", "AZ");
        }

        private static void NoDataSource_Add_US_City(List<AG_CR_US_City> oAG_CR_US_Cities, int lID, string sName, string sState)
        {
            AG_CR_US_City oCity = new AG_CR_US_City();
            oCity.lID = lID;
            oCity.sName = sName;
            oCity.sState = sState;
            oAG_CR_US_Cities.Add(oCity);
        }

        private static void NoDataSource_Add_Last_Names(List<AG_CR_LastName> oAG_CR_LastNames)
        {
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 1, "Smith");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 2, "Johnson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 3, "Williams");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 4, "Jones");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 5, "Brown");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 6, "Davis");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 7, "Miller");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 8, "Wilson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 9, "Moore");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 10, "Taylor");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 11, "Anderson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 12, "Thomas");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 13, "Jackson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 14, "White");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 15, "Harris");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 16, "Martin");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 17, "Thompson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 18, "Garcia");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 19, "Martinez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 20, "Robinson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 21, "Clark");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 22, "Rodriguez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 23, "Lewis");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 24, "Lee");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 25, "Walker");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 26, "Hall");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 27, "Allen");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 28, "Young");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 29, "Hernandez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 30, "King");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 31, "Wright");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 32, "Lopez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 33, "Hill");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 34, "Scott");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 35, "Green");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 36, "Adams");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 37, "Baker");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 38, "Gonzalez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 39, "Nelson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 40, "Carter");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 41, "Mitchell");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 42, "Perez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 43, "Roberts");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 44, "Turner");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 45, "Phillips");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 46, "Campbell");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 47, "Parker");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 48, "Evans");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 49, "Edwards");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 50, "Collins");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 51, "Stewart");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 52, "Sanchez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 53, "Morris");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 54, "Rogers");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 55, "Reed");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 56, "Cook");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 57, "Morgan");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 58, "Bell");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 59, "Murphy");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 60, "Bailey");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 61, "Rivera");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 62, "Cooper");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 63, "Richardson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 64, "Cox");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 65, "Howard");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 66, "Ward");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 67, "Torres");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 68, "Peterson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 69, "Gray");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 70, "Ramirez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 71, "James");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 72, "Watson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 73, "Brooks");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 74, "Kelly");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 75, "Sanders");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 76, "Price");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 77, "Bennett");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 78, "Wood");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 79, "Barnes");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 80, "Ross");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 81, "Henderson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 82, "Coleman");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 83, "Jenkins");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 84, "Perry");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 85, "Powell");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 86, "Long");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 87, "Patterson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 88, "Hughes");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 89, "Flores");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 90, "Washington");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 91, "Butler");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 92, "Simmons");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 93, "Foster");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 94, "Gonzales");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 95, "Bryant");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 96, "Alexander");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 97, "Russell");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 98, "Griffin");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 99, "Diaz");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 100, "Hayes");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 101, "Myers");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 102, "Ford");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 103, "Hamilton");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 104, "Graham");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 105, "Sullivan");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 106, "Wallace");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 107, "Woods");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 108, "Cole");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 109, "West");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 110, "Jordan");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 111, "Owens");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 112, "Reynolds");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 113, "Fisher");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 114, "Ellis");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 115, "Harrison");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 116, "Gibson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 117, "Mcdonald");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 118, "Cruz");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 119, "Marshall");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 120, "Ortiz");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 121, "Gomez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 122, "Murray");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 123, "Freeman");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 124, "Wells");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 125, "Webb");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 126, "Simpson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 127, "Stevens");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 128, "Tucker");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 129, "Porter");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 130, "Hunter");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 131, "Hicks");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 132, "Crawford");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 133, "Henry");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 134, "Boyd");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 135, "Mason");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 136, "Morales");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 137, "Kennedy");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 138, "Warren");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 139, "Dixon");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 140, "Ramos");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 141, "Reyes");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 142, "Burns");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 143, "Gordon");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 144, "Shaw");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 145, "Holmes");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 146, "Rice");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 147, "Robertson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 148, "Hunt");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 149, "Black");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 150, "Daniels");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 151, "Palmer");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 152, "Mills");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 153, "Nichols");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 154, "Grant");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 155, "Knight");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 156, "Ferguson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 157, "Rose");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 158, "Stone");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 159, "Hawkins");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 160, "Dunn");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 161, "Perkins");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 162, "Hudson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 163, "Spencer");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 164, "Gardner");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 165, "Stephens");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 166, "Payne");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 167, "Pierce");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 168, "Berry");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 169, "Matthews");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 170, "Arnold");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 171, "Wagner");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 172, "Willis");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 173, "Ray");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 174, "Watkins");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 175, "Olson");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 176, "Carroll");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 177, "Duncan");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 178, "Snyder");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 179, "Hart");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 180, "Cunningham");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 181, "Bradley");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 182, "Lane");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 183, "Andrews");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 184, "Ruiz");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 185, "Harper");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 186, "Fox");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 187, "Riley");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 188, "Armstrong");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 189, "Carpenter");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 190, "Weaver");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 191, "Greene");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 192, "Lawrence");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 193, "Elliott");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 194, "Chavez");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 195, "Sims");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 196, "Austin");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 197, "Peters");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 198, "Kelley");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 199, "Franklin");
            NoDataSource_Add_Last_Name(oAG_CR_LastNames, 200, "Lawson");
        }

        private static void NoDataSource_Add_Last_Name(List<AG_CR_LastName> oAG_CR_LastNames, int lID, string sLastName)
        {
            AG_CR_LastName oLastName = new AG_CR_LastName();
            oLastName.lID = lID;
            oLastName.sLastName = sLastName;
            oAG_CR_LastNames.Add(oLastName);
        }

        private static void NoDataSource_Add_US_Streets(List<AG_CR_US_Street> oAG_CR_US_Streets)
        {
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 1, "Alley", "Aly");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 2, "Annex", "Anx");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 3, "Arcade", "Arc");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 4, "Avenue", "Ave");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 5, "Bayoo", "Byu");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 6, "Beach", "Bch");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 7, "Bend", "Bnd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 8, "Bluff", "Blf");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 9, "Bluffs", "Blfs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 10, "Bottom", "Btm");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 11, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 12, "Branch", "Br");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 13, "Bridge", "Brg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 14, "Brook", "Brk");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 15, "Brooks", "Brks");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 16, "Burg", "Bg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 17, "Burgs", "Bgs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 18, "Bypass", "Byp");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 19, "Camp", "Cp");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 20, "Canyon", "Cyn");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 21, "Cape", "Cpe");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 22, "Causeway", "Cswy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 23, "Center", "Ctr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 24, "Centers", "Ctrs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 25, "Circle", "Cir");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 26, "Circles", "Cirs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 27, "Cliff", "Clf");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 28, "Cliffs", "Clfs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 29, "Club", "Clb");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 30, "Common", "Cmn");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 31, "Corner", "Cor");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 32, "Corners", "Cors");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 33, "Course", "Crse");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 34, "Court", "Ct");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 35, "Courts", "Cts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 36, "Cove", "Cv");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 37, "Coves", "Cvs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 38, "Creek", "Crk");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 39, "Crescent", "Cres");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 40, "Crest", "Crst");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 41, "Crossing", "Xing");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 42, "Crossroad", "Xrd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 43, "Curve", "Curv");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 44, "Dale", "Dl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 45, "Dam", "Dm");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 46, "Divide", "Dv");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 47, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 48, "Drives", "Drs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 49, "Estate", "Est");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 50, "Estates", "Ests");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 51, "Expressway", "Expy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 52, "Extension", "Ext");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 53, "Extensions", "Exts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 54, "Fall", "Fall");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 55, "Falls", "Fls");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 56, "Ferry", "Fry");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 57, "Field", "Fld");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 58, "Fields", "Flds");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 59, "Flat", "Flt");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 60, "Flats", "Flts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 61, "Ford", "Frd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 62, "Fords", "Frds");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 63, "Forest", "Frst");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 64, "Forge", "Frg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 65, "Forges", "Frgs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 66, "Fork", "Frk");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 67, "Forks", "Frks");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 68, "Fort", "Ft");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 69, "Freeway", "Fwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 70, "Garden", "Gdn");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 71, "Gardens", "Gdns");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 72, "Gateway", "Gtwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 73, "Glen", "Gln");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 74, "Glens", "Glns");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 75, "Green", "Grn");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 76, "Greens", "Grns");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 77, "Grove", "Grv");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 78, "Groves", "Grvs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 79, "Harbor", "Hbr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 80, "Harbors", "Hbrs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 81, "Haven", "Hvn");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 82, "Heights", "Hts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 83, "Highway", "Hwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 84, "Hill", "Hl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 85, "Hills", "Hls");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 86, "Hollow", "Holw");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 87, "Inlet", "Inlt");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 88, "Island", "Is");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 89, "Islands", "Iss");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 90, "Isle", "Isle");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 91, "Junction", "Jct");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 92, "Junctions", "Jcts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 93, "Key", "Ky");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 94, "Keys", "Kys");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 95, "Knoll", "Knl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 96, "Knolls", "Knls");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 97, "Lake", "Lk");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 98, "Lakes", "Lks");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 99, "Land", "Land");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 100, "Landing", "Lndg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 101, "Lane", "Ln");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 102, "Light", "Lgt");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 103, "Lights", "Lgts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 104, "Loaf", "Lf");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 105, "Lock", "Lck");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 106, "Locks", "Lcks");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 107, "Lodge", "Ldg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 108, "Loop", "Loop");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 109, "Mall", "Mall");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 110, "Manor", "Mnr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 111, "Manors", "Mnrs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 112, "Meadow", "Mdw");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 113, "Meadows", "Mdws");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 114, "Mews", "Mews");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 115, "Mill", "Ml");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 116, "Mills", "Mls");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 117, "Mission", "Msn");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 118, "Motorway", "Mtwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 119, "Mount", "Mt");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 120, "Mountain", "Mtn");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 121, "Mountains", "Mtns");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 122, "Neck", "Nck");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 123, "Orchard", "Orch");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 124, "Oval", "Oval");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 125, "Overpass", "Opas");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 126, "Park", "Park");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 127, "Parks", "Park");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 128, "Parkway", "Pkwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 129, "Parkways", "Pkwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 130, "Pass", "Pass");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 131, "Passage", "Psge");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 132, "Path", "Path");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 133, "Pike", "Pike");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 134, "Pine", "Pne");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 135, "Pines", "Pnes");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 136, "Place", "Pl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 137, "Plain", "Pln");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 138, "Plains", "Plns");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 139, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 140, "Point", "Pt");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 141, "Points", "Pts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 142, "Port", "Prt");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 143, "Ports", "Prts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 144, "Prairie", "Pr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 145, "Radial", "Radl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 146, "Ramp", "Ramp");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 147, "Ranch", "Rnch");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 148, "Rapid", "Rpd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 149, "Rapids", "Rpds");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 150, "Rest", "Rst");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 151, "Ridge", "Rdg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 152, "Ridges", "Rdgs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 153, "River", "Riv");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 154, "Road", "Rd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 155, "Roads", "Rds");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 156, "Route", "Rte");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 157, "Row", "Row");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 158, "Rue", "Rue");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 159, "Run", "Run");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 160, "Shoal", "Shl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 161, "Shoals", "Shls");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 162, "Shore", "Shr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 163, "Shores", "Shrs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 164, "Skyway", "Skwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 165, "Spring", "Spg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 166, "Springs", "Spgs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 167, "Spur", "Spur");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 168, "Spurs", "Spur");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 169, "Square", "Sq");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 170, "Squares", "Sqs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 171, "Station", "Sta");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 172, "Stravenue", "Stra");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 173, "Stream", "Strm");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 174, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 175, "Streets", "Sts");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 176, "Summit", "Smt");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 177, "Terrace", "Ter");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 178, "Throughway", "Trwy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 179, "Trace", "Trce");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 180, "Track", "Trak");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 181, "Trafficway", "Trfy");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 182, "Trail", "Trl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 183, "Tunnel", "Tunl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 184, "Turnpike", "Tpke");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 185, "Underpass", "Upas");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 186, "Union", "Un");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 187, "Unions", "Uns");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 188, "Valley", "Vly");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 189, "Valleys", "Vlys");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 190, "Viaduct", "Via");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 191, "View", "Vw");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 192, "Views", "Vws");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 193, "Village", "Vlg");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 194, "Villages", "Vlgs");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 195, "Ville", "Vl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 196, "Vista", "Vis");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 197, "Walk", "Walk");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 198, "Walks", "Walk");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 199, "Wall", "Wall");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 200, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 201, "Ways", "Ways");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 202, "Well", "Wl");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 203, "Wells", "Wls");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 204, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 205, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 206, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 207, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 208, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 209, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 210, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 211, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 212, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 213, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 214, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 215, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 216, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 217, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 218, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 219, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 220, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 221, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 222, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 223, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 224, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 225, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 226, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 227, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 228, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 229, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 230, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 231, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 232, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 233, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 234, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 235, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 236, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 237, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 238, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 239, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 240, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 241, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 242, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 243, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 244, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 245, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 246, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 247, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 248, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 249, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 250, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 251, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 252, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 253, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 254, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 255, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 256, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 257, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 258, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 259, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 260, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 261, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 262, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 263, "Boulevard", "Blvd");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 264, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 265, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 266, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 267, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 268, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 269, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 270, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 271, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 272, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 273, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 274, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 275, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 276, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 277, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 278, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 279, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 280, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 281, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 282, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 283, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 284, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 285, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 286, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 287, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 288, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 289, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 290, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 291, "Plaza", "Plz");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 292, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 293, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 294, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 295, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 296, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 297, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 298, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 299, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 300, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 301, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 302, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 303, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 304, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 305, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 306, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 307, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 308, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 309, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 310, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 311, "Way", "Way");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 312, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 313, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 314, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 315, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 316, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 317, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 318, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 319, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 320, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 321, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 322, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 323, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 324, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 325, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 326, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 327, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 328, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 329, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 330, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 331, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 332, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 333, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 334, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 335, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 336, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 337, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 338, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 339, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 340, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 341, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 342, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 343, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 344, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 345, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 346, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 347, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 348, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 349, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 350, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 351, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 352, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 353, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 354, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 355, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 356, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 357, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 358, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 359, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 360, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 361, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 362, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 363, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 364, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 365, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 366, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 367, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 368, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 369, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 370, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 371, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 372, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 373, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 374, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 375, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 376, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 377, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 378, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 379, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 380, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 381, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 382, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 383, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 384, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 385, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 386, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 387, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 388, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 389, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 390, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 391, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 392, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 393, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 394, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 395, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 396, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 397, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 398, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 399, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 400, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 401, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 402, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 403, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 404, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 405, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 406, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 407, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 408, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 409, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 410, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 411, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 412, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 413, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 414, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 415, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 416, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 417, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 418, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 419, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 420, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 421, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 422, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 423, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 424, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 425, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 426, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 427, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 428, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 429, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 430, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 431, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 432, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 433, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 434, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 435, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 436, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 437, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 438, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 439, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 440, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 441, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 442, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 443, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 444, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 445, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 446, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 447, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 448, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 449, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 450, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 451, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 452, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 453, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 454, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 455, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 456, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 457, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 458, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 459, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 460, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 461, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 462, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 463, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 464, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 465, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 466, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 467, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 468, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 469, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 470, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 471, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 472, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 473, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 474, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 475, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 476, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 477, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 478, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 479, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 480, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 481, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 482, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 483, "Street", "St");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 484, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 485, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 486, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 487, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 488, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 489, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 490, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 491, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 492, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 493, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 494, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 495, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 496, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 497, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 498, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 499, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 500, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 501, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 502, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 503, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 504, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 505, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 506, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 507, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 508, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 509, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 510, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 511, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 512, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 513, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 514, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 515, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 516, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 517, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 518, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 519, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 520, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 521, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 522, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 523, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 524, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 525, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 526, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 527, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 528, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 529, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 530, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 531, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 532, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 533, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 534, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 535, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 536, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 537, "Drive", "Dr");
            NoDataSource_Add_US_Street(oAG_CR_US_Streets, 538, "Drive", "Dr");
        }

        private static void NoDataSource_Add_US_Street(List<AG_CR_US_Street> oAG_CR_US_Streets, int lID, string sName, string sUSPS)
        {
            AG_CR_US_Street oStreet = new AG_CR_US_Street();
            oStreet.lID = lID;
            oStreet.sName = sName;
            oStreet.sUSPS = sUSPS;
            oAG_CR_US_Streets.Add(oStreet);
        }

        public static AGCSE.DateTime FromDate(System.DateTime dtDate)
        {
            AGCSE.DateTime dtReturn = new AGCSE.DateTime(dtDate.Year, dtDate.Month, dtDate.Day, dtDate.Hour, dtDate.Minute, dtDate.Second);
            return dtReturn;
        }

        public static string g_RemoveXMLNameSpaces(string sXML)
        {
            string sXmlns = " xmlns=";
            while (sXML.IndexOf(sXmlns) != -1)
            {
                dynamic lStart = sXML.IndexOf(sXmlns, 0);
                dynamic lEnd = sXML.IndexOf("\"", lStart + sXmlns.Length + 1);
                string sNs = sXML.Substring(lStart, lEnd - lStart + 1);
                sXML = sXML.Replace(sNs, "");
            }
            return sXML;
        }

    }
}
