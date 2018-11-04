using UnityEngine;
using System.Collections;

public class CameraSwipePan : MonoBehaviour
{
    private Vector3 dragOrigin; //Where are we moving?
    private Vector3 clickOrigin = Vector3.zero; //Where are we starting?
    private Vector3 basePos = Vector3.zero; //Where should the camera be initially?

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (clickOrigin == Vector3.zero)
            {
                clickOrigin = Input.mousePosition;
                basePos = transform.position;
            }
            dragOrigin = Input.mousePosition;
        }

        if (!Input.GetMouseButton(0))
        {
            clickOrigin = Vector3.zero;
            return;
        }

        transform.position = new Vector3(Mathf.Clamp(basePos.x + ((clickOrigin.x - dragOrigin.x) * .05f), -100, 100), Mathf.Clamp(basePos.y + ((clickOrigin.y - dragOrigin.y) * .05f), -100, 100), -10);
    }
}