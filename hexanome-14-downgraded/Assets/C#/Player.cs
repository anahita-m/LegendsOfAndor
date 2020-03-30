using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;


namespace Andor
{
    public class Player : MonoBehaviourPun, IPunObservable
    {
        // [HideInInspector]
        // public GameObject sphere;

        private Vector3 newPos;
        private Player_click_handler click_handler;
        public ScreenManager screenManager;

        private string userName;
        private string currentScene;

        // ie Player-Male-Dwarf
        // also encodes the corresponding hero type
        // and Sphere-Male-Dwarf. sphere object is attached to this script.
        private string myTag;
        private string heroType;
        public string position;
        public static string hour;
        public int time;

        public string playerTag;

        private Hero myHero;
        // Will need to use this to verify things like: 
        // showTradeRequest() { if player.lookingAt != Battle then showTradeRequest() }
        // private Screen lookingAt;

        public string NickName { get; internal set; }

        public Vector3 hour1 = new Vector3(1.13f, 30.11f, 0f);
        public Vector3 hour2 = new Vector3(5.26f, 30.11f, 0f);
        public Vector3 hour3 = new Vector3(9.48f, 30.11f, 0f);
        public Vector3 hour4 = new Vector3(13.54f, 30.11f, 0f);
        public Vector3 hour5 = new Vector3(17.79f, 30.11f, 0f);
        public Vector3 hour6 = new Vector3(21.81f, 30.11f, 0f);
        public Vector3 hour7 = new Vector3(26.06f, 30.11f, 0f);

        void Awake()
        {
            currentScene = SceneManager.GetActiveScene().name;
            if (!screenManager)
                Debug.Log("couldnt find a screenManager script attached, note the player script is used in two diff prefabs, so this is probably cuz one of these doesnt have this script attached");

            if (!gameObject.GetComponent<Player_click_handler>())
            {
                Debug.Log("don't got clicker");
            }
            else
            {
                click_handler = gameObject.GetComponent<Player_click_handler>();
            }
        }

        void Start()
        {
            if (photonView.IsMine)
            {
                Debug.Log("in player, view is mine");
                transform.localScale = new Vector3(2.2f, 2.2f, 0.12f);
            }

            playerTag = PlayerPrefs.GetString("MyCharacter");
            // addScreenManager();
            // myHero = new Hero();
            playerGold = new Dictionary<string, int>();
            position = PlayerPrefs.GetString("CharacterRank");
            time = 0;

            // myHero.setGold(UnityEngine.Random.Range(0, 10));
            // updateCoin(myTag, myHero.getGold());
            // Debug.Log("MY PLAYER HAS " + myHero.getGold() + " COINS!");
            // if (!photonView.IsMine && GetComponent<PlayerController>() != null)
            // Destroy(GetComponent<PlayerController>());
        }

        // private void addScreenManager()
        // {
        //     GameObject e = (GameObject) Resources.Load("screenMan");
        //     DontDestroyOnLoad(e);
        //     screenManager = e.GetComponent<ScreenManager>();
        //     screenManager.init();
        //     Debug.Log("added screenmanager to player");
        // }


        public static string getHour()
        {
            return hour;
            //this.hour
        }

        public void setHour(string h)
        {
            hour = h;
        }

        //GET POSITIONS FROM BOARD POSITIONS!

        //public string getPlayerPos()
        //{
        //    return this.position;
        //}

        //public void setPlayerPos(string pos)
        //{
        //    position = pos;
        //}

        public void setTag(string ID)
        {
            myTag = ID;
            gameObject.tag = ID;
            setHeroType();
        }

        public void setHero(Hero hero)
        {
            myHero = hero;
        }

        public string getPlayerTag()
        {
            return myTag;
        }

        public Dictionary<string, int> playerGold;

        // void OnMouseOver()
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         int g = myHero.getGold();
        //         Debug.Log("Player has: " + g);
        //     }
        // }


        // [PunRPC]
        // public void serverUpdateCoin(string playerTag, int gold)
        // {
        //     if (!playerGold.ContainsKey(playerTag))
        //     {
        //         playerGold.Add(playerTag, gold);
        //     }
        //     else
        //     {
        //         playerGold[playerTag] = gold;
        //     }
        // }

        // public void updateCoin(string playerTag, int gold)
        // {
        //     Debug.Log("HIHIHIHIHI");

        //     if (photonView != null && photonView.IsMine)
        //     {
        //         Debug.Log("Im in!");

