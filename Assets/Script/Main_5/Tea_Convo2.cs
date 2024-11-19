using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tea_Convo2 : MonoBehaviour
{
    public GameObject choice_panel;

    public GameObject convo1;
    public GameObject convo2;

    public GameObject background;
    public Sprite background_img;
    public GameObject changgwi_face;

    public int index = 0;
    bool first = false;
    bool second = false;
    bool third = false;

    int choice_num;
    public string next_scene;

    bool face = false;

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
                // 선택지 이후 대사 출력
                if (choice_num == 1)
                {
                    // 선택지 1번 경우
                    convo1.transform.GetChild(index).gameObject.SetActive(true);
                    index++;

                    if (index >= convo1.transform.childCount)
                    {
                        index = 6;
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
                        index = 6;
                        second = false;
                        third = true;
                    }
                }
            }
            else
            {
                if (!face)
                {
                    transform.GetChild(index).gameObject.SetActive(true);
                    index++;

                    if (index >= transform.childCount)
                    {
                        for(int i = 0; i <transform.childCount; i++)
                        {
                            transform.GetChild(i).gameObject.SetActive(false);
                        }

                        for (int i = 0; i < convo1.transform.childCount; i++)
                        {
                            convo1.transform.GetChild(i).gameObject.SetActive(false);
                        }

                        for (int i = 0; i < convo2.transform.childCount; i++)
                        {
                            convo2.transform.GetChild(i).gameObject.SetActive(false);
                        }
                        face = true;
                    }
                }
                else
                {
                    // 창툭튀
                    background.GetComponent<Animator>().enabled = false;
                    background.GetComponent<UnityEngine.UI.Image>().sprite = background_img;
                    changgwi_face.SetActive(true);

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
