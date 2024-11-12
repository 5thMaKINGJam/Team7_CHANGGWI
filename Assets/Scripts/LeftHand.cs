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
        currentAngle = transform.eulerAngles.z;
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

            transform.Rotate(-Vector3.forward * playerAngle);
            currentAngle = transform.eulerAngles.z;
        }      

        if (currentAngle <= 270.0f && timeLimit > 0 && hasStarted == true)
        {
            // ¿Ã±Ë
            inputAllowed = false;
            Pray();
        }
        if (timeLimit<=0)
        {
            GameManager.instance.SetGameOver();
        }
        timeLimit -= Time.deltaTime;

    }
        


    void WidenRotate()
    {
        // «√∑π¿ÃæÓ ¿‘∑¬¿Ã æ¯¿ª ∂ß º’ π˙æÓ¡¸
        if (currentAngle > 270.0f && currentAngle < 360.0f && timeLimit >= 0)
        {
            if (currentAngle >= 330.0f && currentAngle + widenAngle[0] < 360.0f)
            {
                transform.Rotate(Vector3.forward * widenAngle[0]);
                currentAngle = transform.eulerAngles.z;
            }
            else if (currentAngle >= 300.0f && currentAngle + widenAngle[0] < 360.0f)
            {
                transform.Rotate(Vector3.forward * widenAngle[1]);
                currentAngle = transform.eulerAngles.z;
            }
            else if (currentAngle > 270.0f && currentAngle + widenAngle[0] < 360.0f)
            {
                transform.Rotate(Vector3.forward * widenAngle[2]);
                currentAngle = transform.eulerAngles.z;
            }

        }
    }
    void Pray()
    {
        transform.position = new Vector3(-1.5f, -3f, 0f);
    }

    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);

        // æ¿ ¿¸»Ø
        SceneManager.LoadScene(sceneName);
    }


}
