using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private Transform _rightPoint;

    private Slider _slider;
    private Cart _currentCart;
    private float speed = 5f;
    private Vector3 direction;

    public Slider Slider => _slider;
    public Transform LeftPosition => _leftPoint;
    public Transform RightPosition => _rightPoint;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        direction = _rightPoint.position - _leftPoint.position;
        _player.transform.position = _leftPoint.position;
    }

    private void Update()
    {
        if (_player != null)
        {
            _currentCart.Move(_player, _slider, _leftPoint, _rightPoint);
        }
    }

    private void OnEnable()
    {
        _player.CartChanged += OnCnangeCart;
    }

    private void OnDisable()
    {
        _player.CartChanged -= OnCnangeCart;
    }

    private void OnCnangeCart(Cart cart)
    {
        _currentCart = cart;
    }
}