using UnityEngine;

public class BallAcelerometreController : MonoBehaviour
{
 public float spd = 30f;
    public float deadZone = 0.012f;
    public bool autoCalibrateOnStart = true;
    Rigidbody rb;
    Vector2 calib;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (autoCalibrateOnStart) calib = ReadTiltXY();
    }
    Vector2 ReadTiltXY()
    {
        Vector2 acceleration = Input.acceleration;
        return new Vector2(acceleration.x, acceleration.y);
    }
    public void CalibrateNow() => calib = ReadTiltXY();
    void FixedUpdate()
    {
        Vector2 Tilt = ReadTiltXY() - calib;

        if (Tilt.magnitude < deadZone) 
        {
         Tilt = Vector2.zero;   
        }

        Vector3 force = new Vector3(Tilt.x, 0f , Tilt.y) * spd;
        rb.AddForce(force, ForceMode.Acceleration);
    }
}
