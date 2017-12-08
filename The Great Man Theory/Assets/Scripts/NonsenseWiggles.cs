using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonsenseWiggles : MonoBehaviour {

    public float minRange;
    public float maxRange;

    public bool active = true;
    Rigidbody2D body;
    GameManager gm;
    Vector2 anchorOffset = new Vector2();
    Vector2 targetPos;

    // public GameObject showpoint;

    // Use this for initialization
    void Start() {
        body = GetComponentInParent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
        anchorOffset += new Vector2(0f, gm.offset);
        targetPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (active)
            Forces();
    }

    void Forces() {

        Vector2 randPos = RandPos();
        // Vector2 objPos = gameObject.transform.position;
        targetPos += randPos;

        Vector2 forcePoint = body.GetRelativePoint(body.centerOfMass + anchorOffset);

        // Debug.Log(forcePoint);
        // showpoint.transform.position = forcePoint;
        Vector2 force = (targetPos - forcePoint) * gm.extraForce;
        // force.Normalize();
        // force *= gm.maxForce;
        body.AddForceAtPosition(force, forcePoint);
    }

    Vector2 RandPos() {
        Vector2 direct = Random.insideUnitCircle;
        float random = Random.Range(minRange, maxRange);
        return direct * random;
    }
}
