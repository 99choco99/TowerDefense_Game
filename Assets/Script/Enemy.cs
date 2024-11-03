using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    Scene scene;
    Rigidbody2D rigid;
    Transform nxtPoint;
    int wayNum = 0;
    public float speed = 0.1f;

    public float maxHp;
    public float hp;
    public int gold;
    int id;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        rigid = GetComponent<Rigidbody2D>();
        hp = maxHp;
    }

    private void Start()
    {
        nxtPoint = PathFinder.instance.Path[0];
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(nxtPoint.position, transform.position) < 0.1f)
        {
            PathFinding(scene.buildIndex);
        }
        Vector3 move = nxtPoint.position - transform.position;
        rigid.MovePosition(transform.position + move.normalized * Time.fixedDeltaTime * speed);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hp -= 5;
        if (hp <= 0) { 
            GameManager.instance.kill++;
            GameManager.instance.gold += gold;
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        wayNum = 0;
        hp = maxHp;
        transform.gameObject.layer = 6;
        nxtPoint = PathFinder.instance.Path[0];
    }

    void PathFinding(int sceneNum)
    {
        switch (sceneNum)
        {
            case 0:
                Stage1();
                break;
            case 1:
                Stage2(ref wayNum);
                break;
        }
    }
    


    void Stage1()
    {
        wayNum++;
        nxtPoint = PathFinder.instance.Path[wayNum];
    }

    void Stage2(ref int wayNum)
    {
        switch (wayNum)
        {
            case 0:
                wayNum = Random.Range(1, 3);
                break;
            case 1:
                wayNum = 3;
                break;
            case 2:
                wayNum = 4;
                break;
            case 3:
                wayNum = 5;
                break;
            default:
                wayNum++;
                break;
        }
        nxtPoint = PathFinder.instance.Path[wayNum];
    }
}
