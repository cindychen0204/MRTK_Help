// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Provides interpolation over Color.
    /// </summary>
    [Serializable]
    public class InterpolatedColor : InterpolatedValue<Color>
    {
        /// <summary>
        /// Instantiates the InterpolatedColor with default of Color as initial value and skipping the first update frame.
        /// </summary>
        public InterpolatedColor() : this(default(Color)) { }

        /// <summary>
        /// Instantiates the InterpolatedColor with a given Color value as initial value and defaulted to skipping the first update frame.
        /// </summary>
        /// <param Name="initialValue">Initial current value to use.</param>
        /// <param Name="skipFirstUpdateFrame">A flag to skip first update frame after the interpolation target has been set.</param>
        public InterpolatedColor(Color initialValue, bool skipFirstUpdateFrame = false)
            : base(initialValue, skipFirstUpdateFrame)
        { }

        /// <summary>
        /// Overrides the method to calculate the current Color interpolation value by using a Color.Lerp function.
        /// </summary>
        /// <remarks>This method is public because of a Unity compilation bug when dealing with abstract methods on generics.</remarks>
        /// <param Name="startValue">The Color value that the interpolation started at.</param>
        /// <param Name="targetValue">The target Color value that the interpolation is moving to.</param>
        /// <param Name="curveValue">A curve evaluated interpolation position value. This will be in range of [0, 1]</param>
        /// <returns>The new calculated Color interpolation value.</returns>
        public override Color ApplyCurveValue(Color startValue, Color targetValue, float curveValue)
        {
            return Color.Lerp(startValue, targetValue, curveValue);
        }

        /// <summary>
        /// Overrides the method to check if two Colors are equal.
        /// </summary>
        /// <remarks>This method is public because of a Unity compilation bug when dealing with abstract methods on generics.</remarks>
        /// <param Name="one">First Color value.</param>
        /// <param Name="other">Second Color value.</param>
        /// <returns>True if the Colors are equal.</returns>
        public override bool DoValuesEqual(Color one, Color other)
        {
            return one == other;
        }
    }
}