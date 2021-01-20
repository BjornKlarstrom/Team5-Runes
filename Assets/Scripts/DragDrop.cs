using System;
using System.Collections;
using System.Collections.Generic;
using BaseRune;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    [SerializeField] public Canvas _canvas;
    [SerializeField] public RuneClass.Rune dragAbleRuneData;
    
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private float _speed = 1500f;
    private bool _mergeSlot = true;
    public GameObject currentRuneSlot;
    public GameObject CurrentRuneSlot {
        get => currentRuneSlot;
        set {
            if (currentRuneSlot != null && _mergeSlot == false) 
                currentRuneSlot.GetComponent<RuneSlot>().Start();
            currentRuneSlot = value;
        } 
    }

    private void Awake() {
        _mergeSlot = gameObject.GetComponentInParent<RuneSlot>().mergeSlot;
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        _canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData eventData) {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        
        _canvasGroup.blocksRaycasts = true;
        
        if (!eventData.hovered.Find(gameObject => gameObject != null && gameObject.GetComponent<RuneSlot>() != null)) 
            StartCoroutine(MoveToPreviousSlot());
    }

    public void OnPointerDown(PointerEventData eventData) {

    }


    public void RemoveDragAbleFromSlot() {
        
    }
    public IEnumerator MoveToPreviousSlot() {
        while ((transform.parent.position - transform.position).magnitude > 2f) {
            Vector3 dir = (transform.parent.position - transform.position).normalized;
            transform.position += Time.deltaTime * _speed * dir;
            yield return null;
        }
        transform.position = transform.parent.position;
    }
}
