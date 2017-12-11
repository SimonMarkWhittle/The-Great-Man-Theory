using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftCollision : MonoBehaviour {

    public float punctureResist = 8f;
    public float stickyness;
    public float breakForce = 100f;

    public Collider2D collision;
    public Collider2D trigger;

    List<Collider2D> stuckColliders = new List<Collider2D>();

    List<Collider2D> enteredColliders = new List<Collider2D>();

    Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        GameObject otherobj = other.gameObject;
        if (other.CompareTag("Weapon")) {
            Vector2 contact = other.bounds.ClosestPoint(transform.position);
            float magnitude = (contact == Vector2.zero) ? 0f : other.attachedRigidbody.GetPointVelocity(contact).magnitude;
            
            if (magnitude > punctureResist) {
                enteredColliders.Add(other);
                Physics2D.IgnoreCollision(collision, other, true);

                Collide(other, contact);
            }
            // if (otherobj)
        }
    }

    void OnTriggerStay2D(Collider2D other) {

        if (!stuckColliders.Contains(other) && enteredColliders.Contains(other)) {

            Vector2 contact = other.bounds.ClosestPoint(transform.position);
            float magnitude = (contact == Vector2.zero) ? 0f : other.attachedRigidbody.GetPointVelocity(contact).magnitude;

            if (magnitude < punctureResist) {
                MakeStickingJoint(other);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (enteredColliders.Remove(other)) {
            stuckColliders.Remove(other);
            Physics2D.IgnoreCollision(collision, other, false);
        }
    }

    float CalculateImpactForce(Rigidbody2D self, Rigidbody2D other) {
        var impactVelocityX = self.velocity.x - other.velocity.x;
        impactVelocityX *= Mathf.Sign(impactVelocityX);
        var impactVelocityY = self.velocity.y - other.velocity.y;
        impactVelocityY *= Mathf.Sign(impactVelocityY);
        var impactVelocity = impactVelocityX + impactVelocityY;
        float impactForce = impactVelocity * self.mass * other.mass;
        impactForce *= Mathf.Sign(impactForce);

        return impactForce;
    }

    void MakeStickingJoint(Collider2D other) {
        FixedJoint2D stickPoint = gameObject.AddComponent<FixedJoint2D>();
        stickPoint.connectedBody = other.attachedRigidbody;
        stickPoint.breakForce = breakForce;

        stuckColliders.Add(other);
    }

    void Collide(Collider2D other, Vector2 contact) {
        float impactMagnitude = CalculateImpactForce(body, other.attachedRigidbody);
        Vector2 direct = contact - body.centerOfMass;
        Vector2 impactForce = direct.normalized * impactMagnitude;

        body.AddForceAtPosition(impactForce, contact);
        other.attachedRigidbody.AddForceAtPosition(-impactForce, contact);
    }
}
