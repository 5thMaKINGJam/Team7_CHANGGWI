using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tea_Convo4 : MonoBehaviour
{
    public GameObject choice_panel;

    public GameObject convo1;
    public GameObject convo2;

    public GameObject changgwi_face;

    public int index = 0;
    bool first = false;
    bool second = false;
    bool third = false;

    int choice_num;
    public string next_scene;

    bool face = false;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        first = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (first)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index++;

                if (index >= 6)
                {
                    choice_panel.SetActive(true);
                    index = 0;
                }

            }
            else if (second)
            {
/*                second = false;
                third = true;*/
            }
            else
            {
                if (!face)
                {
                    transform.GetChild(index).gameObject.SetActive(true);
                    index++;

                    if (index >= transform.childCount)
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            transform.GetChild(i).gameObject.SetActive(false);
                        }
                        face = true;

                    }
                }
                else
                {
                    if (count > 5)
                    {
                        changgwi_face.SetActive(true);

                        Debug.Log("다음으로 넘어가기");
                        index = transform.childCount - 1;
                        StartCoroutine(ChangeScene(next_scene));
                    }
                    else
                    {
                        count++;
                    }

                }

            }

        }
    }

    public void Choice1()
    {
        Debug.Log(0);
        // 1번 선택
        choice_panel.SetActive(false);
        first = false;
        second = false;
        third = true;
        index = 6;
    }

    public void Choice2()
    {
        Debug.Log(1);
        // 2번 선택
        choice_panel.SetActive(false);
        first = false;
        second = false;
        third = true;
        index = 6;
    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }
}