        //         photonView.RPC("serverUpdateCoin", RpcTarget.All, playerTag, gold);
        //     }
        // }




        public string getHeroType()
        {
            return heroType;
        }

        void Update()
        {
            // if (updateCode())
            updateCode();
            moveToNewPos(newPos);
        }

        // void FixedUpdate()
        // {
        //     updateCode();
        //     moveToNewPos(newPos);

        // }

        public bool updateCode()
        {
            if (photonView.IsMine)
            {
                if (ScreenManager.screens == null)
                {
                    screenManager.init();
                }
                //     if (screenManager == null && currSceneTag() == "AndorBoard")
                //     {
                //         addScreenManager();
                //     }
                //     else
                //         return false;
                // }

                if (Input.GetMouseButtonDown(0))
                {
                    if (click_handler != null)
                    {
                        click_handler.checkClick(newPos, this);
                    }
                    else return false;
                    // string s = currSceneTag();
                }
            }
            return true;
        }

        public void OnClickPass()
        {
            //GameObject player = GameObject.FindGameObjectWithTag(playerTag);
            timeTracker t = GetComponent<timeTracker>();
            t.setHour(5);
        }

        public void OnClickEndDay()
        {
                //GameObject player = GameObject.FindGameObjectWithTag(playerTag);
                timeTracker t = GetComponent<timeTracker>();
                t.setHour(8);
        }

        public void moveTo(string newLoc, Vector3 newPos)
        {
            //check if it is legal in terms of hours 
            transform.position = newPos;
            BoardContents.setNewPlayerPosition(playerTag, newLoc);
            string oldpos = BoardContents.getPlayerPosition(playerTag);
            // int distance = Graph.getDistance(oldpos, newLoc)
            // Monster.moveAllMonstersAtSunrise();
            Monster.moveAllMonstersAtSunrise();
            //foreach (KeyValuePair<string, string> entry in Monster.monsterPositions)
            //{
            //    Debug.Log(entry.Key + " " + entry.Value);
            //}
            GameConsole.instance.UpdateFeedback("Player " + playerTag + " has moved to " + BoardContents.getPlayerPosition(playerTag));


        }



        // extracts the hero tag from our own tag
        // EX.)   if (myTag == "Player-Male-Dwarf") -> output "Male-Dwarf"
        private void setHeroType()
        {
            // must initialize before adding strings
            //heroType = "";
            //int ct = 0;
            //string[] partsOfTag = myTag.Split('-');
            //if (partsOfTag.Length != 3)
            //{
            //    Debug.Log("Found a bad tag in Player.setHeroType: " + myTag);
            //}
            heroType = myTag;
            //heroType = partsOfTag[1] + "-" + partsOfTag[2];
            //foreach(string partOfTag in myTag.Split('-'))
            //{
            //    // skip first val: "Player"
            //    if (ct++ == 0) continue;

            //    heroType += partOfTag;
            //}
        }


        public void moveToNewPos(Vector3 newPos)
        {
            float x1 = transform.position[0];
            float x2 = transform.position[1];
            float x3 = transform.position[2];

            float newX = Mathf.MoveTowards(x1, newPos[0], 1);
            float newY = Mathf.MoveTowards(x2, newPos[1], 1);
            float newZ = Mathf.MoveTowards(x3, newPos[2], 1);

            transform.position = new Vector3(newX, newY, newZ);
        }

        public void setNewPos(Vector3 newPosition)
        {
            newPos = newPosition;
        }


        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            //Debug.Log("tryna write or read");
            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
            }
            else
            {
                newPos = (Vector3)stream.ReceiveNext();
            }
        }

        public static void RefreshInstance(ref Player player, string prefab)
        {
            var position = Vector3.zero;
            var rotation = Quaternion.identity;
            if (player != null)
            {
                position = player.transform.position;
                rotation = player.transform.rotation;
                PhotonNetwork.Destroy(player.gameObject);
            }

        }

        public void changeOfScene(string newSceneTag)
        {
            currentScene = newSceneTag;
            ScreenManager.sceneSwitch(currentScene);
        }


        public string currSceneTag()
        {
            if ( SceneManager.GetActiveScene().name != currentScene)
            {
                Debug.Log("currentScene tag in player different from SceneManager.GetActiveScene().name");
                currentScene = SceneManager.GetActiveScene().name;
            }
            return currentScene;
        }
    }
}

