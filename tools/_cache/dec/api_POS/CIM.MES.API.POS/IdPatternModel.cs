using System;
using System.Collections.Generic;
using System.Globalization;

namespace CIM.MES.API.POS;

internal class IdPatternModel
{
	private static int iConvert = 65;

	private static int iConvert10 = 55;

	private static int i36 = 36;

	private static int i26 = 26;

	internal List<string> FormatList = new List<string>
	{
		"Y", "YY", "YYYY", "Y1", "YA@", "MM", "MA", "M1", "M", "DDD",
		"DD", "D", "D1", "SERALPH", "SERHEX", "SERNUM", "WEEK", "SERMIXED", "%USERPARAM", "SERNUMEXTALPH"
	};

	internal static string[] GetStringToFormat(string format)
	{
		format = format.Replace("][", ",");
		format = format.Replace("[", ",");
		format = format.Replace("]", ",");
		char[] separator = new char[1] { ',' };
		return format.Split(separator, StringSplitOptions.RemoveEmptyEntries);
	}

	internal static string Convert_Year(string format, DateTime userTime)
	{
		string text = "";
		if (format.Equals("Y"))
		{
			return userTime.ToString("yy").Substring(1, 1);
		}
		if (format.Equals("Y1"))
		{
			int num = int.Parse(userTime.ToString("yy"));
			num %= i36;
			if (num > 9)
			{
				return Convert.ToChar(num + iConvert10).ToString();
			}
			return num.ToString();
		}
		return userTime.ToString(format.ToLower());
	}

	internal static string Convert_YAS(string format, DateTime userTime)
	{
		int num = int.Parse(format.Split('@')[1].ToString());
		int num2 = userTime.Year - num;
		if (num2 < 0)
		{
			throw new Exception(">> Convert_YAS Method Error \\r\\n>> StartYser and CurrentTime is over. \\r\\n>> CurrentTime < StartYser");
		}
		int num3 = num2 % i26;
		return Convert.ToChar(iConvert + num3).ToString();
	}

	internal static string Convert_Month(string format, DateTime userTime)
	{
		string text = "";
		if (format.Equals("M"))
		{
			return userTime.Month.ToString();
		}
		if (format.Equals("M1"))
		{
			int num = int.Parse(userTime.Month.ToString());
			if (num > 9)
			{
				num %= i36;
				return Convert.ToChar(num + iConvert10).ToString();
			}
			return num.ToString();
		}
		if (format.Equals("MA"))
		{
			return Convert.ToChar(int.Parse(userTime.Month.ToString()) - 1 + iConvert).ToString();
		}
		return userTime.ToString(format);
	}

	internal static string Convert_Day(string format, DateTime userTime)
	{
		string text = "";
		if (format.Equals("D"))
		{
			return userTime.Day.ToString();
		}
		if (format.Equals("DDD"))
		{
			return userTime.DayOfYear.ToString("000");
		}
		if (format.Equals("D1"))
		{
			int num = int.Parse(userTime.Day.ToString());
			if (num > 9)
			{
				num %= i36;
				return Convert.ToChar(num + iConvert10).ToString();
			}
			return num.ToString();
		}
		return userTime.ToString(format.ToLower());
	}

	internal static string Convert_WeekOfMonth(DateTime currrentTime)
	{
		DateTime time = currrentTime;
		string s = currrentTime.ToString("yyyy-MM-01");
		DateTime result = default(DateTime);
		DateTime.TryParse(s, out result);
		CultureInfo cultureInfo = new CultureInfo("en-US");
		Calendar calendar = cultureInfo.Calendar;
		CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
		DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
		int weekOfYear = calendar.GetWeekOfYear(time, calendarWeekRule, firstDayOfWeek);
		int weekOfYear2 = calendar.GetWeekOfYear(result, calendarWeekRule, firstDayOfWeek);
		int num = weekOfYear - weekOfYear2;
		return (num + 1).ToString();
	}

	internal static string Convert_WeekOfYear(DateTime userTime)
	{
		CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("no");
		return cultureInfo.Calendar.GetWeekOfYear(userTime, cultureInfo.DateTimeFormat.CalendarWeekRule, cultureInfo.DateTimeFormat.FirstDayOfWeek).ToString("00");
	}

