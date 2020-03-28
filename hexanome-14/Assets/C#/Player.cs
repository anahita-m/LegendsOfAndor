﻿using System.Collections;
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

        public bool initialized = false;
        private string userName;
        private string currentScene;

        // ie Player-Male-Dwarf
        // also encodes the corresponding hero type
        // and Sphere-Male-Dwarf. sphere object is attached to this script.
        private string myTag;
        private string heroType;
        public ScreenManager screenManager;

        private Hero myHero;
        // Will need to use this to verify things like: 
        // showTradeRequest() { if player.lookingAt != Battle then showTradeRequest() }
        // private Screen lookingAt;

        public string NickName { get; internal set; }

        void Awake()
        {

            currentScene = SceneManager.GetActiveScene().name;
            // screenManager = baseObj.GetComponent<ScreenManager>();
            if (!screenManager)
                Debug.Log("couldnt find a screenManager script attached, note the player script is used in two diff prefabs, so this is probably cuz one of these doesnt have this script attached");

            click_handler = gameObject.GetComponent<Player_click_handler>();
            if (!gameObject.GetComponent<Player_click_handler>())
            {
                Debug.Log("don't got clicker");
                // gameObject.AddComponent<Player_click_handler>();
                // gameObject.GetComponent<Player_click_handler>().enabled = true;
            }

        }

        void Start()
        {
            if (photonView.IsMine)
            {
                Debug.Log("in player, view is mine");
                Debug.Log("my tag is: " + gameObject.tag);

                transform.localScale = new Vector3(2.2f, 2.2f, 0.12f);
            }
            myHero = new Hero();
            playerGold = new Dictionary<string, int>();
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


        public string getHeroType()
        {
            return heroType;
        }

        void Update()
        {
            updateCode();
        }

        public void updateCode()
        {
            if (photonView.IsMine)
            {
                if (screenManager == null)
                {
                    if (screenManager == null && currSceneTag() == "AndorBoard")
                    {
                        addScreenManager();
                    }
                    else
                        return;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    // string s = currSceneTag();
                    click_handler.checkClick(newPos, this);
                }
            }
            moveToNewPos(newPos);
        }

        private void addScreenManager()
        {
            GameObject e = (GameObject) Resources.Load("screenMan");
            DontDestroyOnLoad(e);
            screenManager = e.GetComponent<ScreenManager>();
            screenManager.init();
            Debug.Log("added screenmanager to player");
        }


        public void setTag(string tag)
        {
            gameObject.tag = tag;
            initialized = true;
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

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            // Debug.Log("tryna write or read");
            if (stream.IsWriting)
            {
                stream.SendNext(transform.position);
            }
            else
            {
                newPos = (Vector3)stream.ReceiveNext();
            }
        }

        public void setNewPos(Vector3 newPosition)
        {
            newPos = newPosition;
        }

    }
}
