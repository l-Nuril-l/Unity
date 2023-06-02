using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject levels;
    [SerializeField] private GameObject start;
    [SerializeField] private Button[] buttons;
    public void Play()
    {
        levels.SetActive(true);
        start.SetActive(false);
    }
    public void Back()
    {
        levels.SetActive(false);
        start.SetActive(true);
    }

    public void LoadLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("level") >= buttons.Length)
            return;

        foreach (var buttons in buttons)
        {
            buttons.interactable = false;
        }

        buttons[0].interactable = true;
        for (int i = 0; i < PlayerPrefs.GetInt("level"); i++)
        {
            buttons[i + 1].interactable = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("level", 0);
        Start();
    }
}
