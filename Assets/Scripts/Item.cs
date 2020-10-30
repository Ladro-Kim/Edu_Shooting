using System;
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

    ItemManager itemManager;
    internal void RememberMe(ItemManager itemManager) // Internal = 같은 프로그램 내에서만 호출 가능. 해킹방지용...?
    {
        this.itemManager = itemManager;
    }

    void OnTriggerEnter(Collider other)
    {
        // 만약 감지된 게임오브젝트의 이름에 플레이어가 포함되어 있다면...
        // 아이템 매니저에게 인사를 하고,
        // 플레이어에게 나의 타입을 알려준다.
        // 파괴되고 싶다.
        if (other.gameObject.name.Contains("Player"))
        {
            itemManager.RecreateItem();

            PlayerHP playerHp = other.GetComponent<PlayerHP>();
            
            switch (type)
            {
                case ItemType.RESTORE_HP:
                    if (playerHp.Hp < 3)
                    {
                        playerHp.Hp++;
                    }
                    break;
                case ItemType.BULLET_POWER_UP:
                    if (GameManager.instance.bulletPower < 3)
                    {
                        GameManager.instance.bulletPower += 1;
                    }
                    break;
            }
            Destroy(gameObject);
        }



    }
}
