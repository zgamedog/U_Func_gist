using UnityEngine;

public class AndroidPower : MonoBehaviour
{

    float e = 0;


    private void OnGUI()
    {
        GUILayout.Label(string.Format($"<size=80>���������{Power.capacity}����,��ѹ{Power.voltage}��</size>"));
        GUILayout.Label(string.Format($"<size=80>ʵʱ����{e}����,ʵʱ����{(int)(e * Power.voltage)},����������{((Power.capacity / e).ToString("f2"))}Сʱ</size>"));
    }


    float t = 0f;
    private void Update()
    {
        if (Time.unscaledTime - t > 1f)
        {
            t = Time.unscaledTime;
            e = Power.electricity;
        }
    }
}


public class Power
{



    static public float electricity
    {
        get
        {   
            if (Application.isMobilePlatform == false)
                return 0f;
#if UNITY_ANDROID
            //��ȡ������΢����������Ƶ����ȡ��ȡһ�δ��2����
            float electricity = (float)manager.Call<int>("getIntProperty", PARAM_BATTERY);
            //С��1W����Ϊ���ĵ�λ�Ǻ�����������Ϊ��΢��
            return ToMA(electricity);
#else
            return -1f;
#endif

        }
    }
    //��ȡ��ѹ ��
    static public float voltage { get; private set; }

    //��ȡ��������� ����
    static public int capacity { get; private set; }

    //��ȡʵʱ��������
    static object[] PARAM_BATTERY = new object[] { 2 }; //BatteryManager.BATTERY_PROPERTY_CURRENT_NOW)
    static AndroidJavaObject manager;
    static Power()
    {   
        if (Application.isMobilePlatform == false)
            return;
#if UNITY_ANDROID
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        manager = currActivity.Call<AndroidJavaObject>("getSystemService", new object[] { "batterymanager" });
        capacity = (int)(ToMA((float)manager.Call<int>("getIntProperty", new object[] { 1 })) / ((float)manager.Call<int>("getIntProperty", new object[] { 4 })/100f));   //BATTERY_PROPERTY_CHARGE_COUNTER 1 BATTERY_PROPERTY_CAPACITY 4
 
        AndroidJavaObject receive = currActivity.Call<AndroidJavaObject>("registerReceiver", new object[] { null,new AndroidJavaObject("android.content.IntentFilter", new object[] { "android.intent.action.BATTERY_CHANGED" }) });
        if (receive != null)
        {  
            voltage = (float)receive.Call<int>("getIntExtra", new object[] { "voltage",0 })/1000f; //BatteryManager.EXTRA_VOLTAGE
        }
#endif
    }

    static float ToMA(float maOrua)
    {
        return maOrua < 10000 ? maOrua : maOrua / 1000f;
    }
}