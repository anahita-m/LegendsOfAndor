using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ScreenManager : MonoBehaviour
{
    public static Dictionary<string, Screen> screens;
    // have to map the scene name to loadlevels
    private GameObject baseObj;

    private GameObject gameObj;

    void Start()
    {
        screens = new Dictionary<string, Screen>();
        initScreens();
    }

    public void init()
    {
        screens = new Dictionary<string, Screen>();
        initScreens();
    }

    public static void sceneSwitch(string newScene){
        if (PhotonNetwork.IsMasterClient){

            PhotonNetwork.IsMessageQueueRunning = false;

            PhotonNetwork.LoadLevel(newScene);

            PhotonNetwork.IsMessageQueueRunning = true;
            onSceneSwitch();
        }
    }


    public static void onSceneSwitch()
    {
        Debug.Log("before tried to addAllClickables()");
        string newScene = SceneManager.GetActiveScene().name;
        if (!screens.ContainsKey(newScene))
        {
            Debug.Log("Attempted to switch to scene: " + newScene +" which is not known to the screenManager script. see this scripts' initScreens() fxn for how to add the missing scene");
        }
        // Debug.Log("well I tried to addAllClickables()");
        screens[newScene].onSwitch();
    }

    public void initScreens()
    {
        string screenTag = "fight-scene";
        screens.Add(screenTag, gameObject.GetComponent<FightScreen>());

        screenTag = "AndorBoard";
        screens.Add(screenTag, gameObject.GetComponent<AndorBoardScreen>());
        Debug.Log("finished adding screens to screenManager's");
    }


    public static List<string> getClickables(string screenName)
    {
        Debug.Log("requested clickables for scene with name: "+screenName);
        if (!screens.ContainsKey(screenName))
        {
            Debug.Log("never added screen with name: " + screenName + " to screen manager dict!");
            return null;
        }
        List<string> clickables = screens[screenName].getClickables();
        if (clickables == null)
            onSceneSwitch();
        clickables = screens[screenName].getClickables();
        if (clickables == null)
            Debug.Log("clickables are still null after calling onSceneSwitch.");

        return clickables;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
