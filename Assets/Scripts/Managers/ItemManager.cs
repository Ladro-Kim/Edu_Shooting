using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

// 시간이 흐르다가 일정 시간이 되면
// 아이템 공장에서 아이템을 하나 만들고
// 내 위치에 가져다 놓고싶다.

public class ItemManager : MonoBehaviour
{
    public GameObject[] itemPrefebs;

    GameObject tempPrefebs;
    Item rememberItem;

    float currentTime;
    float createTime;
    public float min = 4, max = 9;

    bool isDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        isDestroyed = true;
        // 태어날 때 생성시간을 결정하고 싶다.
        // 랜덤으로
        createTime = Random.Range(min, max);

    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed)
        {
            currentTime += Time.deltaTime;
            if (currentTime > createTime)
            {
                currentTime = 0;
                int choose = Random.Range(0, itemPrefebs.Length);
                GameObject item = Instantiate(itemPrefebs[choose]);
                rememberItem = item.GetComponent<Item>();
                rememberItem.RememberMe(this);
                isDestroyed = false;
            }
        }
        else
        {
            return;
            // 만들지마
        }

        //currentTime += Time.deltaTime;
        //if (currentTime >= createTime)
        //{
        //    if (tempPrefebs == null)
        //    {
        //        int choose = Random.Range(0, itemPrefebs.Length);
        //        tempPrefebs = Instantiate(itemPrefebs[choose]);
        //        tempPrefebs.transform.position = transform.position;
        //    }
        //    else
        //    {
        //        createTime = Random.Range(min, max);
        //    }
        //    currentTime = 0;
        //}
    }

    internal void RecreateItem()
    {
        isDestroyed = true;

        // 플레이어가 아이템을 획득하였기 때문에 아이템이 파괴되었다.
        // 아이템을 다시 생성하고 싶다.
    }
}
