using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiro : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    private static int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = gameObject.transform.right * speed;
        Destroy(gameObject, 2);
    }
}
