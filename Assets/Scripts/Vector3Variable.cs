using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Variables/Vector3")]
public class Vector3Variable : ScriptableObject
{
    // Editor value
    [SerializeField] private Vector3 baseValue;            // Base cooldown
                                                              // Internal variables
                                                              // Ability CoolDown
    private Vector3 _value;
    public Vector3 Value { get { return _value; } set { _value = value; } }

    // Initialize coolDown with editor's value
    private void OnEnable()
    {
        _value = baseValue;
    }

    // You can also use OnAfterDeserialize for the other way around
    public void OnAfterDeserialize()
    {
    }
}
