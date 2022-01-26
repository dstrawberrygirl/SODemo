using ScriptableObjectArchitecture;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject _abilityButtonsContainer;
    [SerializeField] private AbilityUI _abilityButtonPrefab;
    [SerializeField] private GameObjectVariable _currentTarget;
    [SerializeField] private GameObjectVariable _currentPlayer;
    [SerializeField] private GameState _gameState;
    
    private void Start()
    {
        _currentTarget.AddListener(HandleTargetChanged);
        _currentPlayer.AddListener(HandleTargetChanged);
    }
    private void OnDestroy()
    {
        _currentTarget.RemoveListener(HandleTargetChanged);
        _currentPlayer.RemoveListener(HandleTargetChanged);
    }
    private void HandleTargetChanged()
    {
        foreach(Transform buttonTransform in _abilityButtonsContainer.transform)
        {
            Destroy(buttonTransform.gameObject);
        }
        foreach(Attack attack in _gameState.PlayerCharacter.Abilities)
        {
            // create a button for each attack as a child of the container. The layout group will handle placement
            AbilityUI ability = Instantiate(_abilityButtonPrefab, _abilityButtonsContainer.transform);
            ability.Setup(attack);
        }
    }
}
