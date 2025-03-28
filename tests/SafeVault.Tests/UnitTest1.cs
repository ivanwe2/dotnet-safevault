namespace SafeVault.Tests;

public class UnitTest1
{
     [Fact]
    public void TestForSQLInjection()
    {
        var model = new UserInputModel
        {
            Username = "test'; DROP TABLE Users; --",
            Email = "test@example.com"
        };
        Assert.False(ValidateModel(model));
    }

    [Fact]
    public void TestForXSS()
    {
        var model = new UserInputModel
        {
            Username = "<script>alert('XSS');</script>",
            Email = "test@example.com"
        };
        Assert.False(ValidateModel(model));
    }

    private bool ValidateModel(UserInputModel model)
    {
        var context = new ValidationContext(model, null, null);
        var results = new List<ValidationResult>();
        return Validator.TryValidateObject(model, context, results, true);
    }
}
