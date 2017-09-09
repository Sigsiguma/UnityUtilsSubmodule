using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace network {
    public class APINetworkManager : SingletonMonoBehaviour<APINetworkManager> {

        private new void Awake() {
            base.Awake();
        }

        public void RequestAPI(APIInterface apiInterface, HttpParam httpParam) {
            var httpClient = new HttpClient(this);
            httpClient.Request(apiInterface, httpParam);
        }
    }
}
