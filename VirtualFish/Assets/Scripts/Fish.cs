using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField]
    private int _hunger;

    [SerializeField]
    private int _happiness;

    private bool _serverTime;



    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(getStringTime());  // TEST
        // PlayerPrefs.SetString("then", "02/16/2022 12:01:01");  // TEST
        PlayerPrefs.SetString("then", getStringTime());
        updateStatus();
    }

    // Update is called once per frame
    // void Update()
    // {
    //
    // }

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


}
