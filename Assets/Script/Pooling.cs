using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public GameObject[] preFabs;
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[preFabs.Length];

        for(int i = 0; i< pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Spawn(int index)
    {
        GameObject select = null;

        foreach (GameObject enemy in pools[index])
        {
            if(!enemy.activeSelf)
            {
                select = enemy;
                select.SetActive(true);
                break;
            }
        }

        if(!select)
        {
            select = Instantiate(preFabs[index]);
            pools[index].Add(select);
        }

        return select;
    }
}
