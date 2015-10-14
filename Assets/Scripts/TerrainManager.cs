using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainManager : MonoBehaviour {

    // Public attribs
    [Header("Valeur en pixel")]
    public float imageWidth;
    public List<GameObject> sprites;
	public List<GameObject> clouds;
    public Transform player;
	public float moveSpeed = 5.5f;

    // Private attribs
    //private List<GameObject> sprites = new List<GameObject>();
    private GameObject previousSprite;
    private GameObject currentSprite;
    private GameObject nextSprite;
	private GameObject currentCloud;
	private GameObject nextCloud;
    private List<GameObject> allSprites = new List<GameObject>();

    // Use this for initialization
    void Start () {
        imageWidth /= 100;
		currentCloud = clouds[Random.Range(0,clouds.Count)];
		currentCloud.transform.position = new Vector3(player.transform.position.x+13,Random.Range(3,5),0);
		nextCloud = clouds[Random.Range(0,clouds.Count)];
		while(nextCloud == currentCloud)
		{
			nextCloud = clouds[Random.Range(0,clouds.Count)];
		}
		nextCloud.transform.position = new Vector3(currentCloud.transform.position.x+Random.Range(10,20),Random.Range(3,5),0);
        //Populate the table

        //Draw element

        previousSprite = (GameObject)Instantiate(sprites[Random.Range(0, sprites.Count)],new Vector3(0 - imageWidth, 0,0), Quaternion.identity);
        allSprites.Add(previousSprite);
      
        Vector3 relativePostion = new Vector3(previousSprite.transform.position.x + imageWidth, 0,0);
        currentSprite = (GameObject)Instantiate(sprites[Random.Range(0, sprites.Count)], relativePostion, Quaternion.identity);
        allSprites.Add(currentSprite);

        relativePostion = new Vector3(currentSprite.transform.position.x + imageWidth, 0, 0);
        nextSprite = (GameObject)Instantiate(sprites[Random.Range(0, sprites.Count)], relativePostion, Quaternion.identity);
        allSprites.Add(nextSprite);

    }
	
	// Update is called once per frame
	void Update () {

		previousSprite.transform.position +=(Vector3.right*moveSpeed*Time.deltaTime);
		currentSprite.transform.position +=(Vector3.right*moveSpeed*Time.deltaTime);
		nextSprite.transform.position +=(Vector3.right*moveSpeed*Time.deltaTime);

        if (currentSprite.transform.position.x < player.position.x ){
            sprites.Remove(previousSprite);
            Destroy(previousSprite);
            previousSprite = currentSprite;
            currentSprite = nextSprite;
            nextSprite = (GameObject)Instantiate(sprites[Random.Range(0, sprites.Count)], new Vector3(currentSprite.transform.position.x + imageWidth,0,0), Quaternion.identity);
        }

		if(currentCloud.transform.position.x < player.position.x - 10)
		{
			currentCloud = nextCloud;
			nextCloud = clouds[Random.Range(0,clouds.Count)];
			while(nextCloud == currentCloud)
			{
				Debug.Log("test");
				nextCloud = clouds[Random.Range(0,clouds.Count)];
			}
            nextCloud.transform.position = new Vector3(player.transform.position.x + Random.Range(15, 20), Random.Range(3, 5), 0);
        }

        currentCloud.transform.position += (Vector3.right * 4f * Time.deltaTime);
        nextCloud.transform.position += (Vector3.right * 4f * Time.deltaTime);




    }
}
