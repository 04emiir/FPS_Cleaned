using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public static Action shootInput;
    public static Action reloadInput;
    public MenuScript menu;
    public GameObject panel;


    [SerializeField] private KeyCode reloadKey = KeyCode.R;

    private void Start() {
        menu = GameObject.Find("MenuController").GetComponent<MenuScript>();
    }

    void Update()
    {
        if (menu.paused == false) {
            if (Input.GetMouseButton(0))
                shootInput?.Invoke();

            if (Input.GetKeyDown(reloadKey))
                reloadInput?.Invoke();

            if (Input.GetKeyDown(KeyCode.Escape)) {
                menu.PauseGame();
                panel.SetActive(true);
            }

        } else {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                menu.Unpause();
                panel.SetActive(false);
            }
        }

   
    }
}
