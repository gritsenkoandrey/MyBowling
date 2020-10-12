﻿using UnityEngine;


namespace ExampleTemplate
{ 
    public static class LayerManager
    {
        #region Fields

        private const string IGNORE_RAYCAST = "Ignore Raycast";
        private const string WATER = "Water";
        private const string ENVIRONMENT = "Environment";
        private const string DEFAULT = "Default";
        private const string NON_COLLIDABLE = "Non-Collidable";
        private const string GROUND = "Ground";
        private const string UI = "UI";

        public const int DEFAULT_LAYER = 0;

        #endregion

    

        #region Proeprties

        public static int IgnoreRaycastLayer { get; }
        public static int EnvironmentLayer { get; }
        public static int DefaultLayer { get; }
        public static int GroundLayer { get; }
        public static int UiLayer { get; }
        public static int NonCollidableLayer { get; }

        #endregion

    

        #region Class lifecycle

        static LayerManager()
        {
            IgnoreRaycastLayer = LayerMask.GetMask(IGNORE_RAYCAST, WATER, NON_COLLIDABLE);
            EnvironmentLayer = LayerMask.GetMask(ENVIRONMENT, GROUND);
            DefaultLayer = LayerMask.GetMask(DEFAULT);
            GroundLayer = LayerMask.GetMask(GROUND);
            UiLayer = LayerMask.GetMask(UI);
            NonCollidableLayer = LayerMask.NameToLayer(NON_COLLIDABLE);
            
            IgnoreLayerCollision();
        }

        #endregion


        #region Methods

        private static void IgnoreLayerCollision()
        {
            
        }

        #endregion
    }
}
