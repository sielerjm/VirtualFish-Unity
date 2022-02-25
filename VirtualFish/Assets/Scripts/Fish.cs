using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Finished Hunter Heidenreich Tutorial: youtu.be/JUgy7Lm3hH8

public class Fish : MonoBehaviour
{
    // [SerializeField] private int _hunger;

    [SerializeField] private int _hungery;

    [SerializeField] private int _happiness;

    [SerializeField] private string _name;

    private bool _serverTime;

    private int _clickCount;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"Fish.cs > Start() "); // + ts.TotalMinutes);  // TEST

        // Debug.Log(getStringTime());  // TEST
        PlayerPrefs.SetString("then", "02/24/2022 15:30:00");  // TEST
        // PlayerPrefs.SetString("then", getStringTime());  // WORKING

        updateStatus();

        if(!PlayerPrefs.HasKey("name")){
            PlayerPrefs.SetString("name", "Fishy");
        }
        _name = PlayerPrefs.GetString("name");
    }

    // Update is called once per frame
    void Update() {

        // Debug.Log($"Fish.cs > Update() "); // + ts.TotalMinutes);  // TEST

        if(Input.GetMouseButtonUp(0)){
            Debug.Log("Clicked");  // TEST

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                // Debug.Log(hit.collider.gameObject.name);  // TEST
                hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }

            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));  // TEST

            if(hit){
                // Debug.Log($"Hit: " +  hit.transform.gameObject.name);  // TEST
                // Debug.Log($"Hit obj: " +  hit.transform.gameObject.tag);  // TEST
                if(hit.transform.gameObject.tag == "fish"){
                    _clickCount ++;
                    // Debug.Log($"Click Count: " +  _clickCount);  // TEST
                    if (_clickCount >= 3) {
                        _clickCount = 0;
                        updateHappiness(1);
                        Debug.Log($"Happiness updated by 1");  // TEST
                    }
                }
            }
        }

    }

    void updateStatus(){

        // if (!PlayerPrefs.HasKey("_hunger")) {
        //     _hunger = 100;
        //     Debug.Log($"updateStatus > if > !PlayerPrefs.HasKey('_hunger'): ... "); // + ts.TotalMinutes);  // TEST
        //     PlayerPrefs.SetInt("_hunger", _hunger);
        // } else {
        //     Debug.Log($"updateStatus > !PlayerPrefs.HasKey('_hunger') > else: ... "); // + ts.TotalMinutes);  // TEST
        //     _hunger = PlayerPrefs.GetInt("_hunger");
        // }

        if (!PlayerPrefs.HasKey("_hungery")) {
            _hungery = 100;
            Debug.Log($"updateStatus > if > !PlayerPrefs.HasKey('_hungery'): ... "); // + ts.TotalMinutes);  // TEST
            PlayerPrefs.SetInt("_hungery", _hungery);
        } else {
            Debug.Log($"updateStatus > !PlayerPrefs.HasKey('_hungery') > else: ... "); // + ts.TotalMinutes);  // TEST
            _hungery = PlayerPrefs.GetInt("_hungery");
        }

        if (!PlayerPrefs.HasKey("_happiness")) {
            _happiness = 100;
            Debug.Log($"updateStatus > if > !PlayerPrefs.HasKey('_happiness'): ... "); // + ts.TotalMinutes);  // TEST
            PlayerPrefs.SetInt("_happiness", _happiness);
        } else {
            Debug.Log($"updateStatus > !PlayerPrefs.HasKey('_happiness') > else: ... "); // + ts.TotalMinutes);  // TEST
            _happiness = PlayerPrefs.GetInt("_happiness");
        }

        if (!PlayerPrefs.HasKey("then")) {
            PlayerPrefs.SetString("then", getStringTime());
        }

        // Debug.Log(getTimeSpan().ToString());  // TEST
        // Debug.Log(getTimeSpan().TotalHours);  // TEST

        // TIME
        TimeSpan ts = getTimeSpan();
        Debug.Log($"Total Minutes: " + ts.TotalMinutes);  // TEST

        // // HUNGER
        // Debug.Log($"Hunger pre-adjust: " + _hunger);  // TEST
        //
        // _hunger -= (int)(ts.TotalMinutes/5);
        // if(_hunger < 0 ){
        //     _hunger = 0;
        // }
        // Debug.Log($"Hunger post-adjust: " + _hunger);  // TEST

        // HUNGERY
        Debug.Log($"Hungery pre-adjust: " + _hungery);  // TEST

        _hungery -= (int)(ts.TotalMinutes/5);
        if(_hungery < 0 ){
            _hungery = 0;
        }
        Debug.Log($"Hungery post-adjust: " + _hungery);  // TEST

        // HAPPINESS
        Debug.Log($"Happiness pre-adjust: " + _happiness);  // TEST
        _happiness -= (int)(ts.TotalMinutes/5);
        if(_happiness < 0 ){
            _happiness = 0;
        }
        Debug.Log($"Happiness post-adjust: " + _happiness);  // TEST



        // UPDATE TIME
        if (_serverTime) {
            updateServer();
        } else {
            InvokeRepeating("updateDevice", 0f, 30f);
        }
    }

    void updateServer(){

    }

    void updateDevice(){
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan(){
        if(_serverTime){
            return new TimeSpan();
        } else{
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    string getStringTime(){
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    // public int hunger{
    //     get{ return _hunger; }
    //     set{ _hunger = value; }
    // }

    public int hungery{
        get{ return _hungery; }
        set{ _hungery = value; }
    }

    public int happiness{
        get{ return _happiness; }
        set{ _happiness = value; }
    }

    public string name{
        get { return _name;}
        set {_name = value;}
    }

    public void updateHappiness(int i){
        happiness += i;
        if (happiness > 100){
            happiness = 100;
        }

    }

    public void updateHunger(int i){
        hungery += i;
        if (hungery > 100){
            hungery = 100;
        }

    }

    public void saveGame(){
        if(!_serverTime){
            updateDevice();
        }
        PlayerPrefs.SetInt("_hungery", _hungery);
        PlayerPrefs.SetInt("_happiness", _happiness);
    }


}
