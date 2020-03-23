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

        private string userName;

        // ie Player-Male-Dwarf
        // also encodes the corresponding hero type
        // and Sphere-Male-Dwarf. sphere object is attached to this script.
        private string myTag;
        private string heroType;
        public string position;
        public string hour;
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


        void Start()
        {
            if (photonView.IsMine)
            {
                Debug.Log("in player, view is mine");
                // sphere = PhotonNetwork.Instantiate("sphere", transform.position, transform.rotation, 0);
                // sphere = (GameObject) Resources.Load("sphere");
                // gameObject.AddComponent<Sphere>();
                // sphere = GetComponent<Sphere>();
                // sphere.SetActive(true);
                transform.localScale = new Vector3(2.2f, 2.2f, 0.12f);
                //if (PhotonNetwork.IsMasterClient) { setTag("Player-Male-Wizard"); }
                //else { setTag("Player-Male-Dwarf"); }
            }

            playerTag = PlayerPrefs.GetString("MyCharacter");
            myHero = new Hero();
            playerGold = new Dictionary<string, int>();
            position = PlayerPrefs.GetString("CharacterRank");
            time = 0;

            myHero.setGold(UnityEngine.Random.Range(0, 10));
            updateCoin(myTag, myHero.getGold());
            Debug.Log("MY PLAYER HAS " + myHero.getGold() + " COINS!");
            // if (!photonView.IsMine && GetComponent<PlayerController>() != null)
            // Destroy(GetComponent<PlayerController>());
        }


        public string getHour()
        {
            return this.hour;
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

        void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                int g = myHero.getGold();
                Debug.Log("Player has: " + g);
            }
        }


        [PunRPC]
        public void serverUpdateCoin(string playerTag, int gold)
        {
            if (!playerGold.ContainsKey(playerTag))
            {
                playerGold.Add(playerTag, gold);
            }
            else
            {
                playerGold[playerTag] = gold;
            }
        }

        public void updateCoin(string playerTag, int gold)
        {
            Debug.Log("HIHIHIHIHI");

            if (photonView != null && photonView.IsMine)
            {
                Debug.Log("Im in!");

                photonView.RPC("serverUpdateCoin", RpcTarget.All, playerTag, gold);
            }
        }




        public string getHeroType()
        {
            return heroType;
        }

        void Update()
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name != "AndorBoard")
                return;
            if (photonView.IsMine)
                checkClick();
            else
            {
                float x1 = transform.position[0];
                float x2 = transform.position[1];
                float x3 = transform.position[2];
                float newX = Mathf.MoveTowards(x1, newPos[0], 1);
                float newY = Mathf.MoveTowards(x2, newPos[1], 1);
                float newZ = Mathf.MoveTowards(x3, newPos[2], 1);
                transform.position = new Vector3(newX, newY, newZ);
            }
        }

        private void checkClick()
        {

            if (Input.GetMouseButtonDown(0))
            {
                string clickedTag = getClickedGameObjectTag();
                if (clickedTag == "") return;

                Vector3 newPos = getClickedPos(clickedTag);

                if (newPos != new Vector3(-10000, 1, 1))
                    moveTo(clickedTag, newPos);
            }
        }

        private Vector3 getClickedPos(string clickedTag)
        {
            // right now we just assume clicked a boardPosition
            int cTag;
            try
            {
                cTag = int.Parse(clickedTag);
                GameObject go = GameObject.FindWithTag(clickedTag);
                BoardPosition bp = go.GetComponent<BoardPosition>();

                Vector3 newPos = bp.getMiddle();
                return newPos;

                // player.gameObject.transform.position = bp.getMiddle();
                // newPos = player.sphere.transform.position;
                // transform.position = new Vector3(-6.81f, 7.57f, 0.0f);
            }
            catch (InvalidCastException e)
            {
                return new Vector3(-10000, 1, 1);
            }
        }

        private string getClickedGameObjectTag()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // RaycastHit hitInfo;
            RaycastHit2D hitInfo = Physics2D.GetRayIntersection(ray);
            Debug.Log("clicked");
            if (hitInfo == null)
                return "";

            string colliderTag = hitInfo.collider.gameObject.tag;
            Debug.Log("want to move to: " + colliderTag);

            return (colliderTag != null) ? colliderTag : "";

        }

        public void moveTo(string newLoc, Vector3 newPos)
        {
            transform.position = newPos;
            BoardContents.setNewPlayerPosition(playerTag, newLoc);
            string oldpos = BoardContents.getPlayerPosition(playerTag);
            // int distance = Graph.getDistance(oldpos, newLoc);
            // Monster.moveAllMonstersAtSunrise();
            Monster.moveAllMonstersAtSunrise();
            //foreach (KeyValuePair<string, string> entry in Monster.monsterPositions)
            //{
            //    Debug.Log(entry.Key + " " + entry.Value);
            //}
            GameConsole.instance.UpdateFeedback("Player " + playerTag + " has moved to " + newLoc);


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

    }
}

