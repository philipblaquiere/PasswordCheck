namespace PasswordCheck.Data
{
	public static class Rules
	{
		private static string SpecialCharacterSet = @"[!\.\\""\+#$%&'()\*,\-/:;<=>?@[\]^_`{|}~]";

		public static Rule AtLeastOneSpecialCharacter => new Rule
		{
			Pattern = $"({SpecialCharacterSet})",
			Name = nameof(AtLeastOneSpecialCharacter),
			Weight = 0,
			MinimumMatchCount = 1,
			Message = "contains at least 1 special character",
			IsOptional = false
		};

		public static Rule AtLeastOneCapitalLetter => new Rule
		{
			Pattern = @"([A-Z]+)",
			Name = nameof(AtLeastOneCapitalLetter),
			Weight = 0,
			MinimumMatchCount = 1,
			Message = "contains at least one capital letter",
			IsOptional = false
		};

		public static Rule AtLeastOneDigit => new Rule
		{
			Pattern = @"([0-9]+)",
			Name = nameof(AtLeastOneDigit),
			Weight = 0,
			MinimumMatchCount = 1,
			Message = "contains at least one digit",
			IsOptional = false
		};

		public static Rule LengthMinimumSix => new Rule
		{
			Pattern = @"^.{6,}$",
			Name = nameof(LengthMinimumSix),
			Weight = 1,
			MinimumMatchCount = 1,
			Message = "contains at least 6 characters",
			IsOptional = false
		};

		public static Rule LengthMaximumSixtyFour => new Rule
		{
			Pattern = @"^.{0,64}$",
			Name = nameof(LengthMaximumSixtyFour),
			Weight = 0,
			MinimumMatchCount = 1,
			Message = "contains less than 64 characters",
			IsOptional = false
		};

		public static Rule LengthMinimumEleven => new Rule
		{
			Pattern = @"^.{11,}$",
			Name = nameof(LengthMinimumEleven),
			Weight = 1,
			MinimumMatchCount = 1,
			Message = "contains at least 11 characters",
			IsOptional = true
		};

		public static Rule LengthMinimumSixteen => new Rule
		{
			Pattern = @"^.{16,}$",
			Name = nameof(LengthMinimumSixteen),
			Weight = 1,
			MinimumMatchCount = 1,
			Message = "contains at least 16 characters",
			IsOptional = true
		};

		public static Rule LengthMinimumTwentyOne => new Rule
		{
			Pattern = @"^.{21,}$",
			Name = nameof(LengthMinimumTwentyOne),
			Weight = 1,
			MinimumMatchCount = 1,
			Message = "contains at least 21 characters",
			IsOptional = true
		};

		public static Rule LengthMinimumTwentySix => new Rule
		{
			Pattern = @"^.{26,}$",
			Name = nameof(LengthMinimumTwentySix),
			Weight = 1,
			MinimumMatchCount = 1,
			Message = "contains at least 26 characters",
			IsOptional = true
		};

		public static Rule AtLeast4Digits => new Rule
		{
			Pattern = @"([0-9])",
			Name = nameof(AtLeast4Digits),
			Weight = 1,
			MinimumMatchCount = 4,
			Message = "contains at least four digits",
			IsOptional = true
		};

		public static Rule AtLeast4SpecialCharacters => new Rule
		{
			Pattern = $"({SpecialCharacterSet})",
			Name = nameof(AtLeast4SpecialCharacters),
			Weight = 1,
			MinimumMatchCount = 4,
			Message = "contains at least four special characters",
			IsOptional = true
		};

		public static Rule AtLeast4CapitalLetters => new Rule
		{
			Pattern = @"([A-Z])",
			Name = nameof(AtLeast4CapitalLetters),
			Weight = 1,
			MinimumMatchCount = 4,
			Message = "contains at least four capital characters",
			IsOptional = true
		};
	}
}
