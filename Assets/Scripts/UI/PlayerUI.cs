using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private PlayerSelectedCustomEvent _customPlayerSelected;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private Slider _playerHealthSlider;
    [SerializeField] private GameState _gameState;
    private void Start()
    {
        _customPlayerSelected.AddListener(SelectCustomPlayerCharacter);
        _gameState.PlayerCharacter.Health.AddListener(OnHealthChanged);
    }
    private void OnDestroy()
    {
        _customPlayerSelected.RemoveListener(SelectCustomPlayerCharacter);
        _gameState.PlayerCharacter.Health.RemoveListener(OnHealthChanged);
    }
    public void SelectCustomPlayerCharacter(PlayerSelectedPayload evt)
    {
        _playerName.text = evt.SelectedCharacter.CharacterName;
        _playerHealthSlider.value = _gameState.PlayerCharacter.Health.Value;
        
        _gameState.PlayerCharacter.Health.RemoveListener(OnHealthChanged);
        _gameState.PlayerCharacter.Health.AddListener(OnHealthChanged);
    }
    private void OnHealthChanged()
    {
        _playerHealthSlider.value = _gameState.PlayerCharacter.Health.Value;
    }

}