	internal static string Convert_SERALPH(string format, int currentSerial)
	{
		string text = "";
		bool flag = true;
		int num = currentSerial;
		int num2 = int.Parse(format.Replace("SERALPH<", "").Replace(">", ""));
		while (flag)
		{
			text = Convert.ToChar(num % i26 + iConvert) + text;
			if (num / i26 == 0)
			{
				flag = false;
			}
			num /= i26;
		}
		while (text.Length < num2)
		{
			text = "A" + text;
		}
		if (text.Length > num2)
		{
			throw new Exception($"SERALPH 가 설정한 {num2} 자리수를 초과했습니다");
		}
		return text;
	}

	internal static string Convert_SERMIXED(string format, int currentSerial)
	{
		string text = "";
		bool flag = true;
		int num = currentSerial;
		int num2 = int.Parse(format.Replace("SERMIXED<", "").Replace(">", ""));
		while (flag)
		{
			int num3 = num % i36;
			text = ((num3 <= 9) ? (num3 + text) : (Convert.ToChar(num3 + iConvert10) + text));
			if (num / i36 == 0)
			{
				flag = false;
			}
			num /= i36;
		}
		while (text.Length < num2)
		{
			text = "0" + text;
		}
		if (text.Length > num2)
		{
			throw new Exception($"SERMIXED 가 설정한 {num2} 자리수를 초과했습니다");
		}
		return text;
	}

	internal static string Convert_SERHEX(string format, int currentSerial)
	{
		int num = int.Parse(format.Replace("SERHEX<", "").Replace(">", ""));
		string text = currentSerial.ToString("X" + num);
		if (text.Length > num)
		{
			throw new Exception($"SERHEX 이 설정한 {num} 자리수를 초과했습니다");
		}
		return text;
	}

	internal static string Convert_SERNUM(string format, int currentSerial)
	{
		int num = int.Parse(format.Replace("SERNUM<", "").Replace(">", ""));
		string text = currentSerial.ToString("D" + num);
		if (text.Length > num)
		{
			throw new Exception($"SERNUM 이 설정한 {num} 자리수를 초과했습니다");
		}
		return text;
	}

	internal static string Convert_SERNUMEXTALPH(string format, int currentSerial)
	{
		string text = "";
		int num = int.Parse(format.Replace("SERNUMEXTALPH<", "").Replace(">", ""));
		text = currentSerial.ToString("D" + num);
		if (text.Length > num)
		{
			string text2 = "";
			text2 = text2.PadLeft(num, '9');
			int currentSerial2 = currentSerial - (int.Parse(text2) + 1);
			text = Convert_SERALPH($"SERALPH<{num}>", currentSerial2);
		}
		return text;
	}

	public static string Convert_SERHEX1NUM1(string format, int currentSerial)
	{
		_ = string.Empty;
		int num = int.Parse(format.Replace("SERHEX1NUM1<", "").Replace(">", ""));
		if (num != 2)
		{
			throw new Exception($"'{format}' - SERHEX1NUM1의 Length는 2만 가능합니다.");
		}
		string text = "";
		string text2 = "";
		int num2 = currentSerial / 10;
		int num3 = currentSerial % 10;
		if (num2 > 9)
		{
			if (num2 > 65535)
			{
				throw new Exception($"'{num2}' - SERHEX1NUM1에서 몫의 최대값을 초과했습니다");
			}
			char c = Convert.ToChar(num2 + iConvert10);
			if (!char.IsLetterOrDigit(c))
			{
				throw new Exception($"'{num2}' - SERHEX1NUM1가 유효한 문자열 범위를 벗어났습니다.");
			}
			text = c.ToString();
		}
		else
		{
			text = num2.ToString();
		}
		text2 = num3.ToString();
		string text3 = text + text2;
		if (text3.Length > num)
		{
			throw new Exception($"SERMIXED 가 설정한 {num} 자리수를 초과했습니다");
		}
		return text3;
	}
}
