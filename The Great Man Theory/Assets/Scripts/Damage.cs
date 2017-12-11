using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public float health = 100f;

    public GameObject weapon;

	// Use this for initialization
	void Start () {
        if (weapon) {
            Collider2D weaponCollider = weapon.GetComponent<Collider2D>();
            Collider2D thisCollider = gameObject.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(weaponCollider, thisCollider);
        }
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
