using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class retunOnDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    void Start()
    {
        StateNameControler.MoneyEarnt = 0;
        StateNameControler.Time = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StateNameControler.Time += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > 1* 1/StateNameControler.difficulty)
        {
            timer = 0;
            StateNameControler.MoneyEarnt++;
            Debug.Log(StateNameControler.MoneyEarnt);
            StateNameControler.Money ++;
        }
    }
    public void InvokeGameEnd()
    {
        Invoke("ToTheMenus", 3);
    }
    void ToTheMenus()
    {
        //SceneManager.LoadScene("menus");
        SceneManager.LoadScene("ResultsScreen");

    }
}
