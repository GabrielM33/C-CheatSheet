using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Serialization;

    public class TouchButton : XRBaseInteractable
    {
        [Header("Visuals")]
        public Material normalMaterial; // normalMaterial: represetnt the material assigned to the gameObject 
        public Material touchedMaterial; // touchedMaterial: represents another material that is used when an object is "touched" or interacts with something

        [Header("Button Data")]
        public int buttonNumber; // is an integer representing the button's number
        public NumberPad linkedNumberpad; // it is linked to the NumberPad gameObject

        private int m_NumberOfInteractor = 0; // is an integer to keep track of how many interactors are currently hovering over the button
        private Renderer m_RendererToChange; //  is a reference to the button's MeshRenderer, which is used to change the button's material during gameplay

        private void Start()
        {
            m_RendererToChange = GetComponent<MeshRenderer>();
        }

        public override bool IsHoverableBy(IXRHoverInteractor interactor)
        {
            return base.IsHoverableBy(interactor) && (interactor is XRDirectInteractor);
        }

        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            base.OnHoverEntered(args);

            //we only want to change for the first interactor that touch (e.g. if we touch with a second hand when one is
            //already touching the button, no need to change the data again)
            if (m_NumberOfInteractor == 0)
            {
                m_RendererToChange.material = touchedMaterial;

                linkedNumberpad.ButtonPressed(buttonNumber);
            }

            m_NumberOfInteractor += 1;
        }

        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);

            m_NumberOfInteractor -= 1;

            //if we have multiple interactor touching that (e.g. 2 hands) then this will be called when only one is removed.
            //we want to make sure we have nothing left hovering before returning it to "normal" state.
            if (m_NumberOfInteractor == 0)
                m_RendererToChange.material = normalMaterial;
        }
    }

"""
Header Section: This section includes public fields for defining materials and button data.

normalMaterial and touchedMaterial are materials for the button's appearance, representing the normal state and the state when the button is "touched" or interacts with something.

buttonNumber is an integer representing the button's number.

linkedNumberpad is a reference to a NumberPad game object, indicating that this button is linked to a number pad.

Private Variables: These variables are used within the class for tracking interactor states and modifying the button's appearance dynamically.

m_NumberOfInteractor is an integer to keep track of how many interactors are currently hovering over the button.

m_RendererToChange is a reference to the button's MeshRenderer, which is used to change the button's material during gameplay.

Start() Method: In the Start method, the m_RendererToChange variable is assigned the reference to the button's MeshRenderer. This is typically done at the beginning of the script.

IsHoverableBy() Method: This method overrides a base method to check if the button can be hovered by an interactor. It returns true if the interactor is a XRDirectInteractor.

OnHoverEntered() Method: This method is called when an interactor enters the hover state with the button. It overrides a base method to perform specific actions:

If there are no interactors currently hovering, it changes the button's material to touchedMaterial.

It calls the ButtonPressed method of the linked NumberPad with the button's number.

It increments the m_NumberOfInteractor counter.

OnHoverExited() Method: This method is called when an interactor exits the hover state with the button. It overrides a base method to perform specific actions:

It decrements the m_NumberOfInteractor counter.

If there are no interactors left hovering, it changes the button's material back to normalMaterial.

"""