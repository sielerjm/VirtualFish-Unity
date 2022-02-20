using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject flashText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("flashTheText", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
            SceneManager.LoadScene("Game");

    }

    void flashTheText() {
        if (flashText.activeInHierarchy){
            flashText.SetActive(false);
        } else {
            flashText.SetActive(true);
        }

    }
}
