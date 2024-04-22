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
    //    enemy = Slime.GetComponent<Enemy>();//슬라임 안에 있는 enemy 스크립트 가져옴.
    //}

    public void SetEnemy(Enemy _enemy)
    {
        enemy = _enemy;
    }

    //private void CheckHp()//현재 체력 얼마인지 나타냄.
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        //checkPlayer();
        transform.position = Camera.main.WorldToScreenPoint(enemy.transform.position+Vector3.down);//슬라임의 위치에 따라 hp 바 이미지 ui가 같이 이동
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
