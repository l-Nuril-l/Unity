using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject[] firstGroup;
    public GameObject[] secondGroup;
    public Activator button;
    public Material normal;
    public Material transparent;
    public bool canPush;

    private void OnTriggerEnter(Collider other)
    {
        if(canPush)
        {
            if(other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                foreach (var el in firstGroup)
                {
                    el.GetComponent<Renderer>().material = normal;
                    el.GetComponent<Collider>().isTrigger = false;
                }
                foreach (var el in secondGroup)
                {
                    el.GetComponent<Renderer>().material = transparent;
                    el.GetComponent<Collider>().isTrigger = true;
                }
                GetComponent<Renderer>().material = transparent;
                button.GetComponent<Renderer>().material = normal;
                button.canPush = true;
            }
        }
    }
}
