using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI coinTextScore; 
    private AudioSource audioManager;
    private int ScoreCount;


     void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Start()
    {
        coinTextScore = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();      
    }

     void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == myTags.COIN_TAG)
        {
            
            target.gameObject.SetActive(false);
            ScoreCount++;
            coinTextScore.text = "x" + ScoreCount;
            audioManager.Play();
        }



    }
    
}
