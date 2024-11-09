using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject tree_text;
    public GameObject road_text;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (count >= 2)
            {
                road_text.SetActive(false);
                tree_text.SetActive(false);
            }
        }
    }

    public void tree_text()
    {
        road_text.SetActive(false);
        tree_text.SetActive(true);
        ChatManager.Instance.tree.SetActive(false);
        count++;
    }

    public void road_text()
    {
        tree_text.SetActive(false);
        road_text.SetActive(true);
        ChatManager.Instance.road.SetActive(false);
        count++;
    }
}
