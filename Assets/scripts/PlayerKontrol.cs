using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerKontrol : MonoBehaviour
{
public float hareketHizi;
public float ziplamaHizi;
private bool ziplamaDurum;
private float move=0;
private Rigidbody2D rb;
private Animator anim;

private bool slide; 
private float slideTimer=0;
[SerializeField]
private float  maxslideTime;

private int score;
[SerializeField] private TMP_Text scoreText;




[SerializeField]
internal float knockbackPower;
internal float knockbackTimer;
[SerializeField]
internal float knockbackLenght;
internal bool knockbackRight;

    void Start()
    {
        score=0;
        scoreText.text="SCORE "+score.ToString();

        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();     
    }

    void Update()
    {
        scoreText.text="SCORE "+score.ToString();
        
        


        //rb.velocity=new Vector2(move*hareketHizi,rb.velocity.y);
        if(knockbackTimer<0)
        {
           rb.velocity=new Vector2(move*hareketHizi,rb.velocity.y);
        }
        
            else{
            if(knockbackRight){
                        rb.velocity=new Vector2(knockbackPower,knockbackPower);
                    }
                    if(!knockbackRight){
                        rb.velocity=new Vector2(-knockbackPower,knockbackPower);
                    }
                    knockbackTimer-=Time.deltaTime;
            }

             move =Input.GetAxis("Horizontal");

        if (move<0)
        {
            transform.eulerAngles=new Vector3(0,180,0);

            slide=false;
            anim.SetBool("slide",false);

        }else if (move>0)
        {
            transform.eulerAngles=new Vector3(0,0,0);
        }
        if (Input.GetButtonDown("Jump") && !ziplamaDurum)
        {
            rb.AddForce(new Vector2(rb.velocity.x,ziplamaHizi));
            ziplamaDurum=true;
        }
        RunAnimations();
        Slide();
    }
    void RunAnimations()
    {
        anim.SetFloat("Speed",Mathf.Abs(move));
        anim.SetBool("jump",ziplamaDurum);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Zemin"))
        {
            ziplamaDurum=false;
        }
    }

    private void Slide()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !slide)
        {
            slideTimer=0;
            slide=true;
            anim.SetBool("slide",true);

        }
        if(slide)
        {
            slideTimer+=Time.deltaTime;
            if(slideTimer>maxslideTime)
            {
                slide=false;
                anim.SetBool("slide",false);
            }
        }
    }



     private void OnTriggerEnter2D(Collider2D othe) {
        if(othe.gameObject.tag=="coin")
        {
        Destroy(othe.gameObject);
        score+=18;
        
        }
        if(othe.gameObject.tag=="coin1")
        {
        Destroy(othe.gameObject);
        score+=19;
        
        }
    }
    
    
}
