using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel ,isLocked;
    public string levelToLoad, levelToCheck , LevelName;
    //monedas recogidas
    public int gemsCollected, totalGems;
    //mejor tiempo y tiempo realizado
    public float bestTime, targetTime;
    // Start is called before the first frame update
    void Start()
    {
       if( isLevel && levelToLoad != null)
        {
            if(PlayerPrefs.HasKey(levelToLoad + "_gems")){
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }
            if (PlayerPrefs.HasKey(levelToLoad + "_time")){
                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }
            isLocked = true;
            if (levelToCheck != null)
            {
                if(PlayerPrefs.HasKey(levelToCheck+ "_unlocked"))
                {
                    if (PlayerPrefs.GetInt(levelToCheck + "_unlocked")==1)
                    {
                        isLocked = false;
                    }
                }
            }
            if(levelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
