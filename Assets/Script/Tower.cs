using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    public int towerLevel;
    public int towerId;
    public float coolTime;
    Weapon weapon;
    Scanner sc;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
        sc = GetComponent<Scanner>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        coolTime -= Time.deltaTime;
        if (!sc.target) { return; }
        if (coolTime <= 0 && Vector2.Distance(sc.target.transform.position, transform.position) <= sc.range)
        {
            switch (towerId) {
                case 0:
                    weapon.Attack(towerLevel);
                    coolTime = 0.5f;
                    if (sc.target.transform.position.x < transform.position.x)
                    {
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipX = true;
                    }
                    break;
                case 1:
                    weapon.Attack(towerLevel);
                    coolTime = 0.5f;
                    break;
            }
        }
    }
}
