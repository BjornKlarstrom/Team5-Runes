using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas _canvas;
    public RuneSO runeBeingDragged;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private float _speed = 1500f;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        
        if (!eventData.hovered.Find(
            gameObject => gameObject != null && gameObject.GetComponent<RuneSlot>() != null))
        {
            Debug.Log("Moving to previous slot");
            StartCoroutine(MoveToPreviousSlot());            
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    private IEnumerator MoveToPreviousSlot()
    {
        while ((transform.parent.position - transform.position).magnitude > 2f)
        {
            Vector3 dir = (transform.parent.position - transform.position).normalized;
            transform.position += Time.deltaTime * _speed * dir;
            yield return null;
        }

        transform.position = transform.parent.position;
        transform.parent.GetComponent<RuneSlot>().AddRune(runeBeingDragged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
