using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Useful class for telling if objects are on screen.</summary> 
 */
public static class RendererExtensions
{
    public static bool IsVisibleFrom(this SpriteRenderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
