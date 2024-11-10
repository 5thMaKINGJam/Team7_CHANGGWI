using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI; 
public class Scene3 : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject change_conv1;
    public GameObject change_conv2;

    public int index = 0;
    bool choice = false;

    int choice_num;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
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
                    choicePanel.SetActive(true); //보이게함
                    index = 0;
                    choice = true;
                }
            }
            else
            {
                if (choice_num == 1)
                {
                    //if (index != 0)
                    //{
                    //    change_conv1.transform.GetChild(index - 1).gameObject.SetActive(false);
                    //}
                    transform.GetChild(2).gameObject.SetActive(false);
                    change_conv1.transform.GetChild(index).gameObject.SetActive(true);
                    index++;
                    if (index >= change_conv1.transform.childCount)
                    {
                        index = 3;
                    }
                }
                else
                {
                    //if (index != 0)
                    //{
                    //    change_conv2.transform.GetChild(index - 1).gameObject.SetActive(false);
                    //}
                    transform.GetChild(2).gameObject.SetActive(false);
                    change_conv2.transform.GetChild(index).gameObject.SetActive(true);
                    index++;

                    if (index >= change_conv2.transform.childCount)
                    {
                        index = 3;
                    }
                }
            }
            /*            else
                        {
                            transform.GetChild(index).gameObject.SetActive(true);
                            index++;

                            if (index >= transform.childCount)
                            {
                                Debug.Log("다음으로 넘어가기");
                            }
                        }*/
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

}