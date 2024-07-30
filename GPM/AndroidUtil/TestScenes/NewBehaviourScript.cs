using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{   
    public Text texxx;

    public void AdroidVer() 
    {   
        var a= AndroidVersion.GetVer();
        texxx.text = a;
    }

    public void AndroidChip() 
    {   
        AndroidChipInfo ac = new AndroidChipInfo();
        var a = ac.GetBoardChipName();
        texxx.text = a;
    }

    public void AdroidMem()
    {   
        AndroidMem _am = new AndroidMem();
        var a = AndroidMem.nativeTotal;
        texxx.text = a.ToString();
    }

    public void AdroidMemInfo()
    {   
        var a = AndroidMem.getMem();
    }
}
