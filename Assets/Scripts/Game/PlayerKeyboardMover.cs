using Game.Objects;
using Objects.Dice;
using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

public class PlayerKeyboardMover : MonoBehaviour
{

    [Inject] private Player _player;
    [Inject] private Grid _grid;
    [Inject] private DiceController _diceController;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var diceValue =1;
            _diceController.SetImage(diceValue);
            var position = _player.transform.position;
            var nextPosition = _grid.GetNextPosition(diceValue, position);
            _player.Move(nextPosition);
            
        }
        
       
    }
}
