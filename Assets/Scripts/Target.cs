using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable {

    public float health;
    public LevelController lev;

     void Start() {
        lev = GameObject.Find("LevelController").GetComponent<LevelController>();
        }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
            if (gameObject.tag == "t_one") {
                lev.contadorOne--;
                lev.currentObjectivesText.text = "x" + lev.contadorOne.ToString();
            } else if (gameObject.tag == "t_two") {
                lev.contadorTwo--;
                lev.currentObjectivesText.text = "x" + lev.contadorTwo.ToString();
            } else if (gameObject.tag == "t_three") {
                lev.contadorThree--;
                lev.currentObjectivesText.text = "x" + lev.contadorThree.ToString();
            }
        }
        
    }
}
