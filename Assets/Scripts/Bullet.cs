using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 10;
    public Rigidbody2D _rigidbody;
    private Animator _animator;
    private AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        soundEffect = GetComponent<AudioSource>();
        _rigidbody.AddForce (new Vector3(transform.right.x * speed,0,0), ForceMode2D.Impulse);

    } 
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Enemy"))
        {
            _rigidbody.velocity = transform.right * 0;
            soundEffect.Play();
            _animator.SetTrigger("Explosion");
            Object.Destroy(gameObject, 0.5f);
        }
    }

    void Update()
    {
        Object.Destroy(gameObject, 1.5f);
    }
}

