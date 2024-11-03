using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int[] killsToLevelUp;
    public int[] levelForNextStage;
    public int curStage;

    public bool isLive;        // 게임이 멈춰있는가?
    public bool stageCleared;  // 스테이지가 끝났는가?

    public int life;
    public int kill;
    public int gold;
    public int level;

    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else
        {
            if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
        }
    }

    private void Start()
    {
        Init();
        isLive = false;
        Time.timeScale = 0;
    }

    private void Update()
    {
        if(life<= 0)
        {
            GameOver();
        }

        if (killsToLevelUp[level - 1] == kill)
        {
            level++;
        }
    }


    void GameOver()
    {
        isLive = false;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        isLive = false;
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        isLive = true;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(curStage);
        Init();
        GamePause();
        curStage = SceneManager.GetActiveScene().buildIndex;
    }

    public void GameStart()
    {
        stageCleared = false;
        Init();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void NextStage()
    {
        SceneManager.LoadScene(curStage++, LoadSceneMode.Single);
        stageCleared = false;
        isLive = true;
        Time.timeScale = 1;
    }


    public void Init()
    {
        kill = 0;
        level = 1;
        life = 10;
        gold = 50;
        curStage = 0;
        Time.timeScale = 1;
        isLive = true;
        stageCleared = false;
    }
}
