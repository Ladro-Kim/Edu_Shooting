using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// 플레이어가 마우스 왼쪽 버튼을 누르면
// 총알공장에서 총알을 하나 만들고,
// 총구 위치에 가져다 좋고 싶다.

public class PlayerFire : MonoBehaviour
{
    // 총알공장, 총구위치, 총알
    public GameObject bulletFactory;
    public GameObject firePosition;

    // Start is called before the first frame update
    void Start()
    {
        bulletFactory = (GameObject) Resources.Load("Prefebs/Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePosition.transform.position;
            // bullet.transform.up = transform.up;
            Destroy(bullet, 5);

        };
    }
}
