using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RarityColor : MonoBehaviour
{
    Image image;
    [SerializeField] RuneSO runeSO;

    void Start()
    {
        image = GetComponent<Image>();
        image.color = runeSO.RarityColor;
    }
}
