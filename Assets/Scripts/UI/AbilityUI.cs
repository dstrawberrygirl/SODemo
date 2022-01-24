using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityUI : MonoBehaviour
{
    private Attack _attack;
    [SerializeField] private TMP_Text _attackNameText;
    [SerializeField] private Image _attackIcon;
    public void Setup(Attack attack)
    {
        _attack = attack;
        _attackIcon.sprite = _attack.DisplayIcon;
        _attackNameText.text = _attack.DisplayName;

    }
}
