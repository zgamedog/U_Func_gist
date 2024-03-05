#if UNITY_IOS && !UNITY_EDITOR
#define IOS_ONLY
using System.Runtime.InteropServices;
#endif

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

                var memfoot =CallNativeMethod();
                // log
#endif
    }

    
#if IOS_ONLY
                [DllImport("__Internal", EntryPoint = "GetMemoryFootPrintSwift")]
                static extern int CallNativeMethod();
#endif

}
