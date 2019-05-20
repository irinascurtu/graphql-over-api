using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
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

        /// <summary>
        /// Calls external service to load the feedbacks
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Feedback>> GetAll()
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


        public async Task<ILookup<int, Feedback>> GetAllInOneGo(IEnumerable<int> talkIds)
        {

            var client = httpClientFactory.CreateClient("Feedbacks");

            var response = await client.GetAsync($"/api/feedbacks/multiple?talks={String.Join(",", talkIds)}");
            var feedbacks = new List<Feedback>();

            if (response.IsSuccessStatusCode)
            {
                feedbacks = await response.Content.ReadAsAsync<List<Feedback>>();
            }


            return feedbacks.ToLookup(r => r.TalkId);
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
