using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RightHand : MonoBehaviour
{
    public float timeLimit = 15f;
    public string next_scene;

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
        currentAngle = transform.eulerAngles.z;
        InvokeRepeating("WidenRotate", 1f, widenInterval);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inputAllowed)
        {
            // �÷��̾ �Է��ϸ� �� �����
            if (!hasStarted)
            {
                hasStarted = true;
            }
            transform.Rotate(Vector3.forward * playerAngle);
            currentAngle = transform.eulerAngles.z;
        }

        if (currentAngle >= 90.0f && timeLimit > 0 && hasStarted == true)
        {
            //�̱�
            inputAllowed = false;
            Pray();
            StartCoroutine(ChangeScene(next_scene));
        }

        if (timeLimit <= 0)
        {
            GameManager.instance.SetGameOver();
        }
        timeLimit -= Time.deltaTime;

    }

    void WidenRotate()
    {
        // �÷��̾� �Է��� ���� �� �� ������
        if (currentAngle < 90.0f && currentAngle > 0.0f && timeLimit >= 0)
        {
            if (currentAngle <= 30.0f && currentAngle - widenAngle[0] > 0.0f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[0]);
                currentAngle = transform.eulerAngles.z;
            }
            else if (currentAngle <= 60.0f && currentAngle - widenAngle[0] > 0.0f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[1]);
                currentAngle = transform.eulerAngles.z;
            }
            else if (currentAngle < 90.0f && currentAngle - widenAngle[0] > 0.0f)
            {
                transform.Rotate(-Vector3.forward * widenAngle[2]);
                currentAngle = transform.eulerAngles.z;
            }

        }

    }
    void Pray()
    {
        transform.position = new Vector3(1.5f, -3f, 0);
    }


    IEnumerator ChangeScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);

        // �� ��ȯ
        SceneManager.LoadScene(sceneName);
    }

}
