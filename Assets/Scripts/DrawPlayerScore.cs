using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DrawPlayerScore : MonoBehaviour
{
    [SerializeField] PlayerScoreObject _playerScore;
    Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = $"People in Mouth: {_playerScore._score}";
    }
}
