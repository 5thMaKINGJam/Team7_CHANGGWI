using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
public class Scene3 : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject change_conv1;
    public GameObject change_conv2;
    public GameObject panel;

    public int index = 0;
    public string next_scene;

    bool choice = false;
    public int choice_num;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!choice) 
            {
                //선택지 안 보일 때 
                if (index < transform.childCount)
                {
                    if(index == 0)
                    {
                        // 첫 번째 대사일 경우
                        transform.GetChild(index).gameObject.SetActive(true);
                        index++;
                    }
                    else
                    {
                        // 두 번째 대사 이후
                        transform.GetChild(index-1).gameObject.SetActive(false);
                        transform.GetChild(index).gameObject.SetActive(true);
                        index++;
                    }
                }
                else if(index == transform.childCount)
                {
                    // 마지막 대사 이후 선택창 오픈
                    choicePanel.SetActive(true);
                }
            }
            else
            {
                if (choice_num == 1)
                {
                    if (index < change_conv1.transform.childCount)
                    {
                        if (index == 0)
                        {
                            // 첫 번째 대사일 경우
                            change_conv1.transform.GetChild(index).gameObject.SetActive(true);
                            index++;
                        }
                        else
                        {
                            // 두 번째 대사 이후
                            change_conv1.transform.GetChild(index - 1).gameObject.SetActive(false);
                            change_conv1.transform.GetChild(index).gameObject.SetActive(true);
                            index++;
                        }
                    }
                    else if (index == change_conv1.transform.childCount && change_conv1.transform.childCount != 0)
                    {
                        // 마지막 대사 이후 다음 씬
                        change_conv1.transform.GetChild(index - 1).gameObject.SetActive(false);
                        StartCoroutine(FadeIn());
                    }
                    else
                    {
                        // 대사가 없는 경우
                        StartCoroutine(FadeIn());
                    }
                }
                else if(choice_num == 2)
                {
                    if (index < change_conv2.transform.childCount)
                    {
                        if (index == 0)
                        {
                            // 첫 번째 대사일 경우
                            change_conv2.transform.GetChild(index).gameObject.SetActive(true);
                            index++;
                        }
                        else
                        {
                            // 두 번째 대사 이후
                            change_conv2.transform.GetChild(index - 1).gameObject.SetActive(false);
                            change_conv2.transform.GetChild(index).gameObject.SetActive(true);
                            index++;
                        }
                    }
                    else if (index == change_conv2.transform.childCount && change_conv2.transform.childCount != 0)
                    {
                        // 마지막 대사 이후 다음 씬
                        change_conv2.transform.GetChild(index - 1).gameObject.SetActive(false);
                        StartCoroutine(FadeIn());
                    }
                    else
                    {
                        // 대사가 없는 경우
                        StartCoroutine(FadeIn());
                    }
                }
            }
        }
    }

    public void Choice1()
    {
        // 1번 선택
        Transform transform = GameObject.Find("change_conv").transform;
        Scene3 script = GameObject.Find("change_conv").GetComponent<Scene3>();
        
        choicePanel.SetActive(false);
        change_conv1.SetActive(true);
        transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
        script.choice_num = 1;
        script.choice = true;
        script.index = 0;
    }

    public void Choice2()
    {
        // 2번 선택
        Transform transform = GameObject.Find("change_conv").transform;
        Scene3 script = GameObject.Find("change_conv").GetComponent<Scene3>();

        choicePanel.SetActive(false);
        change_conv2.SetActive(true);
        transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
        script.choice_num = 2;
        script.choice = true;
        script.index = 0;
    }

    public IEnumerator FadeIn()
    {
        Debug.Log("fadein start");
        GameObject background = panel;
        background.SetActive(true);
        Color color = background.GetComponent<Image>().color;
        color.a = 0;
        background.GetComponent<Image>().color = color;

        float time = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            time += Time.deltaTime;
            percent = time / 2.0f;

            color.a = Mathf.Lerp(0.0f, 0.7f, percent);
            background.GetComponent<Image>().color = color;

            yield return null;
        }

        SceneManager.LoadScene(next_scene);
    }

 }