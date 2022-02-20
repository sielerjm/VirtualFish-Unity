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

        if (_serverTime) {
            updateServer();
        } else {
            updateDevice();
        }
    }

    void updateServer(){

    }

    void updateDevice(){

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
