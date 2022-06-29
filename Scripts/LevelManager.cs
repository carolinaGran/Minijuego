using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//TFG
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    //tiempo que esperaremos para hacer el respawn
    public float waitToRespawn;
    //total de gemas
    public int gemsCollected;
    //total tiempo en el que hemos estado en el nivel
    public float timeInLevel;
    //escena que se cargara a continuación
    public string levelToLoad;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        timeInLevel = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;

    }
    public void RespawnPlayer()
    {
        //llamada a coroutine
        StartCoroutine(RespawnCo());
    }
    //las coroutine permiten dar un tiempo de espera despues de la ejecucion del codigo
    IEnumerator RespawnCo()
    {
        //desactivamos el jugador
        PlayerController.instance.gameObject.SetActive(false);
        //restablecemos la vida para que se visualice cuando se regenere el jugador
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        //transicion de colores de oscurecer o aclarecer
        yield return new WaitForSeconds(waitToRespawn - (1f /UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed)+ 2f);
        UIController.instance.FadeFromBlack();


        //despues del tiempo "waitToRespawn",lo volvemos a activar donde el ultimo 
        //checkpoint
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        UIController.instance.UpdateHealthDisplay();//rellena las vidas
    }
    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }
    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        //  UIController.instance.FadeToBlack();
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);

       /* if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if (gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
            }
        }
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if (timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }*/

         PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        SceneManager.LoadScene(levelToLoad);
    
    }
}
