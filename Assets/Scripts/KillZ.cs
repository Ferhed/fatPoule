using UnityEngine;
using System.Collections;

public class KillZ : MonoBehaviour {

    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (tag == "killZ")
        {
            if (other.gameObject == player)
            {
                //Laisser cette condition vide si jamais on doit intervenir sur le player lors de sa destruction
            }
            else if (other.gameObject.tag == "Poulet")
            {
                player.GetComponent<PlayerControls>().deleteChicken(other.gameObject);
                other.GetComponent<ChickenControl>().killIt();
                Destroy(other.gameObject);
            }
        }
        else if (tag == "miniKillZ")
        {
            if (other.tag == "Poulet")
            {
                player.GetComponent<PlayerControls>().deleteChicken(other.gameObject);
                other.GetComponent<ChickenControl>().killIt();
            }
        }
    }
}
