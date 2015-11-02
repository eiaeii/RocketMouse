using UnityEngine;
using System.Collections;
public class MouseController : MonoBehaviour {

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    public Transform groundCheckTransform;

    private bool grounded;

    public LayerMask groundCheckLayerMask;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

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

        UpdateGroundedStatus();
    }

    void UpdateGroundedStatus()
    {
        //1
        grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);

        //2
        animator.SetBool("grounded", grounded);
    }
}
