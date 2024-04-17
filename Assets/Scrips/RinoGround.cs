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
            if (RinoBox.IsTouchingLayers(LayerMask.GetMask("Ground")) == false)//땅 체크하는 체크박스가 ground에서 떨어지면flip함수 실행
            {
                flip();
            }
    }

    private void checkGround ()
    {
        //if (RinoBox.IsTouchingLayers(LayerMask.GetMask("Ground")) == true)//enemy에 설정된 콜라이더로 땅을 밟고 있으면서                                                                            //땅체크하는 체크박스가 ground에서 떨어지면flip함수 실행(공중에 있을때 부들거리며 떨어지는걸 방지)
        //{
        //    if (RinoBox.IsTouchingLayers(LayerMask.GetMask("Ground")) == false)//땅 체크하는 체크박스가 ground에서 떨어지면flip함수 실행
        //    {
        //        flip();
        //    }
        //}
    }
    private void flip()//땅이 없으면 뒤로 돌기
    {
        
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
