using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//@todo adapter le code à la plateforme mobile
public class PlayerControls : MonoBehaviour {

    // Public Attribs
    public float speed = 1f;
    public float multiplicateurSpeed = 3.0f;

    public float timeToSpeed = 2f;
	public float timeToAttack = 1f;
	public float hitDistance = 2f;
    public float jumpDelay = 1f;
	public float hauteurSaut = 500f;

    public float distPouletPlayer = 3f;

    public List<GameObject> pouletTab = new List<GameObject>();

    // Private Attribs
    private Vector3 relativePosition;
    private float sin = 1f;
    private float currentSpeed = 1f;
	private float currentAttack = 0f;


    private float offsetGroundRay = 1.5f;
    private float delay = 1;
    private float timeElapsed;

    private bool isGrounded = false;
    private Rigidbody2D rigidbody;

    private float timeToAccelerate = 0;


    private float currentJumpDelay = 0f;
    private bool needJump = false;

    // Use this for initialization
    void Start () {
        timeElapsed = Time.fixedTime;
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        
        /* Petit tricks du sinus
        float ratio = (timeElapsed - Time.fixedTime) / delay;
        Debug.Log(Mathf.Sin(ratio));*/
        // random = increment du tableau, nombre pair * i, nombre impair * -i

		/*for(int i = 0; i < pouletTab.Count; i++)
		{
			pouletTab[i].transform.position = new Vector2(transform.position.x + distPouletPlayer + pouletTab[i].GetComponent<ChickenControl>().offSetX , pouletTab[i].transform.position.y);
			
		}*/


        if(timeToAccelerate != 0.0f)
        {
            timeToAccelerate = Mathf.Max(0f, timeToAccelerate - Time.deltaTime);
            currentSpeed = multiplicateurSpeed;
        }

		if(currentAttack != 0.0f)
		{
			currentAttack = Mathf.Max(0f, currentAttack - Time.deltaTime);
		}

        if (currentJumpDelay != 0.0f)
        {
            currentJumpDelay = Mathf.Max(0f, currentJumpDelay - Time.deltaTime);
        }

        if (currentJumpDelay == 0f && needJump == true) {
			rigidbody.AddForce(new Vector2(0, hauteurSaut));
            needJump = false;
            currentJumpDelay = jumpDelay;
        }



       this.Move(speed * currentSpeed, transform.position.y,transform.position.z);

        currentSpeed = 1.0f;
	}

	public void button1 ()
	{
		timeToAccelerate = timeToSpeed;
	}
	public void button2 ()
	{
		if(isGrounded && currentJumpDelay == 0)
		{
            currentJumpDelay = jumpDelay;
            needJump = true;			
			for (int i = 0; i < pouletTab.Count; i++)
			{
                ChickenControl chickenControl = pouletTab[i].GetComponent<ChickenControl>();
                if (pouletTab[i]!=null)
                {
                    chickenControl.jump(Mathf.Abs((chickenControl.offSetX - 1) / 10));
                }
					
			}
		}
	}
	public void button3 ()
	{
		if(currentAttack == 0)
		{
			Attack();
			
		}
	}
    public void reload()
    {
        Application.LoadLevel(1);
    }

    private void FixedUpdate()
    {
        LayerMask floorLayer = 1 << 10;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, offsetGroundRay, floorLayer);
        Debug.DrawRay(transform.position, -Vector2.up, Color.red);

        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Apply move
        this.Move((speed * currentSpeed) * Time.deltaTime, 0, 0);
        currentSpeed = 1.0f;
    }

    private void Attack(){

		if(pouletTab.Count > 0)
		{
			LayerMask persoMask = 1 << 8;
			GameObject currentChicken = chooseChicken();
			Collider2D[] inFront = Physics2D.OverlapCircleAll(currentChicken.transform.position + Vector3.right*hitDistance, 2f, persoMask);
			for (int j = 0; j < inFront.Length; j++)
			{
				if (inFront[j] != GetComponent<Collider2D>())
				{
					Destroy(inFront[j].gameObject);
				}
			}
		}
    }


	private GameObject chooseChicken()
	{
		GameObject currentChicken = null;
		for(int i = 0; i < pouletTab.Count; i++)
		{
			if(currentChicken == null) currentChicken = pouletTab[i];
			else if (currentChicken.transform.position.x < pouletTab[i].transform.position.x)
			{ currentChicken = pouletTab[i];}
		}
		return currentChicken;
	}

    private void Move(float x,float y, float z) {
        relativePosition = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, relativePosition, 0.1f);
    }

    public void deleteChicken(GameObject gameObject) {
        pouletTab.Remove(gameObject);
    }

    public void popChicken(GameObject gameObject)
    {
        pouletTab.Add(gameObject);
    }
}
