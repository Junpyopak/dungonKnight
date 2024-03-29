using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("플레이어 이동")]
    [SerializeField] float moveSpeed = 3f;
    Vector2 movePos;
    Rigidbody2D rigid;
    Animator anim;
    // Start is called before the first frame update

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {

        movePos.x = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + movePos.x, transform.position.y);
        anim.SetBool("walk", movePos.x != 0);
        if(movePos.x<0)
        {
            gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }
    }
}
