using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public static Player instance;

    public float speed = 2f;

    public Animator animator;

    public Vector3 direction;
    public new Rigidbody2D rigidbody2D;
    public InventoryManager inventory;

    public bool running = false;
    public Image StaminaBar;
    public float Stamina, MaxStamina;

    public float AttackCost;
    public float RunCost;
    public float ChargeRate;

    private  Coroutine recharge;

    private void Awake()
    {
        if (instance != null  &&  instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
        inventory = GetComponent<InventoryManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    void Update ()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();

        if (Input.GetKeyDown(KeyCode.LeftShift))
		{
            running = true;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
            running = false;
		}
        if (running && (direction.x != 0 || direction.y != 0)) {
            rigidbody2D.velocity = direction * speed * 2.5f;

            Stamina -= RunCost * Time.deltaTime;
            if(Stamina < 0) {
                Stamina = 0;
            }
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if (recharge != null) {
                StopCoroutine(recharge);
            }
            recharge = StartCoroutine(rechargeStamina());
        }
        else {
            rigidbody2D.velocity = direction * speed;
        }

        AnimateMovement(direction);
        
        if(Input.GetKeyDown("f")) {
            Debug.Log("Attack!");

            Stamina -= AttackCost;
            if(Stamina < 0) {
                Stamina = 0;
            }
            StaminaBar.fillAmount = Stamina / MaxStamina;

            if (recharge != null) {
                StopCoroutine(recharge);
            }
            recharge = StartCoroutine(rechargeStamina());
        }
    }

    private IEnumerator rechargeStamina() {
        yield return new WaitForSeconds(1f);

        while (Stamina < MaxStamina) {
            Stamina += ChargeRate / 10f;
            if (Stamina > MaxStamina) {
                Stamina = MaxStamina;
            }
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Item dropedItem = 
            Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        //dropedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }
    public void DropItem(Item item, int numToDrop)
    {
        for(int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
    // input from player
    // apply movement to sprite

    private void FixedUpdate()
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("IsMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }
}
