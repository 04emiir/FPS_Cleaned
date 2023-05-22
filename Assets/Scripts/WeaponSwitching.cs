using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    [Header("References")]
    [SerializeField] private Transform[] weapons;

    [Header("Keys")]
    [SerializeField] private KeyCode[] keys;

    [Header("Data")]
    [SerializeField] private GunData[] gunData;

    [Header("Settings")]
    [SerializeField] private float switchTime;

    private int selectedWeapon;
    private float timeSinceLastSwitch;

    public TextMeshProUGUI numberOBullet;

    private void Start() {
        selectedWeapon = 0;
        Select(selectedWeapon);

        timeSinceLastSwitch = 0f;
    }



    private void Update() {
        int previousSelectedWeapon = selectedWeapon;

        for (int i = 0; i < keys.Length; i++)
            if (Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= switchTime)
                selectedWeapon = i;

        if (previousSelectedWeapon != selectedWeapon) {
            Select(selectedWeapon);
        }
           

        timeSinceLastSwitch += Time.deltaTime;
    }

    private void Select(int weaponIndex) {
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].gameObject.SetActive(i == weaponIndex);

        timeSinceLastSwitch = 0f;
        int subweaponIndex = weaponIndex;

        OnWeaponSelected(subweaponIndex);
    }

    private void OnWeaponSelected(int weaponIndex) {
        numberOBullet.text = (gunData[weaponIndex].currentAmmo).ToString() + "/" + (gunData[weaponIndex].magSize).ToString();
    }
}
