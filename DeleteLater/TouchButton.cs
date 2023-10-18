using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    public Color TouchedMaterial = Color.red;
    public Material buttonNormal;
    public ButtonNumber buttonNumber;

    protected override void OnHoverEntered(SelectEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        m_Renderer.material = TouchedMaterial;
        LinkedKeypad.ButtonPressed(buttonNumber);
    }

    protected override void OnHoverExited(SelectExitEventArgs args)
    {
        base.OnHoverExited(args);
        m_Renderer.material = buttonNormal;
    }
}
