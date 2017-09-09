using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;

namespace network {
    public static class CoreSerializer {

        public static byte[] Serialize<T>(T obj) {
            var bytes = MessagePackSerializer.Serialize<T>(obj);
            return bytes;
        }

        public static T Deserialize<T>(byte[] bytes) {
            T data = MessagePackSerializer.Deserialize<T>(bytes);
            return data;
        }
    }
}
