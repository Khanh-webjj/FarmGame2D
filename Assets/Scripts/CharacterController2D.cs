using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D r2d;
    [SerializeField] float speed = 2f;
    [SerializeField] float runSpeed = 5f;
    Vector2 motionVector;
    public Vector2 lastMotionVetor;
    Animator animator;
    bool moving;
    bool running;

    // Start is called before the first frame update
    void Awake()
    {
        r2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
            running = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
            running = false;
		}
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(horizontal, vertical);
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical",vertical);

        moving = horizontal != 0|| vertical != 0;
        animator.SetBool("moving", moving);

        if(horizontal != 0 || vertical != 0)
        {
            lastMotionVetor = new Vector2(horizontal,vertical);
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
	}
	// Update is called once per frame
	void FixedUpdate()
    {
        Move();
    }
	private void Move()
	{
        r2d.velocity = motionVector * (running == true ? runSpeed :speed);
	}
	private void OnDisable()
	{
        r2d.velocity = Vector2.zero;
	}
}
