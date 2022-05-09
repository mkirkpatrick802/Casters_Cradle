using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static event Action<InventorySlot> InventorySlotDropped;

    public Item GetItem() => _item;
    private Item _item;

    private Inventory _inventory;

    private Transform _defaultParent;
    private Transform _inventoryParent;
    private Transform _lastParent;

    private Item _tempItem; //When re-adding item to inventory use tempItem

    //Dragging
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;

    //Visuals
    private Image _icon;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _canvas = transform.root.GetComponent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void InventorySpawned(Inventory inventory, Item item, Transform inventoryParent, Transform defaultParent)
    {
        //Set Local Variables
        _inventory = inventory;
        _item = item;
        _defaultParent = defaultParent;
        _inventoryParent = inventoryParent;

        //Set Visuals
        _icon = GetComponentInChildren<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _icon.sprite = item.icon;

        if (item.amount > 1)
        {
            _text.SetText(item.amount.ToString());
        }
        else
        {
            _text.SetText("");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _lastParent = transform.parent;
        transform.SetParent(_defaultParent);
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
        RemoveItem();
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        InventorySlotDropped?.Invoke(this);
        Return();
    }

    private void Return()
    {
        if(transform.parent == _defaultParent)
        {
            transform.SetParent(_lastParent);
        }

        if(transform.parent == _inventoryParent)
        {
            _inventory.AddItem(_tempItem);
        }
    }

    private void RemoveItem()
    {
        Item tempItem = Instantiate(_item);
        _inventory.RemoveItem(_item);
        _tempItem = tempItem;
    }
}
