using System;

namespace Labeler.Core.Attributes
{
    /// <summary>
    /// Add a Label to the field to use alternatively when
    /// in need to display related information more elegantly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class LabelAttribute : Attribute
    {
        internal readonly string Name;

        /// <summary>
        /// Add a Label to the field to use alternatively when
        /// in need to display related information more elegantly.
        /// </summary>
        /// <param name="name">The Label name.</param>
        public LabelAttribute(string name) : base()
        {
            this.Name = name;
        }
    }
}
