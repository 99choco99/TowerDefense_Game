using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        GameManager.instance.life--;
    }
}
