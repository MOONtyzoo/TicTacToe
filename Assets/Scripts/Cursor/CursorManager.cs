using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// See https://www.youtube.com/watch?v=8Fm37H1Mwxw for animated cursor tutorial this system is based on
public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance {get; private set;} // singleton, there can only be one

    [SerializeField] private Canvas canvas;

    [SerializeField] private Image cursorImage;
    [SerializeField] private Sprite defaultCursorSprite;
    [SerializeField] private Sprite interactCursorSprite;

    [SerializeField] private Vector3 hotspotOffset;

    private CursorType activeCursorType = CursorType.Default;
    
    void Start() {
        Cursor.visible = false;
    }

    void Awake() {
        Instance = this;
    }

    void Update() {
        UpdateCursorPosition();
    }

    public void setActiveCursorType(CursorType cursorType) {
        activeCursorType = cursorType;
        updateCursorImage();
    }

    private void updateCursorImage() {
        switch(activeCursorType) {
            case CursorType.Default: cursorImage.sprite = defaultCursorSprite; return;
            case CursorType.Interact: cursorImage.sprite = interactCursorSprite; return;
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
        
        transform.position = mousePos + hotspotOffset;
    }
}
