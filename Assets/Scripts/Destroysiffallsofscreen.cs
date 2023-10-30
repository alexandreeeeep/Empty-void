using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroysiffallsofscreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }
}
