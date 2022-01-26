using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterBehaviour : MonoBehaviour
{
    public Character CharacterTemplate;
    public Faction CharacterFaction;
    public FloatReference Health;
    [SerializeField] private FloatReference _startingHealth = default(FloatReference);
    [SerializeField] private GameObjectVariable _currentTarget;
    [SerializeField] private GameObjectVariable _currentPlayer;

    [SerializeField] private GameObject _targetHighlight;
    [SerializeField] private TurnController _turnController;
    private LookAtConstraint _lookAtConstraint;

    private void Start()
    {
        _lookAtConstraint = GetComponent<LookAtConstraint>();
        _currentTarget.AddListener(HandleTargetChanged);
        Health.Value = _startingHealth.Value;
        CharacterTemplate.Health = Health;
    }
    private void OnDestroy(){
        _currentTarget.RemoveListener(HandleTargetChanged);
    }

    public void HandleDamageTaken(float incomingDamage)
    {
        CharacterTemplate.Health.Value = Mathf.Clamp(CharacterTemplate.Health.Value - incomingDamage, 0, 100f);
        Debug.Log($"{CharacterTemplate.CharacterName} health: {CharacterTemplate.Health.Value}");
        _turnController.EndTurn();
    }

    private void HandleTargetChanged()
    {
        _targetHighlight.SetActive(false);
        
        if (_currentTarget.Value == null){
            return;
        }
        // highlight the targeted enemy
        if (_currentTarget.Value == this.gameObject)
        {
            _targetHighlight.SetActive(true);
        }

        // player looks at the current target
        if (_currentPlayer.Value == this.gameObject)
        {
            AddOrSetConstraintSource(_currentTarget.Value.transform);
        }
        else // everyone else looks at player
        {
            AddOrSetConstraintSource(_currentPlayer.Value.transform);
        }
        _lookAtConstraint.constraintActive = true;
    }

    private void AddOrSetConstraintSource(Transform target)
    {
        if (_lookAtConstraint.sourceCount == 0)
        {
            _lookAtConstraint.AddSource(new ConstraintSource { sourceTransform = target, weight = 1.0f});
        } 
        else
        {
            _lookAtConstraint.SetSource(0, new ConstraintSource { sourceTransform = target, weight = 1.0f});
        }
    }
}
