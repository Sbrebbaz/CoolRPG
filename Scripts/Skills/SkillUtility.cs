using static Enums;

namespace CoolRPG.Scripts.Skills
{
	public static class SkillUtility
	{
		public static int CalculateMultiplier(Element skillElement, Element targetElement)
		{
			int multiplier = 0;

			switch (skillElement)
			{
				case Element.Bland:
					{
						//No multiplier
						multiplier = 0;
						break;
					}
				case Element.Salty:
					{
						break;
					}
				case Element.Sour:
					{
						break;
					}
				case Element.Sweet:
					{
						break;
					}
				case Element.Bitter:
					{
						break;
					}
				case Element.Umami:
					{
						break;
					}
			}

			return multiplier;
		}

	}
}
