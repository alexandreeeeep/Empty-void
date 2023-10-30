using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject[] StrangeObjects;
    private float timer;
    private int preAttack;
    void Start()
    {
        StateNameControler.difficulty = .4f;
        preAttack = -1;
        StateNameControler.Hits = 0;
        StateNameControler.MoneyEarnt = 0;
        timer = 0;
        Instantiate(StrangeObjects[Random.Range(0, StrangeObjects.Length)], transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        int attack = preAttack;//prevents the same attack twice
        timer += Time.deltaTime;
        if (timer > 30)
        {
            timer = 0;
            StateNameControler.difficulty += .1f;
            while(preAttack == attack)
            {
            attack =Random.Range(0, StrangeObjects.Length);
            }
            preAttack = attack;
            Instantiate(StrangeObjects[attack], transform.position, transform.rotation);
        }
    }
}