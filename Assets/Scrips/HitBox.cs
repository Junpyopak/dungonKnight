using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    bool isGround = false;
    /// <summary>
    /// �ٸ� ��ũ��Ʈ�� �Ű��������� �����Ҷ�
    /// </summary>
    //public bool IsGround
    //{
    //    get { return isGround; }
    //}

    BoxCollider2D collision;
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
    }    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = false;

        }
    }
    public bool checkGround()
    {
        return isGround;
    }
}
