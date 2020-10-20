using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    int health = 100;
    
    [SerializeField] float shootDistance = 1000f;
    [SerializeField] Transform player;
       GameObject projectile;
   public Level01Controller level01Controller;
    bool shootTime = true;
    void Start()
    {
        projectile = Resources.Load("projectiles") as GameObject;
    }
        public void TakeDamage(int _damageToTake)
    {
        health -= _damageToTake;
        Debug.Log(health);
        if(health == 0)
        {
            level01Controller.IncreaseScore(5);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= shootDistance)
        {
            transform.LookAt(player);
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }
       

        if (shootTime && Vector3.Distance(player.position, transform.position) <= shootDistance)
        {
            
            ShootPlayer();
        }

        void ShootPlayer()
        {
         

            GameObject projectiles = Instantiate(projectile) as GameObject;
            StartCoroutine(waitShoot());
            projectiles.transform.position = transform.position * 1;
            Rigidbody rb = projectiles.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 10;
            Destroy(projectiles, 5f);
        }
    }

    IEnumerator waitShoot()
    {
        shootTime = false;
        yield return new WaitForSeconds(2);
        shootTime = true;
    }
}
