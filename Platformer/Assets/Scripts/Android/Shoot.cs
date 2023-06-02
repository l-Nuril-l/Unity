using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Weapon heroWithWeapon;
    // Start is called before the first frame update
    void Start()
    {
        heroWithWeapon = FindObjectOfType<Hero>().GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootEvent()
    {
        heroWithWeapon.Shoot();
    }
}
