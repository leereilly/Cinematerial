﻿namespace Cinematerial.Tests
{
    using System;
    using Xunit;

    public class UriExtensionsTests
    {
        [Theory]
        [InlineData("http://www.imdb.com/title/tt1234567")]
        [InlineData("http://www.imdb.com/title/tt0234567")]
        [InlineData("http://www.imdb.com/title/tt1234567/")]
        [InlineData("http://www.imdb.com/title/tt0234567/")]
        [InlineData("http://www.imdb.com/title/tt1234567/reference")]
        [InlineData("http://www.imdb.com/title/tt0234567/reference")]
        [InlineData("http://www.imdb.com/title/tt1375666/?ref_=nv_sr_1")]
        [InlineData("http://www.imdb.com/title/tt0234567/?ref_=nv_sr_1")]
        public void IsImdbMovieUrlUsingValidImdbMovieUrlReturnsTrue(string validImdbMovieUrl)
        {
            // Arrange
            var url = new Uri(validImdbMovieUrl);

            // Act
            var isImdbMovieUrl = url.IsImdbMovieUrl();

            // Assert
            Assert.True(isImdbMovieUrl);
        }

        [Theory]
        [InlineData("http://www.imdb.com/")]
        [InlineData("http://www.imdb.com/list/PQDCzc8WwVQ/")]
        [InlineData("http://www.imdb.com/search/title?genres=drama&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/search/title?release_date=1990,1999&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/chart/top/")]
        [InlineData("http://www.imdb.com/boxoffice/alltimegross?region=world-wide")]
        [InlineData("http://www.imdb.com/user/ur3342822/ratings")]
        [InlineData("http://www.google.com")]
        public void IsImdbMovieUrlUsingNonMovieUrlReturnsFalse(string invalidImdbMovieUrl)
        {
            // Arrange
            var url = new Uri(invalidImdbMovieUrl);

            // Act
            var isImdbMovieUrl = url.IsImdbMovieUrl();

            // Assert
            Assert.False(isImdbMovieUrl);
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt123456/")]
        [InlineData("http://www.imdb.com/title/tt1/")]
        [InlineData("http://www.imdb.com/title/tt/")]
        [InlineData("http://www.imdb.com/title/")]
        [InlineData("http://www.imdb.com/title")]
        public void IsImdbMovieUrlUsingIncompleteImdbMovieUrlReturnsFalse(string incompleteImdbMovieUrl)
        {
            // Arrange
            var url = new Uri(incompleteImdbMovieUrl);

            // Act
            var isImdbMovieUrl = url.IsImdbMovieUrl();

            // Assert
            Assert.False(isImdbMovieUrl);
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt1234567", 1234567)]
        [InlineData("http://www.imdb.com/title/tt0234567", 234567)]
        [InlineData("http://www.imdb.com/title/tt1234567/", 1234567)]
        [InlineData("http://www.imdb.com/title/tt0234567/", 234567)]
        [InlineData("http://www.imdb.com/title/tt1234567/reference", 1234567)]
        [InlineData("http://www.imdb.com/title/tt0234567/reference", 234567)]
        [InlineData("http://www.imdb.com/title/tt1234567/?ref_=nv_sr_1", 1234567)]
        [InlineData("http://www.imdb.com/title/tt0234567/?ref_=nv_sr_1", 234567)]
        public void GetImdbMovieIdUsingValidImdbMovieUrlReturnsImdbMovieIdFromUrl(string validImdbMovieUrl, int expectedImdbMovieId)
        {
            // Arrange
            var url = new Uri(validImdbMovieUrl);

            // Act
            var imdbMovieId = url.GetImdbMovieId();

            // Assert
            Assert.Equal(expectedImdbMovieId, imdbMovieId);
        }

        [Theory]
        [InlineData("http://www.imdb.com/")]
        [InlineData("http://www.imdb.com/list/PQDCzc8WwVQ/")]
        [InlineData("http://www.imdb.com/search/title?genres=drama&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/search/title?release_date=1990,1999&title_type=feature&num_votes=5000,&sort=user_rating,desc")]
        [InlineData("http://www.imdb.com/chart/top/")]
        [InlineData("http://www.imdb.com/boxoffice/alltimegross?region=world-wide")]
        [InlineData("http://www.imdb.com/user/ur3342822/ratings")]
        [InlineData("http://www.google.com")]
        public void GetImdbMovieIdUsingNonMovieUrlThrowsArgumentException(string invalidImdbMovieUrl)
        {
            // Arrange
            var url = new Uri(invalidImdbMovieUrl);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => url.GetImdbMovieId());
        }

        [Theory]
        [InlineData("http://www.imdb.com/title/tt123456/")]
        [InlineData("http://www.imdb.com/title/tt1/")]
        [InlineData("http://www.imdb.com/title/tt/")]
        [InlineData("http://www.imdb.com/title/")]
        [InlineData("http://www.imdb.com/title")]
        public void GetImdbMovieIdUsingIncompleteImdbMovieUrlThrowsArgumentException(string incompleteImdbMovieUrl)
        {
            // Arrange
            var url = new Uri(incompleteImdbMovieUrl);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => url.GetImdbMovieId());
        }

        [Fact]
        public void GetImdbMovieIdOnNullUrlThrowsArgumentNullException()
        {
            // Arrange
            Uri nullUrl = null;

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => nullUrl.GetImdbMovieId());
        }
    }
}