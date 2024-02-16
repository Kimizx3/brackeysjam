using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraA;
    public Camera cameraB;
    public Camera cameraC;
    public Camera cameraC2;
    public Camera cameraD;
    public Camera cameraD2;
    public Material cameraMatA;
    public Material cameraMatB;
    public Material cameraMatC;
    public Material cameraMatC2;
    public Material cameraMatD;
    public Material cameraMatD2;
    
    

    private void Start()
    {
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }

        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = cameraA.targetTexture;
        
        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }

        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
        
        if (cameraC.targetTexture != null)
        {
            cameraC.targetTexture.Release();
        }

        cameraC.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatC.mainTexture = cameraC.targetTexture;
        
        if (cameraC2.targetTexture != null)
        {
            cameraC2.targetTexture.Release();
        }

        cameraC2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatC2.mainTexture = cameraC2.targetTexture;
        
        if (cameraD.targetTexture != null)
        {
            cameraD.targetTexture.Release();
        }

        cameraD.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatD.mainTexture = cameraD.targetTexture;
        
        if (cameraD2.targetTexture != null)
        {
            cameraD2.targetTexture.Release();
        }

        cameraD2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatD2.mainTexture = cameraD2.targetTexture;
    }
}
