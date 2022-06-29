using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUIManager : MonoBehaviour
{
    public static LSUIManager instance;
    public Image fadeScreen;
    //velocidad de transparencia de BlackScreen
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;
    //para activar panel de nombre cuando se selecciona un nivel
    public GameObject levelInfoPanel;
    //acceder al texto del panel
    public Text levelName ,gemsFound,gemsTarget, bestTime ,timeTarget;
   
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        FadeFromBlack();  
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;

            }
        }
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;

            }
        }
    }
    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;

    }
    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;

    }
    public void ShowInfo(MapPoint levelInfo)
    {
        levelName.text = levelInfo.LevelName;
        //texto de monedas y tiempo 
        gemsFound.text = "FOUND: " + levelInfo.gemsCollected;
        gemsTarget.text = "IN LEVEL: " + levelInfo.totalGems;

        timeTarget.text = "TARGET: " + levelInfo.targetTime + "s";
        if(levelInfo.bestTime== 0)
        {
            bestTime.text = "BEST ---";
        }
        else
        {
            bestTime.text = "BEST " + levelInfo.bestTime.ToString("F2") + "s";
        }
        levelInfoPanel.SetActive(true);
    }
    public void HideInfo()
    {
        levelInfoPanel.SetActive(false);
    }
}
