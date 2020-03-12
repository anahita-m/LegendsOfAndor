using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnClickCharacterPick(int whichCharacter)
	{
        if(PlayerInfo.PI != null)
		{
            PlayerInfo.PI.mySelectedCharacter = whichCharacter;

            if (whichCharacter == 0 || whichCharacter == 1)
            {
                PlayerPrefs.SetString("MyCharacter", "wizard");
            }
            if (whichCharacter == 2 || whichCharacter == 3)
            {
                PlayerPrefs.SetString("MyCharacter", "archer");
            }
            if (whichCharacter == 4 || whichCharacter == 5)
            {
                PlayerPrefs.SetString("MyCharacter", "dwarf");
            }
            if (whichCharacter == 6 || whichCharacter == 7)
            {
                PlayerPrefs.SetString("MyCharacter", "warrior");
            }
			//PlayerPrefs.SetString("MyCharacter", whichCharacter);
		}
	}
}
