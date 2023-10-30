using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing : MonoBehaviour
{

    private GameObject player;
    [Header("self")]
    public float Movespeed;
    public Rigidbody2D rb;
    public float bulletSpread;
    [Header("Target")]
    public string Target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Target);
        Vector3 direction = player.transform.position - rb.transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * Movespeed;
        //Debug.Log(rb.velocity);
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
    void FixedUpdate()
    {
        if (rb.position.y > 30 || rb.position.y < -30 || rb.position.x > 30 || rb.position.x < -30)
        {
            Destroy(this.gameObject);
        }
    }
}
