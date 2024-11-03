using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public enum InfoType {  kill, level, gold}
    public InfoType type;


    private void Update()
    {
        if (GameManager.instance.level > GameManager.instance.levelForNextStage[GameManager.instance.curStage] && GameManager.instance.isLive == true)
        {
            StageClear();
        }
    }


    void StageClear()
    {
        transform.Find("StageClear").gameObject.SetActive(true);
        switch (GameManager.instance.life)
        {
            case 10:
            case 9:
            case 8:
                transform.Find("StageClear").Find("blankStar").gameObject.SetActive(false);
                break;
            case 7:
            case 6:
            case 5:
                transform.Find("StageClear").Find("blankStar").GetChild(0).gameObject.SetActive(false);
                transform.Find("StageClear").Find("blankStar").GetChild(1).gameObject.SetActive(false);
                break;
            case 4:
            case 3:
            case 2:
            case 1:
                transform.Find("StageClear").Find("blankStar").GetChild(0).gameObject.SetActive(false);
                break;
        }
        GameManager.instance.stageCleared = true;
        GameManager.instance.isLive = false;
        Time.timeScale = 0;
    }

    private void LateUpdate()
    {
        
        switch (type)
        {
            case InfoType.kill:
                break;
            case InfoType.level:
                break;
            case InfoType.gold:
                break;
        }
    }
}
