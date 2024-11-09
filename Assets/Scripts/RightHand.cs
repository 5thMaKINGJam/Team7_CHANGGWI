using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightHand : MonoBehaviour
{
    public float timeLimit = 20f;

    private bool hasStarted = false;
    [SerializeField]
    private bool inputAllowed = true;

    [SerializeField]
    private float playerAngle = 3f;

    [SerializeField]
    private float currentAngle;

    [SerializeField]
    private float[] widenAngle = { 3f, 4f, 5f };

    [SerializeField]
    private float widenInterval = 1f;

    void Start()
    {
        InvokeRepeating("WidenRotate", 1f, widenInterval);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inputAllowed)
        {
            if (!hasStarted)
            {
                hasStarted = true;
            }
            transform.Rotate(Vector3.forward * playerAngle);
            currentAngle = transform.eulerAngles.z;
        }

        if (currentAngle>=180f && timeLimit > 0 && hasStarted == true)
                {
            //이김
            inputAllowed = false;
            Pray();
            Time.timeScale = 0f;
                    //SceneManager.LoadScene("다음스토리");
                }
        
        if (timeLimit <= 0)
        {
            GameManager.instance.SetGameOver();
        }
        timeLimit -= Time.deltaTime;

    }

    void WidenRotate()
    {
        if (currentAngle < 180f && timeLimit>=0)
        {
            if (currentAngle < 100f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[0]);
                currentAngle = transform.eulerAngles.z;
            }
            else if (currentAngle < 135f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[1]);
                currentAngle = transform.eulerAngles.z;
            }
            else if (currentAngle < 180f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[2]);
                currentAngle = transform.eulerAngles.z;
            }

        }

    }
    void Pray()
    {
        transform.position = new Vector3(-1.5f, -1f, 0);
    }


}
