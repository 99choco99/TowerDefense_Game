using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    Transform nxtPoint;
    int wayNum = 0;
    public float speed = 0.1f;

    public float maxHp;
    public float hp;
    int id;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        hp = maxHp;
    }

    private void Start()
    {
        nxtPoint = GameManager.instance.Path[0];
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(nxtPoint.position, transform.position) < 0.1f)
        {
            wayNum++;
            nxtPoint = GameManager.instance.Path[wayNum];
        }
        Vector3 move = nxtPoint.position - transform.position;
        rigid.MovePosition(transform.position + move.normalized * Time.fixedDeltaTime * speed);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp -= 5;
        if (hp <= 0) { gameObject.SetActive(false); }
    }
    private void OnDisable()
    {
        wayNum = 0;
        hp = maxHp;
        nxtPoint = GameManager.instance.Path[0];
    }
}
