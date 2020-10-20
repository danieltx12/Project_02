using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour


{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] Transform grappleOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] float grappleDistance = 30f;
    [SerializeField] GameObject visualFeedback;
    [SerializeField] int weaponDamage = 50;
    [SerializeField] LayerMask hitLayers;
    [SerializeField] GameObject player;
    [SerializeField] float grappleSpeed = 20f;
    [SerializeField] PlayerMovement playerMovement;
    public LineRenderer grappleLineRenderer;
    public float grappleWidth = 0.1f;
    public float grappleMaxLength = 5f;

    RaycastHit objectHit;
    RaycastHit grappleHit;
    bool grappleCheck = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GrapplePoint();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Grapple();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (grappleCheck)
            {
                playerMovement.velReset();
                grappleCheck = false;
                grappleLineRenderer.enabled = false;
            }
        }
    }

    void GrapplePoint()
    {
        Vector3 rayDirection = cameraController.transform.forward;
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.red, 1f);
        Physics.Raycast(rayOrigin.position, rayDirection, out grappleHit, grappleDistance);


    }
    void Grapple()
{
        Vector3 rayDirection = cameraController.transform.forward;
        if (Physics.Raycast(rayOrigin.position, rayDirection, grappleDistance))
        {
            grappleCheck = true;
            Vector3[] initGrapplePositions = new Vector3[2] { grappleOrigin.position, grappleHit.point };
            grappleLineRenderer.SetPositions(initGrapplePositions);
            grappleLineRenderer.SetWidth(grappleWidth, grappleWidth);
            grappleLineRenderer.enabled = true;
            Vector3 moveVector = grappleHit.point - player.transform.position;
            player.GetComponent<CharacterController>().Move(moveVector * grappleSpeed * Time.deltaTime);
            Debug.Log("Grappled!");

        }
        
    }


    void Shoot()
    {
        Vector3 rayDirection = cameraController.transform.forward;
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.blue, 1f);

        if(Physics.Raycast(rayOrigin.position, rayDirection, out objectHit, shootDistance, hitLayers))
        {
            Debug.Log("You hit the " + objectHit.transform.name);
            visualFeedback.SetActive(true);
            visualFeedback.transform.position = objectHit.point;
            StartCoroutine(MoveBack());
            EnemyShooter enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyShooter>();
            if(enemyShooter != null)
            {
                enemyShooter.TakeDamage(weaponDamage);
            }
        }
        else
        {
            Debug.Log("Miss");
        }
    }

    IEnumerator MoveBack()
    {
        yield return new WaitForSeconds(1);
        visualFeedback.SetActive(false);
    }
}
