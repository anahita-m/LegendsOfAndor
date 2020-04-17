using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ScreenManager
{
    public static Dictionary<string, Screen> screens;
    // have to map the scene name to loadlevels

    public ScreenManager()
    {
        screens = new Dictionary<string, Screen>();
        initScreens();
    }

    public static void sceneSwitch(string newScene){
        // newScene is the name of the unity scene
        if (PhotonNetwork.IsMasterClient){

            // no networking messages sent while the scene loads
            PhotonNetwork.IsMessageQueueRunning = false;

            PhotonNetwork.LoadLevel(newScene);

            PhotonNetwork.IsMessageQueueRunning = true;
            initScreen();
        }
    }


    public static void initScreen()
    {
        Debug.Log("before tried to addAllClickables()");
        string newScene = SceneManager.GetActiveScene().name;
        if (!screens.ContainsKey(newScene))
        {
            Debug.Log("Attempted to switch to scene: " + newScene +" which is not known to the screenManager script. see this scripts' initScreens() fxn for how to add the missing scene");
        }
        Debug.Log("well I tried to addAllClickables()");
        screens[newScene].loadScene();
    }

    public void initScreens()
    {
        string screenName = "fight-scene";
        screens.Add(screenName, new FightScreen(screenName));

        screenName = "AndorBoard";
        screens.Add(screenName, new AndorBoardScreen(screenName));
        Debug.Log("finished adding screens to screenManager's");
    }

    public static List<string> getClickables(string screenName)
    {
        Debug.Log("requested clickables for scene with name: "+screenName);
        if (screens == null)
        {
            Debug.Log("null screen in screenmanager class");
        }
        if (!screens.ContainsKey(screenName))
        {
            Debug.Log("never added screen with name: " + screenName + " to screen manager dict!");
            return null;
        }
        initScreen();
        List<string> clickables = screens[screenName].getClickables();
        if (clickables == null)
            initScreen();
        clickables = screens[screenName].getClickables();
        if (clickables == null)
            Debug.Log("clickables are still null after calling initScreen.");

        return clickables;
    }
}
