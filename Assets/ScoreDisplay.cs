using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    public int Choice;
    private int Money;
    private float timer;
    private float time;
    private int hits;
    private TextMeshProUGUI textmeshPro;
    // Start is called before the first frame update
    void Start()
    {
        timer = .5f;
        textmeshPro = GetComponent<TextMeshProUGUI>();
        //Debug.Log(textmeshPro);
        if (Choice == 0)
        {
            textmeshPro.SetText("Highscore: " + StateNameControler.highscore);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            switch (Choice)
            {
                case 0:
                    textmeshPro.SetText("Highscore: " + StateNameControler.highscore);
                    break;
                case 1:
                    if (StateNameControler.MoneyEarnt > Money)
                    {
                        Money++;
                        textmeshPro.SetText("Score: " + Money);
                        if (Money >= StateNameControler.highscore)
                        {
                            textmeshPro.SetText("Score: " + Money+"  New Highscore");
                            StateNameControler.highscore = Money;
                        }
                    }
                    break;
                case 2:
                    if (StateNameControler.Time > time)
                    {
                        time++;
                        textmeshPro.SetText("Time Survived: " + time+"s");
                    }
                    break;
                case 3:
                    if (StateNameControler.Hits > hits)
                    {
                        hits++;
                        textmeshPro.SetText("Damage taken: " + hits);
                    }
                    break;
            }

        }
    }
}
