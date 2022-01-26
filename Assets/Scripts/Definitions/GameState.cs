using ScriptableObjectArchitecture;
using UnityEngine;

public enum GamePhase { Setup, Started, Finished }

[CreateAssetMenu(menuName = "Demo Game/Game State")]
public class GameState : ScriptableObject
{
    // Adding [SerializeField] attribute to this will not make it save in the SO unless the type itself is serializable
    // And it won't appear in the inspector until the type is serializable
    [SerializeField] private RuntimeCharacter _currentCharacter = default;
    private GamePhase _currentPhase;
    public GamePhase CurrentPhase => _currentPhase;

    public Character PlayerCharacter 
    {
        get
        {
            if (_currentCharacter.PlayerCharacter == null) _currentCharacter = new RuntimeCharacter();
            return _currentCharacter.PlayerCharacter;
        }
    }

    public void Initialize()
    {
        _currentCharacter = new RuntimeCharacter();
        _currentPhase = GamePhase.Setup;
    }
    
    public void StartGame()
    {
        _currentPhase = GamePhase.Started;
    }
    

    #region SOAEnhance
    public PlayerSelectedCustomEvent CustomPlayerSelected;

    public void SelectPlayerCharacter(Character character)
    {
        _currentCharacter.PlayerCharacter = character;
        CustomPlayerSelected.Raise(new PlayerSelectedPayload { SelectedCharacter = character });
    }

    #endregion
    
}

// Adding this attribute means we can save these values in the SO
[System.Serializable]
public struct RuntimeCharacter
{
    public Character PlayerCharacter;
}