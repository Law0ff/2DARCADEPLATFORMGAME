using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public TextMeshProUGUI LifeText;
    private int LifeScoreCount;
    
    private bool CanDamage;

    

    void Awake()
    {
        //LifeText = GameObject.Find("LifeText").GetComponent<TextMeshProUGUI>();
        //LifeScoreCount = 3;
        //LifeText.text = "x" + LifeScoreCount;
        //Debug.Log("working");
        //CanDamage = true;
        LifeText = GameObject.Find("LifeText").GetComponent<TextMeshProUGUI>();
        LifeScoreCount = 4;
        LifeText.text = "x" + LifeScoreCount;
        CanDamage = true;
    }

    public void DealDamage()
    {
        if (CanDamage)
        {
            LifeScoreCount--;
            if (LifeScoreCount >= 0)
            {
                LifeText.text = "x" + LifeScoreCount;
            }

            if (LifeScoreCount == 0)
            {
                //RESTART THE GAME 
                Time.timeScale = 0f;
                StartCoroutine(RestartGame());
            }
            CanDamage = false;
            StartCoroutine(WaitForDamage());
        }
       
    }
    
    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        CanDamage = true;
    }
     
    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("MaýnMenu");
        
    }
}
