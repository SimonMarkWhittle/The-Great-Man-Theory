using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracking : MonoBehaviour {

    GameManager gm;
    public bool active = true;
    public float maxDegrees = 1000f;
    public GameObject point;

	// Use this for initialization
	void Start () {
        gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
            Look();
	}

    void Look() {
        Camera cam = gm.mainCamera;
        Vector2 pos = gameObject.transform.position;
        // Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = point.transform.position;
        Vector2 diffPoint = mousePos - pos;

        Vector2 forward = gameObject.transform.up;

        float angle = AngleBetweenVector2(forward, diffPoint);
        Quaternion lookRot = Quaternion.Euler(0f, 0f, angle);
        Debug.Log(lookRot.eulerAngles);

        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, lookRot, 90f);
    }

    static float AngleBetweenVector2(Vector2 vec1, Vector2 vec2) {
        Vector2 vec1Rotated90 = new Vector2(-vec1.y, vec1.x);
        float sign = (Vector2.Dot(vec1Rotated90, vec2) < 0) ? -1.0f : 1.0f;
        return Vector2.Angle(vec1, vec2) * sign;
    }

    /*
function eeulervector(euler:Vector3):Vector3;//convert euler to vector3.
{
float elevation = Deg2Rad(euler. x);
float heading = Deg2Rad(euler. y)
return Vector3(Cos(elevation) * Sin(heading), Sin(elevation), Cos(elevation) * Cos(heading));
}
    */
}
