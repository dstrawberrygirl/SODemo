using ScriptableObjectArchitecture;
using UnityEngine;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour
{
    private GameObject _playerCharacterObject;
    
    [SerializeField] private GameState _gameState;
    [SerializeField] private TurnController _turnController;
    [SerializeField] private GameObjectCollection _enemies;
    [SerializeField] private List<Character> _allCharacters;
    [SerializeField] private GameObjectVariable _currentTarget;

    #region SOA Enhance
    public GameEvent PlayerSelected;
    public PlayerSelectedCustomEvent CustomPlayerSelected;
    #endregion
    private void Start()
    {
        Debug.Log($"Current Character: {_gameState.PlayerCharacter?.CharacterName} ");
        //if (PlayerSelected) PlayerSelected.AddListener(SelectPlayerCharacter);
        if (CustomPlayerSelected) CustomPlayerSelected.AddListener(SelectCustomPlayerCharacter);
        _turnController.TurnStateChangedEvent.AddListener(HandleTurnStateChanged);
        _turnController.InitializeTurns();
    }

    private void HandleTurnStateChanged(TurnStateEventPayload evt)
    {
        Debug.Log($"Current turn: {evt.CurrentTurn}");
    }

    private void OnDestroy()
    {
        //if (PlayerSelected) PlayerSelected.RemoveListener(SelectPlayerCharacter);
        if (CustomPlayerSelected) CustomPlayerSelected.RemoveListener(SelectCustomPlayerCharacter);
        _turnController.TurnStateChangedEvent.RemoveListener(HandleTurnStateChanged);
        _enemies.Clear();
    }


    public void SelectPlayerCharacter()
    {
        if (_playerCharacterObject != null)
        {
            Destroy(_playerCharacterObject);
        }

        if (_gameState.PlayerCharacter != null)
        {
            InstantiatePlayer(_gameState.PlayerCharacter);
        }
    }


    // We don't even need to check GameState for which character is selected, it's given to us here
    private void SelectCustomPlayerCharacter(PlayerSelectedPayload evt)
    {
        if (_playerCharacterObject != null)
        {
            Destroy(_playerCharacterObject);
        }
        InstantiatePlayer(evt.SelectedCharacter);
    }

    private void InstantiatePlayer(Character playerCharacter)
    {
        Vector3 pos = new Vector3(-2, 1, 0);
        _playerCharacterObject = Instantiate(playerCharacter.Prefab, pos, Quaternion.identity);
        InstantiateEnemies(playerCharacter);
    }

    private void InstantiateEnemies(Character playerCharacter)
    {
        ClearEnemies();
        foreach(Character c in _allCharacters)
        {
            if (c != playerCharacter)
            {
                Vector3 pos = new Vector3((_enemies.Count * 2) + 2, 1, -_enemies.Count);
                GameObject enemy = Instantiate(c.Prefab, pos, Quaternion.identity);
                enemy.GetComponent<CharacterBehaviour>().CharacterFaction = Faction.Enemy;

                _enemies.Add(enemy);
            }
        }
    }

    private void ClearEnemies()
    {
        if (_enemies.Count > 0)
        {
            foreach(var enemy in _enemies)
            {
                Destroy(enemy);
            }
        }
        _enemies.Clear();
    }
    public void StartGame()
    {
        if (_playerCharacterObject == null && _gameState.PlayerCharacter == null)
        {
            Debug.LogError($"Can't start game until you choose a character!");
            return;
        }

        if (_playerCharacterObject == null)
        {
            Debug.Log($"Starting game with previously-selected character: {_gameState.PlayerCharacter.CharacterName}");
            SelectPlayerCharacter();
        }
        else 
        {
            Debug.Log($"Starting new game with {_gameState.PlayerCharacter.CharacterName}");
        } 
        _turnController.StartRound();
        int enemyIdx = Random.Range(0, _enemies.Count - 1);

        _currentTarget.Value = _enemies[enemyIdx];

    }
}
