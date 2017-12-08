using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour {

    public FollowPointer pointer;
    GameManager gm;
    Camera cam;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        cam = gm.mainCamera;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // pointer.SetTarget(mousePos);
        pointer.TargetPos = mousePos - pointer.ForcePoint;
        pointer.Forces();
    }
}
