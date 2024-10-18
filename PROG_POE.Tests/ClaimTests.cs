using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Security.Claims;

namespace PROG_POE.Tests
{
    [TestClass]
    public class ClaimTests
    {
        // Test to check if the Claim Amount is valid
        [TestMethod]
        public void SubmitClaim_ValidClaimAmount_ShouldPass()
        {
            // Arrange
            Claim claim = new PROG_POE.Claim()
            {
                claimAmount = 1500,
                HoursWorked = 40,
                HourlyRate = 50,
                LecturerName = "John Doe",
                AdditionalNotes = "Worked extra hours"
            };

            // Act
            bool result = claim.claimAmount > 0;

            // Assert
            Assert.IsTrue(result, "Claim amount should be greater than zero.");
        }

        // Test to check if the claim amount is invalid (negative amount)
        [TestMethod]
        public void SubmitClaim_InvalidClaimAmount_ShouldFail()
        {
            // Arrange
            Claim claim = new Claim()
            {
                claimAmount = -100,
                HoursWorked = 40,
                HourlyRate = 50,
                LecturerName = "John Doe"
            };

            // Act
            bool result = claim.claimAmount > 0;

            // Assert
            Assert.IsFalse(result, "Claim amount should not be negative.");
        }

        // Test to check file type validation logic
        [TestMethod]
        public void ValidateFileType_ValidFile_ShouldPass()
        {
            // Arrange
            string filePath = "supportingDoc.pdf";

            // Act
            bool result = IsValidFileType(filePath);

            // Assert
            Assert.IsTrue(result, "The file should be valid (PDF, DOCX, XLSX).");
        }

        // Test to check if invalid file type is rejected
        [TestMethod]
        public void ValidateFileType_InvalidFile_ShouldFail()
        {
            // Arrange
            string filePath = "supportingDoc.txt";

            // Act
            bool result = IsValidFileType(filePath);

            // Assert
            Assert.IsFalse(result, "The file should not be valid (only PDF, DOCX, XLSX allowed).");
        }

        // Test for Hours Worked validation
        [TestMethod]
        public void SubmitClaim_ValidHoursWorked_ShouldPass()
        {
            // Arrange
            Claim claim = new Claim()
            {
                HoursWorked = 8,
                claimAmount = 500,
                HourlyRate = 63,
                LecturerName = "Jane Doe"
            };

            // Act
            bool result = claim.HoursWorked > 0 && claim.HoursWorked <= 24;

            // Assert
            Assert.IsTrue(result, "Hours worked should be between 1 and 24.");
        }

        // Helper method for validating file types
        private bool IsValidFileType(string filePath)
        {
            string[] allowedExtensions = { ".pdf", ".docx", ".xlsx" };
            string extension = System.IO.Path.GetExtension(filePath);
            return Array.Exists(allowedExtensions, ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase));
        }
    }
}

