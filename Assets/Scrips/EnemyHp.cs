using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    Enemy enemy;
    private void Awake()
    {

    }
    //void Start()
    //{
    //    enemy = Slime.GetComponent<Enemy>();//������ �ȿ� �ִ� enemy ��ũ��Ʈ ������.
    //}

    public void SetEnemy(Enemy _enemy)
    {
        enemy = _enemy;
    }

    //private void CheckHp()//���� ü�� ������ ��Ÿ��.
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        //checkPlayer();
        transform.position = Camera.main.WorldToScreenPoint(enemy.transform.position+Vector3.down);//�������� ��ġ�� ���� hp �� �̹��� ui�� ���� �̵�
    }

    //private void checkPlayer()
    //{
    //    if(enemy.isPlayer==true)
    //    {
    //        gameObject.SetActive(true);
    //    }
    //    if(enemy.isPlayer== false)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
