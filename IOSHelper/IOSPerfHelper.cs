#if UNITY_IOS && !UNITY_EDITOR
#define IOS_ONLY
#endif
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IOSPerfHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        StartK();
    }

    private void StartK()
    {   

#if IOS_ONLY
                [DllImport("__Internal", EntryPoint = "GetMemoryFootPrintSwift")]
                static extern int CallNativeMethod();

                var memfoot =CallNativeMethod();
#endif
    }

}
