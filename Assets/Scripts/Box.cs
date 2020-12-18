using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 1.5f);
    }

    void Spawn()
    {
        Instantiate(prefab, new Vector3(7.25f, 0, -.05f), transform.rotation);
    }
}
