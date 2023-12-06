using UnityEngine;

//[RequireComponent(typeof(PhysicsController))]
public class ShakeDetect : MonoBehaviour
{

    public float ShakeDetectionThreshold = 3.6f;
    public float MinShakeInterval =0.2f;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    public TextMesh LogTxt;
    public TextMesh LogTxt1;
    public Transform camTrans;

    //private PhysicsController physicsController;

    void Start()
    {   
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        //physicsController = GetComponent<PhysicsController>();

        if(SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;
    }

    void Update()
    {   
        if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold
            && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {   
            ShakeDetected();
            timeSinceLastShake = Time.unscaledTime;
        }   

        LogTxt.text = Input.acceleration.ToString();
        LogTxt1.text = Input.gyro.rotationRateUnbiased.ToString();
        camTrans?.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
    }

    void ShakeDetected() 
    {   
        this.ShakeRigidbodies(Input.acceleration);
    }

    public float ShakeForceMultiplier = 10;
    public Rigidbody[] ShakingRigidbodies;

    public void ShakeRigidbodies(Vector3 deviceAcceleration)
    {
        foreach (var rigidbody in ShakingRigidbodies)
        {
            rigidbody.AddForce(deviceAcceleration * ShakeForceMultiplier, ForceMode.Impulse);
        }
    }
}