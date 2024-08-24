using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float coolTime = 2.0f;
    private void Update()
    {
        coolTime -= Time.deltaTime;
        if(coolTime <= 0)
        {
            GameObject enemy = GameManager.instance.pool.Spawn(0);
            enemy.transform.position = transform.position;
            coolTime = 2.0f;
        }
    }
}
