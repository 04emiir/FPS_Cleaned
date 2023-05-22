using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour {

    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform cam;

    [Header("BulletData")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    public AudioSource bulletSound;
    public AudioSource reloadSound;
    public TextMeshProUGUI numberOBullet;




    float timeSinceLastShot;

    private void Start() {
        cam = GameObject.Find("CameraHolder").transform;
        PlayerShoot.shootInput = Shoot;
        PlayerShoot.reloadInput = StartReload;
        numberOBullet.text = (gunData.currentAmmo).ToString() + "/" + (gunData.magSize).ToString();
    }

    private void OnDisable() {
        gunData.reloading = false;
        PlayerShoot.shootInput -= Shoot;
        PlayerShoot.reloadInput -= StartReload;
    }

    private void OnEnable() {
        PlayerShoot.shootInput = Shoot;
        PlayerShoot.reloadInput = StartReload;
    }


    public void StartReload() {
        if (!gunData.reloading && this.gameObject.activeSelf && gunData.currentAmmo != gunData.magSize)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload() {
        gunData.reloading = true;
        numberOBullet.text = "R/" + (gunData.magSize).ToString();
        yield return new WaitForSeconds(gunData.reloadTime);
        reloadSound.Play();

        gunData.currentAmmo = gunData.magSize;
        numberOBullet.text = (gunData.currentAmmo).ToString() + "/" + (gunData.magSize).ToString();
        gunData.reloading = false;
    }

    private bool CanShoot() => !gunData.reloading && this.gameObject.activeSelf && gunData.currentAmmo > 0 && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    private void Shoot() {
        if (gunData.currentAmmo > 0) {
            if (CanShoot()) {
                bulletSound.Play();
                numberOBullet.text = (gunData.currentAmmo - 1).ToString() + "/" + (gunData.magSize).ToString();
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                
                bullet.GetComponent<Rigidbody>().AddForce(cam.forward * 5000f);
                if (Physics.Raycast(bulletSpawnPoint.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance)) {
                    //Debug.Log(hitInfo.transform.name);
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);
                }
                


                gunData.currentAmmo--;
                timeSinceLastShot = 0;
            }
        }
    }

    private void Update() {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);

    }


}
