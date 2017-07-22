using System.Diagnostics;

namespace utility.log {
    public static class DebugLog {

        [Conditional("UNITY_EDITOR")]
        public static void Log (object log) {
            UnityEngine.Debug.Log(log);
        }

        [Conditional("UNITY_EDITOR")]
        public static void TextLog (string text) {
            UnityEngine.Debug.Log(text);
        }

        [Conditional("UNITY_EDITOR")]
        public static void
    }
}
