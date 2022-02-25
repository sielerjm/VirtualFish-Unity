using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Finished Hunter Heidenreich Tutorial: youtu.be/JUgy7Lm3hH8

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
        // Debug.Log($"gameManager > Start() "); // + ts.TotalMinutes);  // TEST
        // happinessText.GetComponent<Text>().text = fish.GetComponent<Fish>().happiness.ToString();
        // hungerText.GetComponent<Text>().text = fish.GetComponent<Fish>().hunger.ToString();
        // nameText.GetComponent<Text>().text = fish.GetComponent<Fish>().name;  // Doesn't need ".ToString" because name is a string
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log($"gameManager > Update() "); // + ts.TotalMinutes);  // TEST
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

    public void triggerFoodPanel(bool b){
        // foodPanel.SetActive(!foodPanel.activeInHierarchy);
        toggle(foodPanel);

        // if(b){
        //
        //     // If player pressed flakes
        //     fish.GetComponent<Fish>().updateHappiness(5);
        //     Debug.Log($"Happiness updated by 5");  // TEST
        //     fish.GetComponent<Fish>().updateHunger(20);
        //     Debug.Log($"Hunger updated by 20");  // TEST
        //
        //     // If player pressed candy
        //     fish.GetComponent<Fish>().updateHappiness(10);
        //     Debug.Log($"Happiness updated by 1");  // TEST
        //     fish.GetComponent<Fish>().updateHunger(1);
        //     Debug.Log($"Hunger updated by 1");  // TEST
        // }
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

        if(i == 0){

            // If player pressed flakes
            fish.GetComponent<Fish>().updateHappiness(5);
            Debug.Log($"Happiness updated by 5");  // TEST
            fish.GetComponent<Fish>().updateHunger(20);
            Debug.Log($"Hunger updated by 20");  // TEST

        } else if (i == 1) {
            // If player pressed candy
            fish.GetComponent<Fish>().updateHappiness(10);
            Debug.Log($"Happiness updated by 1");  // TEST
            fish.GetComponent<Fish>().updateHunger(1);
            Debug.Log($"Hunger updated by 1");  // TEST
        } else {

        }
    }

    public void toggle(GameObject g){
        if (g.activeInHierarchy){
            g.SetActive(false);
        }
    }

}
