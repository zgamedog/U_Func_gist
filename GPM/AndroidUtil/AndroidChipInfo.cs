using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidChipInfo
{   
    static AndroidJavaClass infoBChip;
    public string GetBoardChipName()
    {   
        string ret = string.Empty;
#if PLATFORM_ANDROID
        if (infoBChip == null)
            infoBChip = new AndroidJavaClass("android.os.Build");

        if (infoBChip == null)
            return ret;

        try
        {
            ret = infoBChip.GetStatic<string>("BOARD");
        }
        catch (Exception e)
        {

        }
        finally
        {
            //Debug.Log("GetStatic BOARD " + ret);
        }

        return ret;
#endif
        return ret;
    }

}
