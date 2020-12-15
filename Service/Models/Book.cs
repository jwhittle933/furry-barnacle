using System.Collections.Generic;

namespace BibleAPI.Service.Models {
	public class Book {
		private int _bookID;
		private string _name;
		private int verseCount;
		private long wordCount;
		private List<string> verses = new List<string>();

		public Book(string name) {
			_name = name;
		}
	}	
}