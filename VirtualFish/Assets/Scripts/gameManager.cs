using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject happinessText;
    public GameObject hungerText;

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
    }
}
