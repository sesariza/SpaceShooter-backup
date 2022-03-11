using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
{

	public class NetworkManager : MonoBehaviourPunCallbacks
	{
		static public NetworkManager Instance;
		public GameObject playerPrefab;
		public GameObject musuhPrefab;

		void Start()
		{
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
				if (PhotonNetwork.IsMasterClient)
				{
					PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.Euler(0f,0f,0f), 0);
                }
                else
                {
					PhotonNetwork.Instantiate(this.musuhPrefab.name, new Vector3(0f, 5f, 5f), Quaternion.Euler(0f,0f,0f), 0);
				}
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
	}
}