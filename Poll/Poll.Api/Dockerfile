FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copiar o arquivo de projeto e restaurar as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o restante do código-fonte
COPY . ./

# Compilar a aplicação
RUN dotnet publish -c Release -o out

# Criar uma imagem mais leve com a aplicação publicada
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expor a porta necessária pela aplicação (ajuste conforme necessário)
EXPOSE 80

# Definir a entrada para a aplicação
ENTRYPOINT ["dotnet", "Poll.Api.dll"]