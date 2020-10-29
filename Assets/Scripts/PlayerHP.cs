using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 체력을 관리하고 싶다.
// 최대체력은 3이고 태어날 때 체력은 최대체력이다.
// 화면에 표시하고 싶다.
// 충돌하면 체력이 1씩 깍인다.
// 체력이 0이 되면 사망한다.

// 최대체력
// 현재체력
// 체력 UI

public class PlayerHP : MonoBehaviour
{
    public Slider hpSlider;

    public int maxHp = 3;
    int curHp;
    
    public int Hp {
        get { return curHp; }
        set { curHp = value; hpSlider.value = curHp; }
    }


    // Start is called before the first frame update
    void Start()
    {
        hpSlider.maxValue = maxHp;
        Hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
