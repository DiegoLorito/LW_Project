using System;
using System.Collections.Generic;
using UnityEngine;

public class SO_Vocabulary : ScriptableObject
{
    public virtual string StrVocab
    {
        get
        {
            Debug.Log("There isn't vocab name");
            
            return null;
        }
    }
    public virtual string StrReinforcement
    {
        get
        {
            Debug.Log("There isn't reiforcement name");

            return null;
        }
    }
    public virtual Sprite SpVocab
    {
        get
        {
            Debug.Log("There isn't vocab image");

            return null;
        }
    }
    public virtual AudioClip ClipVocab
    {
        get
        {
            Debug.Log("There isn't vocab clip");

            return null;
        }
    }
    public virtual AudioClip ClipReinforcement
    {
        get
        {
            Debug.Log("There isn't vocab clip reinforcement");

            return null;
        }
    }
    public virtual AudioClip ClipIncorrect
    {
        get
        {
            Debug.Log("There isn't vocab clip incorrect");

            return null;
        }
    }
    public virtual Sprite Icon
    {
        get
        {
            Debug.Log("There isn't vocab icon");

            return null;
        }
    }
    public virtual string IconName
    {
        get
        {
            Debug.Log("There isn't vocab icon name");

            return null;
        }
    }

    public static implicit operator List<object>(SO_Vocabulary v)
    {
        throw new NotImplementedException();
    }
}
