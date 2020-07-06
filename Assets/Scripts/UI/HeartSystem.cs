using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts;

    private void Start()
    {
        _hearts = new List<Heart>();
        Init(_player.Health);
    }

    private void OnChangeHeart(int current, int max)
    {
        current = Mathf.Clamp(current, 0, max);
        for (int i = 0; i < max; i++)
        {
            if (i < current)
            {
                _hearts[i].gameObject.SetActive(true);
            }

            else
            {
                Color currentColor = _hearts[i].GetComponent<Image>().color;
                _hearts[i].GetComponent<Image>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
            }
        }
    }

    private void Init(int countHeart)
    {
        for(int i=0; i< countHeart; i++)
        {
            _hearts.Add(Instantiate(_heartTemplate, transform.position, Quaternion.identity, transform));
        }
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnChangeHeart;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnChangeHeart;
    }
}