using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// 위로 스크롤 이동하고 싶다.
// 속도
// Offset Y
//  -> 쉐이더의 내용, 쉐이더는 머티리얼이 가지고 있음. 머티리얼은 매시렌더러가 가지고 있음.

public class BG : MonoBehaviour
{
    MeshRenderer mr;
    Material mt;

    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        // 본체에게 메시렌더러를 가져오고 싶다.
        // offset 은 머티리얼이 가지고 있었음.
        mr = GetComponent<MeshRenderer>();
        mt = mr.material;
    }

    // Update is called once per frame
    void Update()
    {
        mt.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
