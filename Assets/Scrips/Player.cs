using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float PlayerHp = 50;
    [Header("�÷��̾� �̵�")]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForse = 3f;
    [SerializeField] float maxjumForse;
    bool isGround = false;
    Vector2 movePos;
    Rigidbody2D rigid;
    Animator anim;
    Collider2D col;
    bool maxJump = false;

    [Header("�÷��̾� �뽬"), SerializeField]
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
    private void jump()//���� �Լ� ontrigger�� isGround�� Ʈ���϶��� �ǰ� �����غ���
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
    private void Dash()//�뽬 �˰��� �����غ���
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isDash = true;
            if (isDash == true)//�뽬�� Ȱ��ȭ�Ǹ�
            {
                dashTime = 0.5f;//0.2�ʵ��� �뽬
                moveSpeed = dashSpeed;
            }
        }
        if (dashTime <= 0)//�뽬�� ����Ǹ� �ٽ� ���� ���ǵ� �� 7��
        {
            moveSpeed = 7;
            //if (isDash == true)//�뽬�� Ȱ��ȭ�Ǹ�
            //{
            //    dashTime = 0.2f;//0.2�ʵ��� �뽬
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
