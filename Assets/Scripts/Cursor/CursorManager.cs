using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// See https://www.youtube.com/watch?v=8Fm37H1Mwxw for animated cursor tutorial this system is based on
public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance {get; private set;} // singleton, there can only be one

    [SerializeField] private Canvas canvas;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 hotspotOffset;

    private CursorType activeCursorType = CursorType.Default;
    
    void Start() {
        Cursor.visible = false;
        setActiveCursorType(default);
    }

    void Awake() {
        Instance = this;
    }

    void Update() {
        UpdateCursorPosition();
        if (Input.GetMouseButtonDown(0)) {
            PlayClickAnimation();
        }
    }

    public void setActiveCursorType(CursorType cursorType) {
        activeCursorType = cursorType;
        setCursorAnimation();
    }

    private void setCursorAnimation() {
        switch(activeCursorType) {
            case CursorType.Default: animator.Play("Cursor-Default", 0, 0.0f); return;
            case CursorType.Interact: animator.Play("Cursor-Interact", 0, 0.0f); return;
        }
    }

    private void PlayClickAnimation() {
        switch(activeCursorType) {
            case CursorType.Default: return;
            case CursorType.Interact: animator.Play("Cursor-Click", 0, 0.0f); return;
        }
    }

    // Code from https://stackoverflow.com/questions/43802207/position-ui-to-mouse-position-make-tooltip-panel-follow-cursor
    private void UpdateCursorPosition() {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera,
            out movePos);

        Vector3 mousePos = canvas.transform.TransformPoint(movePos);
        mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        
        transform.position = mousePos + hotspotOffset;
    }
}
