using UnityEngine;
using UnityEditor;

public class PropellerBoats : MonoBehaviour
{
    public Transform propeller;
    public Transform rudder;
    private Rigidbody rb;

    public float engine_rpm { get; private set; }
    float throttle;
    int direction = 1;

    public float propellers_constant = 0.6F;
    public float engine_max_rpm = 600.0F;
    public float acceleration_cst = 100.0F;
    public float drag = 0.01F;

    public float angleLeft = 30;
    public float angleRight = -30;

    public float angle;

    void Awake()
    {
        engine_rpm = 0F;
        throttle = 0F;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float frame_rpm = engine_rpm * Time.deltaTime * 100;
        rb.AddForceAtPosition(Quaternion.Euler(0, angle, 0) * propeller.forward * propellers_constant * frame_rpm, propeller.position);

        throttle *= (1.0F - drag * 0.001F);
        engine_rpm = throttle * engine_max_rpm * direction;
    }

    public void ThrottleUp()
    {
        throttle += acceleration_cst;
        if (throttle > 1)
            throttle = 1;
    }

    public void ThrottleDown()
    {
        throttle -= acceleration_cst;
        if (throttle < 0)
            throttle = 0;
    }

    public void Brake()
    {
        throttle *= 0.9F;
    }

    public void Reverse()
    {
        direction *= -1;
    }

    public void RudderRight()
    {
        angle = angleRight;
    }

    public void RudderLeft()
    {
        angle = angleLeft;
    }
}
