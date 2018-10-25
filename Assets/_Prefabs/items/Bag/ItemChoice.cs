using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items.Bag;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemChoice : MonoBehaviour, IPointerDownHandler
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public Text NameText;
    public Text CountText;
    public Image ItemImage;
    private BagController _BagController;

    // Use this for initialization
    void Start()
    {
        _BagController = GetComponentInParent<BagController>();
        UpdateValues();
    }
    public void UpdateValues()
    {
        NameText.text = Name;
        CountText.text = "x" + Count;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _BagController.UseItem(Id);
    }
}
