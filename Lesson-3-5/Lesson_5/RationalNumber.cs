namespace Lesson_5
{
	/*
	1. Создать класс рациональных чисел.
	В классе два поля – числитель и знаменатель.
	Предусмотреть конструктор.
	Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --.
	Переопределить метод ToString() для вывода дроби.
	Определить операторы преобразования типов между типом дробь,float, int.
	Определить операторы *, /, %.
	*/
	public class RationalNumber
	{
		public override string ToString() =>
			$"{Numerator}/{Denominator}";

		public int Numerator { get; private set; }
		public uint Denominator { get; private set; } = 1;

		public double Rational => (double)Numerator / Denominator;

		public RationalNumber() { }
		public RationalNumber(int numerator, uint denominator)
		{
			Denominator = denominator;
			Numerator = numerator;
		}


		public static implicit operator double(RationalNumber r1) => r1.Rational;
		public static implicit operator float(RationalNumber r1) => (float)r1.Rational;
		public static implicit operator RationalNumber(int r1) => new RationalNumber(r1, 1);

		#region Operators	==, !=, <, >, <=, >=, +, –, ++, --, *, /, %
		public static bool operator ==(RationalNumber left, RationalNumber right)
		{
			return left.Rational == right.Rational;
		}
		public static bool operator !=(RationalNumber left, RationalNumber right)
		{
			return !(left == right);
		}

		public static bool operator <(RationalNumber left, RationalNumber right)
		{
			return left.Rational < right.Rational;
		}
		public static bool operator >(RationalNumber left, RationalNumber right)
		{
			return !(left <= right);
		}
		public static bool operator <=(RationalNumber left, RationalNumber right)
		{
			return left.Rational <= right.Rational;
		}
		public static bool operator >=(RationalNumber left, RationalNumber right)
		{
			return !(left < right);
		}

		public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
		{
			var numerator = r1.Numerator * (int)r2.Denominator + r2.Numerator * (int)r1.Denominator;
			var denominator = r1.Denominator * r2.Denominator;

			return new RationalNumber(numerator, denominator);
		}
		public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
		{
			return r1 + (-1 * r2);
		}

		public static RationalNumber operator ++(RationalNumber r1)
		{
			r1.Numerator = r1.Numerator + (int)r1.Denominator;
			return r1;
		}
		public static RationalNumber operator --(RationalNumber r1)
		{
			r1.Numerator = r1.Numerator - (int)r1.Denominator;
			return r1;
		}

		public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
		{
			return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
		}
		public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
		{
			return r1 * new RationalNumber((int)r2.Denominator, (uint)r1.Numerator);
		}
		public static RationalNumber operator %(RationalNumber r1, RationalNumber r2)
		{
			var rational = r1 * new RationalNumber((int)r2.Denominator, (uint)r1.Numerator);
			rational.Numerator = (int)(rational.Numerator % r2.Denominator);

			return rational;
		}
		#endregion

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;

			if (ReferenceEquals(obj, null))
				return false;

			if (obj is RationalNumber rational)
				return this == rational;
			else
				return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}