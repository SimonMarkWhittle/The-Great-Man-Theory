using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    Vector2 anchorOffset = new Vector2();
    Rigidbody2D body;
    GameManager gm;
    public bool active=true;

	// Use this for initialization
	void Start () {
        body = GetComponentInParent<Rigidbody2D>();
        anchorOffset += new Vector2(0f, 1f);
        gm = FindObjectOfType<GameManager>();
    }

	// Update is called once per frame
	void Update () {
        if (active)
            Forces();
	}

    void Forces() {
        Debug.Log("Geddit" + ManagerGetter.Get());
        Camera cam = gm.mainCamera;
        Vector3 mousePos3 = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(mousePos3.x, mousePos3.y);

        Vector2 forcePoint = body.GetRelativePoint(body.centerOfMass + anchorOffset);
        Vector2 force = (mousePos - forcePoint) * gm.extraForce;
        // force.Normalize();
        // force *= gm.maxForce;
        body.AddForceAtPosition(force, forcePoint);
    }
}
