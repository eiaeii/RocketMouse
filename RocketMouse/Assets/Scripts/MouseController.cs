using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MouseController : MonoBehaviour {

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    public float forwardAddSpeed = 0.001f;

    public Transform groundCheckTransform;

    private bool grounded;

    public LayerMask groundCheckLayerMask;

    Animator animator;
    public Animator SettlementAnimator;

    public ParticleSystem jetpack;

    private bool dead = false;

    public uint coins = 0;
    public static uint coinsRecord = 0;

    public AudioClip coinCollectSound;

    public AudioSource jetpackAudio;
    public AudioSource footstepsAudio;

    public ParallaxScrool parallax;

    public Text coinsLabel;
    public Text coinsRecordLabel;

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

        parallax.offset = transform.position.x;

        if (!dead)
        {
            Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;

            if (forwardMovementSpeed <= 10)
            {
                forwardMovementSpeed += forwardAddSpeed;
            }
            
            newVelocity.x = forwardMovementSpeed;
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
        
        UpdateGroundedStatus();

        AdjustJetpack(jetPackActive);

        AdjustFootSetpsAndJetpackSound(jetPackActive);
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
        
        if (!dead)
        {
            jetpack.enableEmission = !grounded;
            jetpack.emissionRate = jetpackActive ? 300.0f : 75.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Coins"))
            CollectCoin(collider);
        else
            HitByLaser(collider);
    }

    void HitByLaser(Collider2D laserCollider)
    {
        if (!dead)
            laserCollider.gameObject.GetComponent<AudioSource>().Play();

        jetpack.enableEmission = false;
        dead = true;
        animator.SetBool("dead", true);
        parallax.offset = 0;

        if (coinsRecord < coins)
        {
            coinsRecord = coins;
        }
        coinsRecordLabel.text = coinsRecord.ToString();
        SettlementAnimator.enabled = true;
        SettlementAnimator.SetBool("isOut", false);
    }

    void CollectCoin(Collider2D coinCollider)
    {
        if (!dead)
        {
            coins++;
            coinsLabel.text = coins.ToString();

            Destroy(coinCollider.gameObject);

            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
        }
    }

    void AdjustFootSetpsAndJetpackSound(bool jetpackActive)
    {
        footstepsAudio.enabled = !dead && grounded;

        jetpackAudio.enabled = !dead && !grounded;
        jetpackAudio.volume = jetpackActive ? 1.0f : 0.5f;
    }
}
