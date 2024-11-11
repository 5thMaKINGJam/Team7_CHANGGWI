using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject tree_text;
    public GameObject road_text;

    bool road = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log("click something");
        Debug.Log(clickedObject.name);

        if (road)
        {
            road_text.SetActive(false);
            tree_text.SetActive(false);
            GameObject.Find("ChatManager").GetComponent<ChatManager>().human.SetActive(false);

            StartCoroutine(GameObject.Find("ChatManager").GetComponent<ChatManager>().FadeIn());
        }

        if (clickedObject.name == "tree")
        {
            road_text.SetActive(false);
            tree_text.SetActive(true);
            //GameObject.Find("ChatManager").GetComponent<ChatManager>().road.SetActive(false);
            GameObject.Find("ChatManager").GetComponent<ChatManager>().tree.SetActive(false);
        }
        else if (clickedObject.name == "road")
        {
            tree_text.SetActive(false);
            road_text.SetActive(true);
            GameObject.Find("ChatManager").GetComponent<ChatManager>().road.SetActive(false);
            Destroy(GameObject.Find("ChatManager").GetComponent<ChatManager>().tree);
            road = true;
        }
    }
}
