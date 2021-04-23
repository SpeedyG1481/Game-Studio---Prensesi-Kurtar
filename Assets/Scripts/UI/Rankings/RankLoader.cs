using System.Net.Http;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace UI.Rankings
{
    public class RankLoader : MonoBehaviour
    {
        public TextMeshProUGUI first;
        public TextMeshProUGUI second;
        public TextMeshProUGUI third;
        private bool _isLoaded = false;

        void Start()
        {
            Load();
        }

        private async Task Load()
        {
            HttpClient client = new HttpClient();
            var response =
                await client.GetAsync("https://studio.megalowofficial.com/api/games/rescuetheprincess/rank.txt");

            string responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.Split(new[] {'\r', '\n'});
            int i = 0;
            foreach (var str in result)
            {
                string score = str.Split(new[] {' '})[1];
                string name = str.Split(new[] {' '})[0];
                if (i < 3)
                {
                    if (i == 0)
                    {
                        first.text = name + "(" + score + ")";
                    }
                    else if (i == 1)
                    {
                        second.text = name + "(" + score + ")";
                    }
                    else if (i == 2)
                    {
                        third.text = name + "(" + score + ")";
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