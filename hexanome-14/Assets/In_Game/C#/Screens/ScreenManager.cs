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

    public static void sceneSwitch(string newScene, string playerID){
        // newScene is the name of the unity scene
        // playerName input passed to canOpenScreen which checks if this
        // player can open newScene
        Debug.Log("player with networkID: " + playerID + " wants to switch to scene: " + newScene);
        if (PhotonNetwork.IsMasterClient){
            if (screens.ContainsKey(newScene) && screens[newScene].canOpenScreen(playerID))
            {

                Debug.Log("can open screen, about to switch!");
                // no networking messages sent while the scene loads
                PhotonNetwork.IsMessageQueueRunning = false;

                PhotonNetwork.LoadLevel(newScene);

                PhotonNetwork.IsMessageQueueRunning = true;
                initScreen(newScene);
            }
            else
                Debug.Log("failed to load screen: " + newScene + " This happens when the scene with this name has not been added to the 'screens' dictionary in ScreenManager, or the player who requested to switch screens is not allowed to do so at this time.");
        }
    }


    public static void initScreen(string s)
    {
        Debug.Log("before tried to addAllClickables()");
        // string newScene = SceneManager.GetActiveScene().name;
        if (!screens.ContainsKey(s))
        {
            Debug.Log("Attempted to switch to scene: " + s +" which is not known to the screenManager script. see this scripts' initScreens() fxn for how to add the missing scene");
        }
        screens[s].loadScene();
    }

    public void initScreens()
    {
        string screenName = "fight-scene";
        screens.Add(screenName, new FightScreen(screenName));

        screenName = "Game";
        screens.Add(screenName, new AndorBoardScreen(screenName));
        Debug.Log("finished adding screens to screenManager's");
    }

    public static List<string> getClickables(string screenName, string playerName)
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
        initScreen(screenName);
        // this function returns the tags of all clickable gameObject's in the screen for this player.
        List<string> clickables = screens[screenName].getClickables();
        if (clickables == null)
            initScreen(screenName);
        clickables = screens[screenName].getClickables();
        if (clickables == null)
            Debug.Log("clickables are still null after calling initScreen.");

        return clickables;
    }

#region buttons

    private static bool hasButton(string buttonTag)
    {
        return screens[currScene()].getClickables().Contains(buttonTag);
    }

    private static string currScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    private static bool validClick(string buttonTag)
    {
        if (!hasButton(buttonTag))
        {
            Debug.Log("scene: " + currScene() + " doesn't have the button with tag: " + buttonTag + " in it's list of clickables, check the addAllClickables function for the current scene.");
            return false;
        }
        return true;
    }

    public static void buttonClick(string buttonTag)
    {
        if (validClick(buttonTag))
        {
            screens[currScene()].executeIfLegal(buttonTag);
        }
    }

#endregion buttons


}
