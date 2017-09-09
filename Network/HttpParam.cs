using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace network {
    public class HttpParam {
        public string url_ = null;
        public System.Action onDone = null;
        public System.Action<int> onError = null;

        public RequestBase request = null;
        public ResponseBase response = null;
    }
}
