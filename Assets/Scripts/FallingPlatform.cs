using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallTime;
    private Rigidbody2D _rigidbody;
    private AudioSource soundEffect;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        soundEffect = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallTime);
        }
    }

    void Fall()
    {
        _rigidbody.isKinematic = false;
        soundEffect.Play();
    }
}
