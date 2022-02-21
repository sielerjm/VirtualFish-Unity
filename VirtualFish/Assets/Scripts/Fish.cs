using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private int _hunger;

    [SerializeField] private int _happiness;

    [SerializeField] private bool _serverTime;

    private int _clickCount;



    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(getStringTime());  // TEST
        PlayerPrefs.SetString("then", "02/20/2022 12:50:00");  // TEST
        // PlayerPrefs.SetString("then", getStringTime());  // WORKING
        updateStatus();
    }

    // Update is called once per frame
    void Update() {
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

        if (!PlayerPrefs.HasKey("_hunger")) {
            _hunger = 100;
            PlayerPrefs.SetInt("_hunger", _hunger);
        } else {
            _hunger = PlayerPrefs.GetInt("_hunger");
        }

        if (!PlayerPrefs.HasKey("_happiness")) {
            _happiness = 100;
            PlayerPrefs.SetInt("_happiness", _happiness);
        } else {
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

        // HUNGER
        _hunger -= (int)(ts.TotalMinutes/5);
        if(_hunger < 0 ){
            _hunger = 0;
        }
        Debug.Log($"Hunger: " + _hunger);  // TEST

        // HAPPINESS
        _happiness -= (int)(_hunger*0.2);
        if(_happiness < 0 ){
            _happiness = 0;
        }
        Debug.Log($"Happiness: " + _happiness);  // TEST



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

    public int hunger{
        get{ return _hunger; }
        set{ _hunger = value; }
    }

    public int happiness{
        get{ return _happiness; }
        set{ _happiness = value; }
    }

    public void updateHappiness(int i){
        happiness += i;
        if (happiness > 100){
            happiness = 100;
        }

    }


}
