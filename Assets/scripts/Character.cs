using UnityEngine;
using UnityEngine.EventSystems;

public class Character : Draggable {

    public void OnMouseDown() {
        Debug.Log("click character");
    }

    public override void OnDragDelegate(PointerEventData data) {
        Debug.Log("OnDragDelegate in character");
        base.OnDragDelegate(data);
    }
}
