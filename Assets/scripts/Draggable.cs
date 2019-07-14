using UnityEngine;

// https://stackoverflow.com/questions/23152525/drag-object-in-unity-2d
[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;

    public virtual void OnMouseDown() {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    public virtual void OnMouseDrag() {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
}