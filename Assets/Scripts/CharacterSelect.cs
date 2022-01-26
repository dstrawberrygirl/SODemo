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













    // [SerializeField] private PlayerSelectedCustomEvent _customPlayerSelected;

    // public void RaiseCharacterSelectEvent()
    // {
    //     // We could raise this event here but GameState can't listen for events, so we'd have
    //     // to set the player here also.
    //     _customPlayerSelected.Raise(new PlayerSelectedPayload { SelectedCharacter = _character });
    // }
}
