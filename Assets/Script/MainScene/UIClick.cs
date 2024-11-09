using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIClick : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log("click something");
        Debug.Log(clickedObject.name);
        if (clickedObject.name == "tree")
        {
            Debug.Log("correct");
            road_text.SetActive(false);
            tree_text.SetActive(true);
            ChatManager.Instance.tree.SetActive(false);
            count++;
        }
        else if (clickedObject.name == "road")
        {
            Debug.Log("correct");
            tree_text.SetActive(false);
            road_text.SetActive(true);
            ChatManager.Instance.road.SetActive(false);
            count++;
        }

    }
}
