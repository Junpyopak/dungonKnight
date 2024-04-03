using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�� ����")]
    [SerializeField] float hp = 5f;
    [SerializeField] float speed = 1f;
    Rigidbody2D rigid;
    BoxCollider2D col;
    [SerializeField] float rayDistance = 1f;
    [SerializeField] Color rayColor;
    [SerializeField] bool showRay = false;

    [Header("�÷��̾� �߰� ����")]
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
