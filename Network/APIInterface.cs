using System.Collections;
using System.Collections.Generic;

namespace network {
    public abstract class APIInterface {

        public abstract void RequestAPI(RequestBase request);

        public virtual byte[] PackRequest(RequestBase request) {
            return PackRequest<RequestBase>(request);
        }

        public virtual ResponseBase UnPackResponse(byte[] data) {
            return UnPackResponse<ResponseBase>(data);
        }

        public byte[] PackRequest<T>(T req) {
            return CoreSerializer.Serialize<T>(req);
        }

        public T UnPackResponse<T>(byte[] bytes) {
            return CoreSerializer.Deserialize<T>(bytes);
        }
    }
}
