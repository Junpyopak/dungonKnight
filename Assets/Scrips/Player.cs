using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어 이동")]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpForse = 3f;
    [SerializeField] bool isGround = false;
    Vector2 movePos;
    Rigidbody2D rigid;
    Animator anim;
    Collider2D col;


    [Header("플레이어 대쉬")]
    [SerializeField] float dashTimer = 5f;
    [SerializeField] float dashTime = 0.3f;
    [SerializeField] bool isDash = false;
    [SerializeField] float dashSpeed = 3f;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }
    void Start()
    {
    }
    private void FixedUpdate()
    {
        Move();
        jump();
    }
    void Update()
    {
    }

    private void Move()
    {

        movePos.x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        movePos.y = Input.GetAxisRaw("Vertical");
        transform.position = new Vector2(transform.position.x + movePos.x, transform.position.y);
        anim.SetBool("walk", movePos.x != 0);
        if (movePos.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }
        if (movePos.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }

    }
    private void jump()
    {

        //if(col.IsTouchingLayers(LayerMask.GetMask("Ground"))==true)
        //{
        //    if (Input.GetKeyDown(KeyCode.LeftAlt))
        //    {
        //        rigid.velocity = Vector2.up * jumpForse;
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rigid.velocity = Vector2.up * jumpForse;
        }
    }
}
