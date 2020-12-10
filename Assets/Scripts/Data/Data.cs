using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        #region Fields
        
        [SerializeField] private string _shakeDataPath = null;
        [SerializeField] private string _gameLevelDataPath = null;
        [SerializeField] private string _ballDataPath = null;
        [SerializeField] private string _prefabsDataPath = null;
        [SerializeField] private string _platformDataPath = null;

        private static ShakesData _shake;
        private static GameLevelData _gameLevelData;
        private static BallData _ballData;
        private static PrefabsData _prefabsData;
        private static PlatformData _platformData;

        private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));
        
        #endregion
        

        #region Properties

        public static Data Instance => _instance.Value;

        public ShakesData Shakes
        {
            get
            {
                if (_shake == null)
                {
                    _shake = Load<ShakesData>("Data/" + Instance._shakeDataPath);
                }

                return _shake;
            }
        }

        public GameLevelData GameLevelData
        {
            get
            {
                if (_gameLevelData == null)
                {
                    _gameLevelData = Load<GameLevelData>("Data/" + Instance._gameLevelDataPath);
                }
                return _gameLevelData;
            }
        }

        public BallData Ball
        {
            get
            {
                if (_ballData == null)
                {
                    _ballData = Load<BallData>("Data/" + Instance._ballDataPath);
                }
                return _ballData;
            }
        }

        public PrefabsData PrefabsData
        {
            get
            {
                if (_prefabsData == null)
                {
                    _prefabsData = Load<PrefabsData>("Data/" + Instance._prefabsDataPath);
                }
                return _prefabsData;
            }
        }

        public PlatformData PlatformData
        {
            get
            {
                if (_platformData == null)
                {
                    _platformData = Load<PlatformData>("Data/" + Instance._platformDataPath);
                }
                return _platformData;
            }
        }

        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    
        #endregion
    }
}