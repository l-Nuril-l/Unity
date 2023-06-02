using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Hero hero;
    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponent<Hero>();
    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetMouseButtonDown(0))
        //{
        //Shoot();
        //}
    }

    public void Shoot()
    {
        var pos = shootPos.position;
        if (hero.GetComponentInChildren<SpriteRenderer>().flipX)
        {
            pos.x -= shootPos.localPosition.x * hero.transform.localScale.x * 2;
        }
        Instantiate(bullet, pos, transform.rotation);
    }
}
