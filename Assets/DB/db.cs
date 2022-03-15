using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;


public class db : MonoBehaviour {
    public InputField email;
    public InputField password;
    public InputField username;

    public void req() {
        StartCoroutine(postRequest("https://gateway.arsa.me/application/leksus/register.php", (JSONNode res) => {
            Debug.Log(res);
        }));
    }

    IEnumerator postRequest(string url, System.Action<JSONNode> callback) {
        var uwr = new UnityWebRequest(url, "POST");

        yield return uwr.SendWebRequest();

        if (!uwr.isNetworkError) {
            JSONNode data = JSON.Parse(uwr.downloadHandler.text);
            callback(data);
        }
    }
}
