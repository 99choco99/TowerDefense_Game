using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    Text Hp_Text;
    private void Awake()
    {
        Hp_Text = GetComponent<Text>();
    }

    private void Update()
    {
        Hp_Text.text = "Life : " + GameManager.instance.life.ToString();
    }
}
