using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject gameOverUi;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRestart()
    {
        print("OnClickRestart");
        SceneManager.LoadScene("Shooting");
    }

    public void OnClickExit()
    {
        Application.Quit();
        print("OnClickExit");
    }


}
