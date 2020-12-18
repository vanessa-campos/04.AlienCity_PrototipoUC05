using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletBlue;
    public GameObject bulletOrange;
    public Animator _animator;  

    private int gunNumber = 0;
    public AudioSource soundShoot;


    // Update is called once per frame
    void Update()
    {
        // Capture Gun Button, Gun Animations and Gun image
        _animator.SetInteger("Gun", gunNumber);
        if (Input.GetKeyDown(KeyCode.Tab))
        {        
            if(gunNumber == 1)
            {
                gunNumber = 0;
            }
            else
            {
                gunNumber++;
            }
        }

        // Capture Fire Button 
        if (Input.GetButtonDown("Fire1") && gunNumber == 1)
        {
            soundShoot.Play();
            ShootBlueBullet();             
        }
        if (Input.GetButtonDown("Fire1") && gunNumber == 2)
        {
            soundShoot.Play();
            ShootOrangeBullet();      
        }
    }

    void ShootBlueBullet()
    {        
        Instantiate(bulletBlue, firePoint.position, transform.rotation);
    }
    void ShootOrangeBullet()
    {
        Instantiate(bulletOrange, firePoint.position, transform.rotation);
    }
}
