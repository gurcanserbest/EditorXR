﻿using System;
using UnityEngine;

namespace UnityEditor.Experimental.EditorVR
{
	/// <summary>
	/// Implementors receive a preview origin transform
	/// </summary>
	public interface IGetPreviewOrigin
	{
		/// <summary>
		/// Get the preview transform attached to the given rayOrigin
		/// </summary>
		Func<Transform, Transform> getPreviewOriginForRayOrigin { set; }
	}
}