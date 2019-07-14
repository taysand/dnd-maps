using UnityEngine;
using UnityEngine.EventSystems;

public class Room : Draggable {
    public bool firstRoom = false;
    private bool visible;
    private Renderer roomRenderer;

    void Start() {
        roomRenderer = GetComponent<Renderer>();
        visible = firstRoom;
        roomRenderer.enabled = visible;
        setEnemyVisibility(false);
    }

    public void makeVisible() {
        if (visible) {
            setEnemyVisibility(true);
        } else {
            visible = true;
            roomRenderer.enabled = visible;
        }
    }

    private void setEnemyVisibility(bool visibility) {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag.Equals(GameManager.enemyTag)) {
                child.GetComponent<Renderer>().enabled = visibility;
            }
        }
    }

    public override void OnDragDelegate(PointerEventData data)
    {
        Debug.Log("OnDragDelegate in room");
        return;
    }
}
