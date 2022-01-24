using ScriptableObjectArchitecture;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Character CharacterTemplate;
    public Faction CharacterFaction;
    private float _currentHealth;
    public float CurrentHealth => _currentHealth;
    public float CurrentHealthNormalized => _currentHealth / 100;
    [SerializeField] private GameObjectVariable _currentTarget;

    [SerializeField] private GameObject _targetHighlight;

    private void Start()
    {
        _currentHealth = CharacterTemplate.InitialHealth;
        _currentTarget.AddListener(HandleTargetChanged);
    }

    public void HandleDamageTaken(float incomingDamage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - incomingDamage, 0, 100f);
    }

    public void HandleTargetChanged()
    {
        _targetHighlight.SetActive(false);
        
        if (_currentTarget.Value && _currentTarget.Value == this.gameObject)
        {
            _targetHighlight.SetActive(true);
        }
    }
}
