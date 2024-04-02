using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    bool isGround = false;
    BoxCollider2D collision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        collision = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGround = true;
        }
    }
}
