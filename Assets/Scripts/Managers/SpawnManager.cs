using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간이 흐르다가 생성시간이 되면(일정시간이 되면)
// 적 공장에서 1개를 만들어서
// 랜덤한 스폰 위치목록에 가져다 놓고싶다.
public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnList;

    public GameObject enemyPref;

    int spawnNumber = 3;

    public float spawnTime = 0;

    public float currentTime = 0;

    int randomIndex;



    // Start is called before the first frame update
    void Start()
    {
        // enemy = (GameObject) Resources.Load("Prefebs/Enemy");
        spawnTime = Random.Range(0, spawnNumber);
        randomIndex = (int)spawnTime;
    }

    int latestChoose;

    // Update is called once per frame
    void Update()
    {
        int choose = Random.Range(0, spawnList.Length);
        
        if (choose == latestChoose)
        {
            choose += 1;
            if(choose >= spawnList.Length)
            {
                choose = 0;
            }
        }

        currentTime += Time.deltaTime;

        latestChoose = choose;

        //

        currentTime += Time.deltaTime;

        if (currentTime >= spawnTime)
        {
            // 만약 게임오버가 되지 않았다면.
            // 방법1. 플레이어가 존재한다면
            //         -> 플레이어 게임오브젝트를 찾은 후에 그것이 Null 이 아니라면,
            // 방법2. GameOverUi 가 꺼져있다면
            if (GameObject.Find("Player") != null)
            {
                GameObject enemy = GameObject.Instantiate(enemyPref);

                enemy.transform.position = spawnList[latestChoose].transform.position;
                // Destroy(enemy, 10);
                currentTime = 0;
                spawnTime = Random.Range(1, spawnList.Length);
            }

            if (GameManager.instance.gameOverUi.activeSelf == false)
            {

            }

        }
    }
}
