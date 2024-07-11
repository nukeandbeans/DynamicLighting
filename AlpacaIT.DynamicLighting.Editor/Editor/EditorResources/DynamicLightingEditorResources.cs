﻿// * * * * * * * * * * * * * * * * * * * * * *
//  Author:  Lindsey Keene (nukeandbeans)
//  Contact: Twitter @nukeandbeans, Discord @nukeandbeans
//
//  Description:
//
//  * * * * * * * * * * * * * * * * * * * * * *

using UnityEngine;

namespace AlpacaIT.DynamicLighting.Editor {
    //[CreateAssetMenu(fileName = "DynamicLightingEditorResources", menuName = "ScriptableObjects/DynamicLightingEditorResources", order = 1)]
    internal class DynamicLightingEditorResources : ScriptableObject {
        private static DynamicLightingEditorResources _Instance;

        public static DynamicLightingEditorResources Instance {
            get => _Instance ??= Resources.Load<DynamicLightingEditorResources>( "Editor/DynamicLightingEditorResources" );
        }

        public Texture2D paypalIcon;
        public Texture2D kofiIcon;
        public Texture2D patreonIcon;
        public Texture2D patreonIconWhite;
        public Texture2D discordIcon;
        public Texture2D gitHubIcon;
        public Texture2D gitHubIconWhite;
    }
}