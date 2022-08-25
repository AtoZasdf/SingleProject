using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

    public float Speed = 2f;

    public float jumpForce = 5f;

    public bool grounded = false;
    private bool jump = false;

    public bool righton = false;
    public bool lefton = false;
    public bool downon = false;
    public bool upon = false;

    public bool sideon = false;

    public bool gravity = false;//중력 오브젝트


    float ClickTime = 0f;

    public int isJumpUp = 0;//점프력향상 물약(일회성)  0일때 물약아이템 없는 상태,  1일때 물약아이템 먹은상태, 2일때 막 사용한 상태

    public bool isDubleJump = false;//더블점프 물약(일회성)


    ParticleSystem.MainModule _particle;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        _particle = GetComponent<ParticleSystem>().main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            ClickTime += Time.deltaTime;   
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (ClickTime <= 0.25f && grounded)//기본 점프  (짧게 꾹
            {
                jump = true;
            }
            else if (isDubleJump == true)//더블 점프
            {
                jump = true;
                isDubleJump = false;
            }

            

            ClickTime = 0;
        }

        if (ClickTime > 0.25f && grounded)//높게 점프(jumpup물약 먹었을때만) 길게 꾹
        {
            jump = true;

            if (isJumpUp == 1)
            {
                isJumpUp = 2;
            }
            //물약 안먹었을때는 꾹누르고 있으면 계속 점프가 된다
        }


    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.gameStart)
        {
            rigid.gravityScale = 0;
            return;
        }

        if (jump)
        {
            sideon = false;
            if(righton == true) { Speed = gravity == true ? 2 : -2; } else if(lefton == true) { Speed = gravity == true ? -2 : 2; }

            if(isJumpUp == 2) 
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpForce * 2);
                isJumpUp = 0;
            }
            else
            {
                rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            }
            
            
            jump = false;

            grounded = false;
        }
        if (righton || lefton)
        {

            if(gravity == false)
            {
                if (rigid.velocity.y < 0)
                {
                    sideon = true;
                }
            }
            else
            {
                if (rigid.velocity.y > 0)
                {
                    sideon = true;
                }
            }
            
        }
        rigid.velocity = new Vector2(Speed, rigid.velocity.y);

        if (sideon)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);

            rigid.gravityScale = 0;
            transform.Translate(new Vector2(0, -0.025f));
        }
        else
        {

            rigid.gravityScale = gravity == true ? -1 : 1;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, gravity == true ? 180 : 0));

            jumpForce = gravity == true ? -5f : 5f;

        }

        

        if (isJumpUp == 1 && isDubleJump)
        {
            _particle.startColor = new Color(255, 255, 0, 255);
        }
        else if (isJumpUp==1)
        {
            _particle.startColor = new Color(255, 0, 0, 255);

        }
        else if (isDubleJump)
        {
            _particle.startColor = new Color(0, 255, 0, 255);
        }
        else
        {
            _particle.startColor = new Color(0, 0, 0, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        grounded = true;

        if(col.gameObject.tag == "Finish")
        {
            PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") <= GameManager.instance.CurrentStage ? GameManager.instance.CurrentStage : PlayerPrefs.GetInt("Stage"));
            Debug.Log("클리어");
            GameManager.instance.Clear();
            GameManager.instance.gameStart = false;
        }
        if(col.gameObject.tag == "Enemy")
        {
            GameManager.instance.Dead();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            GameManager.instance.Dead();
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
    }
}
