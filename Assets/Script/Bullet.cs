using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 enemyDir;
    Rigidbody2D rigid;
    Tower tower;

    bool istarget;
    RaycastHit2D curTarget;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        tower = GetComponentInParent<Tower>();
    }

    void FixedUpdate()
    {
        if (!istarget && tower.target)
        {
            istarget = true;
            curTarget = tower.target;
        }

        if (curTarget && curTarget.transform.gameObject.activeSelf)
        {
            enemyDir = curTarget.transform.position - transform.position;
            rigid.MovePosition(transform.position + enemyDir.normalized * 0.2f);
            float rotZ = Mathf.Atan2(enemyDir.y, enemyDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotZ - 90, Vector3.forward);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.position = transform.parent.position;
        istarget = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
