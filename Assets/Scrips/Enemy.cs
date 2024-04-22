using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("적 정보")]
    [SerializeField] float maxhp = 5f;
    [SerializeField] float hp = 5f;
    [SerializeField] float speed = 1f;
    Rigidbody2D rigid;
    BoxCollider2D col;


    [Header("플레이어 발견 패턴")]
    [SerializeField, Range(5f, 25f)] float range = 10f;
    float distance = 0;
    [SerializeField, Range(5f, 10f)] float rayDistance = 10f;
    [SerializeField] Color rayColor;
    [SerializeField] bool showRay = false;
    [SerializeField] public bool isPlayer = false;
    bool isflip = false;

    Transform player;
    [Header("체력바")]
    [SerializeField] GameObject objHpBar;
    [SerializeField] Transform trsHpCanvas;
    EnemyHp hpBar;

    // Start is called before the first frame update
    public enum Tags
    {
        Player,
    }
    public static class Tool
    {
        public static string GetTag(Tags _value)
        {
            return _value.ToString();
        }
    }
    private void OnDrawGizmos()
    {
        if (showRay == true)
        {
            Gizmos.color = rayColor;
            Gizmos.DrawLine(transform.position, transform.position - new Vector3(rayDistance, 0));
            Gizmos.DrawLine(transform.position, transform.position + new Vector3(rayDistance, 0));
        }
    }
    void Start()
    {
        hp = maxhp;
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        // player = transform.Find("Player").GetComponent<Transform>();

        //에너미 체력바 생성
        if (hpBar == null)//hp바가 없더라면
        {
            hpBar = Instantiate(objHpBar, trsHpCanvas).GetComponent<EnemyHp>();// 체력바 생성
            hpBar.initHp();
            hpBar.SetEnemy(this);
        }
        
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        checkPlayer();
        //checkPlayerdis();
    }

    private void Move()
    {
        //float distance = Vector3.Distance(transform.position, player.position);
        //RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector3.right, rayDistance, LayerMask.GetMask(Tool.GetTag(Tags.Player)));///레이퀘스트를 쏴서 플레이어가 맞으면 이동
        //if(ray)
        //{
        //    if (ray.transform.tag == Tags.Player.ToString())
        //    {

        //    }
        //}
        //
        //if (Vector3.Distance(transform.position, trsPlayer.position) < 30)//distance함수,a와b의 거리를 계산해주는 함수를 이용해 적의 플레이어 확인하는것 생각해보기.
        //{
        //    rigid.velocity = new Vector2(-1, 0) * speed;
        //}
        //rigid.velocity = new Vector2(-1, 0) * speed;

        //if (distance <= range)
        //{
        rigid.velocity = new Vector2(-1, 0) * speed;
        //}
        //if (distance <= range)
        //{
        //    transform.LookAt(player);
        //    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}
        //if(isPlayer == true) 
        //{
        //    rigid.velocity = new Vector2(-1, 0) * speed;
        //}

    }
    private void checkPlayer()//플레이어가 플레이어 감지 레이캐스트에 닿았을때 닿았다면 이동
    {
        Vector3 raydistance = new Vector3(-1, 0, 0);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, raydistance, rayDistance, LayerMask.GetMask(Tool.GetTag(Tags.Player)));///레이퀘스트를 쏴서 플레이어가 맞으면 이동
        if (ray)
        {
            isPlayer = true;

            if (hpBar.gameObject.activeSelf == false)//적이 트루가 됐을때 체력바가 없다면 체력바 트루로해서 나타내기
            {
                hpBar.gameObject.SetActive(true);
            }

            //Debug.Log("닿았습니다.");
            if(isPlayer == true)//플레이어가 -1 방향의 레이퀘스트에 닿고,
            {
                if (transform.localScale.x < 0)//적의 로컬스케일x가 0보다 작다면 즉,-1이라면
                {
                    flip();
                }
                Move();
            }
        }
        else
        {
            isPlayer = false;

            if (hpBar.gameObject.activeSelf == true)//적이 폴스가 됐을때 체력바가 있다면 체력바 끄기
            {
                hpBar.gameObject.SetActive(false);
            }

            rigid.velocity = new Vector2(0, 0);
        }
        Vector3 raydistance2 = new Vector3(1, 0, 0);
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, raydistance2, rayDistance, LayerMask.GetMask(Tool.GetTag(Tags.Player)));//x가 1인방향으로 레이퀘스트를 쏴 플레이어 감지
        if(ray2)
        {
            isPlayer = true; 
            //Debug.Log("닿았습니다.");
            if (isPlayer == true)
            {
                if (transform.localScale.x > 0) //적의 로컬스케일x가 0보다 크다면 즉,1이라면
                {
                    flip();
                }
                rigid.velocity = new Vector2(1, 0) * speed;
            }
        }


    }
    private void flip()//뒤돌기
    {
        speed = 1;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    //public bool checkPlayerdis()
    //{
    //    return isPlayer;
    //}
    private void hit()
    {
        hp--;
        hpBar.SetHp(hp, maxhp);
        if (hp==0)
        {
            Destroy(hpBar.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == Tool.GetTag(Tags.Player))
        {
            hit();
            Debug.Log("닿았습니다");
        }
    }
}
