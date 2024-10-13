using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardObscurer : MonoBehaviour
{
    [SerializeField] private Image image;
    public void Activate() {
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
    }

    public void Deactivate() {
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }
}
