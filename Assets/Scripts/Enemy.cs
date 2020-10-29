using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

// 아래로 이동하고 싶다.

public class Enemy : MonoBehaviour
{

    public float speed = 5f;
    public GameObject target;

    Vector3 dir;

    int luckMin = 1;
    int luckMax = 10;
    int luck = 3;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        curHp = maxHp;
        // 태어날 때 방향을 정하고 싶다.
        // 30% 확률로 플레이어를, 그 외에는 아래방향으로.
        // 10개의 숫자 범위를 만들고
        // 그 중 임의의 값 1개를 선택하고 싶다.
        // 그 확률이 30% -> 0 ~ 2를 선택하는 경우 -> 0 ~ 9 중 3 보다 작은 경우. (number < 3)
        // 플레이어 방향으로 이동한다.

        // 유니티 Random 과 시스템 Random 이 다르다. -> 
        int randNumber = Random.Range(luckMin, luckMax); // 0 은 포함, 10은 포함X
        
        if (randNumber < luck)
        {
            target = GameObject.Find("Player");

            dir = target.transform.position - transform.position;
            dir.Normalize();
        } 
        else
        {
            dir = Vector3.down;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // 살아가면서 그 방향으로 이동하고 싶다.
        // transform.LookAt(dir);
        transform.position += dir * speed * Time.deltaTime;


        // transform.Rotate(Quaternion.Euler(0, 0, 10f));
        // transform.Rotate(new Vector3(0, 0, 20f) * Time.deltaTime);


        // Destroy(gameObject, 10);

        // 태어날 때 방향을 정하고 싶다.
        // 살아가면서 그 방향으로 이동하고 싶다.
    }

    void OnCollisionEnter(Collision other)
    {
        // 시각효과를 표현하고 싶다. -> 시각효과 공장에서 시각효과를 1개 만든다.
        // 시각효과를 내 위치로 이동
        GameObject explo = Instantiate(explosion);
        explo.transform.position = transform.position;

        Destroy(explo, 1);

        // Destroy(other.gameObject);
        if (other.gameObject.name.Contains("Player"))
        {
            PlayerHP playerHp = other.gameObject.GetComponent<PlayerHP>();
            
            if (playerHp == null)
            {
                return;
            }

            --playerHp.Hp;

            if (playerHp.Hp <= 0)
            {
                GameManager.instance.gameOverUi.SetActive(true);
                Destroy(other.gameObject);
            }

        }
        else if (other.gameObject.name.Contains("Bullet"))
        {
            Destroy(other.gameObject);

            // 클레스에 바로 접근하는 것이 아니고 게임 오브젝트의 컴포넌트를 가져와서 사용!!
            ScoreManager sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
            ++sm.Score;
        }

        curHp--;
        if (curHp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StopCoroutine(ieHit());
            StartCoroutine(ieHit());
        }

         // transform 처럼 gameObject 도 그냥 가져와짐. -> 내꺼는 그냥 쓰면 됨.

        // transform.rotation = Quaternion.Slerp()

        Debug.Log("OnCollision");
    }

    // 2방을 맞으면 터지고 싶다.
    // 1방 부딛히면 번쩍 거리고 (Mesh Renderer -> Material -> 


    // 2번 부딛히면 터지고 싶다. 
    // 현재체력
    // 최대체력

    int curHp = 0;
    public int maxHp = 2;

    public MeshRenderer bodyRenderer; // 게임 오브젝트 연결하면 오브젝트의 렌더러를 그대로 가져옴.

    IEnumerator ieHit()
    {
        Material mat = bodyRenderer.material;

        Color originColor = mat.GetColor("_EmissionColor");

        // 하얗게 만들었다가
        mat.SetColor("_EmissionColor", Color.white);

        // 0.1초 후
        yield return new WaitForSeconds(0.1f);

        // 원래 색으로 복구하고싶다.
        mat.SetColor("_EmissionColor", originColor);
    }


}
