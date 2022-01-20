using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Demo Game/Turn Controller")]
public class TurnController : ScriptableObject
{
    [SerializeField] private TurnState _startTurnState;
    [SerializeField] private TurnState _endTurnState;
    [SerializeField] private TurnState _playerTurnState;
    [SerializeField] private TurnState _enemyTurnState;
    private List<TurnState> _turnOrder = new List<TurnState>();
    public List<TurnState> TurnOrder => _turnOrder;
    public TurnState CurrentTurnState => _turnOrder[_turnIdx] ? _turnOrder[_turnIdx] : _startTurnState;
    private int _turnIdx;
    public int TurnIdx => _turnIdx;
    private int _turnsPerRound = 3;
    public int TurnsPerRound => _turnsPerRound;
    private int _roundCounter;
    public int RoundCounter => _roundCounter;
    public void StartRound()
    {
        _turnIdx = 1;
        _roundCounter += 1;
        Debug.Log($"Starting round, first turn: {CurrentTurnState}");
        // _turnStateChangedEvent.Raise(new TurnStateEventPayload() { turnState = CurrentTurnState });
    }

    public void InitializeTurns()
    {
        _turnOrder = new List<TurnState>();
        _turnIdx = 0;
        _roundCounter = 0;
        TurnState t = _startTurnState;
        _turnOrder.Add(t);

        for (int i = 0; i < _turnsPerRound; i++)
        {
            TurnState nextTurn = t.GetNextTurnState();
            _turnOrder.Add(nextTurn);
            t = nextTurn;
        }

        _turnOrder.Add(_endTurnState);
        // if (_turnOrderUpdateEvent) _turnOrderUpdateEvent.Raise();
        // _turnStateChangedEvent.Raise(new TurnStateEventPayload() { turnState = CurrentTurnState });
    }
}
