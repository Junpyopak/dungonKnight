using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    Enemy enemy;
    private Image hp;
    [SerializeField] float curHp;
    [SerializeField] float maxHp;
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

    public void initHp()
    {
        hp = transform.Find("Image").GetComponent<Image>();
    }

    public void SetHp(float _curHp, float _maxHp)
    {
        curHp = _curHp;
        maxHp = _maxHp;
        hp.fillAmount = _curHp / _maxHp;
    }
 }
