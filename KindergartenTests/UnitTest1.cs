using ShopTARge23.Data.Migrations;
using System;
using Xunit;

namespace ShopTARge23.Core.Domain.Tests
{
    public class KindergartenTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var groupName = "Preschool";
            var childrenCount = 10;
            var kindergartenName = "Sunny Days Kindergarten";
            var teacher = "Mrs. Smith";
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            // Act
            var kindergarten = new Kindergarten
            {
                Id = id,
                GroupName = groupName,
                ChildrenCount = childrenCount,
                KindergartenName = kindergartenName,
                Teacher = teacher,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            };

            // Assert
            Assert.Equal(id, kindergarten.Id);
            Assert.Equal(groupName, kindergarten.GroupName);
            Assert.Equal(childrenCount, kindergarten.ChildrenCount);
            Assert.Equal(kindergartenName, kindergarten.KindergartenName);
            Assert.Equal(teacher, kindergarten.Teacher);
            Assert.Equal(createdAt, kindergarten.CreatedAt);
            Assert.Equal(updatedAt, kindergarten.UpdatedAt);
        }

        [Fact]
        public void Properties_ShouldAllowNullValues()
        {
            // Arrange
            var kindergarten = new Kindergarten();

            // Act
            kindergarten.Id = null;
            kindergarten.GroupName = null;
            kindergarten.ChildrenCount = 0; // Valid default
            kindergarten.KindergartenName = null;
            kindergarten.Teacher = null;
            kindergarten.CreatedAt = DateTime.MinValue; // Valid default
            kindergarten.UpdatedAt = DateTime.MinValue; // Valid default

            // Assert
            Assert.Null(kindergarten.Id);
            Assert.Null(kindergarten.GroupName);
            Assert.Null(kindergarten.KindergartenName);
            Assert.Null(kindergarten.Teacher);
        }

        [Fact]
        public void ChildrenCount_ShouldBeNonNegative()
        {
            // Arrange
            var kindergarten = new Kindergarten();

            // Act
            kindergarten.ChildrenCount = -5; // Invalid value

            // Assert
            Assert.True(kindergarten.ChildrenCount >= 0, "ChildrenCount should be non-negative.");
        }

        [Fact]
        public void CreatedAt_UpdatedAt_ShouldBeInCorrectOrder()
        {
            // Arrange
            var kindergarten = new Kindergarten
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow.AddMinutes(5)
            };

            // Assert
            Assert.True(kindergarten.CreatedAt < kindergarten.UpdatedAt, "CreatedAt should be earlier than UpdatedAt.");
        }
    }
}
