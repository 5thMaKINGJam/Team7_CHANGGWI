using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeftHand : MonoBehaviour
{
    public float timeLimit = 20f;

    private bool hasStarted = false;
    private bool inputAllowed = true;

    [SerializeField] private TimeBar timeBar;

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
        //if(timeBar == null)
        //{
        //    timeBar = GetComponent<TimeBar>();
        //}
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

        timeLimit -= Time.deltaTime;

        if ((currentAngle>= 180f) && timeLimit>0 && hasStarted == true)
        {
            inputAllowed = false;
            Pray();
            //Time.timeScale = 0f;
            //SceneManager.LoadScene("다음스토리");
            StartCoroutine(ChangeScene("Main(2)"));
        }
        if(timeLimit<=0)
        {
            GameManager.instance.SetGameOver();
        }
        
    }
        


    void WidenRotate()
    {
        if (currentAngle < 360f && timeLimit>=0)
        {
            if (currentAngle < 280f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[0]);
                currentAngle = transform.eulerAngles.z;
                
            }
            else if (currentAngle < 315f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[1]);
                currentAngle = transform.eulerAngles.z;
             
            }
            else if (currentAngle < 360f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[2]);
                currentAngle = transform.eulerAngles.z;
            }
        }
    }
    void Pray()
    {
        transform.position = new Vector3(0f, -1f, 0f);
        //Time.timeScale = 0f;
    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);

        // 씬 전환
        SceneManager.LoadScene(sceneName);
    }


}
