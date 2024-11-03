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
    SpriteRenderer spriteRenderer;


    public int range;
    public LayerMask layerMask;
    public RaycastHit2D target;

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        if (!target || !target.transform.gameObject.activeSelf || Vector2.Distance(target.transform.position, transform.position) > range) { 
            target = Physics2D.CircleCast(transform.position, range, Vector2.zero, 0, layerMask);
        }
        coolTime -= Time.deltaTime;
        if (!target.collider) {  return; }
        if (coolTime <= 0 && Vector2.Distance(target.transform.position, transform.position) <= range)
        {

            switch (towerId) {
                case 0:
                    weapon.Attack(towerLevel);
                    coolTime = 0.5f;
                    if (target.transform.position.x < transform.position.x)
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
