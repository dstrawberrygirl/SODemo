using ScriptableObjectArchitecture;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private GameObject _playerCharacterObject;
    [SerializeField] private GameState _gameState;

    #region SOA Enhance
    public GameEvent PlayerSelected;
    public PlayerSelectedCustomEvent CustomPlayerSelected;
    #endregion
    private void Start()
    {
        Debug.Log($"Current Character: {_gameState.PlayerCharacter?.CharacterName} ");
        //if (PlayerSelected) PlayerSelected.AddListener(SelectPlayerCharacter);
        if (CustomPlayerSelected) CustomPlayerSelected.AddListener(SelectCustomPlayerCharacter);
    }
    private void OnDestroy()
    {
        //if (PlayerSelected) PlayerSelected.RemoveListener(SelectPlayerCharacter);
        if (CustomPlayerSelected) CustomPlayerSelected.RemoveListener(SelectCustomPlayerCharacter);
    }


    public void SelectPlayerCharacter()
    {
        if (_playerCharacterObject != null)
        {
            Destroy(_playerCharacterObject);
        }

        if (_gameState.PlayerCharacter != null)
        {
            _playerCharacterObject = Instantiate(_gameState.PlayerCharacter.Prefab, Vector3.up, Quaternion.identity);
        }
    }


    // We don't even need to check GameState for which character is selected, it's given to us here
    private void SelectCustomPlayerCharacter(PlayerSelectedPayload newCharacter)
    {
        if (_playerCharacterObject != null)
        {
            Destroy(_playerCharacterObject);
        }
        _playerCharacterObject = Instantiate(newCharacter.SelectedCharacter.Prefab, Vector3.up, Quaternion.identity);
    }

    public void StartGame()
    {
        if (_playerCharacterObject != null)
        {
            Debug.Log($"Starting new game with {_gameState.PlayerCharacter.CharacterName}");
        }
        else if (_playerCharacterObject == null && _gameState.PlayerCharacter != null)
        {
            SelectPlayerCharacter();
            Debug.Log($"Starting game with previously-selected character: {_gameState.PlayerCharacter.CharacterName}");
        } else
        {
            Debug.LogError($"Can't start game until you choose a character!");
        }
    }
}
