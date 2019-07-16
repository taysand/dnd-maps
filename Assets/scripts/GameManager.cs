using UnityEngine;
using UnityEngine.SceneManagement;

// this class is also the camera because this is a protype and I'll do what I want
public class GameManager : MonoBehaviour {
    public const string roomTag = "room";
    public const string enemyTag = "enemy";
    public const string loadMapScene = "MapSelect";

    public Camera mainCamera;

    private float cameraMovementSpeed = .1f;

    void Update() {
       controlCameraMovement();
       checkForMapSelect();
    }

    public void LoadLevel(string level) {
        SceneManager.LoadScene(level);
    }

    private void checkForMapSelect() {
        if (Input.GetKey("m")) {
            LoadLevel(loadMapScene);
        }
    }

    private void controlCameraMovement() {
        Vector3 oldPosition = transform.position;
        float xPosition = oldPosition.x;
        float yPosition = oldPosition.y;
        float zPosition = oldPosition.z;
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
