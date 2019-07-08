using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** The game manager */
public class GameManager : Singleton<GameManager>
{
    /** Reference to {@link ClickAction} */
    public ClickAction clickAction;

    /** The game points */
    public int points;

    /** The cooldown period in seconds regain limit */
    public int cooldown = 2;

    /** The limit of clicks allowed in total */
    public int limit = 50;

    // Start is called before the first frame update
    private void Start()
    {
        this.clickAction = new ClickAction(cooldown, limit);
        Cursor.visible = true;
        this.points = 0;
    }

}
