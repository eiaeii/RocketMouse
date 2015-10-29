using UnityEngine;
using System.Collections;
public class MouseController : MonoBehaviour {

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    void FixedUpdate()
    {
        bool jetPackActive = Input.GetButton("Fire1");
        if (jetPackActive)
        {
          GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
        }

        Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
        newVelocity.x = forwardMovementSpeed;
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }
}
