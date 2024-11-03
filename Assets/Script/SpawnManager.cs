using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] preFabs;
    List<GameObject>[] pools;
    public float coolTime = 2.0f;


    private void Awake()
    {
        pools = new List<GameObject>[preFabs.Length];

        for (int i = 0; i < preFabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    private void Update()
    {
        coolTime -= Time.deltaTime;
        if(coolTime <= 0)
        {
            GameObject enemy = Spawn(GameManager.instance.level - 1);
            enemy.transform.position = transform.position;
            coolTime = 2.0f;
        }
    }



    //Enemy »ý¼º
    public GameObject Spawn(int index)
    {
        GameObject select = null;

        foreach (GameObject enemy in pools[index])
        {
            if (!enemy.activeSelf)
            {
                select = enemy;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(preFabs[index]);
            pools[index].Add(select);
        }

        return select;
    }
}
