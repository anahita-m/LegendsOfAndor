using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour, IEnumerable<string>
{
    // Start is called before the first frame update
    protected List<string> clickables =  null;

    // can't just run this function at Start()
    // since the addAllClickables function likely references objects
    // which only exist in the corresponding scene to this screen class
    public void onSwitch()
    {
        if (clickables == null)
        {
            Debug.Log("add all clickables");
            addAllClickables();
        }
    }

    // overriden by children
    protected virtual void addAllClickables()
    {
    }

    public virtual void init()
    {
    }


    public string getName()
    {
        // each screen is given its tag by its parent gameObject: ScreenManager.cs
        return gameObject.tag;
    }

    public List<string> getClickables()
    {
        if (clickables == null)
        {
            Debug.Log("called GetClickables when clickables is still null");
            return null;
        }
        // Debug.Log("returning clickables");
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
