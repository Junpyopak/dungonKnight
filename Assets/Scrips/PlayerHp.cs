using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHp : MonoBehaviour
{
    [Header("�÷��̾� ü�¹�")]
    Slider playerHp;
    [SerializeField] float curHp = 10f;
    [SerializeField] float maxHp = 50f;
    TextMeshPro hpText;
    // Start is called before the first frame update
    void Start()
    {
        playerHp = transform.Find("Hp").GetComponent<Slider>();
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
