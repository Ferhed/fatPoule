using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGame : MonoBehaviour {

    public Image piston1;
    public Image piston2;
    public Image piston3;

    private float start;
    private float end = 25;

	// Use this for initialization
	void Start () {
	
		start = piston1.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
	}

    public void descendPiston(int piston)
    {
        switch (piston)
        {
            case 1:
			piston1.transform.position = new Vector3(piston1.transform.position.x, end,piston1.transform.position.z);
                break;
            case 2:
			piston2.transform.position = new Vector3(piston2.transform.position.x, end,piston2.transform.position.z);
                break;
            case 3:
			piston3.transform.position = new Vector3(piston3.transform.position.x, end,piston3.transform.position.z);
                break;
        }
    }

    public void upPiston(int piston)
    {
        switch (piston)
        {
            case 1:
			piston1.transform.position = new Vector3(piston1.transform.position.x, start,piston1.transform.position.z);
				break;
            case 2:
			piston2.transform.position = new Vector3(piston2.transform.position.x, start,piston2.transform.position.z);
                break;
            case 3:
			piston3.transform.position = new Vector3(piston3.transform.position.x, start,piston3.transform.position.z);
                break;
        }
    }
}
