using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class del : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener ( delegate { onClickAction(); });
    }

    public void onClickAction()
    {
        Text t = gameObject.GetComponentInChildren<Text>();

        // make sure to replace spaces in t.text with -
        Debug.Log(t.text);
    }

}
