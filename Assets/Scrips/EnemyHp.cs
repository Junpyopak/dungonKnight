using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public GameObject Slime;
    Enemy enemy;
    private void Awake()
    {

    }
    void Start()
    {
        enemy = Slime.GetComponent<Enemy>();//������ �ȿ� �ִ� enemy ��ũ��Ʈ ������.
    }


    private void CheckHp()//���� ü�� ������ ��Ÿ��.
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(Slime.transform.position+Vector3.down);//�������� ��ġ�� ���� hp �� �̹��� ui�� ���� �̵�
        checkPlayer();
    }

    private void checkPlayer()
    {
         gameObject.SetActive(enemy.checkPlayerdis());
    }
}
