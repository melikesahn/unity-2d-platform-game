using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public int can=3;
    public GameObject[] kalp;
     PlayerKontrol player;
     public GameObject kaybettinizPanel;

   

    void Start()
    {
       
        kaybettinizPanel.SetActive(false);
        player=GameObject.Find("Player").GetComponent<PlayerKontrol>();
    }

    
    private void OnCollisionEnter2D(Collision2D oth)
    {
        if(oth.transform.tag=="fireBowl")
        {
           can--; 
           player.knockbackTimer=player.knockbackLenght;
           kalp[can].SetActive(false);
           deadKontrol();

        }
        if(player.transform.position.x<transform.position.x)
        {
            player.knockbackRight=false;
        }
        else{
            player.knockbackRight=true;
        }
    }
    void deadKontrol()
    {
        if(can<=0)
        {
         kaybettinizPanel.SetActive(true);
         Time.timeScale=0;
         
        
        }
    }
    
}
