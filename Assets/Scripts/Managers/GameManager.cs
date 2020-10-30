using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject BG;

    public int bulletPower = 1;


    // 적을 10마리 파괴할 때 마다 레벨 1 증가.
    // 배경스크롤 속도가 증가.
    // - 레벨
    // - 누적 파괴수
    // - 죽여야 할 적의 수

    int level;
    public Text textLevel;
    public int Level 
    { 
        get { return level; } 
        set 
        {
            level = value;
            textLevel.text = $"{level}";
        }
    }
    int killCount = 0;
    public int KillCount 
    { 
        get 
        { 
            return killCount; 
        } 
        set 
        {
            killCount = value;
            while (killCount >= maxKillCount)
            {
                Level++;
                killCount -= maxKillCount;
                BG.GetComponent<BG>().Speed = level * 0.1f;
            }
        }
        // 사용자의 누적값을 없애지 않는다.
    }

    public int maxKillCount = 10;


    private void Awake()
    {
        instance = this;
    }

    public GameObject gameOverUi;

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        gameOverUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("Shooting");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }


}
