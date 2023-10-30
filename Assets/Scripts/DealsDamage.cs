using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamage : MonoBehaviour
{

    public bool diesOnHit;
    public GameObject SpawnOnCollition;
    private ParticleSystem _CachedSystem;
    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        moveMent hit = collision.gameObject.GetComponent<moveMent>();
        if (hit != null)
        {
            //Debug.Log("gets hit");
            hit.hit();
            
        }
        if (diesOnHit)
        {
            if (SpawnOnCollition != null)
            {
                Destroy(GetComponent<Rigidbody2D>());
                Destroy(GetComponent<BoxCollider2D>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);
                system.Stop(false, ParticleSystemStopBehavior.StopEmitting);
                Instantiate(SpawnOnCollition, transform.position, transform.rotation);
            }
            else { Destroy(this.gameObject); }
        }
    }
}