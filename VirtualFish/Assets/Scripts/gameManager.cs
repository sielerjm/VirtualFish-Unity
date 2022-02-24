using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;

    public GameObject foodPanel;
    public Sprite[] foodIcons;

    public GameObject fish;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        happinessText.GetComponent<Text>().text = fish.GetComponent<Fish>().happiness.ToString();
        hungerText.GetComponent<Text>().text = fish.GetComponent<Fish>().hunger.ToString();
        nameText.GetComponent<Text>().text = fish.GetComponent<Fish>().name;  // Doesn't need ".ToString" because name is a string
    }

    public void triggerNamePanel(bool b){
        namePanel.SetActive(!namePanel.activeInHierarchy);

        if(b){
            fish.GetComponent<Fish>().name = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("name", fish.GetComponent<Fish>().name);
        }
    }

    public void buttonBehavior(int i){
        switch(i){

            // Feed
            case(0):
            default:
                foodPanel.SetActive(!foodPanel.activeInHierarchy);
                break;

            // Care (clean tank, give medicine)
            case(1):
                break;

            // Play (mini-game)
            case(2):
                break;

            // Quit
            case(3):
                fish.GetComponent<Fish>().saveGame();
                Application.Quit();
                break;

        }
    }

    public void selectFood(int i){
        toggle(foodPanel);
    }

    public void toggle(GameObject g){
        if (g.activeInHierarchy){
            g.SetActive(false);
        }
    }

}
