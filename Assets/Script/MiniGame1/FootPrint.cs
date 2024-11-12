using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FootPrint : MonoBehaviour
{
    public GameObject human_footprint;
    public GameObject changgwi_footprint;
    public Sprite h_leftStep;
    public Sprite h_rightStep;
    public Sprite c_leftStep;
    public Sprite c_rightStep;

    public List<GameObject> key = new List<GameObject>();

    public GameObject gameover;

    public float time_level;
    public string next_scene;

    float x = -8.0f;
    float y;
    float rotation = 0;
    float chang_x;
    float chang_y;
    float chang_rotation = 0;
    bool fail = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Make_FootPrint());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Make_FootPrint()
    {
        yield return new WaitForSeconds(1.0f);

        Vector3 position;
        bool start = false;
        GameObject new_footprint;

        for (int i = 0; i < 20; i++)
        {
            // 사람 발자국 생성
            if (i > 4 && i < 12)
            {
                rotation -= 20.0f;
            }
            else if (i >= 12 && i < 18)
            {
                rotation += 30.0f;
            }
            else
            {
                rotation = 0.0f;
            }

            if (i % 2 == 0)
            {
                y = 0.02f*(x + 7.0f) * (x - 2.0f)* (x - 6.0f);
                position = new Vector3(x, y, 0);
                new_footprint = Instantiate(human_footprint, position, Quaternion.Euler(0, 0, rotation), GameObject.Find("Human").transform);
                new_footprint.GetComponent<SpriteRenderer>().sprite = h_leftStep;
            }
            else
            {
                y = 0.02f * (x + 7.0f) * (x - 2.0f) * (x - 6.0f) - 0.5f;
                position = new Vector3(x, y, 0);
                new_footprint = Instantiate(human_footprint, position, Quaternion.Euler(0, 0, rotation), GameObject.Find("Human").transform);
                new_footprint.GetComponent<SpriteRenderer>().sprite = h_rightStep;
            }
            

            // 5번째부터 창귀 발자국 생성
            if(i > 3)
            {
                if (!start)
                {
                    StartCoroutine(Make_Changgwi_FootPrint());
                    start = true;
                }
                
            }

            // 다음 발자국 위치 설정
            if (i < 4 || i > 14)
            {
                x += 16.0f / 30.0f;
            }
            else
            {
                x += (16.0f / 30.0f)*2;
                
            }

            // 3번째 발자국부터 방향키 함께 생성
            if(i > 1)
            {
                
                // 발자국 위에 방향키 랜덤 생성 후 위치 조정
                int key_num = Random.Range(0, 4);
                GameObject new_key = Instantiate(key[key_num], new Vector3(0, 0, 0), Quaternion.identity, new_footprint.transform);
                new_key.transform.localPosition = new Vector3(0, 1.0f, 0);

                // 3초 동안 키 입력 여부 확인
                float time = 0.0f;
                while (time < time_level)
                {
                    time += Time.deltaTime;

                    // 오브젝트 투명도 낮춤
                    Color color = new_footprint.GetComponent<SpriteRenderer>().color;
                    color.a = color.a - 0.001f;
                    new_footprint.GetComponent<SpriteRenderer>().color = color;

                    // 성공
                    if (!new_key.activeSelf)
                    {
                        break;
                    }

                    yield return null;
                }

                // 실패
                if (new_key.activeSelf)
                {
                    new_key.SetActive(false);
                    new_footprint.SetActive(false);

                    // 실패 화면
                    gameover.SetActive(true);
                    GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
                    StartCoroutine(ChangeScene("Title"));
                    fail = true;
                    break;
                }

            }
            else
            {
                yield return new WaitForSeconds(1.0f);
            }

        }

        if (!fail)
        {
            StartCoroutine(ChangeScene(next_scene));
        }
        

    }

    IEnumerator Make_Changgwi_FootPrint()
    {
        Vector3 position;
        chang_x = x - 0.2f;
        GameObject new_chang_footprint;

        for (int i = 0; i < 10; i++)
        {
            // 발자국 위치 설정
            if (i > 2 && i < 6)
            {
                chang_rotation -= 30.0f;
            }
            else if(i >= 6)
            {
                chang_rotation += 30.0f;
            }
            else
            {
                chang_rotation = 0.0f;
            }

            if (i % 2 == 0)
            {
                chang_y = 0.02f * (chang_x + 7.0f) * (chang_x - 2.0f) * (chang_x - 6.0f);
                position = new Vector3(chang_x, chang_y, 0);
                new_chang_footprint = Instantiate(changgwi_footprint, position, Quaternion.Euler(0, 0, chang_rotation), GameObject.Find("Changgwi").transform);
                new_chang_footprint.GetComponent<SpriteRenderer>().sprite = c_leftStep;
            }
            else
            {
                chang_y = 0.02f * (chang_x + 7.0f) * (chang_x - 2.0f) * (chang_x - 6.0f) - 0.5f;
                position = new Vector3(chang_x, chang_y, 0);
                new_chang_footprint = Instantiate(changgwi_footprint, position, Quaternion.Euler(0, 0, chang_rotation), GameObject.Find("Changgwi").transform);
                new_chang_footprint.GetComponent<SpriteRenderer>().sprite = c_rightStep;
            }


            yield return new WaitForSeconds(1.0f);


            // 다음 발자국 위치 설정
            if (i < 4 || i > 14)
            {
                chang_x += 16.0f / 20.0f;
            }
            else
            {
                chang_x += (16.0f / 20.0f) * 2;

            }
        }

    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }

}
