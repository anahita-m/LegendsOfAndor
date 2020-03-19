using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public Dictionary<string, Screen> screens;
    // have to map the scene name to loadlevels
    private GameObject baseObj;

    private GameObject gameObj;

    // make this dont destroy on load cuz why not
    // Start is called before the first frame update
    void Start()
    {
        // ie don't show move if not your turn
        screens = new Dictionary<>();
        baseObject = (GameObject) Resources.Load("empty");
        initScreens();
    }


    private void initScreens()
    {
        string screenTag = "FightScreen";
        createScreen(screenTag);
        gameObj.AddComponent<FightScreen>();
        screens.Add(screenTag, gameObj.GetComponent<FightScreen>());

        screenTag = "AndorBoardScreen";
        createScreen(screenTag);
        gameObj.AddComponent<AndorBoardScreen>();
        screens.Add(screenTag, gameObj.GetComponent<AndorBoardScreen>());
    }

    private void createScreen(string screenTag)
    {
        gameObj = Instantiate(baseObject, gameObject.transform.position, gameObject.transform.rotation);
        gameObj.transform.parent = gameObject.transform;
        gameObj.tag = screenTag;
    }


    public List<string> getClickables(string screenName)
    {
        return screens[screenName].getClickables();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
