using ScriptableObjectArchitecture;
using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private TurnController _turnController;
    [SerializeField] private GameObjectVariable _player;
    [SerializeField] private GameObjectVariable _currentTarget;
    [SerializeField] private TurnState _myTurnState;
    // Start is called before the first frame update
    private void Start()
    {
        _turnController.TurnStateChangedEvent.AddListener(HandleTurnStateChanged);
    }
    private void OnDestroy()
    {
        _turnController.TurnStateChangedEvent.RemoveListener(HandleTurnStateChanged);
    }
    private void HandleTurnStateChanged(TurnStateEventPayload evt)
    {
        if (evt.CurrentTurn == _myTurnState)
        {
            StartCoroutine(DoAttack());
        }
    }
    private IEnumerator DoAttack()
    {
        Character enemyCharacter = _currentTarget.Value.GetComponent<CharacterBehaviour>().CharacterTemplate;

        int attackIdx = Random.Range(0, enemyCharacter.Abilities.Count - 1);
        Attack attack = enemyCharacter.Abilities[attackIdx];

        // pretend to think
        yield return new WaitForSeconds(1f);
        Instantiate(attack.AttackFX, _currentTarget.Value.transform);
        yield return new WaitForSeconds(2.5f);

        // we know the enemy initiated the attack, so the player takes the damage
        _player.Value.GetComponent<CharacterBehaviour>().HandleDamageTaken(attack.Damage);

    }

}
