using Labeler.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Labeler.Core.Extentions
{
    /// <summary>
    /// Extentions regarding getting a Label or a queryable set ot Labels of an enum entity.
    /// </summary>
    public static class LabelExtentions
    {
        /// <summary>
        /// Get Label for an enum entity.
        /// If more than one Labels have been assigned, the first will be returned.
        /// If there hasn't any Label been assigned, the enum field name will be returned as string.
        /// </summary>
        /// <typeparam name="T">The enum type to examine.</typeparam>
        /// <param name="t">The enum entity to examine.</param>
        /// <returns>
        /// If more than one Labels have been assigned, the first will be returned.
        /// If there hasn't any Label been assigned, the enum field name will be returned as string.
        /// </returns>
        public static string GetLabel<T>(this T t) where T : Enum
        {
            // check if there is a label for field and return the label,
            // otherwise return the field's name as str.
            return GetLabelAttributesForEntity(t).FirstOrDefault()?.Name ?? t.ToString();
        }

        /// <summary>
        /// Get Labels for an enum entity.
        /// If there hasn't any Label been assigned, the enum field name will be returned as string.
        /// </summary>
        /// <typeparam name="T">The enum type to examine.</typeparam>
        /// <param name="t">The enum entity to examine.</param>
        /// <returns>
        /// If there hasn't any Label been assigned, the enum field name will be returned as string.
        /// </returns>
        public static IEnumerable<string> GetLabels<T>(this T t) where T : Enum
        {
            // get labels for entity.
            var labels = GetLabelAttributesForEntity(t);

            // if no labels found, return the field's name as a string in a str[].
            return labels.Length > 0 ? labels.Select(s => s.Name) : new string[] { t.ToString() };
        }

        private static LabelAttribute[] GetLabelAttributesForEntity<T>(T t)
        {
            // get entity's value/field name.
            var fieldName = t.ToString();

            // get entity's field by name.
            var field = t.GetType().GetField(fieldName);

            // get an array of labels for entity.
            return field.GetCustomAttributes(typeof(LabelAttribute), false) as LabelAttribute[];
        }
    }
}
