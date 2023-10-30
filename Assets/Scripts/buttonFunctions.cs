using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class buttonFunctions : MonoBehaviour
{

    [Header("Text Settings")]
    public TextMeshProUGUI MoneyDisplay;
    public bool[] ItemsBought;
    public string Item;
    public int Money;
    public int highscore;
    [Header("buttons")]
    public TextMeshProUGUI[] displayText;
    public GameObject[] BuyButtons;
    // Start is called before the first frame update
    void Start()
    {
        if (StateNameControler.Item == null)
        {
            StateNameControler.highscore = 0;
            StateNameControler.Money = 0;
            StateNameControler.Item = "Empty";
            StateNameControler.ItemsBought = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        }
        int OldMoney = StateNameControler.Money;
        int OldHighScore = StateNameControler.highscore;
        bool[] OldItemsBought = StateNameControler.ItemsBought;
        string OldItem = StateNameControler.Item;
        loadPlayer();
        if (Money < OldMoney)
        {
            highscore = OldHighScore;
            Money = OldMoney;
            Item = OldItem;
            ItemsBought = OldItemsBought;
        }
        SavePlayer();
        //Debug.Log("Saved Successfully");
        //uses saved variables
        if (ItemsBought.Length < 2)
        {
            ItemsBought = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
        }
        //sets up the screen
        Screen.fullScreen = true;
        PlayerPrefs.SetInt("FullscreenPreference", 1);
        MoneyDisplay.text = (Mathf.Floor(Money)).ToString();
        UpdateGUI();
        //Debug.Log("gui running");
        //Debug.Log(ItemsBought);
        if (Item != "" && Item != "Empty")
        {
            //Debug.Log(int.Parse(Item) * 100 + 100);
            Buything((int.Parse(Item) * 100 + 100));
        }
        StateNameControler.highscore = highscore;
    }
    public void playGame()
    {
        StateNameControler.ItemsBought = ItemsBought;
        StateNameControler.Money =Money;
        StateNameControler.Item = Item;
        SavePlayer();
        SceneManager.LoadScene("PlayGame");
    }
    public void updateMoney()//updates the money used
    {
        MoneyDisplay.text = (Mathf.Floor(Money)).ToString();
    }

    public void Buything(int cost)//buys item else equips or un equips it
    {
        if (ItemsBought[(cost - 100) / 100] == true && displayText[(cost - 100) / 100].text != "Equipped")
        {
            UpdateGUI();
            displayText[(cost - 100) / 100].text = "Equipped";
            Item = ((cost - 100) / 100).ToString();
            BuyButtons[(cost - 100) / 100].GetComponent<Image>().color = Color.white;
        }
        else if (displayText[(cost - 100) / 100].text == "Equipped")
        {
            displayText[(cost - 100) / 100].text = "Equip";
            BuyButtons[(cost - 100) / 100].GetComponent<Image>().color = Color.grey;
            Item = "Empty";

        }
        else if (Money>=cost)
        {
            ItemsBought[(cost - 100) / 100] = true;
            Money -= cost;
            MoneyDisplay.text = (Mathf.Floor(Money)).ToString();
            UpdateGUI();
        }
        StateNameControler.Item = Item;
        StateNameControler.ItemsBought = ItemsBought;
        StateNameControler.Money = Money;
        SavePlayer();
    }
    private void UpdateGUI()
    {
        for (int i = 0; i < ItemsBought.Length; i++)
        {
            if (ItemsBought[i] == true)
            {
                displayText[i].text = "Equip";
                BuyButtons[i].GetComponent<Image>().color = Color.grey;
            }
            else
            {
                displayText[i].text = (Mathf.Floor(i * 100+100)).ToString();
                BuyButtons[i].GetComponent<Image>().color = Color.black;
            }
        }
    }


    public void QuitGame()
    {
        StateNameControler.ItemsBought = ItemsBought;
        Item = StateNameControler.Item;
        StateNameControler.Money = Money;
        SavePlayer();
        Application.Quit();
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void loadPlayer()
    {
        StateNameControlerSave Data = SaveSystem.LoadData();//loads data
        //Debug.Log(Data);
        Money = Data.Money;
        Item = Data.Item;
        StateNameControler.Item =Item;
        ItemsBought = Data.ItemsBought;
        highscore = Data.highscore;
    }

}