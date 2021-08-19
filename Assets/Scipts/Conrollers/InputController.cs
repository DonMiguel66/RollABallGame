using System.Collections.Generic;
using UnityEngine;

namespace RollaBallGame
{
    public sealed class InputController : IExecute
    {
        private readonly PlayerBase _playerBase;
        private readonly SaveDataRepository _saveDataRepository;
        private readonly InputData _inputData;
        private readonly Repository _repository;
        private readonly ListExecuteObject _iOList;
        private readonly IOSaveLoadController _iOSaveLoadController;

        public InputController(PlayerBase player, InputData inputData, ListExecuteObject iOList)
        {
            _playerBase = player;
            _inputData = inputData;
            _iOList = iOList;
            _saveDataRepository = new SaveDataRepository();
            _iOSaveLoadController = new IOSaveLoadController(_iOList);

            _repository = new Repository();
        }

        public void Execute()
        {
            _playerBase.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(_inputData.Save))
            {
                _saveDataRepository.Save(_playerBase);
            }
            if (Input.GetKeyDown(_inputData.Load))
            {
                _saveDataRepository.Load(_playerBase);
            }
            if (Input.GetKeyDown(_inputData.SaveAll))
            {
                _repository.SaveIO(_iOSaveLoadController.ListObjects);
            }
            if (Input.GetKeyDown(_inputData.LoadAll))
            {
                _repository.LoadIO(_iOSaveLoadController.ListObjects);
            }
        }
    }

}
