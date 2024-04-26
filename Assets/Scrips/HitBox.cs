using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HitBox : MonoBehaviour
{
    public enum eTypeHitbox
    {
        Attak,
        Ground,
        JumpBoard,

    }

    [SerializeField]
    bool isGround = false;
    [SerializeField] bool maxJump = false;


    /// <summary>
    /// �ٸ� ��ũ��Ʈ�� �Ű��������� �����Ҷ�
    /// </summary>
    //public bool IsGround
    //{
    //    get { return isGround; }
    //}

    BoxCollider2D collision;

    Player player;
    [SerializeField] eTypeHitbox typeHitBox;

    private void Awake()
    {
        player = transform.parent.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        collision = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("jumpBoard"))
        {
            maxJump = true;
        }

        player.TriggerEnter2D(collision, typeHitBox);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = false;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("jumpBoard"))
        {
            maxJump = false;
        }
    }
    public bool checkGround()
    {
        return isGround;
    }

    public bool maxJumpCheck()
    {
        return maxJump;
    }
}
