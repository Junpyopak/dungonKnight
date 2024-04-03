using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("적 정보")]
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
    [SerializeField] bool isPlayer = false;

    Transform player;


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
        }
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        // player = transform.Find("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        checkPlayer();
        //Move();
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
        //rigid.velocity = new Vector2(-1, 0) * speed;
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
    private void checkPlayer()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector3.forward, rayDistance, LayerMask.GetMask(Tool.GetTag(Tags.Player)));///레이퀘스트를 쏴서 플레이어가 맞으면 이동
        if (ray)
        {

            Debug.Log("닿았습니다.");
            isPlayer = true;
        }
    }

}
