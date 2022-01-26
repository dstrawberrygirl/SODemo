using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using TMPro;

public class AbilityUI : MonoBehaviour
{
    private Attack _attack;
    [SerializeField] private TMP_Text _attackNameText;
    [SerializeField] private Image _attackIcon;
    [SerializeField] private GameObjectVariable _player;
    [SerializeField] private GameObjectVariable _target;
    public void Setup(Attack attack)
    {
        _attack = attack;
        _attackIcon.sprite = _attack.DisplayIcon;
        _attackNameText.text = _attack.DisplayName;
        name = _attack.name;
    }
    public void HandleAttackButton()
    {
        // This will only be used for the player on their turn
        Instantiate(_attack.AttackFX, _player.Value.transform);
        StartCoroutine(HandleDamage());
    }
    private IEnumerator HandleDamage()
    {
        yield return new WaitForSeconds(2.5f);
        // we know the player initiated the attack, so the current target takes the damage
        _target.Value.GetComponent<CharacterBehaviour>().HandleDamageTaken(_attack.Damage);
    }
}
