using ConsumerViaCep.Models;
using static System.Console;

WriteLine("Digite o seu CEP:");
var cep = ReadLine();

var enderecoUrl = $@"https://viacep.com.br/ws/{cep}/json/";

var client = new HttpClient();

try
{
    HttpResponseMessage respostaApi = await client.GetAsync(enderecoUrl);

    respostaApi.EnsureSuccessStatusCode();

    string respostaApiJson = await respostaApi.Content.ReadAsStringAsync();

    Endereco? endereco = System.Text.Json.JsonSerializer.Deserialize<Endereco>(respostaApiJson);

    WriteLine("CEP:\n" + endereco.cep);
    WriteLine("Logradouro:\n" + endereco.logradouro);
    WriteLine("Complemento:\n" + endereco.complemento);

}
catch (Exception ex)
{
    WriteLine($"Aconteceu um erro:\n {ex.Message}");
}