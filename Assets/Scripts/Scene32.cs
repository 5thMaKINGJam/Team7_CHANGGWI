using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene32 : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject change_conv1;
    public GameObject change_conv2;

    public string next_scene;
    public int index = 0;
    bool choice = false;

    int choice_num = 0;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))

        {
            //Debug.Log(index);

            if (!choice) //선택지 안 보일 때 
            {
                if (index != 0)
                {
                    transform.GetChild(index - 1).gameObject.SetActive(false);
                }
                transform.GetChild(index).gameObject.SetActive(true);
                index++;
                if (index > 2)
                {
                    choicePanel.SetActive(true);
                    index = 0;
                    choice = true;
                }
            }
            else
            {
                if (choice_num == 1)
                {
                    if (index != 0)
                    {
                        change_conv1.transform.GetChild(index - 1).gameObject.SetActive(false);
                    }

                    transform.GetChild(2).gameObject.SetActive(false);
                    change_conv1.transform.GetChild(index).gameObject.SetActive(true);
                    index++;
                    if (index > change_conv1.transform.childCount)
                    {
                        index = 2;
                        StartCoroutine(ChangeScene(next_scene));
                    }
                }
                else
                {
                    if (index != 0)
                    {
                        change_conv2.transform.GetChild(index - 1).gameObject.SetActive(false);
                    }
                    transform.GetChild(2).gameObject.SetActive(false);
                    change_conv2.transform.GetChild(index).gameObject.SetActive(true);

                    index++;

                    if (index >= change_conv2.transform.childCount)
                    {
                        index = 2;
                        StartCoroutine(ChangeScene(next_scene));
                    }
                }
                }
            }
        
    }

    public void Choice1()
    {
        choice = true;
        Debug.Log(0);
        // 1번 선택
        choicePanel.SetActive(false);
        change_conv1.SetActive(true);
        choice_num = 1;
        index = 0;
    }

    public void Choice2()
    {
        choice = true;
        Debug.Log(1);
        // 2번 선택
        choicePanel.SetActive(false);
        change_conv2.SetActive(true);
        choice_num = 2;
        index = 0;

    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }

} 

