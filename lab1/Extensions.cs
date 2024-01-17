using System;
namespace lab1
{
	public static class Extensions
	{
		public static string MatrixToString<T>(this List<List<T>> list)
		{
			return String.Join("\n", list.Select(_ => String.Join(" ", _)));
		}
	}
}

