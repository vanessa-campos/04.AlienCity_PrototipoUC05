using System.Collections;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public AudioSource saw;
    public AudioSource explosion;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerController player;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        saw.Play();
        _rigidbody.velocity = new Vector2(-6, Random.Range(4, -2));

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<PlayerController>();
        }
    }
    
    void Update()
    {
        Object.Destroy(gameObject, 3);
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.CompareTag("Player"))
        {            
            player.SubtractsLife(); 
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            _rigidbody.velocity = transform.right * 0;
            explosion.Play();
            _animator.SetTrigger("Explosion");
            Object.Destroy(gameObject, 0.5f);
        }
    }
}
