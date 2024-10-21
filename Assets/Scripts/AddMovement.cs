using UnityEngine;

public class AddMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 100f;

    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            Time.timeScale = 1;
            rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            Time.timeScale = 1;
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            Time.timeScale = 1;
            rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            Time.timeScale = 1;
            rb.AddForce(-forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}