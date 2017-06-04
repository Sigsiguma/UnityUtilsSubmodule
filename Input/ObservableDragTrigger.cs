using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ObservableDragTrigger : ObservableTriggerBase {

    private Subject<Vector2> onDrag_;

    private void Start () {
        var tapPositionAsObservable = this.UpdateAsObservable().Select(_ => Camera.main.ScreenToWorldPoint(Input.mousePosition));

        tapPositionAsObservable.Pairwise()
                               .Where(_ => onDrag_ != null)
                               .Where(_ => Input.GetMouseButton(0))
                               .DistinctUntilChanged()
                               .Select(x => x.Current - x.Previous)
                               .Subscribe(vec => onDrag_.OnNext(vec));
    }

    public IObservable<Vector2> OnDragAsObservable () {
        return onDrag_ ?? (onDrag_ = new Subject<Vector2>());
    }

    protected override void RaiseOnCompletedOnDestroy () {
        if (onDrag_ != null) {
            onDrag_.OnCompleted();
        }
    }
}
