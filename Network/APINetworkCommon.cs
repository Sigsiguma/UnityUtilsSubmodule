using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace network {
    public class APINetworkCommon {

    }

    public abstract class RequestBase {
        [MessagePack.Key(0)]
        public CommonRequest common;
    }

    public abstract class ResponseBase {
        [MessagePack.Key(0)]
        public CommonResponse common;
    }

    [MessagePack.MessagePackObject]
    public class CommonRequest {
        [MessagePack.Key(0)]
        public int userID = 0;
    }

    [MessagePack.MessagePackObject]
    public class CommonResponse {
        [MessagePack.Key(0)]
        public int status = 0;
    }
}
