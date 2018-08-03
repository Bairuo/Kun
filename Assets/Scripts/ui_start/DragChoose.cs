using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragChoose : MonoBehaviour {
    public RollingSelection rollingSelection;
    Vector2 touchfirst = Vector2.zero;
    Vector2 touchsecond = Vector2.zero;


    // Update is called once per frame
    void OnGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            touchfirst = Event.current.mousePosition;
        }

        if (Event.current.type == EventType.MouseDrag)
        {
            touchsecond = Event.current.mousePosition;

            if (touchsecond.x - touchfirst.x < -300)    // left
            {
                rollingSelection.Left();
            }
            else if (touchsecond.x - touchfirst.x > 300)    // right
            {
                rollingSelection.Right();
            }

        }
    }
}
