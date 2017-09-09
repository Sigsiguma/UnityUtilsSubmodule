using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace network {
    public class APITest : APIInterface {

        private const string kTestURL = "hoge";

        public override void RequestAPI(RequestBase request) {
            var httpParam = new HttpParam();
            httpParam.url_ = kTestURL;
            httpParam.request = request;
            APINetworkManager.Instance.RequestAPI(this, httpParam);
        }

        public override byte[] PackRequest(RequestBase request) {
            var req = request as APITestRequest;
            return PackRequest<APITestRequest>(req);
        }

        public override ResponseBase UnPackResponse(byte[] data) {
            return UnPackResponse<APITestResponse>(data);
        }

    }

    [MessagePack.MessagePackObject]
    public class APITestRequest : RequestBase {
        [MessagePack.Key(1)]
        public int request = 0;
    }

    [MessagePack.MessagePackObject]
    public class APITestResponse : ResponseBase {
        [MessagePack.Key(1)]
        public int response = 0;
    }
}
