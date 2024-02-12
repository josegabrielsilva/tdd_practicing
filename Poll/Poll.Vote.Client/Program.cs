


List<Guid> optionsId =
    [
        Guid.Parse("3fc18cee-294d-4ce2-ac8a-2053d3a27b8a"),
        Guid.Parse("12345678-90ab-cdef-1234-567890abcdef")
    ];

Guid EscolherItemAleatorio()
{
    int indiceAleatorio = new Random().Next(optionsId.Count);
    return optionsId[indiceAleatorio];
}

//Vote
var voteTask = Task.Run(async () => 
{ 
    var httpClient = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:44325")
    };

    while (true)
    {
        await httpClient.PostAsync($"/Option/{EscolherItemAleatorio()}", new StringContent(""));

        await Task.Delay(TimeSpan.FromMilliseconds(500));
    }
});


//Get
var getTask = Task.Run(async () => 
{
    var httpClient = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:44325")
    };

    while(true)
    {
        var res = await httpClient.GetAsync($"/Option/12345678-90ab-cdef-1234-567890abcdef");
        var content = await res.Content.ReadAsStringAsync();
        Console.WriteLine(content);

        await Task.Delay(TimeSpan.FromMilliseconds(500));
    }
});

Task.WaitAll([voteTask, getTask]);