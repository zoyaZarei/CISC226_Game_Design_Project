using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private static LoadManager instance = null;
    public static List<string> inv = new List<string>();
    public static bool visitedFinalLevel = false;

    public static bool[] level3InvIsFull = { false, false, false };
    public static bool bagIsPickedUp = false;
    public static bool phoneIsPickedUp = false;
    public static bool necklaceIsPickedUp = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "FinalBossFight")
        {
            visitedFinalLevel = true;
        }
    }
}
