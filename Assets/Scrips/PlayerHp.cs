using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHp : MonoBehaviour
{
    Player player;
    private Image hp;
    [Header("플레이어 체력바")]
    [SerializeField] float curHp = 15f;
    [SerializeField] float maxHp = 30f;
    TextMeshPro hpText;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void SetPlayer(Player _player)
    {
        player = _player;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    private void Damage()
    {

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
