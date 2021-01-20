using System;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRune {
    public class CreateDragable : MonoBehaviour {
        [SerializeField]private GameObject dragableGameObjectPrefab;
        [SerializeField]private Sprite dragableSprite;
        [SerializeField]private RuneClass.Rune dragableRuneData;
        [SerializeField]private Canvas _mainCanvas;
        

        private void Update()
        {
            if (transform.childCount < 2) {
                //var test = GetComponentInChildren<DragDrop>().transform;
                if (GetComponentInChildren<DragDrop>() == null) {
                    Debug.Log("boom");
                    var go = Instantiate(dragableGameObjectPrefab, transform);
                    var goData = go.GetComponent<DragDrop>();
                    goData._canvas = _mainCanvas;
                    goData.dragableRuneData = dragableRuneData;
                    goData.GetComponent<Image>().sprite = dragableSprite;
                }
            }
        }
    }
}
