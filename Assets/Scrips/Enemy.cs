using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�� ����")]
    [SerializeField] float maxhp = 5f;
    [SerializeField] float hp = 5f;
    [SerializeField] float speed = 1f;
    Rigidbody2D rigid;
    BoxCollider2D col;


    [Header("�÷��̾� �߰� ����")]
    [SerializeField, Range(5f, 25f)] float range = 10f;
    float distance = 0;
    [SerializeField, Range(5f, 10f)] float rayDistance = 10f;
    [SerializeField] Color rayColor;
    [SerializeField] bool showRay = false;
    [SerializeField] public bool isPlayer = false;
    bool isflip = false;

    Transform player;
    [Header("ü�¹�")]
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

        //���ʹ� ü�¹� ����
        if (hpBar == null)//hp�ٰ� �������
        {
            hpBar = Instantiate(objHpBar, trsHpCanvas).GetComponent<EnemyHp>();// ü�¹� ����
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
        //RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector3.right, rayDistance, LayerMask.GetMask(Tool.GetTag(Tags.Player)));///��������Ʈ�� ���� �÷��̾ ������ �̵�
        //if(ray)
        //{
        //    if (ray.transform.tag == Tags.Player.ToString())
        //    {

        //    }
        //}
        //
        //if (Vector3.Distance(transform.position, trsPlayer.position) < 30)//distance�Լ�,a��b�� �Ÿ��� ������ִ� �Լ��� �̿��� ���� �÷��̾� Ȯ���ϴ°� �����غ���.
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
    private void checkPlayer()//�÷��̾ �÷��̾� ���� ����ĳ��Ʈ�� ������� ��Ҵٸ� �̵�
    {
        Vector3 raydistance = new Vector3(-1, 0, 0);
        RaycastHit2D ray = Physics2D.Raycast(transform.position, raydistance, rayDistance, LayerMask.GetMask(Tool.GetTag(Tags.Player)));///��������Ʈ�� ���� �÷��̾ ������ �̵�
        if (ray)
        {
            isPlayer = true;

            if (hpBar.gameObject.activeSelf == false)//���� Ʈ�簡 ������ ü�¹ٰ� ���ٸ� ü�¹� Ʈ����ؼ� ��Ÿ����
            {
                hpBar.gameObject.SetActive(true);
            }

            //Debug.Log("��ҽ��ϴ�.");
            if(isPlayer == true)//�÷��̾ -1 ������ ��������Ʈ�� ���,
            {
                if (transform.localScale.x < 0)//���� ���ý�����x�� 0���� �۴ٸ� ��,-1�̶��
                {
                    flip();
                }
                Move();
            }
        }
        else
        {
            isPlayer = false;

            if (hpBar.gameObject.activeSelf == true)//���� ������ ������ ü�¹ٰ� �ִٸ� ü�¹� ����
            {
                hpBar.gameObject.SetActive(false);
            }

            rigid.velocity = new Vector2(0, 0);
        }
        Vector3 raydistance2 = new Vector3(1, 0, 0);
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, raydistance2, rayDistance, LayerMask.GetMask(Tool.GetTag(Tags.Player)));//x�� 1�ι������� ��������Ʈ�� �� �÷��̾� ����
        if(ray2)
        {
            isPlayer = true; 
            //Debug.Log("��ҽ��ϴ�.");
            if (isPlayer == true)
            {
                if (transform.localScale.x > 0) //���� ���ý�����x�� 0���� ũ�ٸ� ��,1�̶��
                {
                    flip();
                }
                rigid.velocity = new Vector2(1, 0) * speed;
            }
        }


    }
    private void flip()//�ڵ���
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
            Debug.Log("��ҽ��ϴ�");
        }
    }
}
