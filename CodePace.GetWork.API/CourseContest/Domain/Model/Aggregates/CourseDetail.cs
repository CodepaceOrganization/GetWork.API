using System;
using System.Collections.Generic;
using CodePace.GetWork.API.CourseContest.Domain.Model.Entities;


namespace CodePace.GetWork.API.CourseContest.Domain.Model.Aggregates
{
    public class CourseDetail
    {
        private string _description;
        private string _image;
        private string _image2;
        private string _image3;
        private string _introduction;
        private string _development;
        private string _test;
        private ICollection<Goal> _goals = new List<Goal>();

        protected internal CourseDetail(
            int contestId, 
            string description, 
            string image, 
            string image2, 
            string image3,
            string introduction,
            string development,
            string test)
        {
            ContestId = contestId;
            UpdateDescription(description);
            UpdateImages(new Dictionary<string, string> { { "Image", image }, { "Image2", image2 }, { "Image3", image3 } });            
            UpdateIntroduction(introduction);
            UpdateDevelopment(development);
            UpdateTest(test);
        }

        public int ContestId { get; set; }
        
        public ICollection<Goal> Goals { get; set; }

        
        public int Id { get; private set; }
        public string Description { get => _description; private set => UpdateDescription(value); }
        public string Image { get => _image; private set => UpdateImages(new Dictionary<string, string> { { "Image", value } }); }
        public string Image2 { get => _image2; private set => UpdateImages(new Dictionary<string, string> { { "Image2", value } }); }
        public string Image3 { get => _image3; private set => UpdateImages(new Dictionary<string, string> { { "Image3", value } }); }
        public string Introduction { get => _introduction; private set => UpdateIntroduction(value); }
        public string Development { get => _development; private set => UpdateDevelopment(value); }
        public string Test { get => _test; private set => UpdateTest(value); }
        
        public void UpdateDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            _description = description;
        }
        
        public void UpdateImages(Dictionary<string, string> images)
        {
            if (images == null || images.Count == 0)
            {
                throw new ArgumentException("Images cannot be null or empty.", nameof(images));
            }

            if (images.ContainsKey("Image"))
            {
                _image = images["Image"];
            }

            if (images.ContainsKey("Image2"))
            {
                _image2 = images["Image2"];
            }

            if (images.ContainsKey("Image3"))
            {
                _image3 = images["Image3"];
            }
        }

        public void UpdateIntroduction(string introduction)
        {
            if (string.IsNullOrEmpty(introduction))
            {
                throw new ArgumentException("Introduction cannot be null or empty.", nameof(introduction));
            }

            _introduction = introduction;
        }

        public void UpdateDevelopment(string development)
        {
            if (string.IsNullOrEmpty(development))
            {
                throw new ArgumentException("Development cannot be null or empty.", nameof(development));
            }

            _development = development;
        }

        public void UpdateTest(string test)
        {
            if (string.IsNullOrEmpty(test))
            {
                throw new ArgumentException("Test cannot be null or empty.", nameof(test));
            }

            _test = test;
        }

        
        

    }
}