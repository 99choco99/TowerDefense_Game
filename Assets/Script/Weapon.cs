using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Weapon : MonoBehaviour
{
    public int weaponId;
    public float speed;
    public float damage;

    Vector3 enemyDir;
    SpriteRenderer spriter;
    Animator anim;
    Scanner sc;


    public GameObject[] weaponPreFabs;
    List<GameObject>[] weaponPools;


    private void Awake()
    {
        
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sc = GetComponentInParent<Scanner>();

        weaponPools = new List<GameObject>[weaponPreFabs.Length];

        for(int i = 0; i< weaponPreFabs.Length; i++)
        {
            weaponPools[i] = new List<GameObject>();
        }
    }

    void FixedUpdate()
    {
        switch (weaponId)
        {
            case 0:
                Arrow();
                break;
            case 1:
                break;

        }


    }


    void Arrow()
    {
        if (sc.target && Vector2.Distance(sc.target.transform.position, transform.position) <= sc.range)
        {
            anim.SetBool("Find", true);
            enemyDir = sc.target.transform.position - transform.position;
            float rotZ = Mathf.Atan2(enemyDir.y, enemyDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotZ - 180, Vector3.forward);
        }
        else
        {
            anim.SetBool("Find", false);
        }
    }

    public GameObject Attack(int towerIevel)
    {
        GameObject select = null;

        foreach (GameObject weapon in weaponPools[towerIevel])
        {
            if (!weapon.activeSelf)
            {
                select = weapon;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(weaponPreFabs[towerIevel], transform.parent);
            weaponPools[towerIevel].Add(select);
            select.transform.position = transform.position;
        }

        return select;
    }

}
