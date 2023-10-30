using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesRandomly : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer;
    [Header("Direction")]
    public bool movesToLeft;
    public bool rotate90;
    public float Spread;
    [Header("Speed")]
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        if (movesToLeft)
        {
            rb.velocity = new Vector2(Random.Range(-speed, -speed/2), Random.Range(-Spread, Spread));
        }
        else
        {
            rb.velocity = new Vector2(Random.Range(speed/2, speed), Random.Range(-Spread, Spread));
        }
        if (rotate90)
        {
            if (movesToLeft)
            {
                rb.velocity = new Vector2(Random.Range(-Spread,Spread), Random.Range(-speed, -speed/2));
            }
            else
            { rb.velocity = new Vector2(Random.Range(-Spread, Spread), Random.Range(speed/2, speed)); }
        }

    }

    void Awake()//when awake gets the ridged body
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 100 || transform.position.x < -17)
        {
            Destroy(this.gameObject);
        }
    }
}
