
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
//summary.native-heap
//pirvateOhter
//summary.graphics
//summary.code

        String ret ="";
        
        // int nativePss = dbm.nativePss;
        // ret += "dbm.nativePss "+ nativePss +" ";


        //ret += "dbm.otherPrivateDirty "+ pOther +" ";

        //ret += "dbm.otherPss "+ pOther +" ";
        
   
  
        //pOther = dbm.otherSharedDirty;
        //ret += "dbm.otherSharedDirty "+ pOther +" ";

        String tmp ="";

        String pss = dbm.getMemoryStat( "summary.total-pss" );
        //ret += " total-pss "+pss +" ";
        ret += pss+"|";
        String nativeHeap = dbm.getMemoryStat( "summary.native-heap" );
        //ret += " native-heap "+nativeHeap +" ";
        ret += nativeHeap+"|";
        int pOther = dbm.otherPrivateDirty;   
        int OOther = dbm.otherPss;
        int pirvateOhter = OOther - pOther;  // pirvateOhter 
        ret += pirvateOhter+"|";
        //ret += "pirvateOhter "+ pirvateOhter +" ";

        String graphics = dbm.getMemoryStat( "summary.graphics" );
        //ret += " summary.graphics "+tmp +" ";
        ret += graphics+"|";
        String code = dbm.getMemoryStat( "summary.code" );
        //ret += " summary.code "+tmp +" ";
        ret += code+"|";
        
        return ret;
    }   
}