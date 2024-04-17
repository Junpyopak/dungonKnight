using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float PlayerHp = 50;
    [Header("플레이어 이동")]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForse = 3f;
    [SerializeField] float maxjumForse;
    bool isGround = false;
    Vector2 movePos;
    Rigidbody2D rigid;
    Animator anim;
    Collider2D col;
    bool maxJump = false;

    [Header("플레이어 대쉬"), SerializeField]
    float dashTime = 0.5f;
    bool isDash = false;
    [SerializeField] float dashSpeed = 12;

    HitBox hitBox;




    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        hitBox = GetComponentInChildren<HitBox>();
        bool isGround = hitBox.checkGround();
        bool maxJump = hitBox.maxJumpCheck();
        //bool isGround2 = hitBox.IsGround;
        //
    }
    void Start()
    {

    }


    private void FixedUpdate()
    {
        Move();
        jump();
        Dash();
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
    private void jump()//점프 함수 ontrigger로 isGround가 트루일때만 되게 생각해보기
    {


        //isGround = col.IsTouchingLayers(LayerMask.GetMask("Ground"));

        if (hitBox.checkGround() == true && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            rigid.velocity = Vector2.up * jumpForse;
        }

        if (hitBox.maxJumpCheck() == true)
        {
            rigid.velocity = Vector2.up * maxjumForse;
        }

    }
    private void Dash()//대쉬 알고리즘 수정해보기
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isDash = true;
            if (isDash == true)//대쉬가 활성화되면
            {
                dashTime = 0.5f;//0.2초동안 대쉬
                moveSpeed = dashSpeed;
            }
        }
        if (dashTime <= 0)//대쉬가 종료되면 다시 원래 스피드 인 7로
        {
            moveSpeed = 7;
            //if (isDash == true)//대쉬가 활성화되면
            //{
            //    dashTime = 0.2f;//0.2초동안 대쉬
            //    moveSpeed = dashSpeed;
            //}
        }
        else
        {
            dashTime -= Time.deltaTime;
            isDash = false;
        }

    }
    //public float checkPosition()
    //{
    //    return transform.position.x;
    //}
}
