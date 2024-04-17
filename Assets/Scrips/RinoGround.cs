using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinoGround : MonoBehaviour
{
    [SerializeField] bool isGround;
    BoxCollider2D RinoBox;

    // Start is called before the first frame update
    void Start()
    {
        RinoBox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
            if (RinoBox.IsTouchingLayers(LayerMask.GetMask("Ground")) == false)//�� üũ�ϴ� üũ�ڽ��� ground���� ��������flip�Լ� ����
            {
                flip();
            }
    }

    private void checkGround ()
    {
        //if (RinoBox.IsTouchingLayers(LayerMask.GetMask("Ground")) == true)//enemy�� ������ �ݶ��̴��� ���� ��� �����鼭                                                                            //��üũ�ϴ� üũ�ڽ��� ground���� ��������flip�Լ� ����(���߿� ������ �ε�Ÿ��� �������°� ����)
        //{
        //    if (RinoBox.IsTouchingLayers(LayerMask.GetMask("Ground")) == false)//�� üũ�ϴ� üũ�ڽ��� ground���� ��������flip�Լ� ����
        //    {
        //        flip();
        //    }
        //}
    }
    private void flip()//���� ������ �ڷ� ����
    {
        
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
