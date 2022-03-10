using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Realtime;

namespace Photon.Pun.Demo.PunBasics
{
#pragma warning disable 649

	/// <summary>
	/// Game manager.
	/// Connects and watch Photon Status, Instantiate Player
	/// Deals with quiting the room and the 
	/// </summary>
	public class NetworkManager : MonoBehaviourPunCallbacks
	{

		static public NetworkManager Instance;

		private GameObject instance;

		[Tooltip("The prefab to use for representing the player")]
		[SerializeField]
		private GameObject playerPrefab;

		void Start()
		{
			Instance = this;

			if (!PhotonNetwork.IsConnected)
			{
				SceneManager.LoadScene("SSLauncher");

				return;
			}

			if (playerPrefab == null)
			{ 
				Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
			}
			else
			{
				if (PlayerManager.LocalPlayerInstance == null)
				{
					Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
					PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
				}
				else
				{
					Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
				}
			}

		}

		
	}

}