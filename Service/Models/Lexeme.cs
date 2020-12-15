using BibleAPI.Service.Lexer;

namespace BibleAPI.Service.Models
{
    public class Lexeme : ILexer
    {
		private string pos;	
		private string raw;

		public Lexeme(string word) {
			raw = word;
		}


		public string POS() => pos;
    }
}