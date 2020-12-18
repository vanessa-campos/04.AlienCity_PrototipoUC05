using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletBlue;
    public GameObject bulletOrange;
    public Animator _animator;
    public Image gun1;
    public Image gun2;


    private int gunNumber = 0;
    public AudioSource soundShoot;

    private void Start()
    {
        gun1.color = new Vector4(0, 0, 0, 0);
        gun2.color = new Vector4(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Capture Gun Button, Gun Animations and Gun image
        _animator.SetInteger("Gun", gunNumber);
        if (Input.GetKeyDown(KeyCode.Tab))
        {        
            if(gunNumber == 2)
            {
                gunNumber = 0;
                gun1.color = new Vector4(0, 0, 0, 0);
                gun2.color = new Vector4(0, 0, 0, 0);
            }
            else
            {
                gunNumber++;
                if(gunNumber == 1)
                {
                    gun1.color = new Vector4(1,1,1,1);
                }
                if (gunNumber == 2)
                {
                    gun2.color = new Vector4(1, 1, 1, 1);
                }
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
