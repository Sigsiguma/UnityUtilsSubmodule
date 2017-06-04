using UnityEngine;
using UniRx;

namespace utility.input {
    public static partial class ObservableInputTriggerExtensions {

        public static IObservable<Unit> OnLongPointerDownAsObservable (this Component component) {
            if (component == null || component.gameObject == null) return Observable.Empty<Unit>();
            return GetOrAddComponent<ObservableLongPointerDownTrigger>(component.gameObject).OnLongPointerDownAsObservable();
        }

        public static IObservable<Vector2> OnDragAsObservable (this Component component) {
            if (component == null || component.gameObject == null) return Observable.Empty<Vector2>();
            return GetOrAddComponent<ObservableDragTrigger>(component.gameObject).OnDragAsObservable();
        }
    }
}
