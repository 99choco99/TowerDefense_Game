using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public RaycastHit2D[] targets;
    public int range;
    public LayerMask layerMask;

    public RaycastHit2D target;
    RaycastHit2D tempTarget;


    private void FixedUpdate()

    {
        if (!target || !target.transform.gameObject.activeSelf || Vector2.Distance(target.transform.position, transform.position) > range)
        {
            Aiming();
        }
    }


    void Aiming()
    {
        target = Physics2D.CircleCast(transform.position, range, Vector2.zero, 0, layerMask);
    }

}
