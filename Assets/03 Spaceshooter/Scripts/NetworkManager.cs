using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections;

namespace Photon.Pun.Demo.PunBasics
{
	public class NetworkManager : MonoBehaviourPunCallbacks
	{
		static public NetworkManager Instance;
		public GameObject playerPrefab;
		public GameObject musuhPrefab;

		public Text scoreText;
		public Text gameoverText;
		private int Score;
		public bool death;
		public bool Minedeath;

		void Start()
		{
			Score = 0;
			Instance = this;

			if (!PhotonNetwork.IsConnected)
			{
				SceneManager.LoadScene("SSLauncher");
				return;
			}

			Debug.Log("MASTER = " + PhotonNetwork.IsMasterClient);

			if (playerPrefab == null)
			{ 
				Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
			}
			else
			{
				Respawn();
			}
		}

		public override void OnPlayerEnteredRoom(Player other)
		{
			Debug.Log("OnPlayerEnteredRoom() " + other.NickName); // not seen if you're the player connecting

			if (PhotonNetwork.IsMasterClient)
			{
				Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
			}
		}

		public void addScore()
		{
			Score++;
			UpdateScore(Score);
		}

		private void UpdateScore(int newScore)
		{
			scoreText.text = "SCORE: " + newScore;
		}

		public void GameOver()
		{
			if (death)
			{
				Debug.Log("Game Over");
				gameoverText.text = "GAMEOVER\n";
				StartCoroutine(StartOver());
			}
		}

		public void Respawn()
        {
			if (PhotonNetwork.IsMasterClient)
			{
				Debug.Log("Spawn Master");
				PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.Euler(0f, 0f, 0f), 0);
			}
			else
			{
				Debug.Log("Spawn Enemy");
				PhotonNetwork.Instantiate(this.musuhPrefab.name, new Vector3(0f, 5f, 5f), Quaternion.Euler(0f, 0f, 0f), 0);
			}

		}

		private IEnumerator StartOver()
		{	
			yield return new WaitForSeconds(5);

			if (Minedeath) Respawn();
			gameoverText.text = "";
			death = false;
			Minedeath = false;
		}
	}
}