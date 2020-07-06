using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Menu))]
public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CheckerLastProduct _checkerLastProduct;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private int _heartToScore;
    [SerializeField] private int _moneyToScore;

    private Menu _menu;

    private void Start()
    {
        _menu = GetComponent<Menu>();
    }

    private void OnEnable()
    {
        _player.Dead += ShowScore;
        _checkerLastProduct.AllProductFinished += ShowScore;
    }

    private void OnDisable()
    {
        _player.Dead -= ShowScore;
        _checkerLastProduct.AllProductFinished -= ShowScore;
    }

    private void ShowScore(int heartValue, int moneyValue)
    {
        _scoreText.text = (_heartToScore * heartValue + _moneyToScore * moneyValue).ToString();
        _menu.OpenPanel(_scorePanel);
    }
}