using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tea_Convo : MonoBehaviour
{
    public GameObject choice_panel;
    
    public GameObject convo1;
    public GameObject convo2;

    public int index = 0;
    bool first = false;
    bool second = false;
    bool third = false;
    public int choice_num;
    public string next_scene;

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
            if(first)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index++;

                if(index >= 7)
                {
                    choice_panel.SetActive(true);
                    index = 0;

                }
                
            }
            else if(second)
            {
                // 선택지 이후 대사 출력
                if(choice_num == 1)
                {
                    // 선택지 1번 경우
                    convo1.transform.GetChild(index).gameObject.SetActive(true);
                    index++;

                    if (index >= convo1.transform.childCount)
                    {
                        index = 7;
                        second = false;
                        third = true;
                    }
                }
                else
                {
                    // 선택지 2번 경우
                    convo2.transform.GetChild(index).gameObject.SetActive(true);
                    index++;

                    if (index >= convo2.transform.childCount)
                    {
                        index = 7;
                        second = false;
                        third = true;
                    }
                }
            }
            else
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index++;

                if (index >= transform.childCount)
                {
                    Debug.Log("다음으로 넘어가기");
                    index = transform.childCount - 1;
                    StartCoroutine(ChangeScene(next_scene));
                }
            }

        }
    }

    public void Choice1()
    {
        Debug.Log(0);
        // 1번 선택
        choice_panel.SetActive(false);
        convo1.SetActive(true);
        choice_num = 1;
        index = 0;
        first = false;
        second = true;
    }

    public void Choice2()
    {
        Debug.Log(1);
        // 2번 선택
        choice_panel.SetActive(false);
        convo2.SetActive(true);
        choice_num = 2;
        index = 0;
        first = false;
        second = true;
    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }
}
