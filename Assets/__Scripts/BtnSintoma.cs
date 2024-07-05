using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSintoma : MonoBehaviour {
    
    public string SintomaID;
    public bool selected = false;
    [SerializeField] private Sprite normal, highlight;
    [SerializeField] private Image _image;

    public void click() {
        if (selected) {
            _image.sprite = normal;
        }
        else
            _image.sprite = highlight;

        selected = !selected;
    }

    public void clear() {
        selected = false;
        _image.sprite = normal;
    }
}
