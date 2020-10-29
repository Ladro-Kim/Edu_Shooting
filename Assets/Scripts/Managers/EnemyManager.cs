using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간이 흐르다가 생성시간이 되면(일정시간이 되면)
// 적 공장에서 1개를 만들어서
// 내 위치에 가져다 놓고싶다.
public class EnemyManager : MonoBehaviour
{

    public GameObject enemyPref; // 프리펩
    public GameObject spawnPos;

    float randomMin = 0.5f;
    float randomMax = 3f;

    public float spawnTime = 0;

    public float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // enemy = (GameObject) Resources.Load("Prefebs/Enemy");
        spawnTime = Random.Range(randomMin, randomMax);

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTime)
        {
            // Instantiate(enemyPref).transform.position = spawnPos.transform.position;
            
            GameObject enemy = GameObject.Instantiate(enemyPref);
            enemy.transform.position = spawnPos.transform.position;
            // Destroy(enemy, 10);
            currentTime = 0;
            spawnTime = Random.Range(randomMin, randomMax);
        }
        
        


    }
}
