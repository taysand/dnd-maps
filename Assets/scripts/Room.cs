using UnityEngine;

public class Room : Draggable {
    public bool firstRoom = false;
    private bool visible;
    private Renderer roomRenderer;
    private bool fullyActivated = false;

    void Start() {
        roomRenderer = GetComponent<Renderer>();
        visible = firstRoom;
        roomRenderer.enabled = visible;
        setEnemyVisibility(false);
    }

    public void makeVisible() {
        if (visible) {
            setEnemyVisibility(true);
            fullyActivated = true;
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

    public override void OnMouseDown() {
        if (!fullyActivated) {
            makeVisible();
        }
    }

    public override void OnMouseDrag() {
        // TODO: add rooms and position them
        return;
    }
}
