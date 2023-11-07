using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardMatchingGame.Presentation
{
    public class PresentationSceneReferenceHolder : MonoBehaviour
    {
        internal static GridHandlerPresentation GridHandlerPresentation;

        [SerializeField] private GridHandlerPresentation _gridHandlerPresentation;

        private void Awake()
        {
            GridHandlerPresentation = _gridHandlerPresentation;

        }
    }
}
