using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    public Gun[] guns;
    Rigidbody2D rb;
    public float jumpPower;
    float moveSpeed = 3;
    bool moveUp;
    bool moveDown;
    bool MoveLeft;
    bool MoveRight;
    bool jump;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    bool Speedup;
    bool shoot;
    bool isDead=false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        rb=GetComponent<Rigidbody2D>();
        foreach (Gun gun in guns)
        {
            gun.isActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        MoveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        Speedup = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        jump = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);;
        shoot=Input.GetMouseButtonDown(0);

        if (shoot)
        {
            shoot = false;
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        isGrounded=Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.0f,0.22f),CapsuleDirection2D.Horizontal,0,groundLayer);
        if(!isDead){

      
        if (Speedup)
        {
            moveAmount *= 2;
        }
        Vector2 move = Vector2.zero;
        if (MoveLeft)
        {
            move.x -= moveAmount;
            animator.SetFloat("Speed", Mathf.Abs(move.x));
        }else{
            animator.SetFloat("Speed", 0);

        }
        if (MoveRight)
        {
            move.x += moveAmount;
            animator.SetFloat("Speed", Mathf.Abs(move.x));
        }
        if(jump&&isGrounded)
        {
            rb.velocity= new Vector2(rb.velocity.x,jumpPower);
            

        }

        pos += move;
        if (pos.x <= 40f)
        {
            pos.x = 40f;
        }
        if (pos.x >= 56f)
        {
            pos.x = 56f;
        }
        

        transform.position = pos;
          }
    }
    public void RestartGame(){
         SceneManager.LoadScene(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
                isDead=true;
                animator.SetInteger("Isdead", 1);
                Destroy(gameObject,2.2f);
                Destroy(bullet.gameObject);
                SceneManager.LoadScene(1);

            }
        }
        Destructble destructable = collision.GetComponent<Destructble>();
        if (destructable != null)
        {

            Destroy(gameObject);
            Destroy(destructable.gameObject);
        }
        
    }
}
