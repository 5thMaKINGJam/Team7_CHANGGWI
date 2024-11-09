using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FootPrint : MonoBehaviour
{
    public GameObject human_footprint;
    public GameObject changgwi_footprint;
    public List<GameObject> key = new List<GameObject>();

    public GameObject gameover;
    public GameObject gameclear;

    float x = -8.0f;
    float y;
    float chang_x;
    float chang_y;

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

        for(int i = 0; i < 20; i++)
        {
            // ��� ���ڱ� ����
            if(i % 2 == 0)
            {
                y = 0.02f*(x + 7.0f) * (x - 2.0f)* (x - 6.0f);
            }
            else
            {
                y = 0.02f * (x + 7.0f) * (x - 2.0f) * (x - 6.0f) - 0.5f;
            }
            position = new Vector3(x, y, 0);
            GameObject new_footprint = Instantiate(human_footprint, position, Quaternion.identity, GameObject.Find("Human").transform);

            // 5��°���� â�� ���ڱ� ����
            if(i > 3)
            {
                if (!start)
                {
                    StartCoroutine(Make_Changgwi_FootPrint());
                    start = true;
                }
                
            }

            // ���� ���ڱ� ��ġ ����
            if (i < 4 || i > 14)
            {
                x += 16.0f / 30.0f;
            }
            else
            {
                x += (16.0f / 30.0f)*2;
                
            }

            // 3��° ���ڱ����� ����Ű �Բ� ����
            if(i > 1)
            {
                
                // ���ڱ� ���� ����Ű ���� ���� �� ��ġ ����
                int key_num = Random.Range(0, 4);
                GameObject new_key = Instantiate(key[key_num], new Vector3(0, 0, 0), Quaternion.identity, new_footprint.transform);
                new_key.transform.localPosition = new Vector3(0, 1.0f, 0);

                // 3�� ���� Ű �Է� ���� Ȯ��
                float time = 0.0f;
                while (time < 2.0f)
                {
                    time += Time.deltaTime;

                    // ������Ʈ ���� ����
                    Color color = new_footprint.GetComponent<SpriteRenderer>().color;
                    color.a = color.a - 0.001f;
                    new_footprint.GetComponent<SpriteRenderer>().color = color;

                    // ����
                    if (!new_key.activeSelf)
                    {
                        break;
                    }

                    yield return null;
                }

                // ����
                if (new_key.activeSelf)
                {
                    new_key.SetActive(false);
                    new_footprint.SetActive(false);

                    // ���� ȭ��
                    gameover.SetActive(true);
                    break;
                }

            }
            else
            {
                yield return new WaitForSeconds(2.0f);
            }

            yield return new WaitForSeconds(0.5f);
        }

        gameclear.SetActive(true);

    }

    IEnumerator Make_Changgwi_FootPrint()
    {
        Vector3 position;
        chang_x = x - 0.2f;

        for (int i = 0; i < 10; i++)
        {
            // ���ڱ� ��ġ ����
            if (i % 2 == 0)
            {
                chang_y = 0.02f * (chang_x + 7.0f) * (chang_x - 2.0f) * (chang_x - 6.0f);
            }
            else
            {
                chang_y = 0.02f * (chang_x + 7.0f) * (chang_x - 2.0f) * (chang_x - 6.0f) - 0.5f;
            }

            position = new Vector3(chang_x, chang_y, 0);
            GameObject new_chang_footprint = Instantiate(changgwi_footprint, position, Quaternion.identity, GameObject.Find("Changgwi").transform);


            yield return new WaitForSeconds(2.0f);


            // ���� ���ڱ� ��ġ ����
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

}
