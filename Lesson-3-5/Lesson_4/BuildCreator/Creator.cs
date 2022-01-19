using System.Collections;

namespace Lesson_4.BuildCreator
{
	/*
	2. * Для реализованного класса создать новый класс Creator, который будет являться фабрикой объектов класса здания.
	Для этого изменить модификатор доступа к конструкторам класса, в новый созданный класс добавить перегруженные фабричные методы CreateBuild для создания объектов класса здания.
	В классе Creator все методы сделать статическими, конструктор класса сделать закрытым.
	Для хранения объектов класса здания в классе Creator использовать хеш-таблицу.
	Предусмотреть возможность удаления объекта здания по его уникальному номеру из хеш-таблицы.
	Создать тестовый пример, работающий с созданными классами.
	 */
	public class Creator : Build
	{
		public static Hashtable Builds = new Hashtable();

		private Creator() { }

		public static Build CreateBuild()
		{
			Build build = new Creator();
			Builds.Add(build.GetID(), build);
			return build;
		}

		public static void DeleteBuild(int id)
		{
			if (Builds.ContainsKey(id))
				Builds.Remove(id);
		}
	}
}
