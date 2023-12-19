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
}
