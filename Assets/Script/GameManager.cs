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

    public bool isLive;        // ������ �����ִ°�?
    public bool stageCleared;  // ���������� �����°�?

    public int life;
    public int kill;
    public int gold;
    public int level;

    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
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
