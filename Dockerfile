# Define a imagem base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos de projeto para o diretório de trabalho
COPY FluxoCaixa.Core/FluxoCaixa.Core.csproj FluxoCaixa.Core/
COPY FluxoCaixa.Lancamentos.Application/FluxoCaixa.Lancamentos.Application.csproj FluxoCaixa.Lancamentos.Application/
COPY FluxoCaixa.Lancamentos.Data/FluxoCaixa.Lancamentos.Data.csproj FluxoCaixa.Lancamentos.Data/
COPY FluxoCaixa.Lancamentos.Domain/FluxoCaixa.Lancamentos.Domain.csproj FluxoCaixa.Lancamentos.Domain/
COPY FluxoCaixa.WebApp.MVC/FluxoCaixa.WebApp.MVC.csproj FluxoCaixa.WebApp.MVC/

# Restaura as dependências dos projetos
RUN dotnet restore FluxoCaixa.WebApp.MVC/FluxoCaixa.WebApp.MVC.csproj

# Copia todo o código-fonte para o diretório de trabalho
COPY . ./

# Publica o projeto principal
RUN dotnet publish FluxoCaixa.WebApp.MVC/FluxoCaixa.WebApp.MVC.csproj -c Release -o out

# Define a imagem base para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Define o diretório de trabalho dentro do contêiner
WORKDIR /app

# Copia os arquivos publicados para o diretório de trabalho
COPY --from=build /app/out ./

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "FluxoCaixa.WebApp.MVC.dll"]
