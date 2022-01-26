using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private GameState _gameState;

    public void SelectCharacter()
    {
        _gameState.SelectPlayerCharacter(_character);
    }
}
