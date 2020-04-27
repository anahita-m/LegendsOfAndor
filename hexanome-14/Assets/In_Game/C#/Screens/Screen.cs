using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : IEnumerable<string>
{
    // list of all clickables in this screen.
    // each clickable should correspond with an action
    protected List<string> clickables;
    protected string screenName;

    public Screen(string name)
    {
        clickables =  null;
        screenName = name;
    }
    // since the addAllClickables function likely references objects
    // which only exist in the corresponding scene to this screen class
    public void loadScene()
    {
        if (clickables == null)
        {
            Debug.Log("add all clickables");
            addAllClickables();
        }
    }

    public virtual void preSwitchSceneActions() { }

    // overriden by children
    protected virtual void addAllClickables() { }

    public virtual bool canOpenScreen(string playerID) { return true; }

    public virtual void executeIfLegal(string buttonName) { }

    public string getName()
    {
        // each screen is given its tag by its parent gameObject: ScreenManager.cs
        return screenName;
    }


    public List<string> getClickables()
    {
        if (clickables == null)
        {
            Debug.Log("called GetClickables when clickables is still null");
            return null;
        }
        return clickables;
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
