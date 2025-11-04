using UnityEngine;

public class SimpleMove2D : MonoBehaviour
{
    public Vector2 destiny = Vector2.zero;
    public float velocity = 3f;
    public Rigidbody2D rigidbody2D;
    public void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0f;
        rigidbody2D.interpolation = RigidbodyInterpolation2D.Interpolate;
    }
    public void FixedUpdate()
    {
        Vector2 direction = (destiny - (Vector2)transform.position).normalized;
        rigidbody2D.linearVelocity = velocity * direction;
    }

}
