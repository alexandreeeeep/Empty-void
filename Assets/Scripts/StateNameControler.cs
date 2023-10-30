using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateNameControler
{
    public static string Item;
    public static int highscore;
    public static int Money;
    public static bool[] ItemsBought;
    //for death screen
    public static float difficulty;
    public static float MoneyEarnt;
    public static float Time;
    public static float Hits;

}
[System.Serializable]
public class StateNameControlerSave
{
    public int highscore;
    public string Item;
    public int Money;
    public bool[] ItemsBought;

    public StateNameControlerSave(buttonFunctions scriptHolder)
    {
        Money = scriptHolder.Money;
        Item = scriptHolder.Item;
        ItemsBought = scriptHolder.ItemsBought;
        highscore = scriptHolder.highscore;
    }
}

