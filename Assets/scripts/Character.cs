using UnityEngine;

public class Character : Draggable
{
    private float clicked = 0;
    private float clickTime = 0;
    private float clickDelay = .5f;
 
    public override void OnMouseDown() {
        base.OnMouseDown();
        if (gameObject.tag.Equals(GameManager.enemyTag)) {
            DestroyEnemyOnDoubleClick();
        }
    }

    private void DestroyEnemyOnDoubleClick() {
        // https://forum.unity.com/threads/detect-double-click-on-something-what-is-the-best-way.476759/
        clicked++;
        if (clicked == 1) {
            clickTime = Time.time;
        }
 
        if (clicked > 1 && Time.time - clickTime < clickDelay) {
            clicked = 0;
            clickTime = 0;
            Destroy(gameObject);
        } else if (clicked > 2 || Time.time - clickTime > 1) {
            clicked = 0;
        }
    }
}
