using UnityEngine;
using System.Collections;

public class ChickenControl : MonoBehaviour {

    // Private Attribs
    private bool isGrounded = false;
    private float offsetGroundRay = 1.5f;
    private bool needJump = false;
    private float jumpDelay;
    private float startValor;
    private float timeElapsed;
    private GameObject player;
    private PlayerControls playerControls;


    private Animator chickenAnimator;

    // public Attribs
    public float offSetX = 0;
    public bool isAlive = true;

    // Use this for initialization
    void Start () {
        startValor = Random.Range(0, 10);
        timeElapsed = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerControls  = player.GetComponent<PlayerControls>();

        chickenAnimator = GetComponent<Animator>();

        float rdmScale = Random.Range(0.8f, 1.2f);
        transform.localScale *= rdmScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (jumpDelay != 0.0f)
        {
            jumpDelay = Mathf.Max(0f, jumpDelay - Time.deltaTime);
        }

        if (jumpDelay == 0.0f && needJump && isGrounded)
        {
            if (playerControls.CurrentSpeed <= 1f) {
                chickenAnimator.SetTrigger("Jump");
            }
            needJump = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Random.Range(0, 200) + 400));
        }

        float ratio = (timeElapsed - Time.fixedTime);
        offSetX = Mathf.Sin(ratio + startValor);

        if (isAlive)
        {
            chickenAnimator.SetFloat("Speed", playerControls.CurrentSpeed);
            transform.position = new Vector2(player.transform.position.x + playerControls.distPouletPlayer + offSetX, transform.position.y);
        }
    }

    void FixedUpdate() {
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
    }

    public void attackAnimation() {
        chickenAnimator.SetTrigger("Attack");
    }

    public void killIt()
    {
        isAlive = false;
    }

    public void jump(float time) {
        needJump = true;
        jumpDelay = time;
    }
}



