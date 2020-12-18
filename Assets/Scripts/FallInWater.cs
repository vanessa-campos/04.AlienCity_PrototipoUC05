using System.Collections;
using UnityEngine;

public class FallInWater : MonoBehaviour
{
    private ControlMessage CM;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controlMessageObject = GameObject.FindWithTag("ControlMessage");
        if (controlMessageObject != null)
        {
            CM = controlMessageObject.GetComponent<ControlMessage>();
        }
    }

    [System.Obsolete]
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CM.GameOver();
        }
        Destroy(other.gameObject);
    }
}
