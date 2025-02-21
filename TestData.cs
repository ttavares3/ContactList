using Newtonsoft.Json;

public class TestData
{
    public string BaseUrl { get; set; }
    public string TableLocator { get; set; }
    public Urls Urls { get; set; }
    public Buttons Buttons { get; set; }
    public Credentials Credentials { get; set; }
    public FormCreateUserAndContact FormCreateUserAndContact { get; set; }
    public FormCreateContact FormCreateContact { get; set; }
    public UpdateContact UpdateContact { get; set; }

    public static TestData LoadFromJson(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<TestData>(json);
    }
}

public class Credentials
{
    public string EmailLocator { get; set; }
    public string PasswordLocator { get; set; }
    public string EmailValue { get; set; }
    public string PasswordValue { get; set; }
}

public class Urls
{
    public string Login { get; set; }
    public string Contacts { get; set; }
}
public class Buttons
{
    public string Submit { get; set; }
    public string SignUp { get; set; }
    public string AddContact { get; set; }
    public string LogOut { get; set; }
    public string EditContact { get; set; }
    public string Return { get; set; }
    public string Delete { get; set; }
}
public class FormCreateUserAndContact
{
    public string FirstNameLocator { get; set; }
    public string LastNameLocator { get; set; }
    public string FirstNameValue { get; set; }
    public string LastNameValue { get; set; }
}

public class FormCreateContact
{
    public string FirstNameValue { get; set; }
    public string LastNameValue { get; set; }
    public string EmailValue { get; set; }
    public string FullNameValue { get; set; }
}

public class UpdateContact
{
    public string FirstNameValue { get; set; }
    public string LastNameValue { get; set; }
}
