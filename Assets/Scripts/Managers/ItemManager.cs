using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 시간이 흐르다가 일정 시간이 되면
// 아이템 공장에서 아이템을 하나 만들고
// 내 위치에 가져다 놓고싶다.

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemPrefebs;

    GameObject tempPrefebs;

    float currentTime;
    float createTime;
    public float min = 4, max = 9;

    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 생성시간을 결정하고 싶다.
        // 랜덤으로
        createTime = Random.Range(min, max);


    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= createTime)
        {
            if (tempPrefebs == null)
            {
                int choose = Random.Range(0, itemPrefebs.Length);
                tempPrefebs = Instantiate(itemPrefebs[choose]);
                tempPrefebs.transform.position = transform.position;

            }
            else
            {
                createTime = Random.Range(min, max);
            }
            currentTime = 0;


        }
    }
}
