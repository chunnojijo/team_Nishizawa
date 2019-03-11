﻿using UnityEngine;
using UnityEditor;
using System.Collections;

using Arbor.StateMachine.StateBehaviours;

namespace ArborEditor.StateMachine.StateBehaviours
{
	using Arbor;

	[CustomEditor(typeof(TweenRigidbodyRotation))]
	public class TweenRigidbodyRotationInspector : TweenBaseInspector
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			
			DrawBase();
			
			EditorGUILayout.Space();
			
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_Target" ) );

			SerializedProperty tweenMoveTypeProperty = serializedObject.FindProperty("_TweenMoveType");
			EditorGUILayout.PropertyField(tweenMoveTypeProperty);

			TweenMoveType tweenMoveType = EnumUtility.GetValueFromIndex<TweenMoveType>(tweenMoveTypeProperty.enumValueIndex);
			switch (tweenMoveType)
			{
				case TweenMoveType.Absolute:
				case TweenMoveType.Relative:
					EditorGUILayout.PropertyField(serializedObject.FindProperty("_From"));
					break;
				case TweenMoveType.ToAbsolute:
					break;
			}
			EditorGUILayout.PropertyField( serializedObject.FindProperty( "_To" ) );

			serializedObject.ApplyModifiedProperties();
		}
	}
}