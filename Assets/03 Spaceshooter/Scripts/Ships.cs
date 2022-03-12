using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

namespace Photon.Pun.Demo.PunBasics
{
    public class Ships : MonoBehaviourPunCallbacks, IPunObservable
    {
        public float speed;
        public float tilt;
        public Boundary boundary;
        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;

        private float nextFire;
        int Firing;
        int GetFiring;
        private NetworkManager gameController;

        void Start()
        {
            gameController = GameObject.Find("GameController").GetComponent<NetworkManager>();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                // We own this player: send the others our data
                stream.SendNext(Firing);
                Firing = 0;
            }
            else
            {
                // Network player, receive data
                GetFiring = (int)stream.ReceiveNext();

                Debug.Log(GetFiring);

                if (GetFiring == 1)
                {
                    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                }

                if (GetFiring == 2)
                {
                    Destroy(gameObject);
                    gameController.GameOver();
                }

                GetFiring = 0;
            }
        }

        void Update()
        {
             if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
             {
                 return;
             }

            if (photonView.IsMine && Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Firing = 1;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            if (other.gameObject.name == "Shoot(Clone)")
            {
                Firing = 2;
                gameController.GameOver();
                Destroy(gameObject,0.5f);
            }
        }

        void FixedUpdate()
        {
            if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;

            GetComponent<Rigidbody>().position = new Vector3
            (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
            );

            GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        }
    }
}


