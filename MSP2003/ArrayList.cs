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

internal class ArrayList
{

    private object[] mp_oObjects;
    private int mp_lCount;

    private int mp_lGrowFactor = 100;
    public ArrayList()
    {
        mp_oObjects = new object[mp_lGrowFactor];
        mp_lCount = 0;
    }

    public int Add(object value)
    {
        if (mp_lCount > mp_oObjects.Length - 1)
        {
            object[] oObjectsTemp;
            oObjectsTemp = new object[mp_lCount + mp_lGrowFactor];
            Array.Copy(mp_oObjects, oObjectsTemp, Math.Min(mp_oObjects.Length, oObjectsTemp.Length));
            mp_oObjects = oObjectsTemp;
        }
        mp_oObjects[mp_lCount] = value;
        mp_lCount = mp_lCount + 1;
        return mp_lCount;
    }

    public object this[int index]
    {
        get
        {
            if (index < 0 | (index > mp_lCount - 1))
            {
                throw new ArgumentException("Index must be non-negative and less than the size of the ArrayList");
            }
            return mp_oObjects[index];
        }
        set
        {
            if (index < 0 | (index > mp_lCount - 1))
            {
                throw new ArgumentException("Index must be non-negative and less than the size of the ArrayList");
            }
            mp_oObjects[index] = value;
        }
    }

    public void RemoveAt(int index)
    {
        int i = 0;
        if (mp_lCount == 0)
        {
            throw new ArgumentException("ArrayList is empty");
        }
        if (index < 0 | (index > mp_lCount - 1))
        {
            throw new ArgumentException("Index must be non-negative and less than the size of the ArrayList");
        }
        for (i = index; i <= mp_lCount - 2; i++)
        {
            mp_oObjects[i] = mp_oObjects[i + 1];
        }
        mp_lCount = mp_lCount - 1;
    }

    public int Count
    {
        get { return mp_lCount; }
    }

    public void Clear()
    {
        mp_oObjects = new object[mp_lGrowFactor];
        mp_lCount = 0;
    }


}
