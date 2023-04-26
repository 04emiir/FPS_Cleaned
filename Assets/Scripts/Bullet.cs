using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;
    // Start is called before the first frame update
    private void Awake() {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }
}
