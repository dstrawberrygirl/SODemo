using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnUI : MonoBehaviour
{
    [SerializeField] private GameObject _turnDetails;
    [SerializeField] private  TurnController _turnController;
    private List<GameObject> _turns;
    [SerializeField] private GameEvent _gameInit;

    private void Awake()
    {
        _gameInit.AddListener(HandleGameInit);
    }
    private void OnDestroy()
    {
        _gameInit.RemoveListener(HandleGameInit);
    }
    private void HandleGameInit()
    {
        _turnController.TurnStateChangedEvent.AddListener(HandleTurnStateChanged);
    }

    private void HandleTurnStateChanged(TurnStateEventPayload evt)
    {
        if (_turnController.TurnIdx == 0 || _turns == null || _turns.Count == 0)
        {
            // Start round, remove previous turn display items
            if (_turns != null && _turns.Count > 0)
            {
                foreach(var turn in _turns)
                {
                    Destroy(turn);
                }
            }

            _turns = new List<GameObject>();
            // Add turn display for each turn in the round
            foreach(TurnState turn in _turnController.TurnOrder)
            {
                GameObject turnDetails = Instantiate(_turnDetails, transform);
                turnDetails.GetComponentInChildren<TMPro.TMP_Text>().text = turn.DisplayName;
                _turns.Add(turnDetails);
            }
        }
        for (int i = 0; i < _turns.Count; i++)
        {
            if (i < _turnController.TurnIdx)
            {
                _turns[i].GetComponentInChildren<Image>().color = Color.gray;
            }
            if (i == _turnController.TurnIdx)
            {
                _turns[i].GetComponentInChildren<Image>().color = Color.green;
            }
            else 
            {
                _turns[i].GetComponentInChildren<Image>().color = Color.white;
            }
        }
    }
}
