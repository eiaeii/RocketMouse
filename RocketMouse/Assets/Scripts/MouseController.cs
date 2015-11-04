using UnityEngine;
using System.Collections;
public class MouseController : MonoBehaviour {

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    public Transform groundCheckTransform;

    private bool grounded;

    public LayerMask groundCheckLayerMask;

    Animator animator;

    public ParticleSystem jetpack;

    private bool dead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        bool jetPackActive = Input.GetButton("Fire1");

        jetPackActive = jetPackActive && !dead;

        if (jetPackActive)
        {
          GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
        }

        if (!dead)
        {
            Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
            newVelocity.x = forwardMovementSpeed;
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
        
        UpdateGroundedStatus();

        AdjustJetpack(jetPackActive);
    }

    void UpdateGroundedStatus()
    {
        //1
        grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);

        //2
        animator.SetBool("grounded", grounded);
    }

    void AdjustJetpack(bool jetpackActive)
    {
        jetpack.enableEmission = !grounded;
        jetpack.emissionRate = jetpackActive ? 300.0f : 75.0f;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        HitByLaser(collider);
    }

    void HitByLaser(Collider2D laserCollider)
    {
        dead = true;
        animator.SetBool("dead", true);
    }
}
