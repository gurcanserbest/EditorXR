﻿using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VR.Modules;

public class InspectorInputFieldItem : InspectorPropertyItem
{
	[SerializeField]
	private InputField m_InputField;

	public override void Setup(InspectorData data)
	{
		base.Setup(data);

		var val = string.Empty;
		switch (m_SerializedProperty.propertyType)
		{
			case SerializedPropertyType.Integer:
				val = m_SerializedProperty.intValue.ToString();
				break;
			case SerializedPropertyType.Float:
				val = m_SerializedProperty.floatValue.ToString();
				break;
			case SerializedPropertyType.String:
				val = m_SerializedProperty.stringValue;
				break;
			case SerializedPropertyType.Character:
				val = m_SerializedProperty.intValue.ToString();
				break;
		}

		m_InputField.text = val;
	}

	public void SetValue(string input)
	{
		switch (m_SerializedProperty.propertyType)
		{
			case SerializedPropertyType.Integer:
				int i;
				if (int.TryParse(input, out i) && m_SerializedProperty.intValue != i)
					m_SerializedProperty.intValue = i;
				break;
			case SerializedPropertyType.Float:
				float f;
				if (float.TryParse(input, out f) && !Mathf.Approximately(m_SerializedProperty.floatValue, f))
					m_SerializedProperty.floatValue = f;
				break;
			case SerializedPropertyType.String:
				if(!m_SerializedProperty.stringValue.Equals(input))
					m_SerializedProperty.stringValue = input;
				break;
			case SerializedPropertyType.Character:
				char c;
				if (char.TryParse(input, out c) && c != m_SerializedProperty.intValue)
					m_SerializedProperty.intValue = c;
				break;
		}

		data.serializedObject.ApplyModifiedProperties();
	}

	protected override void DropItem(Transform fieldBlock, IDropReciever dropReciever, GameObject target)
	{

	}

	public override bool TestDrop(GameObject target, object droppedObject)
	{
		return false;
	}

	public override bool RecieveDrop(GameObject target, object droppedObject)
	{
		return false;
	}
}