namespace Lesson_4.BuildCreator
{
	/*1. Реализовать класс для описания здания (уникальный номер здания, высота, этажность, количество квартир, подъездов).
	 * Поля сделать закрытыми, предусмотреть методы для заполнения полей и получения значений полей для печати.
	 * Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества квартир на этаже и т.д.
	 * Предусмотреть возможность, чтобы уникальный номер здания генерировался программно.
	 * Для этого в классе предусмотреть статическое поле, которое бы хранило последний использованный номер здания,
	 * и предусмотреть метод, который увеличивал бы значение этого поля.*/
	public class Build
	{
		static int LastID;

		private readonly int id;
		private float height;
		private int floors;
		private int apartments;
		private int entrances;

		public int GetID()
		{
			return id;
		}

		public float GetHeight()
		{
			return height;
		}
		public void SetHeight(float value)
		{
			height = value;
		}

		public int GetFloors()
		{
			return floors;
		}
		public void SetFloors(int value)
		{
			floors = value;
		}

		public int GetApartments()
		{
			return apartments;
		}
		public void SetApartments(int value)
		{
			apartments = value;
		}

		public int GetEntrances()
		{
			return entrances;
		}
		public void SetEntrances(int value)
		{
			entrances = value;
		}

		private int GetNewID()
		{
			return ++LastID;
		}


		protected Build()
		{
			id = GetNewID();
		}


		public float GetFloorHeight()
		{
			return height / floors;
		}
		public int GetApartmentsInEntrance()
		{
			return apartments / entrances;
		}
		public int GetApartmentsInFloor()
		{
			return GetApartmentsInEntrance() / floors;
		}
	}
}
