using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    private static ChatManager instance = null;

    public GameObject forest1;
    public GameObject forest2;
    public GameObject forest3;
    public GameObject panel;

    public GameObject tree;
    public GameObject road;

    public GameObject human;
    public GameObject changgwi;

    public Conversation human_convo;
    public Conversation chang_convo;

    List<string> human_convo_list;
    List<string> chang_convo_list;

    public Text human_txt;
    public Text chang_txt;

    public bool human_turn = true;
    public bool scene1 = false;
    public bool scene2 = false;
    public bool scene3 = false;

    public int loop_num = 1;
    public int index;

    private void Awake()
    {
        // ΩÃ±€≈Ê
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static ChatManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        human_convo = human.GetComponentInChildren<Conversation>();
        chang_convo = changgwi.GetComponentInChildren<Conversation>();

        human_convo_list = human_convo.convo;
        chang_convo_list = chang_convo.convo;

        if(loop_num == 1)
        {
            index = 3;
            loop_num++;
        }
        else if(loop_num == 2)
        {
            loop_num++;
        }
        else if(loop_num == 3)
        {
            loop_num++;
        }
        else
        {
            index = 1;
            loop_num++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Ω£1
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // scene1 Ω√¿€
            if (!scene1)
            {
                //gameObject.GetComponent<Scene1>().enabled = true;
                if (human_convo.convoIndex < index)
                {
                    PrintHumanConvo();
                }
                else
                {
                    StartCoroutine(FadeIn());
                }
            }
            // scene2 Ω√¿€
            else if (!scene2)
            {
                if (human_convo.convoIndex == index)
                {
                    PrintHumanConvo();
                }
/*                else
                {
                    StartCoroutine(FadeIn());
                }*/
            }
            // scene3 Ω√¿€
            else
            {
                scene3 = true;
            }

        }

    }
    
    public void PrintHumanConvo()
    {
        changgwi.SetActive(false);
        human.SetActive(true);
        human_txt.text = human_convo_list[human_convo.convoIndex].ToString();
        human_convo.convoIndex++;
    }

    public void PrintChanggwiConvo()
    {
        changgwi.SetActive(true);
        chang_txt.text = chang_convo_list[chang_convo.convoIndex].ToString();
        chang_convo.convoIndex++;
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

        background.SetActive(false);

        if (!scene1)
        {
            forest1.SetActive(false);
            forest2.SetActive(true);
            scene1 = true;
            changgwi.SetActive(false);
            human.SetActive(false);

            tree.SetActive(true);
            road.SetActive(true);
        }
        else if(!scene2)
        {
            forest2.SetActive(false);
            forest3.SetActive(true);
            scene2 = true;
            changgwi.SetActive(false);
            human.SetActive(false);
        }

        //StartCoroutine(FadeOut());
    }

}
