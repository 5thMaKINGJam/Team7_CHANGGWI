using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    private float timer;
    public GameObject eye_back;
    AudioSource eye_sound;

    // Start is called before the first frame update
    void Start()
    {
        eye_sound = GetComponentInParent<AudioSource>();
        StartCoroutine(EyeEvent());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EyeEvent()
    {
        timer = 0;
        float percent = 0.0f;

        // 2ÃÊ µ¿¾È ´«µ¿ÀÚ Ä¿Áü
        while (percent < 1 && Time.timeScale == 1)
        {
            timer += Time.deltaTime;
            percent = timer / 2.0f;

            eye_back.transform.localScale = new Vector3(Mathf.Lerp(1.0f, 1.5f, percent), Mathf.Lerp(1.0f, 1.5f, percent), 0);

            yield return null;
        }

        // ´«µ¿ÀÚ È­¸é °¡¿îµ¥ °©ÅöÆ¢
        if (timer > 2.0f)
        {
            Time.timeScale = 0;
            eye_sound.Play();
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localScale = new Vector3(6.7f, 6.7f, 0);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
            GetComponentInParent<SystemManager>().fail_eye_num++;
        }
        yield return new WaitForSecondsRealtime(2.0f);

        Time.timeScale = 1;
        Destroy(this.gameObject);
        
    }

    private void OnMouseDown()
    {
        if (Time.timeScale == 1)
        {
            Debug.Log("click");
            Destroy(this.gameObject);
        }
    }
}
