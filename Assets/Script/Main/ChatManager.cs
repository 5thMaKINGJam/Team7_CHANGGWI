using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChatManager : MonoBehaviour
{
    //private static ChatManager instance = null;

    public GameObject forest1;
    public GameObject forest2;
    public GameObject panel;

    public GameObject tree;
    public GameObject road;

    public GameObject human;
    public Conversation human_convo;

    List<string> human_convo_list;

    public Text human_txt;

    public bool scene1 = false;
    public bool scene2 = false;

    public int index;   // scene2�� �Ѿ�� ���� index
    public string next_scene;    // ���� �� �̸� 

    // Start is called before the first frame update
    void Start()
    {
        human_convo_list = human_convo.GetComponent<Conversation>().convo;

    }

    // Update is called once per frame
    void Update()
    {

        // ��1
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // scene1 ����
            if (!scene1)
            {
                // scene1 ��� ���� ������ ��� ���
                if (human_convo.convoIndex < index)
                {
                    PrintHumanConvo();
                }
                else
                {
                    // scene2�� �Ѿ��
                    StartCoroutine(FadeIn());
                    human.SetActive(false);
                }
            }
            // scene2 ����
            else if (!scene2)
            {
                if (human_convo.convoIndex < human_convo_list.Count)
                {
                    // ���� ��� ���
                    PrintHumanConvo();
                }
            }

        }

    }
    
    public void PrintHumanConvo()
    {
        human.SetActive(true);
        human_txt.text = human_convo_list[human_convo.convoIndex].ToString();
        human_convo.convoIndex++;
    }


    IEnumerator FadeOut()
    {
        Debug.Log("fadeout start");
        GameObject background = panel;
        background.SetActive(true);
        Color color = background.GetComponent<Image>().color;
        color.a = 50;
        background.GetComponent<Image>().color = color;


        while (color.a > 0)
        {
            color.a = color.a - 0.001f;
            background.GetComponent<Image>().color = color;

            yield return null;
        }

        background.SetActive(false);
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
        while (time < 2.0f)
        {
            time += Time.deltaTime;

            color.a = color.a + 0.001f;
            background.GetComponent<Image>().color = color;

            yield return null;
        }

        if (!scene1)
        {
            scene1 = true;

            forest1.SetActive(false);
            forest2.SetActive(true);

            tree.SetActive(true);
            road.SetActive(true);

            background.SetActive(false);
        }
        else if (!scene2)
        {
            scene2 = true;
            human.SetActive(false);

            SceneManager.LoadScene(next_scene);
        }

    }

}
