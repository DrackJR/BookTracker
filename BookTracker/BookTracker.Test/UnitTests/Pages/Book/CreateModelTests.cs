using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookTracker.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Test.UnitTests.Pages.Book
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new BookTracker.Pages.Books.CreateModel(context);

            pageModel.ModelState.AddModelError("Name", "Required");

            // Act
            var result = pageModel.OnPost();

            // Assert
            object value = result.Should().BeOfType<PageResult>();
            context.Books.Count().Should().Be(0);
        }
    }
}
