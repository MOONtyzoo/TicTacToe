using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This class should be attached to objects that change the cursor type when hovered over
public class CursorObject : MonoBehaviour
{
    [SerializeField] private CursorType hoverCursorType = CursorType.Default;
    public void OnMouseEnter() {
        CursorManager.Instance.setActiveCursorType(hoverCursorType);
        print("HELLO");
    }

    public void OnMouseExit() {
        CursorManager.Instance.setActiveCursorType(CursorType.Default);
    }
}
