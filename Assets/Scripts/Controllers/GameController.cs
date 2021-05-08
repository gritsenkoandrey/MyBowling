using UnityEngine;


namespace Scripts
{
    public sealed class GameController : MonoBehaviour
    {
        #region Fields
        
        private Controllers _controllers;
        
        #endregion
        

        #region UnityMethods
        
        private void Awake()
        {
            _controllers = new Controllers();
            Cleaner();
            Initialization();
            Services.Instance.CameraServices.SetCamera(Camera.main);
            //ScreenInterface.GetInstance().Execute(ScreenType.MainMenu);
        }

        private void Update()
        {
            for (var i = 0; i < _controllers.Length; i++)
            {
                _controllers[i].Execute();
            }
        }

        #endregion

        public void Cleaner()
        {
            _controllers.Cleaner();
        }

        public void Initialization()
        {
            _controllers.Initialization();
        }
    }
}
