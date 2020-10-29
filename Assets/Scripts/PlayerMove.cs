using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // 속도는 기획의 영역.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 사용자의 입력을 받고
        // 상하좌우의 방향으로
        // 이동하고 싶다.
        // 벡터 = 방향 * 크기
        // 최종위치 = 현재위치 + 방향(Direction) * 속도(Velocity) * 시간(1sec = Time.deltaTime)

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(xInput, yInput, 0f);
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
        // transform.Rotate(new Vector3(5f, 0, 0) * Time.deltaTime);

    }
}
