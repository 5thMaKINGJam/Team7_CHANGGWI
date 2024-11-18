using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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

    public int index;   // scene2로 넘어가는 기준 index
    public string next_scene;    // 다음 씬 이름 

    // Start is called before the first frame update
    void Start()
    {
        human_convo_list = human_convo.GetComponent<Conversation>().convo;

    }

    // Update is called once per frame
    void Update()
    {

        // 숲1
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // scene1 시작
            if (!scene1)
            {
                // scene1 대사 끝날 때까지 대사 출력
                if (human_convo.convoIndex < index)
                {
                    PrintHumanConvo();
                }
                else
                {
                    // scene2로 넘어가기
                    StartCoroutine(FadeIn());
                    human.SetActive(false);
                }
            }
            // scene2 시작
            else if (!scene2)
            {
                if (human_convo.convoIndex < human_convo_list.Count)
                {
                    // 다음 대사 출력
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

        if (scene1)
        {
            human.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
        else
        {
            // 한 대사 마다 y 위치 60씩 감소
            human.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, human.GetComponent<RectTransform>().anchoredPosition.y - 60, 0);
        }
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
        float percent = 0.0f;

        while (percent < 1)
        {
            time += Time.deltaTime;
            percent = time / 2.0f;

            color.a = Mathf.Lerp(0.0f, 0.7f, percent);
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
