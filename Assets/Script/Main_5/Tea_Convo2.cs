using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tea_Convo2 : MonoBehaviour
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

    bool face = false;

    // Start is called before the first frame update
    void Start()
    {
        first = true;
        second = false;
        third = false;
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
                    first = false;
                    second = true;
                    index = 0;

                }

            }
            else if (second)
            {
                // ������ ���� ��� ���
                if (choice_num == 1)
                {
                    // ������ 1�� ���
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
                    // ������ 2�� ���
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
                        face = true;
                        
                    }
                }
                else
                {
                    changgwi_face.SetActive(true);

                    Debug.Log("�������� �Ѿ��");
                    index = transform.childCount - 1;
                    StartCoroutine(ChangeScene("MiniGame1(2)"));
                }
                
            }

        }
    }

    public void Choice1()
    {
        Debug.Log(0);
        // 1�� ����
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
        // 2�� ����
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

        // �� ��ȯ
        SceneManager.LoadScene(sceneName);
    }
}