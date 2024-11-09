using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    private float timer;
    public GameObject eye_back;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EyeEvent());
    }

    // Update is called once per frame
    void Update()
    {
/*        timer += Time.deltaTime;
        transform.localScale = new Vector3(transform.localScale.x + 0.001f, transform.localScale.y + 0.001f, 0);

        if (timer > 2.0f)
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localScale = new Vector3(7, 7, 0);
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(this.gameObject);
            }
        }*/

    }

    IEnumerator EyeEvent()
    {
        timer = 0;

        // 2ÃÊ µ¿¾È ´«µ¿ÀÚ Ä¿Áü
        while(timer < 2.0f && Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            eye_back.transform.localScale = new Vector3(eye_back.transform.localScale.x + 0.001f, eye_back.transform.localScale.y + 0.001f, 0);

            yield return null;
        }

        // ´«µ¿ÀÚ È­¸é °¡¿îµ¥ °©ÅöÆ¢
        if(timer > 2.0f)
        {
            Time.timeScale = 0;
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localScale = new Vector3(7, 7, 0);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
            GetComponentInParent<SystemManager>().fail_eye_num++;
        }

        yield return new WaitForSecondsRealtime(2.0f);

        Time.timeScale = 1;
        Destroy(this.gameObject);
        
    }

    private void OnMouseDown()
    {
        Debug.Log("click");
        Destroy(this.gameObject);
    }
}
