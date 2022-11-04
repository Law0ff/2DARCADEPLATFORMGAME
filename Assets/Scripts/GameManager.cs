using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{   
    public static GameManager Instance;
    float slowDownTime;

    public PressTextPanel pressTextPanel;
    private void Awake()
    {
        Instance = this;
    }
    public void OnSlowTime(float time)
    {
        pressTextPanel.ShowText(KeyCode.J);
        slowDownTime = time;
        Time.timeScale = 0.08f;
        Time.fixedDeltaTime = Time.timeScale * 0.03f;
        StartCoroutine(OnSlowTimeCR());
    }
    IEnumerator OnSlowTimeCR()
    {
        while (Time.timeScale < 1f)
        {
            Time.timeScale += (1f / slowDownTime) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            yield return null;
        }
        pressTextPanel.CloseText();
        yield return null;


    }
}
