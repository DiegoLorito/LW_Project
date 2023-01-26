using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Extensions
{
    public static void EnableAllChilds(this Transform _transform, bool enable)
    {
        for (int i = 0; i < _transform.childCount; i++)
        {
            _transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    #region SCREEN

    public static float ScreenRatio(this Screen _screen)=> (float) Screen.width / (float) Screen.height;

    #endregion

    #region CAMERA

    public static Bounds OrthographicBounds(this Camera _camera)
    {
        float cameraHeight = _camera.orthographicSize * 2;
        float cameraWidth = cameraHeight * _camera.aspect;

        Vector2 offset = _camera.transform.position;
        Vector2 size = new Vector2(cameraWidth, cameraHeight);

        Bounds bounds = new Bounds(offset,size);

        return bounds;
    }
    public static float OrthographicBoundsSizeX(this Camera _camera)=> _camera.OrthographicBounds().size.x;
    public static float OrthographicBoundsSizeY(this Camera _camera)=> _camera.OrthographicBounds().size.y;
    public static float OrthographicBoundsMidSizeX(this Camera _camera)=> _camera.OrthographicBounds().size.x/2;
    public static float OrthographicBoundsMidSizeY(this Camera _camera)=> _camera.OrthographicBounds().size.y/2;

    #endregion

    #region GAME OBJECT

    public static void Enable(this GameObject gameObject) => gameObject.SetActive(true);
    public static void Disable(this GameObject gameObject) => gameObject.SetActive(false);
    public static T[] GetComponentsInDirectChildren<T>(this GameObject gameObject) where T : Component
    {
        List<T> components = new List<T>();

        for (int i = 0; i < gameObject.transform.childCount; ++i)
        {
            T component = gameObject.transform.GetChild(i).GetComponent<T>();
            if (component != null)
                components.Add(component);
        }

        return components.ToArray();
    }

    #endregion

    #region TRANSFORM


    private static Vector3 _auxPos;
    private static Vector3 _auxRot;
    private static Vector3 _auxScl;

    public static T[] GetComponentsInDirectChildren<T>(this Transform gameObject) where T : Component
    {
        List<T> components = new List<T>();

        for (int i = 0; i < gameObject.transform.childCount; ++i)
        {
            T component = gameObject.transform.GetChild(i).GetComponent<T>();
            if (component != null)
                components.Add(component);
        }

        return components.ToArray();
    }
    public static void SetActive(this Transform _transform, bool value) => _transform.gameObject.SetActive(value);
    public static void ShuffleSiblingIndex(this Transform _transform)
    {
        int[] currentOrder = new int[_transform.childCount];

        for (int i = 0; i < currentOrder.Length; i++)
        {
            int index = i;

            currentOrder[i] = index;
        }

        currentOrder.Shuffle();

        for (int i = 0; i < currentOrder.Length; i++)
        {
            int siblingIndex = currentOrder[i];

            _transform.GetChild(i).SetSiblingIndex(siblingIndex);
        }
    }
    public static void SetPosX(this Transform _transform, float value)
    {
        _auxPos = _transform.position;
        _auxPos.x = value;

        _transform.position = _auxPos;
    }
    public static void SetPosY(this Transform _transform, float value)
    {
        _auxPos = _transform.position;
        _auxPos.y = value;

        _transform.position = _auxPos;
    }
    public static void SetPosZ(this Transform _transform, float value)
    {
        _auxPos = _transform.position;
        _auxPos.z = value;

        _transform.position = _auxPos;
    }

    public static void SetLocalPosX(this Transform _transform, float value)
    {
        _auxPos = _transform.localPosition;
        _auxPos.x = value;

        _transform.localPosition = _auxPos;
    }
    public static void SetLocalPosY(this Transform _transform, float value)
    {
        _auxPos = _transform.localPosition;
        _auxPos.y = value;

        _transform.localPosition = _auxPos;
    }
    public static void SetLocalPosZ(this Transform _transform, float value)
    {
        _auxPos = _transform.localPosition;
        _auxPos.z = value;

        _transform.localPosition = _auxPos;
    }

    public static void RotateX(this Transform _transform, float value)
    {
        _auxRot = _transform.rotation.eulerAngles;
        _auxRot.x = value;

        _transform.rotation = Quaternion.Euler(_auxRot);
    }
    public static void RotateY(this Transform _transform, float value)
    {
        _auxRot = _transform.rotation.eulerAngles;
        _auxRot.y = value;

        _transform.rotation = Quaternion.Euler(_auxRot);
    }
    public static void RotateZ(this Transform _transform, float value)
    {
        _auxRot = _transform.rotation.eulerAngles;
        _auxRot.z = value;

        _transform.rotation = Quaternion.Euler(_auxRot);
    }

    public static void ScaleX(this Transform _transform, float value)
    {
        _auxScl = _transform.localScale;
        _auxScl.x = value;

        _transform.localScale = _auxScl;
    }
    public static void ScaleY(this Transform _transform, float value)
    {
        _auxScl = _transform.localScale;
        _auxScl.y = value;

        _transform.localScale = _auxScl;
    }
    public static void ScaleZ(this Transform _transform, float value)
    {
        _auxScl = _transform.localScale;
        _auxScl.z = value;

        _transform.localScale = _auxScl;
    }

    #endregion

    #region SPRITE RENDERER
    public static void SetAlpha(this SpriteRenderer _spriteRenderer, float alpha)
    {
        Color color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, alpha);
        _spriteRenderer.color = color;
    }
    #endregion


    #region Image
    public static void SetAlpha(this Image _image, float alpha)
    {
        Color color = new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
        _image.color = color;
    }
    #endregion

    #region TEXT
    public static void SetAlpha(this Text _text, float alpha)
    {
        Color color = new Color(_text.color.r, _text.color.g, _text.color.b, alpha);

        _text.color = color;
    }
    #endregion

    #region Color

    public static void SetAlpha(this Color _color, float alpha) => _color.a = alpha;

    #endregion

    #region LIST
    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];

            int rand = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[rand];

            list[rand] = temp;
        }
    }
    public static T RandomItem<T>(this List<T> list)
    {
        int randomIndex = UnityEngine.Random.Range(0, list.Count);

        return list[randomIndex];
    }

    #endregion

    #region DICTIONARY

    public static TValue[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
    {
        List<TValue> list = new List<TValue>();

        foreach (TValue value in dictionary.Values)
        {
            list.Add(value);
        }

        return list.ToArray();
    }

    #endregion

    #region QUEUE

    public static T PoolDequeue<T>(this Queue<T> queue)
    {
        T item = queue.Dequeue();

        queue.Enqueue(item);

        return item;
    }

    #endregion

    #region ARRAY
    public static void Shuffle<T>(this T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            T temp = array[i];

            int rand = UnityEngine.Random.Range(i, array.Length);
            array[i] = array[rand];

            array[rand] = temp;
        }
    }
    public static T[] SubArray<T>(this T[] array, int offset, int length)
    {
        T[] result = new T[length];

        Array.Copy(array, offset, result, 0, length);

        return result;
    }
    public static T RandomItem<T>(this T[] array)
    {
        int randomIndex = UnityEngine.Random.Range(0, array.Length);

        return array[randomIndex];
    }
    public static bool Contains<T>(this T[] array, T item)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(array[i], item)) return true;
        }

        return false;
    }
    public static bool Exists<T>(this T[] array, Predicate<T> match)
    {
        return Array.Exists(array, match);
    }
    public static T[] Concat<T>(this T[] first, params T[] second)
    {
        if (first == null)
        {
            return second;
        }
        if (second == null)
        {
            return first;
        }

        T[] result = new T[first.Length + second.Length];
        first.CopyTo(result, 0);
        second.CopyTo(result, first.Length);

        return result;
    }
    public static void ForEachCustom<T>(this IList<T> list, Action<T> _action) where T : MonoBehaviour
    {
        for (int i = 0; i < list.Count; i++)
        {
            _action(list[i]);
        }
    }


    public static float Duration(this AudioClip[] array)
    {
        float duration = 0;

        for (int i = 0; i < array.Length; i++)
        {
            duration += array[i].length;
        }

        return duration;
    }
    #endregion
}
