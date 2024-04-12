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
        enemy = Slime.GetComponent<Enemy>();//슬라임 안에 있는 enemy 스크립트 가져옴.
    }


    private void CheckHp()//현재 체력 얼마인지 나타냄.
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(Slime.transform.position+Vector3.down);//슬라임의 위치에 따라 hp 바 이미지 ui가 같이 이동
        checkPlayer();
    }

    private void checkPlayer()
    {
         gameObject.SetActive(enemy.checkPlayerdis());
    }
}
