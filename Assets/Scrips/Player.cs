using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Enemy;

public class Player : MonoBehaviour
{
    private float hp = 15;
    [Header("플레이어 이동")]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForse = 3f;
    [SerializeField] float maxjumForse;
    bool isGround = false;
    Vector2 movePos;
    Rigidbody2D rigid;
    Animator anim;
    BoxCollider2D colbox;
    bool maxJump = false;

    [Header("플레이어 대쉬"), SerializeField]
    float dashTime = 0.5f;
    bool isDash = false;
    [SerializeField] float dashSpeed = 12;

    HitBox hitBox;

    [Header("플레이어 공격")]
    private float curTime;
    [SerializeField] float damage = 3f;
    [SerializeField] float coolTime = 0.5f;

    [Header("체력바")]
    [SerializeField] GameObject objHp;
    [SerializeField] Transform trsHpCanvas;
    [SerializeField] float curHp = 15;
    [SerializeField] float maxHp = 30;

    PlayerHp hpBar;
    public enum Tags
    {
        Player,
        weapon,
        enemy,
    }
    public static class Tool
    {
        public static string GetTag(Tags _value)
        {
            return _value.ToString();
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colbox = transform.Find("Attackbox").GetComponent<BoxCollider2D>();
        hitBox = GetComponentInChildren<HitBox>();
        bool isGround = hitBox.checkGround();
        bool maxJump = hitBox.maxJumpCheck();
        //bool isGround2 = hitBox.IsGround;
        //
    }
    void Start()
    {
        hp = maxHp;
        hpBar = GameObject.Find("PlayerHp").GetComponent<PlayerHp>();// 체력바 찾기
        hpBar.initHp();
        hpBar.SetPlayer(this);
    }


    private void FixedUpdate()
    {
        //colbox.enabled = false;
        Move();
        jump();
        Dash();
        Attack();
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

    private void Attack()//공격
    {
        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.C))//c키를 누르면 공격
            {
                anim.SetBool("attack", true);
                curTime = coolTime;
            }
        }
        else
        {
            anim.SetBool("attack", false);

            curTime -= Time.deltaTime;
        }

    }

    private void Colon()
    {
        colbox.enabled = true;//플레이어 자식중에 웨폰박스
    }

    private void endAttack()
    {
        colbox.enabled = false;
    }

    public void TriggerEnter2D(Collider2D other, HitBox.eTypeHitbox _type)
    {
        if (_type == HitBox.eTypeHitbox.Attak)
        {
            if (other.tag == Tool.GetTag(Tags.enemy))
            {
                Enemy enemy = other.GetComponent<Enemy>();
                enemy.hit(damage);
            }
        }
        //if (_type == HitBox.eTypeHitbox.Hit)
        //{
        //    if (other.tag == Tool.GetTag(Tags.enemy))
        //    {
        //        Damage();
        //    }
        //}
    }

    public void TriggerExit2D(Collider2D collision, HitBox.eTypeHitbox _type)
    {

    }

    public void hit(float _damage)
    {
        hp -= _damage;
        hpBar.SetHp(hp, maxHp);
        if (hp <= 0)
        {
            Destroy(hpBar.gameObject);
            Destroy(gameObject);
        }
    }
    //public void Damage()
    //{
    //    damage = 1;
    //    hp -= damage;
    //    hpBar.SetHp(hp, maxHp);
    //    if(hp <= 0)
    //    {
    //        Destroy(hpBar.gameObject);
    //        Destroy(gameObject);
    //    }
    //}
}
