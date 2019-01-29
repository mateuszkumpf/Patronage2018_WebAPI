FROM microsoft/dotnet:2.2-aspnetcore-runtime AS Base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build

# Restore dotnet before build to allow for caching
WORKDIR /
COPY Patronage2018.Application/Patronage2018.Application.csproj /src/Patronage2018.Application/
COPY Patronage2018.Domain/Patronage2018.Domain.csproj /src/Patronage2018.Domain/
COPY Patronage2018.Infrastructure/Patronage2018.Infrastructure.csproj /src/Patronage2018.Infrastructure/
COPY Patronage2018.Persistence/Patronage2018.Persistence.csproj /src/Patronage2018.Persistence/
COPY Patronage2018.WebAPI/Patronage2018.WebAPI.csproj /src/Patronage2018.WebAPI/

ENV ConnectionStrings:PatronageDatabase Server=db;Database=Patronage2018WebAPI;User ID=sa;Password=Pass@word

RUN dotnet restore /src/Patronage2018.WebAPI/Patronage2018.WebAPI.csproj

# Copy source files and build
COPY . /src

RUN dotnet build /src/Patronage2018.WebAPI/Patronage2018.WebAPI.csproj -c Release
RUN dotnet publish /src/Patronage2018.WebAPI/Patronage2018.WebAPI.csproj --no-restore -c Release -o /app

# Copy compiled app to runtime container
FROM base AS final
COPY --from=build /app .
CMD ["dotnet", "Patronage2018.WebAPI.dll"]