using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Header("Spawining")]
    public GameObject StrangeObjects;
    private float timer;
    public float ShootingRate;
    public bool doesRotate;
    public bool DestoryAfterAttack;
    public int Randomness;
    [Header("Movement")]
    public float y;
    public float yChange;
    public float x;
    public float xChange;
    [Header("Difficulty")]
    public bool effectedByDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }
    int randomise()
    {
        for (int i = 1; i < Randomness + 1; i++)
        {
            if (Random.Range(0, 10) >= 2+Randomness)
            {
                //Debug.Log("Randomised to be "+i);
                return i;
            }
        }
        return Randomness+1;
    }
    // Update is called once per frame
    void Update()
    {
        if (effectedByDifficulty)
        {
            timer += Time.deltaTime * randomise() * StateNameControler.difficulty;
        }
		else
		{
            timer += Time.deltaTime * randomise();

        }
        if (timer > ShootingRate)
        {
            timer = 0;
            for (int i = 1; i <= randomise(); i++)
            {
                if (x != 0 && y != 0)
                {
                    transform.position = new Vector2(Random.Range(x, x + xChange), Random.Range(y, y + yChange));
                }
                if (doesRotate)
                {
                    Instantiate(StrangeObjects, transform.position, Random.rotation);
                }
                else
                {
                    Instantiate(StrangeObjects, transform.position, transform.rotation);
                }
                if (DestoryAfterAttack)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
