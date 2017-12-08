using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracking : MonoBehaviour {

    GameManager gm;
    public float maxDegrees = 1000f;
    public GameObject point;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Look();
	}

    void Look() {
        gameObject.transform.LookAt(point.transform, Vector3.forward);
        Vector3 angles = gameObject.transform.rotation.eulerAngles;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angles.z));
    }
}
