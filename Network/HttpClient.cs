using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace network {
    public class HttpClient {

        private MonoBehaviour monoBehaviour_ = null;

        public HttpClient(MonoBehaviour monoBehaviour) {
            monoBehaviour_ = monoBehaviour;
        }

        public void Request(APIInterface apiInterface, HttpParam httpParam) {
            utility.log.DebugLog.TextAsset(monoBehaviour_ != null, "MonoBehaviour is nul!!!");
            monoBehaviour_.StartCoroutine(RequestCoroutine(apiInterface, httpParam));
        }

        private IEnumerator RequestCoroutine(APIInterface apiInterface, HttpParam httpParam) {
            utility.log.DebugLog.TextAsset(apiInterface != null, "APIInterface is nul!!!");
            utility.log.DebugLog.TextAsset(httpParam != null, "HttpParam is null!!!");
            utility.log.DebugLog.TextAsset(!string.IsNullOrEmpty(httpParam.url_), "URL is invalid!!");

            UnityWebRequest www = new UnityWebRequest(httpParam.url_);
            www.method = UnityWebRequest.kHttpVerbPOST;
            var bytes = apiInterface.PackRequest(httpParam.request);
            Debug.Log(MessagePack.MessagePackSerializer.ToJson(bytes));
            UploadHandlerRaw handler = new UploadHandlerRaw(bytes);
            www.uploadHandler = handler;

            yield return www.Send();

            if (www.isNetworkError) {
                utility.log.DebugLog.ErrorTextLog(www.error);
                if (httpParam.onError != null) {
                    httpParam.onError(404);
                }
            } else {
                httpParam.response = apiInterface.UnPackResponse(www.downloadHandler.data);

                if (httpParam.onDone != null) {
                    httpParam.onDone();
                }
            }

        }

    }
}