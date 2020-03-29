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
                PlayerPrefs.SetString("CharacterRank", "34");
            }
            if (whichCharacter == 2 || whichCharacter == 3)
            {
                PlayerPrefs.SetString("MyCharacter", "archer");
                PlayerPrefs.SetString("CharacterRank", "25");

            }
            if (whichCharacter == 4 || whichCharacter == 5)
            {
                PlayerPrefs.SetString("MyCharacter", "dwarf");
                PlayerPrefs.SetString("CharacterRank", "7");

            }
            if (whichCharacter == 6 || whichCharacter == 7)
            {
                PlayerPrefs.SetString("MyCharacter", "warrior");
                PlayerPrefs.SetString("CharacterRank", "14");

            }
            //PlayerPrefs.SetString("MyCharacter", whichCharacter);
        }
	}
}
