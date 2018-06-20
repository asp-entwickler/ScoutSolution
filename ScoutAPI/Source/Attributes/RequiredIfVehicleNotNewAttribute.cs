using System;
using System.ComponentModel.DataAnnotations;

namespace ScoutAPI
{

	public class RequiredIfVehicleNotNewAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext context)
		{
			Object instance = context.ObjectInstance;
			Type type = instance.GetType();

			Object isNew = type.GetProperty("IsNew").GetValue(instance, null);

			if ((bool)isNew)
				return ValidationResult.Success;

			var propetyName = context.ObjectType.GetProperty(context.MemberName).Name;
			Object attributeValue = type.GetProperty(propetyName).GetValue(instance, null);

			if (attributeValue == null)
				return new ValidationResult(string.Format("Attribute '" + propetyName + "' required if vehicle not new."));

			var stringAttributeValue = attributeValue.ToString();
			if (string.IsNullOrEmpty(stringAttributeValue) || stringAttributeValue == "0")
				return new ValidationResult(string.Format("Attribute '" + propetyName + "' required if vehicle not new."));

			return ValidationResult.Success;

		}

	}

}