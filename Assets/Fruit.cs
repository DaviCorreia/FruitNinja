using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float force = 10f;

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
