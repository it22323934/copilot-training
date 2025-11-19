using NSubstitute;
using Microsoft.Extensions.Configuration;
using Library.ApplicationCore;
using Library.Infrastructure.Data;
using Library.ApplicationCore.Entities;

namespace UnitTests.Infrastructure.JsonLoanRepository;

public class GetLoan
{
    private readonly ILoanRepository _mockLoanRepository;
    private readonly Library.Infrastructure.Data.JsonLoanRepository _jsonLoanRepository;
    private readonly IConfiguration _configuration;
    private readonly JsonData _jsonData;

    public GetLoan()
    {
        _mockLoanRepository = Substitute.For<ILoanRepository>();
        _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"JsonPaths:Authors", "Json/Authors.json"},
                {"JsonPaths:Books", "Json/Books.json"},
                {"JsonPaths:BookItems", "Json/BookItems.json"},
                {"JsonPaths:Patrons", "Json/Patrons.json"},
                {"JsonPaths:Loans", "Json/Loans.json"}
            })
            .Build();
        
        _jsonData = new JsonData(_configuration);
        _jsonLoanRepository = new Library.Infrastructure.Data.JsonLoanRepository(_jsonData);
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when loan ID is found")]
    public async Task GetLoan_ReturnsLoanWhenFound()
    {
        // Arrange
        var expectedLoanId = 1; // This loan ID exists in Loans.json
        var expectedLoan = new Loan
        {
            Id = expectedLoanId,
            BookItemId = 17,
            PatronId = 22,
            LoanDate = new DateTime(2023, 12, 8, 0, 40, 43),
            DueDate = new DateTime(2023, 12, 22, 0, 40, 43),
            ReturnDate = null
        };
        
        _mockLoanRepository.GetLoan(expectedLoanId).Returns(expectedLoan);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(expectedLoanId);

        // Assert
        Assert.NotNull(actualLoan);
        Assert.Equal(expectedLoanId, actualLoan.Id);
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when loan ID is not found")]
    public async Task GetLoan_ReturnsNullWhenNotFound()
    {
        // Arrange
        var nonExistentLoanId = 9999; // Assuming this loan ID does not exist in Loans.json

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(nonExistentLoanId);

        // Assert
        Assert.Null(actualLoan);
    }
}