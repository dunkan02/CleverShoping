using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Cart> _carts;
    [SerializeField] private Player _player;
    [SerializeField] private CartView _cartTemplate;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _carts.Count; i++)
        {
            AddItem(Instantiate(_carts[i]));
        }
    }

    private void AddItem(Cart cart)
    {
        CartView cartView = Instantiate(_cartTemplate, _itemContainer.transform);
        cartView.Render(cart);
        cartView.ButtonSellClick += OnButtonSellClick;
    }

    private void OnButtonSellClick(Cart cart, CartView cartView)
    {
        TrySellCart(cart, cartView);
    }

    private void TrySellCart(Cart cart, CartView cartView)
    {
        if (!cart.IsBuyed && cart.Price <= _player.Money)
        {
            cart.Buy();
            _player.BuyCart(cart);

            cartView.ButtonSellClick -= OnButtonSellClick;
            cartView.MarkAsBuyed();
        }
    }
}