using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SystemManager : MonoBehaviour
{
    public GameObject eye;
    public Text time_text;

    public GameObject gameover;
    public GameObject gameclear;

    public int fail_eye_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MainSystem());
    }

    private void Update()
    {
        // 게임 실패
        if (fail_eye_num >= 3)
        {
            CancelInvoke("MakeEyes");
            Time.timeScale = 0;
            gameover.SetActive(true);
        }
    }

    IEnumerator MainSystem()
    {
        bool start = false;

        float timer = 20.0f;
        while(timer >= 0 )
        {
            timer -= Time.deltaTime;
            time_text.text = timer.ToString("F2");

            if (!start)
            {
                InvokeRepeating("MakeEyes", 0, 0.5f);
                start = true;
            }

            if(timer < 2.0f)
            {
                CancelInvoke("MakeEyes");
            }

            yield return null;
        }
        time_text.text = "0.00";
        gameclear.SetActive(true);

    }

    void MakeEyes()
    {
        float x;
        float y;
        Vector3 position;

        x = Random.Range(-7, 7);
        y = Random.Range(-3, 3);
        position = new Vector3(x, y, 0);

        Instantiate(eye, position, Quaternion.identity, GameObject.Find("Eyes").transform);
    }
}
