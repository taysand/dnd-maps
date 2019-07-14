using UnityEngine;
using UnityEngine.EventSystems;

public class Character : Draggable {
    public override void OnDragDelegate(PointerEventData data) {
        Debug.Log("OnDragDelegate in character");
        base.OnDragDelegate(data);
    }
}
