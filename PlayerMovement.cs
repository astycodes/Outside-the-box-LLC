// PlayerMovement.cs
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 50f;
    public float maxSpeed = 5f;
    Rigidbody rb;

    void Awake() => rb = GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // consider new Input System later
        float v = Input.GetAxis("Vertical");
        Vector3 input = (transform.forward * v + transform.right * h).normalized;
        if (input.sqrMagnitude > 0.01f)
        {
            rb.AddForce(input * moveForce * Time.fixedDeltaTime, ForceMode.Acceleration);
            Vector3 horizontalVel = rb.velocity; horizontalVel.y = 0;
            if (horizontalVel.magnitude > maxSpeed)
                rb.velocity = horizontalVel.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }
    }
}
