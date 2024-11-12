using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene("Title");
    }
}
