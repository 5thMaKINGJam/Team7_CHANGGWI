using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyCode;
    public bool key_input = false;

    // Update is called once per frame
    void Update()
    {
        switch (keyCode)
        {
            case 0:
                // 위
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    key_input = true;
                    SetObject();
                }
                break;

            case 1:
                // 아래
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    key_input = true;
                    SetObject();
                }
                break;

            case 2:
                // 왼쪽
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    key_input = true;
                    SetObject();
                }
                break;

            case 3:
                // 오른쪽
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    key_input = true;
                    SetObject();
                }
                break;
        }
    }

    void SetObject()
    {
        gameObject.SetActive(false);
        Color color = transform.GetComponentInParent<SpriteRenderer>().color;
        color.a = 1.0f;
        transform.GetComponentInParent<SpriteRenderer>().color = color;
    }
}
