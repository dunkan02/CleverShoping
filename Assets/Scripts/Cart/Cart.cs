using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Cart : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed =false;
    [SerializeField] private float _speed;

    public float Speed => _speed;
    public Sprite Icon => _icon;
    public string Label => _label;
    public int Price => _price;
    public bool IsBuyed => _isBuyed;

    abstract public void Move(Player player, Slider slider, Transform leftPoint, Transform rightPoint);

    public void Buy()
    {
        _isBuyed = true;
    }
}