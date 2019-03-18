using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Conference.Service
{
    public class FeedbackService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public FeedbackService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<Feedback>> GetAll()
        {
            var client = httpClientFactory.CreateClient("Feedbacks");

            var response = await client.GetAsync("/api/feedbacks");
            var lst = new List<Feedback>();

            if (response.IsSuccessStatusCode)
            {
                lst = await response.Content.ReadAsAsync<List<Feedback>>();
            }

            return lst;
        }


        public async Task<List<Feedback>> GetById(int id)
        {
            var client = httpClientFactory.CreateClient("Feedbacks");

            var response = await client.GetAsync($"/api/feedbacks/{id}");
            var lst = new List<Feedback>();

            if (response.IsSuccessStatusCode)
            {
                lst = await response.Content.ReadAsAsync<List<Feedback>>();
            }

            return lst;
        }


        public async Task<List<Feedback>> GetByTalkType(int talkId)
        {
            var client = httpClientFactory.CreateClient("Feedbacks");
            var response = await client.GetAsync($"/api/feedbacks/{talkId}/talks");
            var lst = new List<Feedback>();

            if (response.IsSuccessStatusCode)
            {
                lst = await response.Content.ReadAsAsync<List<Feedback>>();
            }

            return lst;
        }
    }
}
