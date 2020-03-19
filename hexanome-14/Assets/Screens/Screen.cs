using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour, IEnumerable<string>
{
    public ScreenManager screenManager;
    // Start is called before the first frame update
    protected List<string> clickables;

    // // for the click script
    // public List<string> getClickableTags()
    // {
    // }

    // // for if we can switch to this scene
    // public void canSwitchScreens(string playerTag)
    // {
    // }



    // Start is called before the first frame update
    void Start()
    {
        clickables = new List<>();
    }


    public string getName()
    {
        // each screen is given its tag by its parent gameObject: ScreenManager.cs
        return gameObject.tag;
    }

    public List<string> getClickables()
    {
        return GetEnumerator();
    }

    public IEnumerator<string> GetEnumerator()
    {
        foreach(string clickableTag in clickables)
        {
            yield return clickableTag;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}
