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
    [SerializeField] float rayDistance = 1f;
    [SerializeField] Color rayColor;
    [SerializeField] bool showRay = false;

    [Header("플레이어 발견 패턴")]
    [SerializeField, Range(5f, 25f)] float range = 10f;
    float distance = 0;

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

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void Move()
    {

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
        rigid.velocity = new Vector2(-1, 0) * speed;
        //float distance = Vector3.Distance(transform.position, player.position);
        //if (distance <= range)
        //{
        //    rigid.velocity = new Vector2(-1, 0) * speed;
        //}
        //if (distance <= range)
        //{
        //    transform.LookAt(player);
        //    transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}

    }

}
