using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager gm;
    public Camera mainCamera;
    public float extraForce;
    public float maxForce;

	// Use this for initialization
	void Start () {
        gm = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static GameManager Get() {
        Debug.Log(gm);
        Debug.Log("Camera is: " + gm.mainCamera);
        if (gm = null) {
            Debug.Log("Wanna getta gm");
            gm = MonoBehaviour.FindObjectOfType<GameManager>();
            Debug.Log("gm is now: " + gm);
        }
        return gm;
    }

}
