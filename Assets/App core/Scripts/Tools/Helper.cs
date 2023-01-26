using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class Helper
{
    private static Camera _camera;

    public static Camera Camera
    {
        get
        {
            if (_camera == null) _camera = Camera.main;
            return _camera;
        }
    }
    public static float ScreenRatio
    {
        get { return (float)Screen.width / (float)Screen.height; }
    }
    public static bool IsIpadScreen
    {
        get
        {
            //if (Screen.orientation == ScreenOrientation.Landscape) { }
            return Screen.height * 1.5f >= Screen.width;
        }
    }




    public static bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }

    public static Vector2 GetWorldPositionOfCanvasElement(RectTransform element)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position,Camera ,out Vector3 result);
        return result;
    }
    public static Vector2 GetScreenPositionOfCanvasElement(Vector3 position)
    {
        return RectTransformUtility.WorldToScreenPoint(Camera, position);
    }


    public static bool RandomBool()
    {
        return Random.value > 0.5f;
    }


    //===== WAIT FOR SECONDS =====//
    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWait(float time) 
    {
        if (WaitDictionary.TryGetValue(time, out var wait)) return wait;

        WaitDictionary[time] = new WaitForSeconds(time);

        return WaitDictionary[time];
    }

    //===== GET TILES FROM TILEMAP =====//
    public static IEnumerable<Vector3Int> GetTilesFromMap(Tilemap map)
    {
        foreach (var pos in map.cellBounds.allPositionsWithin)
        {
            if (map.HasTile(pos))
            {
                yield return pos;
            }
        }
    }

    //===== GET CHILS POSITION FROM TRANSFORM =====//
    public static IEnumerable<Vector2> GetChildPositionFromTransform(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            yield return parent.GetChild(i).localPosition;
        }

    }
}
