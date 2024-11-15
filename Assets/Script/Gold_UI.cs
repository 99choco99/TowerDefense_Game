using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold_UI : MonoBehaviour
{
    Text gold_text;
    private void Awake()
    {
        gold_text = GetComponent<Text>();
    }

    private void Update()
    {
        gold_text.text = "Gold : " + GameManager.instance.gold.ToString(); 
    }
}
