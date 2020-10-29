using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템의 정보를 가지고 있고 싶다.



public class Item : MonoBehaviour
{
    // type 값이 1이면 회복
    // type 값이 2이면 총알의 파워를 2로 업그레이드

    public enum ItemType
    {
        RESTORE_HP,
        BULLET_POWER_UP
    }

    public ItemType type;

    void Update()
    {
        
    }


}
