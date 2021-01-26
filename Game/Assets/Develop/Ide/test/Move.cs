using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10;
    private void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(x, 0, z);
        vec = vec * speed;
        rigidbody.AddForce(vec);

    }
}
