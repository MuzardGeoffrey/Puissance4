using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerConnection : MonoBehaviour
{
    protected HttpClient httpClient = new HttpClient();

        protected async Task<Player> PostAsync<Player>(string jsonObject, string route)
        {
            try
            {
                HttpContent content = new StringContent(
                                jsonObject,
                                Encoding.UTF8,
                                "application/json"
                            );

                HttpResponseMessage response = await this.httpClient.PostAsync(route, content);
                var result = await response.Content.ReadAsStringAsync();

                if (result != null)
                {
                    return JsonUtility.FromJson<Player>(result);
                }

                return default;
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                return default;
            }
        }

        public async Task<Player> Connection(Player player)
        {
            var route = "https://localhost:44351/api/Players/Login";
            return await this.PostAsync<Player>(JsonUtility.ToJson(player), route);
        }
}
