using System;
using System.Reflection;
using System.Text;
namespace System.Linq.Dynamic
{
	public abstract class DynamicClass
	{
		public override string ToString()
		{
			var properties = base.GetType().GetRuntimeProperties().ToArray();
			var stringBuilder = new StringBuilder();
			stringBuilder.Append("{");

			for (int i = 0; i < properties.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(properties[i].Name);
				stringBuilder.Append("=");
				stringBuilder.Append(properties[i].GetValue(this, null));
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}
	}
}
