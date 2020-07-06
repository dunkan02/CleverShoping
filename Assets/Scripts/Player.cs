using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _health;
    [SerializeField] private List<Cart> _carts;

    private Cart _currentCart;
    private int _currentCartIndex = 0;
    private int _currentHealth;

    public int Money { get; private set; }
    public int Health => _health;
    public Cart CurrentCart => _currentCart;


    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<Cart> CartChanged;
    public event UnityAction<int, int> Dead;

    private void Awake()
    {
        _currentHealth = _health;

        List<Cart> cartsTemp = new List<Cart>();
        for (int i = 0; i < _carts.Count; i++)
        {
            cartsTemp.Add(Instantiate(_carts[i], transform.position, Quaternion.identity, transform));
        }
        _carts = cartsTemp;

        ChangeCart(_currentCartIndex);
    }


    private void ChangeCart(int index)
    {
        _currentCart = _carts[index];

        GetComponent<SpriteRenderer>().sprite = _currentCart.Icon;

        Vector2 colliderBoundsVector = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = colliderBoundsVector;

        CartChanged?.Invoke(_currentCart);
    }

    public void NextCart()
    {
        _currentCartIndex++;
        if (_currentCartIndex >= _carts.Count)
            _currentCartIndex = 0;

        ChangeCart(_currentCartIndex);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyCart(Cart cart)
    {
        _carts.Add(cart);
        Money -= cart.Price;
        MoneyChanged?.Invoke(Money);
    }

    public void ApplayDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Dead?.Invoke(0, Money);
            Destroy(gameObject);
        }
    }
}