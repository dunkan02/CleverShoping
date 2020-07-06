using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CartView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _button;
    [SerializeField] private Sprite _imageBackgroundBuyedItem;
    private Cart _cart;

    public event UnityAction<Cart, CartView> ButtonSellClick;

    public void Render(Cart cart)
    {
        _cart = cart;
        _image.sprite = cart.Icon;
        _price.text = cart.Price.ToString();
        _label.text = cart.Label;

        if (_cart.IsBuyed)
        {
            MarkAsBuyed();
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonSellClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonSellClick);
    }

    private void OnButtonSellClick()
    {
        ButtonSellClick?.Invoke(_cart, this);
    }

    public void MarkAsBuyed()
    {
        _button.interactable = false;
        GetComponent<Image>().sprite = _imageBackgroundBuyedItem;
    }
}