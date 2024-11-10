using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public Slider timer;
    [SerializeField] private float timeLimit = 20f;
    [SerializeField] private GameObject TimerUI;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Slider>();
        timer.maxValue = timeLimit;
        timer.value=timeLimit;
        if (TimerUI == null)
        {
            TimerUI = gameObject;
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (timer.value > 0.0f)
        {
            timer.value-=Time.deltaTime;
        }
        else
        { 
            timer.value = 0.0f;
        }

    }

    
}
