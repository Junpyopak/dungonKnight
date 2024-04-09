using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    private Slider Hpbar;
    [SerializeField] float maxHp = 7;
    [SerializeField] float curHp = 3;
    private Transform trsEnemy;

    private void Awake()
    {
        Hpbar = GetComponent<Slider>();
    }
    void Start()
    {
        trsEnemy = transform.Find("Slime").GetComponent<Transform>();
    }
    private void ChPostion()//슬라임의 위치에 따라 체력바의 위치 같이 이동
    {
        Vector3 movePos = trsEnemy.position;//슬라임의 위치
        movePos.y -= 0.7f;
        transform.position = movePos;
    }

    private void CheckHp()//현재 체력 얼마인지 나타냄.
    {
        if (Hpbar != null)
            Hpbar.value = curHp / maxHp;
    }
    // Update is called once per frame
    void Update()
    {
        ChPostion();
        CheckHp();
    }
}
