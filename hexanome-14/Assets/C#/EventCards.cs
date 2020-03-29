using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCards : MonoBehaviour
{
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }


//     //EVENT CARD - 1

//     //EVENT CARD - 2
//      public static void eventCard2(Array playerList){
//         GameConsole.displayMessage("24-  Any hero not on a forest space loses 2 wllpower points.");
//         foreach (string playerTag in playerList){
//         	int playerPos = convertToInt(GameObject.FindWithTag(playerTag).GetComponent<BoardPosition>.position);
//             if (playerPos <= 20 && playerPos >= 0){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower -= 3;
//             }
//         }
//     }

//     //EVENT CARD - 3

//     //EVENT CARD - 4

//     //EVENT CARD - 5

//     //EVENT CARD - 6

//     //EVENT CARD - 7
//      public static void eventCard7(Array playerList){
//         GameConsole.displayMessage("7-  The hero with the lowest rank rolls one of his hero dice.The group loses the rolled number of willpower points.");
//         //TO DO 
//     }

//     //EVENT CARD - 8

//     //EVENT CARD - 9

//     //EVENT CARD - 10

//     //EVENT CARD - 11
//     public static void eventCard11(){
//         GameConsole.displayMessage("11- Each creature has 1 extra strength point.");
//         List monsterPositions = BoardContents.getAllMonsterPositions().Keys.ToList();
//         foreach (var monster in monsterPositions){
//             GameObject.FindWithTag(monster).GetComponent<Monster>.strength += 1;
//             }
//         }
//     }



//     //EVENT CARD - 12


//      //EVENT CARD - 13
//     public static void eventCard13(Array playerList){
//         GameConsole.displayMessage("13-  Each Hero who has fewer than 10 willpower points can immediately raise his total to 10.");
//         foreach (string playerTag in playerList){
//             if (GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower < 10){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower = 10;
//             }
//         }
//     }

//     //EVENT CARD - 14
//     public static void eventCard14(Array playerList){
//         GameConsole.displayMessage("14 - Dwarf and Warrior immediately get 3 willpower points each.");
//         GameObject.FindWithTag(“dwarf”).GetComponent<Hero>.willpower += 3;
//         GameObject.FindWithTag(“warrior”).GetComponent<Hero>.willpower += 3;
//     }


//     //EVENT CARD - 15

//     //EVENT CARD - 16

//     //EVENT CARD - 17

//     //EVENT CARD - 18

//     //EVENT CARD - 19

//     //EVENT CARD - 20


//     //EVENT CARD - 24

//     public static void eventCard24(Array playerList){
//         GameConsole.displayMessage("24-  Any hero not on a forest space loses 2 wllpower points.");
//         foreach (string playerTag in playerList){
//         	int playerPos = convertToInt(GameObject.FindWithTag(playerTag).GetComponent<BoardPosition>.position);
//             if (playerPos = 71 || playerPos = 72 || playerPos = 0){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower -= 2;
//             }
//         }
//     }
    

//     //EVENT CARD - 28
//     public static void eventCard28(Array playerList){
//         GameConsole.displayMessage("28 - Every Hero whose time marker is presently in the sunrise box gets 2 willpower points");
//         foreach (string playerTag in playerList){
//             if (GameObject.FindWithTag(playerTag).GetComponent<Player>.hour == 0){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower += 2;
//             }
//         }
//     }

// //EVENT CARD - idk2
//     public static void eventCardIdk2(Array playerList){
//         GameConsole.displayMessage("idk - The wizard and the archer each immediately get 3 willpower points.");
//             if (playerTag == "wizard" || playerTag == "archer"){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower += 3;
//         }
//     }

//     //EVENT CARD 31
//      public static void eventCard31(Array playerList){
//         GameConsole.displayMessage("31-  Any hero not on a forest space loses 2 wllpower points.");
//         foreach (string playerTag in playerList){
//         	int playerPos = convertToInt(GameObject.FindWithTag(playerTag).GetComponent<BoardPosition>.position);
//             if (playerPos = 71 || playerPos = 72 || playerPos = 0){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower -= 2;
//             }
//         }
//     }

//     //EVENT CARD - 32
//     public static void eventCard32(Array playerList){
//         GameConsole.displayMessage("32: Each Hero whose time marker is presently in the sunrise box loses 2 willpower points");
//         foreach (string playerTag in playerList){
//             if (GameObject.FindWithTag(playerTag).GetComponent<Player>.hour == 0){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower -= 2;
//             }
//         }
//     }


//     //EVENT CARD RANDOM!! DON'T KNOW
//     public static void eventCardIDK(Array playerList){
//         GameConsole.displayMessage("Not Sure 3 -  Each hero standing on a space with a number between 37 and 70 now loses 3 willpower points.");
//         foreach (string playerTag in playerList){
//             int pos = convertToInt(GameObject.FindWithTag(playerTag).GetComponent<BoardPosition>.position);
//             if( pos >= 37 && pos <= 70){
//                 GameObject.FindWithTag(playerTag).GetComponent<Hero>.willpower -= 3;
//             }
//         }
//     }
}
