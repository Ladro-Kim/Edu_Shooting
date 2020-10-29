using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 위로 이동하고 싶다.
// 이동, Speed
public class Bullet : MonoBehaviour
{

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

}
