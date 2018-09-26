FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /consoleapp

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore -r debian.9-x64

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -r debian.9-x64 -o out
ENTRYPOINT ["dotnet", "out/LibsassSample.dll"]