using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickRouter : MonoBehaviour
{
    // all buttons in scene: fight-scene have this as their onClick fxn
    public void fightSceenButton()
    {
        // button name is the name (NOT TAG) of the gameObject which contains the clicked button
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        ScreenManager.buttonClick(clickedButtonName);
    }
}
