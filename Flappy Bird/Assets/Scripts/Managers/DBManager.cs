using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Managers
{
    public class DBManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;

        private string _requestDownloadedText;
        private Text _score;
        private string _uri = "https://jsonplaceholder.typicode.com/users?id=1";

        private void Start()
        {
            GetData();
        }

        private void GetData() => StartCoroutine(GetDataCoroutine());
    
        private IEnumerator GetDataCoroutine()
        {
            using (UnityWebRequest request = UnityWebRequest.Get(_uri))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    _requestDownloadedText = request.downloadHandler.text;
                    //Debug.Log(requestDownloadedText);
                }
            }
        }

        public void PostData() => StartCoroutine(PostDataCoroutine());
    
        private IEnumerator PostDataCoroutine()
        {
            WWWForm form = new WWWForm();
            form.AddField("body", $"Your score {_gameManager.Score}");
            using (UnityWebRequest request = UnityWebRequest.Post(_uri, form))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError)
                    Debug.Log(request.error);
                else
                {
                    _requestDownloadedText = request.downloadHandler.text;
                    //Debug.Log(request.downloadHandler.text);
                }
            }
        }
    }
}
