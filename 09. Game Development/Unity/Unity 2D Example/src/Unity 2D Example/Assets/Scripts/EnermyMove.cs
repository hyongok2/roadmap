using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;
    public int nextMove;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        Invoke("Think", 3);
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(nextMove, body.velocity.y);


        //지형 체크
        Vector2 frontVec = new Vector2(body.position.x + nextMove * 0.2f ,body.position.y);
        Debug.DrawRay(frontVec, Vector3.down, Color.green);

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            Turn();
        }

    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        animator.SetInteger("WalkSpeed", nextMove);

        if(nextMove != 0) 
            spriteRenderer.flipX = nextMove == 1;

        Invoke("Think", Random.Range(2f, 5f));
    }

    void Turn()
    {
        nextMove *= -1;
        CancelInvoke();
        spriteRenderer.flipX = nextMove == 1;
        Invoke("Think", 3);
    }

    public void OnDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        capsuleCollider.enabled= false;
        body.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        //Destroy
        Invoke("DeActive", 5);
    }

    private void DeActive()
    {
        gameObject.SetActive(false);
    }
}
