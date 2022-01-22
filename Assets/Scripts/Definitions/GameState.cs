using ScriptableObjectArchitecture;
using UnityEngine;
[CreateAssetMenu(menuName = "Demo Game/Game State")]
public class GameState : ScriptableObject
{
    // Adding [SerializeField] attribute to this will not make it save in the SO unless the type itself is serializable
    // And it won't appear in the inspector until the type is serializable
    [SerializeField] private RuntimeCharacter _currentCharacter = default;

    #region SOA Enhance
    public GameEvent PlayerSelected;
    public PlayerSelectedCustomEvent CustomPlayerSelected;
    #endregion

    public Character PlayerCharacter 
    {
        get
        {
            if (_currentCharacter == null) _currentCharacter = new RuntimeCharacter();
            return _currentCharacter.PlayerCharacter;
        }
    }

    public void Initialize()
    {
        _currentCharacter = new RuntimeCharacter();
    }

    public void SelectPlayerCharacter(Character character)
    {
        _currentCharacter.PlayerCharacter = character;
        if (PlayerSelected) PlayerSelected.Raise();
        if (CustomPlayerSelected) CustomPlayerSelected.Raise(new PlayerSelectedPayload { SelectedCharacter = character });
    }
}

// Adding this attribute means we can save these values in the SO
[System.Serializable]
public class RuntimeCharacter
{
    public Character PlayerCharacter;
}