using System;

using UnityEngine;

//https://developer.android.com/reference/android/os/Debug.MemoryInfo#getMemoryStat(java.lang.String)
//https://developer.android.com/reference/android/os/Debug.MemoryInfo
//https://developer.android.com/reference/android/os/Debug

public class AndroidMem
{        
    public static AndroidJavaClass m_androidMem;
    public static AndroidJavaObject m_androidMemInfo;

    public struct AMem 
    {   
        public int Pss;
        public int Rss;
        public int Native;
        
    }

    public AndroidMem()
    {   
        AndroidMem.m_androidMem = new AndroidJavaClass("android.os.Debug");
    }   

    public static string getMem()   
    {   
        AndroidJavaClass myClass = new AndroidJavaClass("com.DefaultCompany.NewUnityProject.MyClass");
        Debug.LogError("myClass myClass " + myClass);
        var ss = myClass.CallStatic<string>("testMethod", new object[] { "--------------Test" });
        Debug.LogError("ss ss " + ss);
        return string.Empty;
        m_androidMemInfo = m_androidMem.Call<AndroidJavaObject>("MemoryInfo");
        Debug.LogError("m_androidMemInfo " + m_androidMemInfo);

        var a = m_androidMem.Call<string>("getMemoryStat",new object[] { "summary.graphics" } );

        Debug.LogError("summary graphics kb " + a);

        return string.Empty;
    }

    public static long nativeTotal
    {   
        get 
        {   
            if (m_androidMem == null)
            {   
                Debug.LogError("null m_androidMem MemoryInfo");
                return -1;
            }   
              
            var a = m_androidMem.CallStatic<long>("getNativeHeapSize");
            Debug.LogError("kb nativePss  " + a );

            a = m_androidMem.CallStatic<long>("getNativeHeapAllocatedSize");
            Debug.LogError("kb getNativeHeapAllocatedSize  " + a);

            a = m_androidMem.CallStatic<long>("getNativeHeapFreeSize");
            Debug.LogError("kb getNativeHeapFreeSize  " + a);

            a = m_androidMem.CallStatic<long>("getPss");
            Debug.LogError("kb getPss  " + a);

            //a = m_androidMem.CallStatic<long>("getRss");
            //Debug.LogError("byte getRss  " + a);
            return a;
        }
    }   

}

public class AndroidVersion
{   
    public static string GetVer()
    {
        AndroidVersion a = new AndroidVersion();
        return AndroidVersion.ALL_VERSION;
    }

    public AndroidVersion() 
    {   
        AndroidVersion.versionInfo = new AndroidJavaClass("android.os.Build$VERSION");
    }

    public static AndroidJavaClass versionInfo;

    //static AndroidVersion()
    //{   
    //    versionInfo = new AndroidJavaClass("android.os.Build$VERSION");
    //}

    public static string BASE_OS
    {
        get
        {
            return versionInfo.GetStatic<string>("BASE_OS");
        }
    }

    public static string CODENAME
    {
        get
        {
            return versionInfo.GetStatic<string>("CODENAME");
        }
    }

    public static string INCREMENTAL
    {
        get
        {
            return versionInfo.GetStatic<string>("INCREMENTAL");
        }
    }

    public static int PREVIEW_SDK_INT
    {
        get
        {
            return versionInfo.GetStatic<int>("PREVIEW_SDK_INT");
        }
    }

    public static string RELEASE
    {
        get
        {
            return versionInfo.GetStatic<string>("RELEASE");
        }
    }

    public static string SDK
    {
        get
        {
            return versionInfo.GetStatic<string>("SDK");
        }
    }

    public static int SDK_INT
    {
        get
        {
            return versionInfo.GetStatic<int>("SDK_INT");
        }
    }

    public static string SECURITY_PATCH
    {
        get
        {
            return versionInfo.GetStatic<string>("SECURITY_PATCH");
        }
    }

    public static string ALL_VERSION
    {
        get
        {   
            Debug.LogError("null ALL_VERSION versionInfo " + versionInfo.ToString());
            string version = "BASE_OS: " + BASE_OS + "\n";
            version += "CODENAME: " + CODENAME + "\n";
            version += "INCREMENTAL: " + INCREMENTAL + "\n";
            version += "PREVIEW_SDK_INT: " + PREVIEW_SDK_INT + "\n";
            version += "RELEASE: " + RELEASE + "\n";
            version += "SDK: " + SDK + "\n";
            version += "SDK_INT: " + SDK_INT + "\n";
            version += "SECURITY_PATCH: " + SECURITY_PATCH;

            return version;
        }
    }
}
