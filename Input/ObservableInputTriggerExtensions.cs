using UnityEngine;
using UniRx;

namespace utility.input {
    public static partial class ObservableInputTriggerExtensions {

        public static IObservable<Unit> OnLongPointerDownAsObservable (this GameObject gameObject) {
            if (gameObject == null) return Observable.Empty<Unit>();
            return GetOrAddComponent<ObservableLongPointerDownTrigger>(gameObject).OnLongPointerDownAsObservable();
        }

        public static IObservable<Vector2> OnDragAsObservable (this GameObject gameObject) {
            if (gameObject == null) return Observable.Empty<Vector2>();
            return GetOrAddComponent<ObservableDragTrigger>(gameObject).OnDragAsObservable();
        }

        private static T GetOrAddComponent<T> (GameObject gameObject)
            where T : Component {
            var component = gameObject.GetComponent<T>();
            if (component == null) {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }
    }
}
