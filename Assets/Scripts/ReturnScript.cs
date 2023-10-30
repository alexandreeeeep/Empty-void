using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            if (Input.touchCount > 0)
            {
                SceneManager.LoadScene("Menus");
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
