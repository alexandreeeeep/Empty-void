using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TimeTime;
    private float timer;
    void Start()
    {
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > TimeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
