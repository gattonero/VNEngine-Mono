using System;
using System.Xml;

/// <summary>
/// Промежуточный класс для хранение реплик, то есть Author - для обозначения автора реплики,
/// Text - сам текст реплики, BGPic - номер фоновой картинки
/// </summary>
namespace VNE
{
	public class Replica
	{
		public string Author;
		public string Text;
		public int BGPic;
		//public int CPic;

		// TODO: Добавить номер картинки персонажа

		public Replica (string loadText, string loadAuthor, int loadNumBG)
		{
			Author = loadAuthor;

			Text = loadText;

			BGPic = loadNumBG;

			//CPic = loadNumC;
		}
	}
}

