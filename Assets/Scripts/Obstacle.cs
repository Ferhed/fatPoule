using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D elementImpactant)
    {
        if (elementImpactant.tag == "Poulet")
        {
            
            Destroy(gameObject);
        } else if (elementImpactant.tag == "Player") {
            // end game
        }
    }
}
