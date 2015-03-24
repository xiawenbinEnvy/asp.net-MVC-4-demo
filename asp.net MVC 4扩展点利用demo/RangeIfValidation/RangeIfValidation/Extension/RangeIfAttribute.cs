using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RangeIfValidation.Extension
{
    /// <summary>
    /// 自定义ValidationAttribute，
    /// 可以根据Model内另一属性的值，来决定被验证的属性的值是否在合法区间内
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IfAttribute : RangeAttribute
    {
        private object typeid;
        public string Property { get; set; }
        public string Value { get; set; }

        public IfAttribute(string property, string value, double minimum, double maximum)
            : base(minimum, maximum)
        {
            this.Property = property;
            this.Value = value ?? "";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(this.Property);
            object propertyValue = property.GetValue(validationContext.ObjectInstance, null);
            propertyValue = propertyValue ?? "";
            if (propertyValue.ToString() != this.Value)
            {
                return ValidationResult.Success;
            }
            return base.IsValid(value, validationContext);
        }

        public override object TypeId
        {
            get { return typeid ?? (typeid = new object()); }
        }
    }
}