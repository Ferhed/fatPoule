using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    // Public Attribs
    public float zoomInOut;
    public float offSetX = 0f;

    // Private Attribs
    private Transform elementToFollow;
    private Vector2 offsetPosition;
    private Vector3 relativePosition;

	// Use this for initialization
	void Start () {
        elementToFollow =  GameObject.FindGameObjectWithTag("Player").transform;
        offsetPosition = new Vector3(elementToFollow.position.x-offSetX, elementToFollow.position.y, zoomInOut);
        transform.position = offsetPosition;
    }
	
	// Update is called once per frame
	void Update () {	
	}

	void LateUpdate() {
		relativePosition = Vector3.Lerp(transform.position, new Vector3(elementToFollow.position.x+offSetX, 0f, zoomInOut), 6f);
		transform.position = relativePosition;
	}
}
