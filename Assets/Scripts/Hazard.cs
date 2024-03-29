﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hazard : MonoBehaviour
{
    [SerializeField] private Level01Controller levelController;
    // Start is called before the first frame update
    void Start()
    {

        levelController = FindObjectOfType<Level01Controller>();

    }

    // Update is called once per frame
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelController.Damage();
            if (gameObject.tag == "Projectile")
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (gameObject.tag == "Projectile" && other.tag != "Enemy")
            {
                Destroy(gameObject);
            }
        }
        
      
        }
}
