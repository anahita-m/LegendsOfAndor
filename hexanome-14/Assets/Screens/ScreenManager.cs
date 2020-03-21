using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public Dictionary<string, Screen> screens;
    // have to map the scene name to loadlevels
    private GameObject baseObj;

    private GameObject gameObj;
    // public ScreenManager screenManager;

    // void Awake()
    // {
    //     DontDestroyOnLoad(this.gameObject);
    // }

    // make this dont destroy on load cuz why not
    // Start is called before the first frame update
    void Start()
    {
        // ie don't show move if not your turn
        // screenManager = GameObject.FindWithTag("ScreenManager").GetComponent<ScreenManager>();
        screens = new Dictionary<string, Screen>();
        baseObj = (GameObject) Resources.Load("empty");
        initScreens();
        DontDestroyOnLoad(gameObject);
    }

    public void init()
    {
        screens = new Dictionary<string, Screen>();
        baseObj = (GameObject) Resources.Load("empty");
        initScreens();
        // DontDestroyOnLoad(gameObject);

    }

    public void onSceneSwitch()
    {
        Debug.Log("before tried to addAllClickables()");
        string newScene = SceneManager.GetActiveScene().name;
        if (!screens.ContainsKey(newScene))
        {
            Debug.Log("Attempted to switch to scene: " + newScene +" which is not known to the screenManager script. see this scripts' initScreens() fxn for how to add the missing scene");
        }
        Debug.Log("well I tried to addAllClickables()");
        screens[newScene].onSwitch();
    }

    private void initScreens()
    {
        string screenTag = "fight-scene";
        createScreen(screenTag);
        gameObj.AddComponent<FightScreen>();
        screens.Add(screenTag, gameObj.GetComponent<FightScreen>());

        screenTag = "AndorBoard";
        createScreen(screenTag);
        gameObj.AddComponent<AndorBoardScreen>();
        screens.Add(screenTag, gameObj.GetComponent<AndorBoardScreen>());
    }

    private void createScreen(string screenTag)
    {
        gameObj = Instantiate(baseObj, gameObject.transform.position, gameObject.transform.rotation);
        gameObj.transform.parent = gameObject.transform;
        gameObj.tag = screenTag;
    }


    public List<string> getClickables(string screenName)
    {
        Debug.Log("requested clickables for scene with name: "+screenName);
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
