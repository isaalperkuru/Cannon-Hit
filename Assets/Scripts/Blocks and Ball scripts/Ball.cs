using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= -13 || transform.position.y >= 15)
            Destroy(gameObject);
    }
}
