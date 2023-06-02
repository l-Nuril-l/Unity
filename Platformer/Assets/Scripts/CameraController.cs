using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;


    private void Awake()
    {
        if(!player)
        {
            player = FindObjectOfType<Hero>().transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.position;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
        if (Input.GetButton("Cancel"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
