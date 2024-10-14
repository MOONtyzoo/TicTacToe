using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardObscurer : MonoBehaviour
{
    [SerializeField] private GameObject obscurer;
    public void Activate() {
        obscurer.SetActive(true);
    }

    public void Deactivate() {
        obscurer.SetActive(false);
    }
}
