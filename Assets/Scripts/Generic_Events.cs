using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Generic_Events : MonoBehaviour
{

}

[System.Serializable]
public class IntEvent : UnityEvent<int> { }
public class FloatEvent : UnityEvent<float> { }
public class StringEvent : UnityEvent<string> { }
public class CharEvent : UnityEvent<char> { }