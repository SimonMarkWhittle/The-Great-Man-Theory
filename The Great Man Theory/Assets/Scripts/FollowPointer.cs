using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour {
    
    GameManager gm;
    Rigidbody2D body;
    Vector2 anchorOffset;
    Vector2 targetPos;
    Vector2 forcePoint;

    public Vector2 ForcePoint {
        get { return body.GetRelativePoint(forcePoint); }
    }
    public Vector2 TargetPos {
        get { return targetPos; }
        set { targetPos = value; } }

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        anchorOffset = new Vector2(0f, gm.offset);

        targetPos = body.centerOfMass + anchorOffset;
        forcePoint = body.centerOfMass + anchorOffset;
	}
	
	// Update is called once per frame
	void Update () {
        // Forces();
	}

    public void SetTarget(Vector2 newTarget) {
        targetPos = newTarget;
    }

    public void Forces() {
        Vector2 force = targetPos * gm.extraForce;
        body.AddForceAtPosition(force, ForcePoint);
    }
}
