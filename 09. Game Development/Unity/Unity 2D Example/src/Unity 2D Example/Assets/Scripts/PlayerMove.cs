using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;

    public AudioClip audioJump;
    public AudioClip audioAttack;
    public AudioClip audioDamaged;
    public AudioClip audioItem;
    public AudioClip audioDie;
    public AudioClip audioFinish;

    public float maxSpeed;
    public float jumpPower;

    CapsuleCollider2D capsuleCollider;
    Rigidbody2D body;
    SpriteRenderer spriteRenderer;
    Animator animator;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && animator.GetBool("isJumping") == false)
        {
            body.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            PlaySound(audioJump);
        }

        //Stop Speed SetUp
        if (Input.GetButtonUp("Horizontal"))
        {            
            body.velocity = new Vector2(body.velocity.normalized.x * 0.5f, body.velocity.y);
        }

        if(Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX= Input.GetAxisRaw("Horizontal") == -1;
        }

        //Walking Animation
        if(Mathf.Abs(body.velocity.x) < 0.3f)
        {
            animator.SetBool("isWalking",false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        body.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (body.velocity.x > maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }
        else if (body.velocity.x < -maxSpeed)
        {
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);
        }

        if(body.velocity.y < 0)
        {
            Debug.DrawRay(body.position, Vector3.down, Color.green);

            RaycastHit2D rayHit = Physics2D.Raycast(body.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    animator.SetBool("isJumping", false);
                }
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enermy")
        {
            if(body.velocity.y < 0 || transform.position.y > collision.transform.position.y)
            {
                OnAttack(collision.transform);
            }
            else
                OnDamaged(collision.transform.position);
        }
        else if(collision.gameObject.tag == "Spike")
        {
            OnDamaged(collision.transform.position);
        }
    }

    private void OnAttack(Transform enemy)
    {
        // Point
        gameManager.stagePoint += 100;

        body.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        PlaySound(audioAttack);

        // Enemy die
        EnermyMove enermyMove  = enemy.GetComponent<EnermyMove>();
        if(enermyMove != null)
             enermyMove.OnDamaged();
    }

    private void OnDamaged(Vector3 position)
    {
        gameManager.HealthDown();

        // 公利 葛靛
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = position.x > transform.position.x ? -1 : 1; 

        body.AddForce(new Vector2(dirc,1) * 7 , ForceMode2D.Impulse);

        PlaySound(audioDamaged);

        animator.SetTrigger("doDamaged");

        Invoke("OffDamaged", 3);
    }

    private void OffDamaged()
    {
        // 公利 葛靛 秦力
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            bool isBronze = collision.gameObject.name.Contains("Bronze");
            bool isSliver = collision.gameObject.name.Contains("Silver");
            bool isGold = collision.gameObject.name.Contains("Gold");

            if(isBronze)        gameManager.stagePoint += 50;
            else if(isSliver)   gameManager.stagePoint += 100;
            else if(isGold)     gameManager.stagePoint += 300;

            collision.gameObject.SetActive(false);

            PlaySound(audioItem);
        }
        else if(collision.gameObject.tag == "Finish")
        {
            PlaySound(audioFinish);
            gameManager.NextStage();
        }
    }

    public void OnDie()
    {
        PlaySound(audioDie);
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        capsuleCollider.enabled = false;
        body.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    public void VelocityZero()
    {
        body.velocity = Vector2.zero;
    }
}
