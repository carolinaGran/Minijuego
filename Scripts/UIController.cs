using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    //TFG
    // Start is called before the first frame update
    public static UIController instance;
    //variables para las imagenes
    //hay que declarar la libreria UnityEngine.UI;
    public Image heart1, heart2, heart3;
    //hacer referencia cuando el corazon esta lleno y cuando esta vacio
    public Sprite heartFull, heartEmpty, heartHalf;
    //texto del canvas ui de las gemas
   public Text gemText;
    //Referencia a la imagen BlackScreen, para transición entre niveles
    public Image fadeScreen;
    //velocidad de transparencia de BlackScreen
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;
    public GameObject levelCompleteText;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateGemCount();
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed*Time.deltaTime));
            if(fadeScreen.color.a == 1f)
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
    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 3:
                //el orden es distinto pues el orden que se vacian me aparecia desordenado
                heart2.sprite = heartHalf;
                heart1.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 2:
                //el orden es distinto pues el orden que se vacian me aparecia desordenado
                heart2.sprite = heartEmpty;
                heart1.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                //el orden es distinto pues el orden que se vacian me aparecia desordenado
                heart2.sprite = heartEmpty;
                heart1.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                break;
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }
    public void UpdateGemCount()
    {
        gemText.text = LevelManager.instance.gemsCollected.ToString();
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
}

