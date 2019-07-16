using UnityEngine;

public class Character : Draggable
{
    private float clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.7f;
 
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
            clicktime = Time.time;
        }
 
        if (clicked > 1 && Time.time - clicktime < clickdelay) {
            clicked = 0;
            clicktime = 0;
            Destroy(gameObject);
        } else if (clicked > 2 || Time.time - clicktime > 1) {
            clicked = 0;
        }
    }
}
