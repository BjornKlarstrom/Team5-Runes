using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Rune : MonoBehaviour
{
    [SerializeField] private RuneSO runeSO;

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        Image image = GetComponent<Image>();
        image.color = runeSO.RarityColor;
        image.sprite = runeSO.Sprite;
        //image.overrideSprite = runeSO.Sprite;
    }
}
