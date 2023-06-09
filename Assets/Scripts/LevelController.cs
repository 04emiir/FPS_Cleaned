using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public Transform[] curentObjectivesOne;
    public Transform[] curentObjectivesTwo;
    public Transform[] curentObjectivesThree;
    public TextMeshProUGUI currentObjectivesText;
    public TextMeshProUGUI currentLevel;

    public int contadorOne, contadorTwo, contadorThree;
    public GameObject panel;

    public GameObject barrierOne;
    public GameObject barrierTwo;
    public GameObject barrierThree;

    public MenuScript menu;


    bool oneFinished, twoFinished;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("MenuController").GetComponent<MenuScript>();
        oneFinished = false;
        twoFinished= false;
        contadorOne = 0;
        contadorTwo = 0;
        contadorThree = 0;
        foreach (var item in curentObjectivesOne) {
            contadorOne++;
        }

        foreach (var item in curentObjectivesTwo) {
            item.gameObject.SetActive(false);
            contadorTwo++;
        }

        foreach (var item in curentObjectivesThree) {
            item.gameObject.SetActive(false);
            contadorThree++;
        }

        currentLevel.text = "Level One";
        currentObjectivesText.text = "x" + contadorOne.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (contadorOne == 0 && !oneFinished) {
            currentLevel.text = "Level Two";
            currentObjectivesText.text = "x" + contadorTwo.ToString();
            foreach (var item in curentObjectivesTwo) {
                item.gameObject.SetActive(true);
            }
            oneFinished= true;
            Destroy(barrierOne);
        }

        if (contadorTwo == 0 && !twoFinished) {
            currentLevel.text = "Level Three";
            currentObjectivesText.text = "x" + contadorThree.ToString();
            foreach (var item in curentObjectivesThree) {
                item.gameObject.SetActive(true);
            }
            twoFinished = true;
            Destroy(barrierTwo);
            Destroy(barrierThree);
        }

        if (contadorThree == 0) {
            menu.PauseGame();
            panel.SetActive(true);

        }
    }
}
