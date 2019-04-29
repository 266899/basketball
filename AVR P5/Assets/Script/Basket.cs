using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public GameObject score; //reference to the ScoreText gameobject, set in editor


    
    void OnTriggerEnter() //if ball hits basket collider
    {
        int currentScore = int.Parse(score.GetComponent<Text>().text) + 1; //add 1 to the score
        score.GetComponent<Text>().text = currentScore.ToString();
      
         
       
    }
}