
package com.DefaultCompany.NewUnityProject;

import android.os.Debug;
import com.unity3d.player.UnityPlayerActivity;
import com.unity3d.player.UnityPlayer;

public class MyClass extends UnityPlayerActivity {    

    public static String testMethod(String data) { 
        //Log.i("TAG", "The data was "+data);
        //return data;
        return LogMemInfo();
    }   

    static String LogMemInfo()
    {   
        
        android.os.Debug.MemoryInfo dbm = new android.os.Debug.MemoryInfo();
        Debug.getMemoryInfo(dbm);
//kb 
//summary.total-pss
//summary.graphics
//summary.native-heap
//summary.code

        String ret ="";
        
        int nativePss = dbm.nativePss;
        ret += "dbm.nativePss "+ nativePss +" ";

        int pOther = dbm.otherPrivateDirty;
        //ret += "dbm.otherPrivateDirty "+ pOther +" ";

        int OOther = dbm.otherPss;
        //ret += "dbm.otherPss "+ pOther +" ";

        int pirvateOhter = OOther - pOther;
        ret += "pirvateOhter "+ pirvateOhter +" ";
        //pOther = dbm.otherSharedDirty;
        //ret += "dbm.otherSharedDirty "+ pOther +" ";

        String tmp ="";

        tmp = dbm.getMemoryStat( "summary.total-pss" );
        ret += " total-pss "+tmp +" ";

        tmp = dbm.getMemoryStat( "summary.native-heap" );
        ret += " native-heap "+tmp +" ";

        tmp = dbm.getMemoryStat( "summary.graphics" );
        ret += " summary.graphics "+tmp +" ";

        tmp = dbm.getMemoryStat( "summary.code" );
        ret += " summary.code "+tmp +" ";

        return ret;
    }   
}