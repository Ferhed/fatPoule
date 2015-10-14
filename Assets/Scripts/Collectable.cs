using UnityEngine;
using System.Collections;

// This class pop a element
public class Collectable : MonoBehaviour {
    
    //Public attribs
    public GameObject elementToPop;

    //Private attribs
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameObject.tag == "Fruit")
        {
            transform.Rotate(new Vector3(0, 100, 0)*Time.deltaTime);
        }


	}

    private void OnTriggerEnter2D(Collider2D elementImpactant) {
        if (transform.tag == "Cage" && elementImpactant.tag == "Player") {
            player.GetComponent<PlayerControls>().popChicken(Instantiate(elementToPop, transform.position, elementToPop.transform.rotation) as GameObject);
            Destroy(gameObject);
        }
        
        if (transform.tag == "Fruit") {
            Debug.Log("Take 1 Point");
            Destroy(gameObject);
        }
    }
}
