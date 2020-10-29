using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목적지를 향해서 이동하고 싶다.
// 목적지, Speed

public class Tail : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * Time.deltaTime * (speed - 2);
        transform.eulerAngles += new Vector3(5f, 0, 0) * Time.deltaTime;
    }

    private void OnDestroy()
    {
        
    }
}
