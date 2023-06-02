using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var lvl = SceneManager.GetActiveScene().buildIndex;
            if (PlayerPrefs.GetInt("level") < lvl)
                PlayerPrefs.SetInt("level", lvl);
            if(SceneManager.sceneCountInBuildSettings - 1 == lvl)
                SceneManager.LoadScene(0);
            else
            SceneManager.LoadScene(lvl + 1);
        }
    }
}
