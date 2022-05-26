using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONT : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("移動速度")] public float speed;
    [Header("ジャンプ速度")] public float jumpSpeed;
    [Header("重力")] public float gravity;
    [Header("ジャンプする高さ")] public float jumpHeight;
    [Header("ジャンプ制限時間")] public float jumpLimitTime;
    [Header("接地判定")] public GROUNDCHECK ground;
    [Header("頭をぶつけた判定")] public GROUNDCHECK head;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public AudioClip sound01;
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private new AudioSource audio;
    private bool isGround = false;
    private bool isJump = false;
    private bool isHead = false;
    private float jumpPos = 0.0f;
    private float jumpTime = 0.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audio = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGround = ground.IsGround();
        isHead = head.IsGround();
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxis("Vertical");
        
        float xSpeed = 0.0f;
        float ySpeed = -gravity;
        
        if (isGround)
        {
            if (Input.GetKey("up"))
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y;
                isJump = true;
                jumpTime = 0.0f;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            bool pushUpKey = Input.GetKey("up");
            
            bool canHeight = jumpPos + jumpHeight > transform.position.y;
            
            bool canTime = jumpLimitTime > jumpTime;
            if (Input.GetKey("up") && jumpPos + jumpHeight> transform.position.y)
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }
    
        if (Input.GetKey("left"))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("RUN", true);
            xSpeed = -speed;
            
            
        }
        else if (Input.GetKey("right"))
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("RUN", true);
            xSpeed = speed;
        }
        else
        {
            anim.SetBool("RUN", false);
            xSpeed = 0.0f;
        }
        anim.SetBool("JUMP", isJump); 
        anim.SetBool("GROUND", isGround); 
        rb.velocity = new Vector2(xSpeed,ySpeed);
    }
    void Update()
    {
        var i = this.transform.localScale.x;

        isGround = ground.IsGround();

        if (isGround)
        {
            if(Input.GetKey("right")!=true && Input.GetKey("left")!=true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if(i == 1)
                    {
                        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                        anim.SetBool("FIRE", true);
                        audio.PlayOneShot(sound01);
                    }
                    else if(i == -1)
                    {
                        Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
                        anim.SetBool("FIRE", true);
                        audio.PlayOneShot(sound01);
                    }
                }
                else
                {
                    anim.SetBool("FIRE", false);
                }
            }
            else if (Input.GetKey("right"))
            {
                anim.SetBool("FIRE", false);
            }
            else if (Input.GetKey("left"))
            {
                anim.SetBool("FIRE", false);
            }
            else
            {
                anim.SetBool("FIRE", false);
            }
        }

    }
}
