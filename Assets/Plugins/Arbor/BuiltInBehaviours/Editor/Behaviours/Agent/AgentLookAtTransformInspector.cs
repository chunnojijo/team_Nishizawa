﻿using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	[CustomEditor(typeof(AgentLookAtTransform))]
	public class AgentLookAtTransformInspector : AgentRotateBaseInspector
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawBase();

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(serializedObject.FindProperty("_AngularSpeed"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("_Target"));
			
			serializedObject.ApplyModifiedProperties();
		}
	}
}