using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class moveMent : MonoBehaviour
{
    public int Hp;
    private int maxHp;
    private Rigidbody2D rb;
    public string Item;
    private float healRate;
    private float invunrableTimer;
    private float invun;
    private float firstHeal;
    // Start is called before the first frame update
    void Start()
    {
        invun = 0f;
        invunrableTimer = 0f;
        healRate = 5f;
        maxHp = 5;
        firstHeal = 4f;
        Item = StateNameControler.Item;
        if (Item != "Empty")
        {
            switch (int.Parse(Item))//upgrades
            {
                case 0:
                    firstHeal = 3.5f;
                    invun = .5f;
                    break;
                case 6:
                    firstHeal = 3f;
                    healRate = 4f;
                    invun = .5f;
                    break;
                case 12:
                    firstHeal = 3f;
                    healRate = 3.5f;
                    invun = .5f;
                    maxHp = 6;
                    Hp = 6;
                    break;
                case 1:
                    firstHeal = 3f;
                    break;
                case 7:
                    firstHeal = 2.5f;
                    break;
                case 13:
                    firstHeal = 1.5f;
                    break;
                case 2:
                    transform.localScale = new Vector3(.4f, .4f, 0);
                    break;
                case 8:
                    transform.localScale = new Vector3(.35f, .35f, 0);
                    break;
                case 14:
                    transform.localScale = new Vector3(.3f, .3f, 0);
                    break;
                case 3:
                    invun = 1f;
                    break;
                case 9:
                    invun = 1.5f;
                    break;
                case 15:
                    invun = 2f;
                    break;
                case 4:
                    healRate = 4f;
                    break;
                case 10:
                    healRate = 3f;
                    break;
                case 16:
                    healRate = 2f;
                    break;
                case 5:
                    maxHp = 6;
                    Hp = 6;
                    break;
                case 11:
                    maxHp = 7;
                    Hp = 7;
                    break;
                case 17:
                    maxHp = 8;
                    Hp = 8;
                    break;
                default:
                    break;
            }
        }
        GameObject Hpbar = GameObject.Find("HpBarBack");
        Hpbar.transform.localScale = new Vector3((Hp / 2.5f) - .5f, 0.2f, 0);
        Hpbar = GameObject.Find("HpBar");
        Hpbar.transform.localScale = new Vector3((Hp / 2.5f) - .5f, 0.2f, 0);
        Camera Cam = Camera.main.gameObject.GetComponent<Camera>();
        Cam.clearFlags = CameraClearFlags.SolidColor;
        Cam.backgroundColor = Color.grey;
    }
    void Awake()//when awake gets the ridged body
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        invunrableTimer += Time.deltaTime;
        
        if (Input.touchCount > 0)//input and validation
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0;
            rb.velocity = new Vector3(0, 0, 0);
            if (touchPos.y + 1 > 5)
            {
                touchPos.y = 4;
            }
            else if (touchPos.y + 1 < -5)
            {
                touchPos.y = -5;
            }
            transform.position = new Vector3(touchPos.x, touchPos.y + 1, touchPos.z);
        }
        if (transform.position.y > 5)
        {
            transform.position = new Vector2(transform.position.x, 5);
        }
        else if (transform.position.y < -5)
        {
            transform.position = new Vector2(transform.position.x, -5);
        }
        if (transform.position.x > 11)
        {
            transform.position = new Vector2(11, transform.position.y);
        }
        else if (transform.position.x < -11)
        {
            transform.position = new Vector2(-11, transform.position.y);
        }

    }
    public void hit()//if it gets hit
    {
        if (invunrableTimer>=invun) {//only gets hit if you are not imune
            invunrableTimer = 0;
            Camera Cam = Camera.main.gameObject.GetComponent<Camera>();
            Cam.clearFlags = CameraClearFlags.SolidColor;
            Cam.backgroundColor = Color.red;
            Invoke("FixBackround", .2f);
            Hp--;
            StateNameControler.Hits++;
            CancelInvoke("heal");//restarts healing timer the healing
            Invoke("heal", firstHeal);
            GameObject Hpbar = GameObject.Find("HpBar");
            Hpbar.transform.localScale = new Vector3((Hp / 2.5f) - .5f, 0.2f, 0);
            if (Hp <= 0)
            {
                CancelInvoke();
                retunOnDeath Script = GameObject.Find("Player").GetComponent<retunOnDeath>(); ;
                Script.InvokeGameEnd();
                Destroy(this.gameObject);//destroys player on death
            }
        }
        else//turns backround blue if you
        {
            Camera Cam = Camera.main.gameObject.GetComponent<Camera>();
            Cam.clearFlags = CameraClearFlags.SolidColor;
            Cam.backgroundColor = Color.blue;
            Invoke("FixBackround", .2f);
        }
    }
    void FixBackround()//reverts backround from red
    {
        Camera Cam = Camera.main.gameObject.GetComponent<Camera>();
        Cam.clearFlags = CameraClearFlags.SolidColor;
        Cam.backgroundColor = Color.grey;
    }
    void heal()//heals player untill full hp
    {
        Hp++;
        GameObject Hpbar = GameObject.Find("HpBar");
        Hpbar.transform.localScale = new Vector3((Hp / 2.5f) - .5f, 0.2f, 0);
        if (Hp < maxHp)
        {
            Invoke("heal", healRate);
        }
    }
}
