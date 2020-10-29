using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;



// 점수를 관리하고 싶다. (증가시키고 싶다.)
// UI에 표현하고 싶다. 점수를
// 증가룰 : 적을 1기 잡으면 1점 증가.

// - 점수
// - 점수UI
// 태어날 때 최고점수를 읽어오고, 갱신할 때 저장하고 싶다.
// - 최고점수 처리를 하고싶다.
//    -> 점수가 증가했을 때 최고점수보다 높으면 최고점수를 갱신한다.
// ScoreManager를 SingleTon 으로 만들고 싶다.

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    public Text highScoreText;
    float highScore;

    public float HighScore {
        get { return highScore; }
        set 
        {
            highScore = value;
            highScoreText.text = ($"High : {highScore.ToString("N2")} 점");
            
        }
    }


    // Property. 함수를 변수처럼 쓸 수 있게 해줌.
    // public int score { get { return score; } set { score = value; } }
    public Text scoreText;
    float score;

    public float Score {
        get { return score; } 
        set { 
            score = value; 
            scoreText.text = ($"Score : {score.ToString("N2")} 점"); 
            if (score > highScore)
            {
                HighScore = score;
            }
        } 
    }

    

    // int score { get { return score; } set { } }

    // static int age;
    void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore", 0);
        // ScoreManager.age = 20; // class 가 아닌, 객체의 속성! static 이 아닐 때 : this.age;  /  static 일 때 : ScoreManager.age; (유일한 변수)
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("HighScore", HighScore);
    }

}
