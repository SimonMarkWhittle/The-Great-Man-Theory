using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float health = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0f) {
            gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter2D(Collision2D other) {
        Collider2D box = other.collider;
        GameObject go = box.gameObject;
        if (go.CompareTag("Weapon")) {
            Vector2 veloc = other.relativeVelocity;
            float mass = other.rigidbody.mass;

            float force = mass * veloc.magnitude;
            health -= force;
        }
    }
}
