using System.Net.Http;
using TMPro;
using UnityEngine;

namespace UI.Rankings
{
    public class RankLoader : MonoBehaviour
    {
        public TextMeshProUGUI first;
        public TextMeshProUGUI second;
        public TextMeshProUGUI third;

        void Start()
        {
            Load();
        }

        private async void Load()
        {
            var client = new HttpClient();
            var response =
                await client.GetAsync("https://studio.megalowofficial.com/api/games/rescuetheprincess/rank.txt");

            var responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.Split(new[] {'\r', '\n'});
            var i = 0;
            foreach (var str in result)
            {
                var score = str.Split(new[] {' '})[1];
                var username = str.Split(new[] {' '})[0];
                if (i < 3)
                {
                    if (i == 0)
                    {
                        first.text = username + "(" + score + ")";
                    }
                    else if (i == 1)
                    {
                        second.text = username + "(" + score + ")";
                    }
                    else if (i == 2)
                    {
                        third.text = username + "(" + score + ")";
                    }
                }
                else
                {
                    break;
                }

                i++;
            }
        }
    }
}