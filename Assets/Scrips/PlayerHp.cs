using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [Header("플레이어 체력바")]
    Slider playerHp;
    [SerializeField] float curHp = 10f;
    [SerializeField] float maxHp = 50f;
    // Start is called before the first frame update
    void Start()
    {
        playerHp.value = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Hpbar()
    {

    }
    private void Damage()
    {

    }
}
