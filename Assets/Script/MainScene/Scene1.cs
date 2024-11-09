using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Scene1 : MonoBehaviour
{
    private bool human_turn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (ChatManager.Instance.human_convo.convoIndex == 0)
            {
                ChatManager.Instance.PrintHumanConvo();
            }
            else
            {
                StartCoroutine(FadeOut());
            }

        }
    }

    IEnumerator FadeOut()
    {
        GameObject background = ChatManager.Instance.panel;
        background.SetActive(true);
        Color color = background.GetComponent<CanvasRenderer>().GetColor();
        color.a = 50;
        background.GetComponent<CanvasRenderer>().SetColor(color);

        float time = 0.0f;
        while(color.a <= 50)
        {
            time += Time.deltaTime;

            color.a = color.a - 0.1f;
            background.GetComponent<CanvasRenderer>().SetColor(color);

            yield return null;
        }

        background.SetActive(false);
        ChatManager.Instance.forest1.SetActive(false);
        ChatManager.Instance.forest2.SetActive(true);
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        GameObject background = ChatManager.Instance.panel;
        background.SetActive(true);
        Color color = background.GetComponent<CanvasRenderer>().GetColor();
        color.a = 0;
        background.GetComponent<CanvasRenderer>().SetColor(color);

        float time = 0.0f;
        while (color.a > 50)
        {
            time += Time.deltaTime;

            color.a = color.a + 0.1f;
            background.GetComponent<CanvasRenderer>().SetColor(color);

            yield return null;
        }

        background.SetActive(false);
    }
}
