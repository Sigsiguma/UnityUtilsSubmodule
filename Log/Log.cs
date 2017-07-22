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
        public static void WarningLog (object log) {
            UnityEngine.Debug.LogWarning(log);
        }

        [Conditional("UNITY_EDITOR")]
        public static void WarningTextLog (string text) {
            UnityEngine.Debug.LogWarning(text);
        }

        [Conditional("UNITY_EDITOR")]
        public static void ErrorLog (object log) {
            UnityEngine.Debug.LogError(log);
        }

        [Conditional("UNITY_EDITOR")]
        public static void ErrorTextLog (string text) {
            UnityEngine.Debug.LogError(text);
        }

        [Conditional("UNITY_EDITOR")]
        public static void Asset (bool condition, object log) {
            UnityEngine.Debug.Assert(condition, log);
        }

        [Conditional("UNITY_EDITOR")]
        public static void TextAsset (bool condition, string text) {
            UnityEngine.Debug.Assert(condition, text);
        }
    }
}
