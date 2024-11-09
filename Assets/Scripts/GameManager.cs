using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   public static GameManager instance=null;

    [SerializeField]
    private GameObject gameOverPanel;

    [HideInInspector]
    public bool isGameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        Invoke("ShowGameOverPanel", 1f);
    }

    void ShowGameOverPanel()
    {
      gameOverPanel.SetActive(true);
    }

   
  
}
