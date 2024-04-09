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
    private void ChPostion()//�������� ��ġ�� ���� ü�¹��� ��ġ ���� �̵�
    {
        Vector3 movePos = trsEnemy.position;//�������� ��ġ
        movePos.y -= 0.7f;
        transform.position = movePos;
    }

    private void CheckHp()//���� ü�� ������ ��Ÿ��.
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
