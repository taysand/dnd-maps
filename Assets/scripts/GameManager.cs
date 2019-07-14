using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is also the camera because this is a protype and I'll do what I want
public class GameManager : MonoBehaviour
{
    public const string roomTag = "room";
    public const string enemyTag = "enemy";

    public Camera mainCamera;

    private float cameraMovementSpeed = .1f;

    void Update()
    {
       controlCameraMovement();
       checkForRoomClicks();
    }

// it would be great if this could happen in Room.onMouseDown()
    private void checkForRoomClicks() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.rigidbody.tag.Equals(roomTag))
            {
                Debug.Log("hit a thing " + hit.rigidbody.gameObject);
                hit.rigidbody.gameObject.GetComponent<Room>().makeVisible();
            }
        }
    }

    private void controlCameraMovement() {
        float xPosition = transform.position.x;
        float yPosition = transform.position.y;
        float zPosition = transform.position.z;
        float zoom = mainCamera.orthographicSize;

        if (Input.GetKey("up") || Input.GetKey("w")) {
            yPosition = yPosition + cameraMovementSpeed;
        }
        if (Input.GetKey("down") || Input.GetKey("s")) {
            yPosition = yPosition - cameraMovementSpeed;
        }
        if (Input.GetKey("right") || Input.GetKey("d")) {
            xPosition = xPosition + cameraMovementSpeed;
        }
        if (Input.GetKey("left") || Input.GetKey("a")) {
            xPosition = xPosition - cameraMovementSpeed;
        }
        if (Input.GetKey("-")) {
            zoom = zoom + cameraMovementSpeed;
        }
        if (Input.GetKey("=")) {
            zoom = zoom - cameraMovementSpeed;
        }

        transform.position = new Vector3(xPosition, yPosition, zPosition);
        mainCamera.orthographicSize = zoom;
    }
}
