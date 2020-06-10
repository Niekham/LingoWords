using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System;
namespace Lingowords
{
    public class Words
    {
        private Language language;
        private IList<string> wordsList = new List<string>();

        public Words(string[] words, Language lang){
            this.language = lang;
            foreach( string word in words ){
                if( IsMatch(word) ){
                    wordsList.Add(word);
                }
            }
        }

        public string Language(){
            return this.language.ToString();
        }

        public IList<string> WordsList(){
            return this.wordsList;
        }


        private bool IsMatch( string word )
        {
            var regex = new Regex("^[a-z]{5,7}$");
            return regex.IsMatch(word);
        }
    }
}
